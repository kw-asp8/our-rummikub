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
            this.text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(34, 62);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(25, 12);
            this.text.TabIndex = 0;
            this.text.Text = "test";
            this.text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.text);
            this.Name = "Tile";
            this.Size = new System.Drawing.Size(100, 150);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TileBlock_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text;
    }
}
