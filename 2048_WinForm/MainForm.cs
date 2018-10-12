using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static _2048_WinForm.PublicVar;

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
            time++;
            timeLabel.Text = "时间：" + time.ToString() + "s";
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
                    lastNum = Program.CopyToB(num);
                    lastScore = score;
                    num = Program.SquareRot90(num, 3);
                    num = Program.Merge(num);
                    num = Program.SquareRot90(num, 1);
                    break;
                case Keys.Down: //下
                case Keys.S:
                    lastNum = Program.CopyToB(num);
                    lastScore = score;
                    num = Program.SquareRot90(num, 1);
                    num = Program.Merge(num);
                    num = Program.SquareRot90(num, 3);
                    break;
                case Keys.Left: //左
                case Keys.A:
                    lastNum = Program.CopyToB(num);
                    lastScore = score;
                    num = Program.Merge(num);
                    break;
                case Keys.Right: //右
                case Keys.D:
                    lastNum = Program.CopyToB(num);
                    lastScore = score;
                    num = Program.SquareRot90(num, 2);
                    num = Program.Merge(num);
                    num = Program.SquareRot90(num, 2);
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
                    Timer1.Enabled = false;
                    Program.Start();
                    break;
                default:
                    break;
            }

            if (e.KeyCode==Keys.Up||e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.W || e.KeyCode == Keys.S || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                Program.Point point = Program.RandomPoint(num);
                if (!Program.IsEquals(num, lastNum))
                {
                    num = Program.SetNewNum(num);
                }

                SetGameArea(num);

                if (!Program.CanMove(num))
                {
                    Timer1.Enabled = false;
                    MessageBox.Show("请按确定键重新开始", "游戏结束！");
                    Program.Start();
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
                            pictureBoxes[i, j].Image = null;
                            break;
                        case 2:
                            pictureBoxes[i, j].Image = Properties.Resources.num2;
                            break;
                        case 4:
                            pictureBoxes[i, j].Image = Properties.Resources.num4;
                            break;
                        case 8:
                            pictureBoxes[i, j].Image = Properties.Resources.num8;
                            break;
                        case 16:
                            pictureBoxes[i, j].Image = Properties.Resources.num16;
                            break;
                        case 32:
                            pictureBoxes[i, j].Image = Properties.Resources.num32;
                            break;
                        case 64:
                            pictureBoxes[i, j].Image = Properties.Resources.num64;
                            break;
                        case 128:
                            pictureBoxes[i, j].Image = Properties.Resources.num128;
                            break;
                        case 256:
                            pictureBoxes[i, j].Image = Properties.Resources.num256;
                            break;
                        case 512:
                            pictureBoxes[i, j].Image = Properties.Resources.num512;
                            break;
                        case 1024:
                            pictureBoxes[i, j].Image = Properties.Resources.num1024;
                            break;
                        case 2048:
                            pictureBoxes[i, j].Image = Properties.Resources.num2048;
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
            timeLabel.Text = "时间：" + time.ToString() + "s";
            scoreLabel.Text = "得分："+ score.ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            scoreLabel.Location = new Point(primaryScreenHeight*115/600+(primaryScreenWidth-primaryScreenHeight)/2,primaryScreenHeight*66/600);
            timeLabel.Location = new Point(primaryScreenHeight * 370 / 600 + (primaryScreenWidth - primaryScreenHeight) / 2, primaryScreenHeight * 66 / 600);
        }

        public void SetBackgroundImage(byte index)
        {
            switch (index)
            {
                case 0:
                    BackgroundImage = Properties.Resources.backgroundImage1;
                    break;
                case 1:
                    BackgroundImage = Properties.Resources.backgroundImage2;
                    break;
                default:
                    break;
            }
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            settingForm.ShowDialog();
        }
    }
}
