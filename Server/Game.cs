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
        public static readonly int MaxTileNum = 30;
        public static readonly int InitialTableWidth = 15;
        public static readonly int InitialTableHeight = 6;

        public Room Room { get; private set; }
        public bool IsEnabled { get; set; } = false;
        public Tile[,] PreviousTable { get; private set; }
        public List<Tile> PreviousHoldingTiles { get; private set; } = new List<Tile>();
        public Tile[,] Table { get; set; }
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
            PreviousTable = new Tile[InitialTableHeight, InitialTableWidth];
            Table = new Tile[InitialTableHeight, InitialTableWidth];
            InitDummy();
            ShuffleDummy();
        }

        public void ResolveTableSize()
        {
            if (TableHorizontalCap < 25 && TableVerticalCap < 16)
            {
                bool existsInTopOrBottom = false;
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[0, j] != null || Table[Table.GetLength(0) - 1, j] != null)
                    {
                        existsInTopOrBottom = true;
                        break;
                    }
                }
                bool existsInLeftOrRight = false;
                for (int i = 0; i < Table.GetLength(0); i++)
                {
                    if (Table[i, 0] != null || Table[i, Table.GetLength(1) - 1] != null)
                    {
                        existsInLeftOrRight = true;
                        break;
                    }
                }

                if (existsInTopOrBottom && existsInLeftOrRight)
                {
                    SetCapacity(TableHorizontalCap + 4, TableVerticalCap + 4);
                }
            }
        }

        public int TableHorizontalCap { get { return Table.GetLength(1); } }
        public int TableVerticalCap { get { return Table.GetLength(0); } }

        public void SetCapacity(int horizontalCap, int verticalCap)
        {
            Tile[,] oldTiles = new Tile[Table.GetLength(0), Table.GetLength(1)];

            for (int i = 0; i < Table.GetLength(0); i++)//기존 판 내용 복사
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                    oldTiles[i, j] = Table[i, j];
            }

            Table = new Tile[verticalCap, horizontalCap];//기존 판 확장

            int disVer = (verticalCap - oldTiles.GetLength(0)) / 2;
            int disHor = (horizontalCap - oldTiles.GetLength(1)) / 2;

            for (int i = disVer; i < verticalCap - disVer; i++)
            {
                for (int j = disHor; j < horizontalCap - disHor; j++)
                {
                    if (oldTiles[i - disVer, j - disHor] != null)
                    {
                        Table[i, j] = oldTiles[i - disVer, j - disHor];
                    }
                }
            }
        }

        private void ShuffleDummy()
        {
            Random random = new Random();
            int n = Dummy.Count;

            for (int i = Dummy.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                Tile value = Dummy[rnd];
                Dummy[rnd] = Dummy[i];
                Dummy[i] = value;
            }
        }

        public void Start()
        {
            ClearGameData();
            CurrentPlayer = Room.Players[0];
            IsEnabled = true;

            foreach (Player player in Room.Players)
            {
                for (int i = 0; i < 14; i++)
                {
                    player.HoldingTiles.Add(PopDummy());
                }
            }
            PreviousHoldingTiles = new List<Tile>(CurrentPlayer.HoldingTiles);
        }
        
        public void End()
        {
            IsEnabled = false;
        }

        public Tile PopDummy()
        {
            Tile tile = Dummy[0];
            Dummy.RemoveAt(0);
            return tile;
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
                    for (int k = 1; k <= 13; k++)
                    {
                        tile = new NumberTile(v, k);
                        Dummy.Add(tile);
                    }
                }
            }

            Dummy.Add(new JokerTile(TileColor.RED));
            Dummy.Add(new JokerTile(TileColor.BLACK));

            return;
        }

        public List<TileSet> GetTileSets()//타일의 모든 조합을 가져옴
        {
            List<Tile> Set = new List<Tile>();
            List<TileSet> totalSet = new List<TileSet>();
            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[i, j] != null)
                        Set.Add(Table[i, j]);
                    else
                    {
                        if (Set.Count() != 0)
                        {
                            totalSet.Add(new TileSet(Set));
                            Set = new List<Tile>();
                        }
                    }
                }
            }
            return totalSet;
        }

        public List<TileSet> GetPreviousTileSets()//타일의 모든 조합을 가져옴
        {
            List<Tile> Set = new List<Tile>();
            List<TileSet> totalSet = new List<TileSet>();
            for (int i = 0; i < PreviousTable.GetLength(0); i++)
            {
                for (int j = 0; j < PreviousTable.GetLength(1); j++)
                {
                    if (PreviousTable[i, j] != null)
                        Set.Add(PreviousTable[i, j]);
                    else
                    {
                        if (Set.Count() != 0)
                        {
                            totalSet.Add(new TileSet(Set));
                            Set = new List<Tile>();
                        }
                    }
                }
            }
            return totalSet;
        }

        public void Rollback()//rollback 버튼 클릭시
        {
            Table = (Tile [,])PreviousTable.Clone();
            CurrentPlayer.HoldingTiles = PreviousHoldingTiles;
        }

        public bool HasAnyInvalidTileSet()
        {
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

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[i, j] != null)
                    {
                        Table[i, j].IsFromTable = true;
                    }
                }
            }

            CurrentPlayer = Room.Players[nextIndex];
            PreviousTable = (Tile[,])Table.Clone();
            PreviousHoldingTiles = new List<Tile>(CurrentPlayer.HoldingTiles);
        }

        public bool CanEndGame()
        {
            return Room.Players.Any(player => player.HoldingTiles.Count == 0);
        }

        public GameStatus ToStatus()
        {
            PlayerInfo currentPlayer = CurrentPlayer != null ? CurrentPlayer.ToInfo() : null;
            Dictionary<string, int> holdingTilesNumDic = new Dictionary<string, int>();
            foreach (Player player in Room.Players)
            {
                holdingTilesNumDic[player.Nickname] = player.HoldingTiles.Count;
            }

            return new GameStatus(IsEnabled, currentPlayer, holdingTilesNumDic);
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
        
        public int Run()
        {
            TileColor beginningColor=TileColor.BLACK;
            TileColor currentColor= TileColor.BLACK; 
            int jokerNumber1 = 0;
            int jokerNumber2 = 0;

            if (Tiles.Count < 3) return 0;
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
                                        return 0;
                                }
                            }
                            beginningColor = numberTile.Color;
                        }
                        else
                        {
                            Tile tile2 = Tiles[i - 1];
                            NumberTile numberTile2 = (NumberTile)tile2;
                            if (numberTile.Number != numberTile2.Number + 1)
                                return 0;//전타일 +1 이 아니면 RUN아님
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
                if (!Equals(beginningColor, currentColor)) return 0;
            }
            return jokerNumber1 + jokerNumber2 + Tiles.Sum(tile => {
                return tile is NumberTile ? (tile as NumberTile).Number : 0;
            });
        }

        public int Group()
        {
            List<TileColor> tilesColor = new List<TileColor>();
            int tileNumber1 = 0;
            int count_numberTile = 0;

            if (Tiles.Count < 3 || Tiles.Count > 4) return 0;
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
                            return 0;
                        //맨 처음 숫자와 다를 경우 false 반환

                        for (int j = 0; j < count_numberTile-1; j++)
                        {
                            //그 전까지의 타일 색상 비교
                            if (tilesColor[j] == numberTile.Color)
                                return 0;
                            else
                            {
                                tilesColor.Add(numberTile.Color);
                            }
                        }
                    }
                }
            }
            return tileNumber1 * Tiles.Count;
        }

        public bool IsValid()
        {
            return Run() > 0 || Group() > 0;
        }

        public int SumOfNumbers()
        {
            return Run() + Group();
        }

        public override bool Equals(object obj)
        {
            return obj is TileSet set &&
                   !Tiles.Except(set.Tiles).Any() &&
                   !set.Tiles.Except(Tiles).Any();
        }

        public override int GetHashCode()
        {
            return 1095759006 + EqualityComparer<List<Tile>>.Default.GetHashCode(Tiles);
        }

        public static bool operator ==(TileSet lhs, TileSet rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TileSet lhs, TileSet rhs)
        {
            return !(lhs == rhs);
        }
    }
}
