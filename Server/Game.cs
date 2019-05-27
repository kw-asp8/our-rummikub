using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Game
    {
        public Room Room { get; private set; }
        public bool IsEnabled { get; set; } = false;
        public Tile[,] PreviousTable { get; private set; } = new Tile[20,20];
        public Tile[,] Table { get; private set; } = new Tile[20,20];
        public List<Tile> Dummy { get; private set; } = new List<Tile>();
        public Player CurrentPlayer { get; private set; }

        public Game()
        {
            Room = new Room(this);
            InitDummy();
        }

        public void ClearGameData()
        {
            IsEnabled = false;
            foreach (Player player in Room.Players)
            {
                player.ClearGameData();
            }
            PreviousTable=null;
            Table=null;
            InitDummy();
        }

        public void Start()
        {
            ClearGameData();
            CurrentPlayer = Room.Players[0];
            IsEnabled = true;
        }
        
        public void End()
        {
            IsEnabled = false;
        }

        public Player PlayerOf(Connection connection)
        {
            foreach (Player player in Room.Players)
            {
                if (player.Connection == connection)
                {
                    return player;
                }
            }
            return null;
        }

        public Player GetManager()
        {
            if (!Room.IsEmpty())
            {
                return Room.FirstPlayer();
            }
            else
            {
                return null;
            }
        }

        public void InitDummy()//13*4*2 + 2
        {
            Dummy.Clear();

            Tile tile;
            TileColor color = TileColor.RED;
            var type = Enum.GetValues(color.GetType());

            for (int j = 0; j < 2; j++)
            {
                foreach (TileColor v in type)
                {
                    for (int k = 0; k < 13; k++)
                    {
                        tile = new NumberTile(v, k);
                        Dummy.Add(tile);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
                Dummy.Add(new JokerTile());

            return;
        }

        public Tile TakeTile(Location location)
        {
            //양쪽에 타일이 없으면 타일이 하나인 조합 완성
            return null; //TODO
        }

        public TileSet TakeTileSet(Location location)
        {
            //양쪽에 타일이 하나라도 있는 경우
            return null; //TODO
        }

        public void PutTileSet(Location location)
        {
            //TODO
        }

        public List<TileSet> GetTileSets()//타일의 모든 조합을 가져옴
        {
            List<Tile> Set = new List<Tile>();
            List<TileSet> totalSet = new List<TileSet>();
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 0; j <= 19; j++)
                {
                    if (Table[i, j] != null)
                        Set.Add(Table[i, j]);
                    else
                    {
                        if (Set.Count() != 0)
                        {
                            totalSet.Add(new TileSet(Set));
                            Set.Clear();
                        }
                    }
                }
            }
            return totalSet; //TODO
        }

        public void Rollback()//rollback 버튼 클릭시
        {
            Table = (Tile [,])PreviousTable.Clone();
        }

        public bool HasAnyInvalidTileSet()
        {
            PreviousTable = (Tile[,])Table.Clone();
            bool hasInvalidSet = false;
            foreach (TileSet tileSet in GetTileSets())
            {
                if (!tileSet.IsValid())
                {
                    hasInvalidSet = true;
                }
            }
            return hasInvalidSet;
        }

        public void NextTurn()//nextturn 버튼 클릭시
        {
            int nextIndex = Room.Players.IndexOf(CurrentPlayer) + 1;
            if (nextIndex >= Room.Players.Count)
                nextIndex = 0;

            CurrentPlayer = Room.Players[nextIndex];
        }

        public GameStatus ToStatus()
        {
            PlayerInfo currentPlayer = CurrentPlayer != null ? CurrentPlayer.ToInfo() : null;
            return new GameStatus(IsEnabled, currentPlayer);
        }
    }

    public class Location
    {
        public int X { get; }
        public int Y { get; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class TileSet
    {
        public List<Tile> Tiles { get; private set; } = new List<Tile>();
        
        public TileSet(List<Tile> tiles)
        {
            this.Tiles = tiles;
        }
        
        public bool Run()
        {
            TileColor beginningColor=TileColor.BLACK;
            TileColor currentColor= TileColor.BLACK; 
            int jokerNumber1 = 0;
            int jokerNumber2 = 0;

            if (Tiles.Count < 3) return false;
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tile tile = Tiles[i];
                if (tile is NumberTile)
                {
                    NumberTile numberTile = (NumberTile)tile;
                    if (i !=0)
                    {
                        if (Tiles[i - 1] is JokerTile)//전타일이 조커일때
                        {
                            jokerNumber1 = numberTile.Number - 1;
                            if (i >= 2) {
                                if (Tiles[i - 2] is JokerTile) {//조커 조커 일 경우
                                    jokerNumber2 = jokerNumber1 + 1;
                                }
                                else
                                {
                                    Tile tile2 = Tiles[i - 2];
                                    NumberTile twotilebefore = (NumberTile)tile2;
                                    if ((twotilebefore.Number+1)!= jokerNumber1)
                                        return false;
                                }
                            }
                            beginningColor = numberTile.Color;
                        }
                        else
                        {
                            Tile tile2 = Tiles[i - 1];
                            NumberTile numberTile2 = (NumberTile)tile2;
                            if (numberTile.Number != numberTile2.Number + 1)
                                return false;//전타일 +1 이 아니면 RUN아님
                        }
                    }
                    if (i == 0) beginningColor = numberTile.Color;
                    currentColor = numberTile.Color;
                }
                else if (tile is JokerTile)
                {
                    if (i != 0)
                    {//처음이 조커이면 무시
                        //지금 읽은 타일이 조커라면
                        Tile tile2 = Tiles[i - 1];
                        if (tile2 is JokerTile)
                            jokerNumber2 = jokerNumber1 + 1;
                        else
                        {
                            NumberTile numberTile2 = (NumberTile)tile2;
                            jokerNumber2 = numberTile2.Number + 1;
                        }
                    }
                }
                if (!Equals(beginningColor, currentColor)) return false;
            }
            return true;
        }

        public bool Group()
        {
            List<TileColor> tilesColor = new List<TileColor>();
            int tileNumber1 = 0;
            int count_numberTile = 0;

            if (Tiles.Count < 3 || Tiles.Count > 4) return false;
            //타일의 개수 3개 미만 4개 초과일 경우 바로 false 반환

            for (int i = 0; i < Tiles.Count; i++)
            {
                Tile tile = Tiles[i];
                if (tile is NumberTile)
                { //조커 타일일 경우 고려x
                    NumberTile numberTile = (NumberTile)tile;
                    count_numberTile++;

                    if (tilesColor.Count == 0)
                    {
                        tilesColor.Add(numberTile.Color);
                        tileNumber1 = numberTile.Number;
                        //처음 타일은 바로 넣기
                    }
                    else
                    {
                        if (tileNumber1 != numberTile.Number)
                            return false;
                        //맨 처음 숫자와 다를 경우 false 반환

                        for (int j = 0; j < count_numberTile-1; j++)
                        {
                            //그 전까지의 타일 색상 비교
                            if (tilesColor[j] == numberTile.Color)
                                return false;
                            else
                            {
                                tilesColor.Add(numberTile.Color);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool IsValid()
        {
            return !(Run() && Group()); //둘다 참이 아니라면
        }
    }
}
