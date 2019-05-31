using Common;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public delegate void InteractionHandler(Tile tile, int i, int j);

    public partial class TileGridPanel : UserControl
    {
        public Size TileSize { get; set; }

        private TileBlock[,] tiles;

        public bool OptionRemoveSpaces { get; set; } = false;

        public InteractionHandler OnPlace { get; set; } = (tile, i, j) => { };

        public InteractionHandler OnPickup { get; set; } = (tile, i, j) => { };

        public TileGridPanel()
        {
            InitializeComponent();
        }

        public Tile[,] GetTileTable()
        {
            Tile[,] tileTable = new Tile[tiles.GetLength(0), tiles.GetLength(1)];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] != null)
                        tileTable[i, j] = tiles[i, j].Tile;
                }
            }
            return tileTable;
        }

        public List<Tile> GetTileList()
        {
            List<Tile> tileList = new List<Tile>();
            foreach (TileBlock block in tiles)
            {
                if (block != null)
                    tileList.Add(block.Tile);
            }
            return tileList;
        }

        public void SetCapacity(int horizontalCap, int verticalCap)
        {
            if (tiles == null)
            {
                tiles = new TileBlock[verticalCap, horizontalCap];
            }
            else
            {
                //TODO 크기 조정
            }
        }

        public void SortAscending()//TODO 오름차순으로 타일 정렬
        {
            List<TileBlock> tileAcenList = new List<TileBlock>();

            for (int i = 0; i < tiles.GetLength(0); i++)//tiles의 숫자타일들 list에 추가
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileBlock block = tiles[i, j];

                    if (block.Tile is NumberTile)
                    {
                        tileAcenList.Add(block);
                    }
                }
            }

            //숫자기준으로 오름차순으로 정렬
            tileAcenList.Sort((TileBlock block1, TileBlock block2) =>
            {
                return ((NumberTile)block1.Tile).Number.CompareTo(((NumberTile)block2.Tile).Number);
            });

            for (int i = 0; i < tiles.GetLength(0); i++)//tiles의 조커들 list 마지막에 추가
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileBlock block = tiles[i, j];
                    if (block.Tile is JokerTile)
                    {
                        tileAcenList.Add(block);
                    }
                }
            }

            int m = 0;
            int n = 0;

            foreach (TileBlock block in tileAcenList)
            {
                tiles[m, n] = block;
                tiles[m, n].Location = new Point(n* TileSize.Width, m* TileSize.Height);

                n++;
                if (n >= tiles.GetLength(0))
                {
                    n = 0;
                    m++;

                    if (n >= tiles.GetLength(1))
                    {
                        break;
                    }
                }
            }
        }

        public void GroupAsNumber()//TODO 같은 숫자의 타일끼리 모아서 정렬
        {
            //색깔별로 리스트에 넣고 각각 정렬하고 하나의 리스트tileAcenList에 합침

            List<TileBlock> tileAcenList = new List<TileBlock>();
            List<TileBlock> tileBlackList = new List<TileBlock>();
            List<TileBlock> tileRedList = new List<TileBlock>();
            List<TileBlock> tileBlueList = new List<TileBlock>();
            List<TileBlock> tileYellowList = new List<TileBlock>();


            for (int i = 0; i < tiles.GetLength(0); i++)//tiles의 숫자타일들을 각 색깔list에 추가
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileBlock block = tiles[i, j];

                    if (block.Tile is NumberTile)
                    {
                        if (((NumberTile)block.Tile).Color == TileColor.BLACK)
                            tileBlackList.Add(block);
                        else if (((NumberTile)block.Tile).Color == TileColor.RED)
                            tileRedList.Add(block);
                        else if (((NumberTile)block.Tile).Color == TileColor.BLUE)
                            tileBlueList.Add(block);
                        else if (((NumberTile)block.Tile).Color == TileColor.YELLOW)
                            tileYellowList.Add(block);
                    }
                }
            }

            //숫자기준으로 오름차순으로 정렬
            tileBlackList.Sort((TileBlock block1, TileBlock block2) =>
            {
                return ((NumberTile)block1.Tile).Number.CompareTo(((NumberTile)block2.Tile).Number);
            });
            tileRedList.Sort((TileBlock block1, TileBlock block2) =>
            {
                return ((NumberTile)block1.Tile).Number.CompareTo(((NumberTile)block2.Tile).Number);
            });
            tileBlueList.Sort((TileBlock block1, TileBlock block2) =>
            {
                return ((NumberTile)block1.Tile).Number.CompareTo(((NumberTile)block2.Tile).Number);
            });
            tileYellowList.Sort((TileBlock block1, TileBlock block2) =>
            {
                return ((NumberTile)block1.Tile).Number.CompareTo(((NumberTile)block2.Tile).Number);
            });

            foreach (TileBlock i in tileBlackList)
                tileAcenList.Add(i);
            foreach (TileBlock i in tileRedList)
                tileAcenList.Add(i);
            foreach (TileBlock i in tileBlueList)
                tileAcenList.Add(i);
            foreach (TileBlock i in tileYellowList)
                tileAcenList.Add(i);

            for (int i = 0; i < tiles.GetLength(0); i++)//tiles의 조커들 list 마지막에 추가
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileBlock block = tiles[i, j];
                    if (block.Tile is JokerTile)
                        tileAcenList.Add(block);
                }
            }

            int m = 0;
            int n = 0;

            foreach (TileBlock block in tileAcenList)
            {
                tiles[m, n] = block;
                tiles[m, n].Location = new Point(n * TileSize.Width, m * TileSize.Height);

                n++;
                if (n >= tiles.GetLength(0))
                {
                    n = 0;
                    m++;
                    if (n >= tiles.GetLength(1))
                        break;
                }
            }

        }

        public void RemoveSpaces()
        {
            //TODO 타일과 타일 사이의 빈 공간들을 제거하여 정렬
        }

        public bool CanPlaceAt(int x, int y)
        {
            Point index = LocationToIndex(new Point(x, y));
            return (index.Y >= 0 && index.Y < tiles.GetLength(0) &&
                index.X >= 0 && index.X < tiles.GetLength(1));
        }

        public void AddTile(TileBlock tile, int i, int j)
        {
            panel.Controls.Add(tile);
            tiles[i, j] = tile;

            tile.Location = new Point(j * TileSize.Width, i * TileSize.Height);
            tile.Size = new Size(TileSize.Width, TileSize.Height);
            tile.ContainerGrid = this;

            if (OptionRemoveSpaces)
            {
                RemoveSpaces();
            }
            OnPlace(tile.Tile, i, j);
        }

        public void PlaceTile(TileBlock tile, int x, int y)
        {
            Point index = LocationToIndex(new Point(x, y));
            AddTile(tile, index.Y, index.X);
        }

        public bool PlaceAtFirst(TileBlock tile)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] == null)
                    {
                        AddTile(tile, i, j);
                        return true;
                    }
                }
            }
            return false;
        }

        public void PickupTile(TileBlock tile)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] == tile)
                    {
                        PickupTile(i, j);
                        return;
                    }
                }
            }
        }

        public TileBlock BlockAt(int i, int j)
        {
            return tiles[i, j];
        }

        public TileBlock PickupTile(int i, int j)
        {
            TileBlock tile = tiles[i, j];
            panel.Controls.Remove(tile);
            this.Parent.Controls.Add(tile);
            tiles[i, j] = null;
            OnPickup(tile.Tile, i, j);
            return tile;
        }

        private Point LocationToIndex(Point loc)
        {
            int innerX = loc.X - this.Left;
            int innerY = loc.Y - this.Top;
            return new Point(innerX / TileSize.Width, innerY / TileSize.Height);
        }
    }
}
