using Common;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Client
{
    public delegate void InteractionHandler(Tile tile, int i, int j);

    public partial class TileGridPanel : UserControl
    {
        public Size TileSize { get; set; }
        public TileBlock[,] tiles;
        private TileBlock[,] oldTiles;
        public GameForm gameform;

        public bool OptionRemoveSpaces { get; set; } = false;

        public InteractionHandler OnPlace { get; set; } = (tile, i, j) => { };

        public InteractionHandler OnPickup { get; set; } = (tile, i, j) => { };

        public TileGridPanel()
        {
            InitializeComponent();
        }
        public void SetGameForm(GameForm gameform)
        {
            this.gameform = gameform;
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
            else//TODO 크기 조정
            {
                //타일크기
                this.TileSize = new Size(this.Width / horizontalCap, this.Height / verticalCap);
                for (int i = 0; i < tiles.GetLength(0); i++)//타일들의 실제 크기 조정
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        TileBlock block = tiles[i, j];
                        if (block != null)
                            block.Invoke(new MethodInvoker(delegate () { block.Size = this.TileSize; }));
                    }
                }

                oldTiles = new TileBlock[tiles.GetLength(0), tiles.GetLength(1)];

                for (int i = 0; i < tiles.GetLength(0); i++)//기존 판 내용 복사
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                        oldTiles[i, j] = tiles[i, j];
                }

                tiles = new TileBlock[verticalCap, horizontalCap];//기존 판 확장

                int disVer = (verticalCap - oldTiles.GetLength(0)) / 2;
                int disHor = (horizontalCap - oldTiles.GetLength(1)) / 2;

                for (int i = disVer; i < verticalCap - disVer; i++) {
                    for (int j = disHor; j < horizontalCap - disHor; j++) {
                        if (oldTiles[i - disVer, j - disHor] != null)
                        {
                            tiles[i, j] = oldTiles[i - disVer, j - disHor];
                            tiles[i,j].Invoke(new MethodInvoker(delegate() { tiles[i, j].Location = new Point(j * TileSize.Width, i * TileSize.Height); }));
                        }
                    }
                }
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
                    if (block != null)
                    {
                        if (block.Tile is NumberTile)
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
                    if (block != null)
                    {
                        if (block.Tile is JokerTile)
                            tileAcenList.Add(block);
                    }
                }
            }

            int m = 0;
            int n = 0;

            foreach (TileBlock block in tileAcenList)
            {
                tiles[m, n] = block;
                tiles[m, n].Location = new Point(n * TileSize.Width, m * TileSize.Height);

                n++;
                if (n >= tiles.GetLength(1))
                {
                    n = 0;
                    m++;
                    if (m >= tiles.GetLength(0))
                        break;
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
                    if (block != null)
                    {
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
                    if (block != null) {
                        if (block.Tile is JokerTile)
                            tileAcenList.Add(block);
                    }
                }
            }

            int m = 0;
            int n = 0;

            foreach (TileBlock block in tileAcenList)
            {
                tiles[m, n] = block;
                tiles[m, n].Location = new Point(n * TileSize.Width, m * TileSize.Height);

                n++;
                if (n >= tiles.GetLength(1))
                {
                    n = 0;
                    m++;
                    if (m >= tiles.GetLength(0))
                        break;
                }
            }

        }

        public void RemoveSpaces()//TODO 타일과 타일 사이의 빈 공간들을 제거하여 정렬
        {
            List<TileBlock> tileBlockList = new List<TileBlock>();

            for (int i = 0; i < tiles.GetLength(0); i++)//tiles의 모든 타일 list에 추가
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileBlock block = tiles[i, j];

                    if (block != null)
                        tileBlockList.Add(block);
                }
            }

            int m = 0;
            int n = 0;
            foreach (TileBlock block in tileBlockList)
            {
                tiles[m, n] = block;
                tiles[m, n].Location = new Point(n * TileSize.Width, m * TileSize.Height);

                n++;
                if (n >= tiles.GetLength(1))
                {
                    n = 0;
                    m++;

                    if (m >= tiles.GetLength(0))
                        break;
                }
            }
        }

        public bool CanPlaceAt(int x, int y)
        {
            Point index = LocationToIndex(new Point(x, y));
            return (index.Y >= 0 && index.Y < tiles.GetLength(0) &&
                index.X >= 0 && index.X < tiles.GetLength(1));
        }

        public void AddTile(TileBlock tile, int i, int j, bool callEvent = true)
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
            if (callEvent)
            {
                OnPlace(tile.Tile, i, j);
            }
        }
        public bool isPlaceable(Point index,int Size)
        {
            for(int i=0;i<Size;i++)
            {
                try
                {
                    if (tiles[index.Y, index.X + i] != null)
                        return false;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return true;
            
        }
        public bool PlaceTile(TileBlock tile, int x, int y)
        {
            Point index = LocationToIndex(new Point(x, y));
            if (tile.leftblock != null )
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        if (tiles[i, j] == tile.leftblock)
                        {
                            AddTile(tile, i, j + 1);
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                try
                {
                    if (tiles[index.Y, index.X] == null)
                    {
                        if (tile.tileblockset != null && tile.tileblockset.Count > 0 && isPlaceable(index, tile.tileblockset.Count))
                        {
                            AddTile(tile, index.Y, index.X);
                            return true;
                        }
                        else if (tile.tileblockset == null)
                        {
                            AddTile(tile, index.Y, index.X);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        return PlaceTile(tile, new Point(index.X + 1, index.Y));
                    }
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
        public bool PlaceTile(TileBlock tile,Point index)
        {
            if (tile.leftblock != null)
            {
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        if (tiles[i, j] == tile.leftblock)
                        {
                                AddTile(tile, i, j + 1);
                                return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                if (tiles[index.Y, index.X] == null)
                {
                    if (tile.tileblockset != null && tile.tileblockset.Count>0 && isPlaceable(index,tile.tileblockset.Count))
                    {
                        AddTile(tile, index.Y, index.X);
                        return true;
                    }
                    else if (tile.tileblockset == null)
                    {
                        AddTile(tile, index.Y, index.X);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return PlaceTile(tile, new Point(index.X + 1, index.Y));
                }
            }
        }
        public bool PlaceAtFirst(TileBlock tile, bool callEvent = true)
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] == null)
                    {
                        AddTile(tile, i, j, callEvent);
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

        public TileBlock PickupTile(int i, int j, bool callEvent = true)
        {
            TileBlock tile = tiles[i, j];
            //tile.Visible = false;
            panel.Controls.Remove(tile);
            this.Parent.Controls.Add(tile);
            tiles[i, j] = null;
            if (callEvent)
            {
                OnPickup(tile.Tile, i, j);
            }
            return tile;
        }

        private Point LocationToIndex(Point loc)
        {
            int innerX = loc.X - this.Left;
            int innerY = loc.Y - this.Top;
            return new Point(innerX / TileSize.Width, innerY / TileSize.Height);
        }

        public void TileGridPanel_MouseDown(object sender, MouseEventArgs e)
        {
            int innerX = this.Left;
        }
        public List<TileBlock> FindTileSet(TileBlock tile)
        {
            List<TileBlock> tileset = new List<TileBlock>();
            int r, c;
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] == tile)
                    {
                        r = i;
                        c = j;
                            for (int sc = c; sc >= 0; sc--)
                            {
                                if (sc > 0)
                                {
                                    if (tiles[r, sc - 1] == null)
                                    {
                                            for (int b = sc; b < tiles.GetLength(1); b++)
                                            {
                                                if (tiles[r, b] != null)
                                                {
                                                    if (b > 0)
                                                    {
                                                        tiles[r, b].leftblock = tiles[r, b - 1];
                                                    }
                                                    tileset.Add(tiles[r, b]);
                                                }
                                                else
                                                    return tileset;
                                            }
                                    return tileset;
                                    }
                                }
                                else if (sc == 0)
                                {
                                        for (int b = sc; b < tiles.GetLength(1); b++)
                                        {
                                            if (tiles[r, b] != null)
                                            {
                                                if (b > 0)
                                                {
                                                    tiles[r, b].leftblock = tiles[r, b - 1];
                                                }
                                                tileset.Add(tiles[r, b]);
                                            }
                                            else
                                                return tileset;
                                        }
                                }
                                
                            }
                        
                    }
                }
            }
            return tileset;
        }
    }

}
