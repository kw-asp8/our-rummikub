namespace Client
{
    partial class TileBlock
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_num = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_num
            // 
            this.lbl_num.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_num.BackColor = System.Drawing.Color.Transparent;
            this.lbl_num.Font = new System.Drawing.Font("나눔바른고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_num.Location = new System.Drawing.Point(0, 0);
            this.lbl_num.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(24, 29);
            this.lbl_num.TabIndex = 0;
            this.lbl_num.Text = "J";
            this.lbl_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_num.Click += new System.EventHandler(this.lbl_num_Click);
            this.lbl_num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_num_MouseDown);
            this.lbl_num.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_num_MouseMove);
            this.lbl_num.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_num_MouseUp);
            // 
            // TileBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_num);
            this.Name = "TileBlock";
            this.Size = new System.Drawing.Size(24, 29);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_num;
    }
}
