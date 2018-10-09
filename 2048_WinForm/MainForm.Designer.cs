namespace _2048_WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundListBox = new System.Windows.Forms.ListBox();
            this.focusSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("迷你简汉真广标", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreLabel.Location = new System.Drawing.Point(79, 47);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(102, 21);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "得分显示";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("迷你简汉真广标", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeLabel.Location = new System.Drawing.Point(414, 47);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(102, 21);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "时间显示";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(100, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 400);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // backgroundListBox
            // 
            this.backgroundListBox.FormattingEnabled = true;
            this.backgroundListBox.ItemHeight = 12;
            this.backgroundListBox.Items.AddRange(new object[] {
            "background1",
            "background2"});
            this.backgroundListBox.Location = new System.Drawing.Point(470, 560);
            this.backgroundListBox.Name = "backgroundListBox";
            this.backgroundListBox.Size = new System.Drawing.Size(107, 28);
            this.backgroundListBox.TabIndex = 6;
            this.backgroundListBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundListBox_SelectedIndexChanged);
            // 
            // focusSet
            // 
            this.focusSet.Location = new System.Drawing.Point(102, 55);
            this.focusSet.Name = "focusSet";
            this.focusSet.Size = new System.Drawing.Size(10, 10);
            this.focusSet.TabIndex = 0;
            this.focusSet.Text = "焦点按钮";
            this.focusSet.UseVisualStyleBackColor = true;
            this.focusSet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::_2048_WinForm.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.ControlBox = false;
            this.Controls.Add(this.backgroundListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.focusSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "2048小游戏";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox backgroundListBox;
        private System.Windows.Forms.Button focusSet;
    }
}

