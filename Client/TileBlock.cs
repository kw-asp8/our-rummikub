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
    public partial class TileBlock : UserControl
    {
        public Tile Tile { get; private set; }

        private List<TileGridPanel> grids = new List<TileGridPanel>();
        private bool isDragging = false;
        private Point startPoint;
        private Point prevLocation;
        private TileGridPanel prevGrid;

        public TileGridPanel ContainerGrid { get; set; } = null;

        public TileBlock(Tile tile, List<TileGridPanel> grids)
        {
            InitializeComponent();
            this.Tile = tile;
            this.grids = grids;
            if (Tile is NumberTile)
            {
                lbl_num.Text = (((NumberTile)Tile).Number).ToString();
                TileColor color = ((NumberTile)Tile).getColor();

                switch(color.ToString())
                {
                    case "RED":
                        lbl_num.ForeColor = Color.Red;
                        break;
                    case "YELLOW":
                        lbl_num.ForeColor = Color.Yellow;
                        break;
                    case "BLUE":
                        lbl_num.ForeColor = Color.Blue;
                        break;
                    case "BLACK":
                        lbl_num.ForeColor = Color.Black;
                        break;
                }
            }
            else if (Tile is JokerTile)
            {
                lbl_num.Text = "J";
                TileColor color = ((JokerTile)Tile).getColor();

                switch(color.ToString())
                {
                    case "RED":
                        lbl_num.ForeColor = Color.Red;
                        break;
                    case "BLACK":
                        lbl_num.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void TileBlock_MouseDown(object sender, MouseEventArgs e)
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

        private void TileBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left += e.X - startPoint.X;
                this.Top += e.Y - startPoint.Y;
            }
        }

        private void TileBlock_MouseUp(object sender, MouseEventArgs e)
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

        private void lbl_num_MouseDown(object sender, MouseEventArgs e)
        {
            TileBlock_MouseDown(sender, e);
        }

        private void lbl_num_MouseUp(object sender, MouseEventArgs e)
        {
            TileBlock_MouseUp(sender, e);
        }

        private void lbl_num_MouseMove(object sender, MouseEventArgs e)
        {
            TileBlock_MouseMove(sender, e);
        }
    }
}
