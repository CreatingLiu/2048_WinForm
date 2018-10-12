using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static _2048_WinForm.PublicVar;


namespace _2048_WinForm
{
    public partial class SettingForm : Form
    {
        private bool isRevoke = Properties.Settings.Default.isRevoke;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine(BackgroundMusicListBox.SelectedIndex);
            Trace.WriteLine(BackgroundImageListBox.SelectedIndex);
            Properties.Settings.Default.backgroundMusicIndex = (byte)BackgroundMusicListBox.SelectedIndex;
            Properties.Settings.Default.backgroundImageIndex = (byte)BackgroundImageListBox.SelectedIndex;
            mainForm.SetBackgroundImage((byte)BackgroundImageListBox.SelectedIndex);
            Properties.Settings.Default.isRevoke = isRevoke;
            Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Location = new Point(primaryScreenWidth/2-229,primaryScreenHeight/2-145);

            BackgroundImageListBox.SelectedIndex = Properties.Settings.Default.backgroundImageIndex;
            BackgroundMusicListBox.SelectedIndex = Properties.Settings.Default.backgroundMusicIndex;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RevokeOnButton_CheckedChanged(object sender, EventArgs e)
        {
            isRevoke = true;
        }

        private void RevokeOffButton_CheckedChanged(object sender, EventArgs e)
        {
            isRevoke = false;
        }
    }
}
