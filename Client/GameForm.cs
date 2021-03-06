﻿using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GameForm : Form
    {
        private List<TileGridPanel> tileGridPanels = new List<TileGridPanel>();

        private GameClient client;
        private RoomStatus roomStatus;
        private GameStatus gameStatus;

        public GameForm(GameClient client)
        {
            this.client = client;

            InitializeComponent();
            
            profile1.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile1.Width, profile1.Height, 15, 25));
            profile2.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile2.Width, profile2.Height, 15, 25));
            profile3.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile3.Width, profile3.Height, 15, 25));
            profile4.Region = Region.FromHrgn(CreateRoundRectRgn(1, 1, profile4.Width, profile4.Height, 15, 25));

            tileGridPanels.Add(tgpTable);
            tileGridPanels.Add(tgpHolding);

            tgpTable.TileSize = new Size(36, 48);
            tgpTable.SetCapacity(15, 6);
            tgpTable.OnPlace += (tile, i, j) => client.UpdateTable(tgpTable.GetTileTable());
            tgpTable.OnPickup += (tile, i, j) => client.UpdateTable(tgpTable.GetTileTable());

            tgpHolding.TileSize = new Size(36, 48);
            tgpHolding.SetCapacity(15, 2);
            tgpHolding.OnPlace += (tile, i, j) => client.UpdatePrivateTiles(tgpHolding.GetTileList());
            tgpHolding.OnPickup += (tile, i, j) => client.UpdatePrivateTiles(tgpHolding.GetTileList());
            tgpHolding.OptionRemoveSpaces = false;

            profile1.Visible = false;
            profile2.Visible = false;
            profile3.Visible = false;
            profile4.Visible = false;
            btn_complete.Visible = false;
            btn_return.Visible = false;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]            //Dll임포트

        private static extern IntPtr CreateRoundRectRgn                            //파라미터

        (
            int nLeftRect,      // x-coordinate of upper-left corner
            int nTopRect,       // y-coordinate of upper-left corner
            int nRightRect,     // x-coordinate of lower-right corner
            int nBottomRect,    // y-coordinate of lower-right corner   
            int nWidthEllipse,  // height of ellipse
            int nHeightEllipse  // width of ellipse  
        );

        private Point mousePoint;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        // 마우스 클릭시 먼저 선언된 mousePoint변수에 현재 마우스 위치값이 들어갑니다.

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        // 클릭상태로 마우스를 이동시 이동한 만큼에서 윈도우 위치값을 빼게됩니다.

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            btn_timer.Text = (int.Parse(btn_timer.Text) - 1).ToString();

            if (btn_timer.Text == "0")
            {
                tmrClock.Stop();
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        public void UpdateRoomStatus(RoomStatus roomStatus)
        {
            this.roomStatus = roomStatus;

            //TODO Update the form
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        if (i < roomStatus.Players.Count)
                        {
                            profile1.Visible = true;
                            nickname1.Text = roomStatus.Players[0].Nickname;
                            remain1.Text = roomStatus.Players[0].TileAmount.ToString();

                            if (gameStatus != null && gameStatus.CurrentPlayer != null &&
                                gameStatus.CurrentPlayer.Nickname == roomStatus.Players[i].Nickname)
                            {
                                nickname1.ForeColor = Color.FromArgb(0xFFD600);
                            }
                            else
                            {
                                nickname1.ForeColor = Color.White;
                            }
                        }
                        else
                        {
                            profile1.Visible = false;
                            nickname1.Text = "";
                            remain1.Text = "";
                            nickname1.ForeColor = Color.White;
                        }
                        break;
                    case 1:
                        if (i < roomStatus.Players.Count)
                        {
                            profile2.Visible = true;
                            nickname2.Text = roomStatus.Players[1].Nickname;
                            remain2.Text = roomStatus.Players[1].TileAmount.ToString();

                            if (gameStatus != null && gameStatus.CurrentPlayer != null &&
                                gameStatus.CurrentPlayer.Nickname == roomStatus.Players[i].Nickname)
                            {
                                nickname2.ForeColor = Color.FromArgb(0xFFD600);
                            }
                            else
                            {
                                nickname2.ForeColor = Color.White;
                            }
                        }
                        else
                        {
                            profile2.Visible = false;
                            nickname2.Text = "";
                            remain2.Text = "";
                            nickname2.ForeColor = Color.White;
                        }
                        break;
                    case 2:
                        if (i < roomStatus.Players.Count)
                        {
                            profile3.Visible = true;
                            nickname3.Text = roomStatus.Players[2].Nickname;
                            remain3.Text = roomStatus.Players[2].TileAmount.ToString();

                            if (gameStatus != null && gameStatus.CurrentPlayer != null &&
                                gameStatus.CurrentPlayer.Nickname == roomStatus.Players[i].Nickname)
                            {
                                nickname3.ForeColor = Color.FromArgb(0xFFD600);
                            }
                            else
                            {
                                nickname3.ForeColor = Color.White;
                            }
                        }
                        else
                        {
                            profile3.Visible = false;
                            nickname3.Text = "";
                            remain3.Text = "";
                            nickname3.ForeColor = Color.White;
                        }
                        break;
                    case 3:
                        if (i < roomStatus.Players.Count)
                        {
                            profile4.Visible = true;
                            nickname4.Text = roomStatus.Players[3].Nickname;
                            remain4.Text = roomStatus.Players[3].TileAmount.ToString();

                            if (gameStatus != null && gameStatus.CurrentPlayer != null &&
                                gameStatus.CurrentPlayer.Nickname == roomStatus.Players[i].Nickname)
                            {
                                nickname4.ForeColor = Color.FromArgb(0xFFD600);
                            }
                            else
                            {
                                nickname4.ForeColor = Color.White;
                            }
                        }
                        else
                        {
                            profile4.Visible = false;
                            nickname4.Text = "";
                            remain4.Text = "";
                            nickname4.ForeColor = Color.White;
                        }
                        break;
                }
            }
        }

        public void UpdateGameStatus(GameStatus gameStatus)
        {
            if (this.gameStatus != null && this.gameStatus.CurrentPlayer != gameStatus.CurrentPlayer)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    tmrClock.Stop();
                    btn_timer.Text = "60";
                    tmrClock.Start();
                    foreach(TileBlock t in this.Controls["MainForm"].Controls.Find("TileBlock", false))
                    {
                        t.Dispose();
                        this.Controls["MainForm"].Controls.Remove(t);
                    }

                    if (gameStatus.CurrentPlayer.Nickname == client.Player.Nickname)
                    {
                        btn_complete.Visible = true;
                        btn_return.Visible = true;
                    }
                    else
                    {
                        btn_complete.Visible = false;
                        btn_return.Visible = false;
                    }
                }));
            }

            this.gameStatus = gameStatus;

            Invoke(new MethodInvoker(delegate ()
            {
                if (gameStatus.IsEnabled)
                    btnStart.Hide();
                else
                    btnStart.Show();
            }));
        }

        public void UpdateTable(Tile[,] table)
        {
            tgpTable.SetCapacity(table.GetLength(1), table.GetLength(0));

            Invoke(new MethodInvoker(() =>
            {
                for (int i = 0; i < tgpTable.GetTileTable().GetLength(0); i++)
                {
                    for (int j = 0; j < tgpTable.GetTileTable().GetLength(1); j++)
                    {
                        if (tgpTable.BlockAt(i, j) != null)
                        {
                            TileBlock block = tgpTable.PickupTile(i, j, false);
                            block.Parent.Controls.Remove(block);
                        }
                    }
                }
            }));

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Tile tile = table[i, j];
                    
                    if (tile != null)
                    {
                        TileBlock block = new TileBlock(tile, tileGridPanels);
                        
                        block.Size = new Size(40, 40);
                        block.Location = new Point(100, 100);

                        Invoke(new MethodInvoker(() => tgpTable.AddTile(block, i, j, false)));
                    }
                }
            }
        }

        public void UpdatePrivateTiles(List<Tile> privateTiles)
        {
            Invoke(new MethodInvoker(() =>
            {
                for (int i = 0; i < tgpHolding.GetTileTable().GetLength(0); i++)
                {
                    for (int j = 0; j < tgpHolding.GetTileTable().GetLength(1); j++)
                    {
                        if (tgpHolding.BlockAt(i, j) != null)
                        {
                            TileBlock block = tgpHolding.PickupTile(i, j, false);
                            block.Parent.Controls.Remove(block);
                        }
                    }
                }
            }));
            Invoke(new MethodInvoker(() =>
            {
                foreach (Tile tile in privateTiles)
                {
                    TileBlock block = new TileBlock(tile, tileGridPanels);
                    block.Size = new Size(40, 40);
                    block.Location = new Point(100, 100);

                    tgpHolding.PlaceAtFirst(block, false);
                }
            }));
        }

        public void PrintChatMessage(string playerName, string message)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txt_log.AppendText("<" + playerName + ">: " + message + "\r\n");
            }));
        }

        public void ShowResultForm(List<PlayerInfo> ranking)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                GameResultForm resultForm = new GameResultForm(client, ranking);
                resultForm.StartPosition = FormStartPosition.CenterParent;
                resultForm.Owner = this;
                resultForm.Show();
            }));
        }

        private void Btn_complete_Click(object sender, EventArgs e)
        {
            client.NextTurn();
        }

        private void Btn_return_Click(object sender, EventArgs e)
        {
            client.RequestRollback();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!gameStatus.IsEnabled)
            {
                client.StartGame();
            }
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            client.SendChat(txtbox_chat.Text);
            txtbox_chat.Clear();
        }

        private void txtbox_chat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 엔터키 눌렀을 때
            {
                e.SuppressKeyPress = true;
                client.SendChat(txtbox_chat.Text);
                txtbox_chat.Clear();
            }
        }

        private void Lbl_title_Click(object sender, EventArgs e)
        {
            TileBlock tile = new TileBlock(new JokerTile(TileColor.BLACK), tileGridPanels);
            tile.Size = new Size(40, 40);
            tile.Location = new Point(100, 100);

            tgpHolding.PlaceAtFirst(tile);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            tgpHolding.SetGameForm(this);
            tgpTable.SetGameForm(this);
        }
        public GameClient getClient()
        {
            return client;
        }
        public GameStatus getGameStatus()
        {
            return gameStatus;
        }

        private void Btn_sort_col_Click(object sender, EventArgs e)
        {
            tgpHolding.GroupAsNumber();
            client.UpdatePrivateTiles(tgpHolding.GetTileList());
        }

        private void btn_sort_num_Click(object sender, EventArgs e)
        {
            tgpHolding.SortAscending();
            client.UpdatePrivateTiles(tgpHolding.GetTileList());
        }

        private void OutlineBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void OutlineBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }
    }
}
