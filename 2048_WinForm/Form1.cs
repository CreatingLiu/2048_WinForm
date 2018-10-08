using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _2048_WinForm
{
    

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Up:    //上
                case (char)Keys.W:

                    break;
                case (char)Keys.Down: //下
                case (char)Keys.S:

                    break;
                case (char)Keys.Left: //左
                case (char)Keys.A:

                    break;
                case (char)Keys.Right: //右
                case (char)Keys.D:

                    break;
                case (char)Keys.H:    //帮助

                    break;
                case (char)Keys.Z:   //撤销 

                    break;
                case (char)Keys.X:   //保存

                    break;
                case (char)Keys.L:   //读档

                    break;
                case (char)Keys.R:   //重置

                    break;
                default:
                    break;
            }
        }
    }
}
