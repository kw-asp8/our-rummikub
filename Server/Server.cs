using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
        }

        class Game
        {
            public List<Player> Players { get; private set; } = new List<Player>();
            public Dictionary<Location, Tile> PreviousTable { get; private set; } = new Dictionary<Location, Tile>();
            public Dictionary<Location, Tile> Table { get; private set; } = new Dictionary<Location, Tile>();
            public List<Tile> Dummy { get; private set; } = new List<Tile>();
            private int currentPlayerNum = 0;

            public Dictionary<Location,Tile> GetTable()
            {
                return new Dictionary<Location, Tile>();
            }
            
            public Game(List<Player> players)
            {
                this.Players = players;
                SetDummy();
            }

            public List<Tile> GetDummy()
            {
                return new List<Tile>();
            }

            public void SetDummy()//13*4*2 + 2
            {
                Tile tile;
                TileColor color = TileColor.RED;
                var type = Enum.GetValues(color.GetType());

                for (int j = 0; j < 2; j++) {
                    foreach(TileColor v in type)
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

            public Player GetCurrentPlayer()
            {
                return Players[currentPlayerNum];
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
                return new List<TileSet>(); //TODO
            }

            public void Rollback()//rollback 버튼 클릭시
            {
                Table = new Dictionary<Location, Tile>(PreviousTable);
            }

            public void NextTurn()//nextturn 버튼 클릭시
            {
                PreviousTable = GetTable();
                bool hasInvalidSet = true;
                foreach (TileSet tileSet in GetTileSets())
                {
                    if (!tileSet.IsValid())
                    {
                        hasInvalidSet = false;
                    }
                }
                if (hasInvalidSet)
                {
                    currentPlayerNum++;
                    if (currentPlayerNum > 4)
                        currentPlayerNum = 0;
                }
            }
        }

        class Location
        {
            public int X { get; }
            public int Y { get; }

            public Location(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        class Player
        {
            private const int maxTileAmount = 20;

            public string Nickname { get; private set; }
            public List<Tile> HoldingTiles { get; private set; } = new List<Tile>();
            public bool HasEnrolled { get; private set; } = false;
            public List<TileSet> ReleasedTileSets { get; private set; } = new List<TileSet>();
            //TODO connection

            public Player(string nickname)
            {
                this.Nickname = nickname;
            }

            public int GetTileAmount()
            {
                return HoldingTiles.Count;
            }

            public bool CanTakeTile()
            {
                return GetTileAmount() < maxTileAmount;
            }

            public void SetEnrolled()
            {
                HasEnrolled = true;
            }
        }

        class TileSet
        {
            public List<Tile> Tiles { get; private set; } = new List<Tile>();

            public TileSet(List<Tile> tiles)
            {
                this.Tiles = tiles;
            }
            public bool Run()
            {
                TileColor previousColor = TileColor.RED;
                TileColor currentColor = TileColor.RED;
                int jokerNumber1 = 0;
                int jokerNumber2 = 0;

                if (Tiles.Count < 3) return false;
                for (int i = 0; i < Tiles.Count; i++)
                {
                    Tile tile = Tiles[i];
                    if (tile is NumberTile)
                    {
                        NumberTile numberTile = (NumberTile)tile;
                        if (Tiles[i - 1] is JokerTile)//전타일이 조커일때
                            jokerNumber1 = numberTile.Number - 1;
                        else {
                            Tile tile2 = Tiles[i - 1];
                            NumberTile numberTile2 = (NumberTile)tile2;
                            if (numberTile2.Number != numberTile.Number + 1)
                                return false;
                }
                        if (i==0) previousColor = numberTile.Color;
                        currentColor = numberTile.Color;
                    }
                    else if (tile is JokerTile)
                    {
                        //다음에 읽은 타일이 조커라면
                        Tile tile2 = Tiles[i - 1];
                        NumberTile numberTile2 = (NumberTile)tile2;
                        jokerNumber2 = numberTile2.Number + 1;
                    }
                    if (!Equals(previousColor, currentColor)) return false;
                }
                return true;
            }

            public bool Group()
            {
                return true;
            }

            public bool IsValid()
            {
                return !(Run() && Group()); //둘다 참이 아니라면
            }
        }

        class Tile
        {
        }

        class NumberTile : Tile
        {
            public TileColor Color { get; private set; }
            public int Number { get; private set; }

            public NumberTile(TileColor color, int number)
            {
                this.Color = color;
                this.Number = number;
            }

            public TileColor getColor()
            {
                return Color;
            }
        }

        class JokerTile : Tile
        {
        }

        enum TileColor
        {
            RED, YELLOW, BLUE, BLACK
        }

        class Manipulation
        {

        }
    }
}
