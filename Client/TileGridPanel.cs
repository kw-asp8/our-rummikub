using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

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

        public void SortAscending()
        {
            //TODO 오름차순으로 타일 정렬
        }

        public void GroupAsNumber()
        {
            //TODO 같은 숫자의 타일끼리 모아서 정렬
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
