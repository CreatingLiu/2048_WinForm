namespace _2048_WinForm
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BackgroundMusicListBox = new System.Windows.Forms.ListBox();
            this.BackgroundImageListBox = new System.Windows.Forms.ListBox();
            this.RevokeOnButton = new System.Windows.Forms.RadioButton();
            this.RevokeOffButton = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "背景：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "撤销：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "音乐：";
            // 
            // BackgroundMusicListBox
            // 
            this.BackgroundMusicListBox.FormattingEnabled = true;
            this.BackgroundMusicListBox.ItemHeight = 12;
            this.BackgroundMusicListBox.Items.AddRange(new object[] {
            "（无）",
            "River Flows In You                  ——刘倩倩",
            "Sing, R. Sing! - 幼女幻奏          ——刘倩倩",
            "恋愛サーキュレーション"});
            this.BackgroundMusicListBox.Location = new System.Drawing.Point(92, 40);
            this.BackgroundMusicListBox.Name = "BackgroundMusicListBox";
            this.BackgroundMusicListBox.Size = new System.Drawing.Size(314, 52);
            this.BackgroundMusicListBox.TabIndex = 3;
            // 
            // BackgroundImageListBox
            // 
            this.BackgroundImageListBox.FormattingEnabled = true;
            this.BackgroundImageListBox.ItemHeight = 12;
            this.BackgroundImageListBox.Items.AddRange(new object[] {
            "backgroundImage1    ——曹子悦",
            "backgroundImage2    ——曹子悦"});
            this.BackgroundImageListBox.Location = new System.Drawing.Point(92, 118);
            this.BackgroundImageListBox.Name = "BackgroundImageListBox";
            this.BackgroundImageListBox.Size = new System.Drawing.Size(314, 52);
            this.BackgroundImageListBox.TabIndex = 4;
            // 
            // RevokeOnButton
            // 
            this.RevokeOnButton.AutoSize = true;
            this.RevokeOnButton.Checked = true;
            this.RevokeOnButton.Location = new System.Drawing.Point(92, 195);
            this.RevokeOnButton.Name = "RevokeOnButton";
            this.RevokeOnButton.Size = new System.Drawing.Size(47, 16);
            this.RevokeOnButton.TabIndex = 5;
            this.RevokeOnButton.TabStop = true;
            this.RevokeOnButton.Text = "打开";
            this.RevokeOnButton.UseVisualStyleBackColor = true;
            this.RevokeOnButton.CheckedChanged += new System.EventHandler(this.RevokeOnButton_CheckedChanged);
            // 
            // RevokeOffButton
            // 
            this.RevokeOffButton.AutoSize = true;
            this.RevokeOffButton.Location = new System.Drawing.Point(145, 195);
            this.RevokeOffButton.Name = "RevokeOffButton";
            this.RevokeOffButton.Size = new System.Drawing.Size(47, 16);
            this.RevokeOffButton.TabIndex = 6;
            this.RevokeOffButton.Text = "关闭";
            this.RevokeOffButton.UseVisualStyleBackColor = true;
            this.RevokeOffButton.CheckedChanged += new System.EventHandler(this.RevokeOffButton_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(98, 228);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(94, 28);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(245, 228);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 28);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "取消";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 290);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.RevokeOffButton);
            this.Controls.Add(this.RevokeOnButton);
            this.Controls.Add(this.BackgroundImageListBox);
            this.Controls.Add(this.BackgroundMusicListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox BackgroundMusicListBox;
        private System.Windows.Forms.ListBox BackgroundImageListBox;
        private System.Windows.Forms.RadioButton RevokeOnButton;
        private System.Windows.Forms.RadioButton RevokeOffButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}