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
        public static int lastTime = 0;
        public static int score = 0;
        public static int lastScore = 0;
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

        public static void Start()
        {
            PublicVar.num = SetNewNum(PublicVar.num);  //放置开始的两个点
            PublicVar.num = SetNewNum(PublicVar.num);

            //num = SetMyNum();       //去掉注释以调试程序

        }

        public class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X
            {
                get;
                set;
            }
            public int Y
            {
                get;
                set;
            }
        }

        public static short[,] SetNewNum(short[,] a)
        {
            Point rp;
            rp = RandomPoint(a);
            if (rp != null)
                a[rp.X, rp.Y] = 2;
            return a;
        }

        public static Point RandomPoint(short[,] a)  //查找返回随机空位置
        {
            List<Point> lstP = new List<Point>();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == 0)
                    {
                        lstP.Add(new Point(i, j));
                    }
                }
            }
            if (lstP.Count == 0)
            {
                return null;
            }
            int rnd = new Random().Next(lstP.Count);
            return lstP[rnd];
        }

        public static short[,] CopyToB(short[,] a)
        {
            short[,] b = new short[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    b[i, j] = a[i, j];
                }
            }
            return b;
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
