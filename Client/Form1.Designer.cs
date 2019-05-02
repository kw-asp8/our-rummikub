namespace WindowsFormsApp17
{
    partial class Background
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Chatting = new System.Windows.Forms.Panel();
            this.Main = new System.Windows.Forms.Panel();
            this.btn_timer = new System.Windows.Forms.Button();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chatting
            // 
            this.Chatting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.Chatting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Chatting.Location = new System.Drawing.Point(0, 448);
            this.Chatting.Name = "Chatting";
            this.Chatting.Size = new System.Drawing.Size(672, 106);
            this.Chatting.TabIndex = 0;
            // 
            // Main
            // 
            this.Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(240)))));
            this.Main.Controls.Add(this.btn_timer);
            this.Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(672, 448);
            this.Main.TabIndex = 1;
            // 
            // btn_timer
            // 
            this.btn_timer.AllowDrop = true;
            this.btn_timer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.btn_timer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_timer.FlatAppearance.BorderSize = 0;
            this.btn_timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_timer.Location = new System.Drawing.Point(567, 25);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(84, 60);
            this.btn_timer.TabIndex = 0;
            this.btn_timer.Text = "button1";
            this.btn_timer.UseVisualStyleBackColor = false;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 554);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.Chatting);
            this.Name = "Background";
            this.Text = "R";
            this.Load += new System.EventHandler(this.Background_Load);
            this.Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Chatting;
        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Button btn_timer;
    }


}

