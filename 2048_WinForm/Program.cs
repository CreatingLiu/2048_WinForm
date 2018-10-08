using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2048_WinForm
{
    public static class PublicVar   //全局变量区域
    {
        public static short[,] num;
        public static short[,] lastNum;
        public static int time = 0;
        public static int score = 0;
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PublicVar.num[i, j] = 0;
                    PublicVar.lastNum[i, j] = 0;
                }
            }  //初始化数组变量

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();

            PictureBox[,] pictureBoxes = new PictureBox[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pictureBoxes[i, j] = new PictureBox
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = false,
                        Size = new System.Drawing.Size(80, 80),
                        Location = new System.Drawing.Point(100 + i * 100, 100 + j * 100),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Enabled = false
                    };
                    mainForm.Controls.Add(pictureBoxes[i, j]);
                }
            }  //初始化pictureBox

            pictureBoxes[0, 0].Image = Properties.Resources.num2;

            Application.Run(mainForm);

        }
    }

    class SaveFile
    {
        public int[,] Num { get; }
        public int Score { get; }
        public long Time { get; }
        public SaveFile(int[,] num, int score, long time)
        {
            Num = num;
            Score = score;
            Time = time;
        }
    }
}
