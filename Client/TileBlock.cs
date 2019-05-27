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
    public partial class TileBlock : UserControl
    {
        private List<TileGridPanel> grids = new List<TileGridPanel>();
        private bool isDragging = false;
        private Point startPoint;
        private Point prevLocation;
        private TileGridPanel prevGrid;

        public TileGridPanel ContainerGrid { get; set; } = null;

        public TileBlock(List<TileGridPanel> grids)
        {
            InitializeComponent();
            this.grids = grids;
        }

        private void Tile_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = new Point(e.X, e.Y);
            prevGrid = ContainerGrid;
            prevLocation = new Point(ContainerGrid.Left + Location.X, ContainerGrid.Top + Location.Y);

            if (ContainerGrid != null)
            {
                ContainerGrid.PickupTile(this);
                ContainerGrid = null;
            }

            this.BringToFront();
        }

        private void Tile_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left += e.X - startPoint.X;
                this.Top += e.Y - startPoint.Y;
            }
        }

        private void Tile_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            TileGridPanel grid = FindTileGrid();
            if (grid != null)
            {
                grid.PlaceTile(this, this.Left, this.Top);
            }
            else
            {
                this.Location = prevLocation;
                prevGrid.PlaceTile(this, this.Left, this.Top);
            }
        }

        private TileGridPanel FindTileGrid()
        {
            foreach (TileGridPanel grid in grids)
            {
                if (this.CollidesWith(grid) && grid.CanPlaceAt(this.Left, this.Top))
                {
                    return grid;
                }
            }
            return null;
        }

        private bool CollidesWith(TileGridPanel panel)
        {
            if (this.Right < panel.Left || this.Left > panel.Right) return false;
            if (this.Bottom < panel.Top || this.Top > panel.Bottom) return false;
            return true;
        }
    }
}
