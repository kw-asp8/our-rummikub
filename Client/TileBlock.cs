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
        public TileBlock leftblock = null;
        private List<TileGridPanel> grids = new List<TileGridPanel>();
        private bool isDragging = false;
        public Point startPoint;
        public Point prevLocation;
        public List<TileBlock> tileblockset = new List<TileBlock>();
        public TileGridPanel prevGrid;

        public TileGridPanel ContainerGrid { get; set; }

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

        public void TileBlock_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (ContainerGrid.gameform.getClient().Player == null || ContainerGrid.gameform.getClient().Player.Nickname != ContainerGrid.gameform.getGameStatus().CurrentPlayer.Nickname)
                    return;
            }
            catch (NullReferenceException i)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (ContainerGrid != null)
                {
                    tileblockset = null;
                    leftblock = null;
                    isDragging = true;
                        prevLocation = new Point(ContainerGrid.Left + Location.X, ContainerGrid.Top + Location.Y);
                        prevGrid = ContainerGrid;
                        startPoint = new Point(e.X, e.Y);
                        ContainerGrid.PickupTile(this);
                        ContainerGrid = null;
                }
                BringToFront();
            }
            else
            {
                tileblockset = this.ContainerGrid.FindTileSet(this);
                if (ContainerGrid != null)
                {
                    foreach (TileBlock t in tileblockset)
                    {
                        t.tileblockset = tileblockset;
                        t.isDragging = true;
                        t.prevLocation = new Point(t.ContainerGrid.Left + t.Location.X, t.ContainerGrid.Top + t.Location.Y);
                        t.prevGrid = t.ContainerGrid;
                        t.startPoint = new Point(e.X, e.Y);
                        t.ContainerGrid.PickupTile(t);
                        t.ContainerGrid = null;

                    }
                }
                foreach (TileBlock t in tileblockset)
                {
                    t.BringToFront();
                }
            }
            
        }

        public void TileBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if(e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - startPoint.X;
                    this.Top += e.Y - startPoint.Y;
                }
                else
                {
                    foreach (TileBlock t in tileblockset)
                    {
                        t.Left += e.X - t.startPoint.X;
                        t.Top += e.Y - t.startPoint.Y;
                    }
                }
            }
        }

        private void TileBlock_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging == false)
                return;
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                TileGridPanel grid;
                if (leftblock != null)
                    grid = leftblock.ContainerGrid;
                else
                    grid = FindTileGrid();
                if (grid != null)
                {
                    if (!grid.PlaceTile(this, Left, Top) || (Tile.IsFromTable && grid == grids[1]))
                    {
                        Location = prevLocation;
                        prevGrid.PlaceTile(this, Left, Top);
                    }
                }
                else
                {
                    Location = prevLocation;
                    prevGrid.PlaceTile(this, Left, Top);
                }
            }
            else
            {
                foreach (TileBlock t in tileblockset)
                {
                    t.isDragging = false;
                    TileGridPanel grid;
                    if (t.leftblock != null)
                        grid = t.leftblock.ContainerGrid;
                    else
                        grid = FindTileGrid();
                    if (grid != null)
                    {
                        if (!grid.PlaceTile(t, t.Left, t.Top) || (t.Tile.IsFromTable && grid == grids[1]))
                        {
                            t.Location = t.prevLocation;
                            t.prevGrid.PlaceTile(t, t.Left, t.Top);
                        }
                    }
                    else
                    {
                        t.Location = t.prevLocation;
                        t.prevGrid.PlaceTile(t, t.Left, t.Top);
                    }
                }
            }
            
        }
        //public bool isPlaceable()
        //{
        //    for (int i = 1; i < tileblockset.Count(); i++)
        //    {
        //        if (tileblockset[i].FindTileGrid().isPlaceable(tileblockset[i]) == false)
        //            return false;
        //    }
        //    return true;
        //}
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

        private void lbl_num_Click(object sender, EventArgs e)
        {

        }
    }
}
