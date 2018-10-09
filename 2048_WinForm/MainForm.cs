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
            PublicVar.time++;
            timeLabel.Text = PublicVar.time.ToString();
        }

        private void MainForm_KeyPress(object sender, KeyEventArgs e)
        {
            if (!Timer1.Enabled)
            {
                Timer1.Enabled = true;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:    //上
                case Keys.W:
                    PublicVar.lastNum = Program.CopyToB(PublicVar.num);
                    PublicVar.lastTime = PublicVar.time;
                    PublicVar.lastScore = PublicVar.score;
                    PublicVar.num = Program.Merge(PublicVar.num);
                    SetGameArea(PublicVar.num);
                    break;
                case Keys.Down: //下
                case Keys.S:
                    PublicVar.lastNum = Program.CopyToB(PublicVar.num);
                    PublicVar.lastTime = PublicVar.time;
                    PublicVar.lastScore = PublicVar.score;
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 2);
                    PublicVar.num = Program.Merge(PublicVar.num);
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 2);
                    SetGameArea(PublicVar.num);
                    break;
                case Keys.Left: //左
                case Keys.A:
                    PublicVar.lastNum = Program.CopyToB(PublicVar.num);
                    PublicVar.lastTime = PublicVar.time;
                    PublicVar.lastScore = PublicVar.score;
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 3);
                    PublicVar.num = Program.Merge(PublicVar.num);
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 1);
                    SetGameArea(PublicVar.num);
                    break;
                case Keys.Right: //右
                case Keys.D:
                    PublicVar.lastNum = Program.CopyToB(PublicVar.num);
                    PublicVar.lastTime = PublicVar.time;
                    PublicVar.lastScore = PublicVar.score;
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 1);
                    PublicVar.num = Program.Merge(PublicVar.num);
                    PublicVar.num = Program.SquareRot90(PublicVar.num, 3);
                    SetGameArea(PublicVar.num);
                    break;
                case Keys.H:    //帮助

                    break;
                case Keys.Z:   //撤销 

                    break;
                case Keys.X:   //保存

                    break;
                case Keys.L:   //读档

                    break;
                case Keys.R:   //重置

                    break;
                default:
                    break;
            }
            if (e.KeyCode==Keys.Up&&e.KeyCode == Keys.Down && e.KeyCode == Keys.Left && e.KeyCode == Keys.Right && e.KeyCode == Keys.W && e.KeyCode == Keys.S && e.KeyCode == Keys.A && e.KeyCode == Keys.D)
            {
                bool a = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (PublicVar.num[i, j] == 0)
                            a = true;
                    }
                }  //判断是否有空位

                if (a)
                    Program.RandomPoint(PublicVar.num);

                if (Program.CanMove(PublicVar.num))
                {

                }
                
            }
        }

        public void SetGameArea(short[,] num)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (num[i, j])
                    {
                        case 0:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num0;
                            break;
                        case 2:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num2;
                            break;
                        case 4:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num4;
                            break;
                        case 8:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num8;
                            break;
                        case 16:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num16;
                            break;
                        case 32:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num32;
                            break;
                        case 64:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num64;
                            break;
                        case 128:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num128;
                            break;
                        case 256:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num256;
                            break;
                        case 512:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num512;
                            break;
                        case 1024:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num1024;
                            break;
                        case 2048:
                            PublicVar.pictureBoxes[i, j].Image = Properties.Resources.num2048;
                            break;
                        default:
                            break;
                    }
                }
            }   //设置每一个pictureBox的值
            SetDateArea();
        }

        private void SetDateArea()
        {
            timeLabel.Text = PublicVar.time.ToString();
            scoreLabel.Text = PublicVar.score.ToString();
        }
    }
}
