using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TileGridPanel : UserControl
    {
        public Size TileSize { get; set; }

        private Tile[,] tiles;

        public bool OptionRemoveSpaces { get; set; } = false;

        public TileGridPanel()
        {
            InitializeComponent();
        }

        public void SetCapacity(int horizontalCap, int verticalCap)
        {
            if (tiles == null)
            {
                tiles = new Tile[verticalCap, horizontalCap];
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

        private void AddTile(Tile tile, int i, int j)
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
        }

        public void PlaceTile(Tile tile, int x, int y)
        {
            Point index = LocationToIndex(new Point(x, y));
            AddTile(tile, index.Y, index.X);
        }

        public bool PlaceAtFirst(Tile tile)
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

        public void PickupTile(Tile tile)
        {
            panel.Controls.Remove(tile);
            this.Parent.Controls.Add(tile);
        }

        private Point LocationToIndex(Point loc)
        {
            int innerX = loc.X - this.Left;
            int innerY = loc.Y - this.Top;
            return new Point(innerX / TileSize.Width, innerY / TileSize.Height);
        }
    }
}
