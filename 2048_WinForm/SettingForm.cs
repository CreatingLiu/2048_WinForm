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
            Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            BackgroundImageListBox.SelectedIndex = Properties.Settings.Default.backgroundImageIndex;
            BackgroundMusicListBox.SelectedIndex = Properties.Settings.Default.backgroundMusicIndex;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
