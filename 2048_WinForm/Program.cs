using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2048_WinForm
{
    public static class PublicVar   //全局变量区域
    {
        public static short[,] num = new short[4, 4];
        public static short[,] lastNum = new short[4, 4];
        public static int time = 0;
        public static int lastTime = 0;
        public static int score = 0;
        public static int lastScore = 0;

        public static PictureBox[,] pictureBoxes = new PictureBox[4, 4];
        public static MainForm mainForm;
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PublicVar.mainForm = new MainForm();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PublicVar.pictureBoxes[i, j] = new PictureBox
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = false,
                        Size = new System.Drawing.Size(80, 80),
                        Location = new System.Drawing.Point(100 + j * 100, 160 + i * 100),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Enabled = false
                    };
                    PublicVar.mainForm.Controls.Add(PublicVar.pictureBoxes[i, j]);
                }
            }  //初始化pictureBox

            //pictureBoxes[0, 0].Image = Properties.Resources.num2;
            Start();


            Application.Run(PublicVar.mainForm);
            Console.Read();
        }

        public static void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PublicVar.num[i, j] = 0;
                    PublicVar.lastNum[i, j] = 0;
                }
            }  //初始化数组变量

            PublicVar.time = 0;             //初始化计分计时
            PublicVar.score = 0;

            PublicVar.num = SetNewNum(PublicVar.num);  //放置开始的两个点
            PublicVar.num = SetNewNum(PublicVar.num);
            //PublicVar.num = SetMyNum();            //去掉注释以调试程序

            PublicVar.lastNum = CopyToB(PublicVar.num);
            PublicVar.mainForm.SetGameArea(PublicVar.num);
        }

        private static short[,] SetMyNum()
        {
            short[,] a =
            {
                {0,2,2,0 },
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 }
            };
            return a;
        }  //调试用，手动设定初始值

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
        }  //点类

        public static short[,] SetNewNum(short[,] a)
        {
            Point rp = RandomPoint(a);
            if (rp != null)
                a[rp.X, rp.Y] = 2;
            return a;
        }  //放置新点

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
            System.Threading.Thread.Sleep(30);
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
        } //复制数组

        public static short[,] SquareRot90(short[,] a, int rotNum)
        {
            while (rotNum < 0)
            {
                rotNum += 4;
            }
            for (int rot_i = 0; rot_i < rotNum; rot_i++)
            {
                short[,] b = new short[4,4];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        b[j, a.GetLength(0) - i - 1] = a[i, j];
                    }
                }
                a = b;
            }
            return a;
        } //旋转

        public static short[,] Merge(short[,] a)
        {
            for (short i = 0; i < 4; i++)
            {
                short last_j = 0;
                for (short j = 0; j < 4; j++)//合并
                {
                    if (a[i, j] != 0)
                    {
                        if (a[i, j] == a[i, last_j] && j != last_j)
                        {
                            PublicVar.score = PublicVar.score + a[i, j] + a[i, last_j];
                            a[i, j] = (short)(a[i, j] + a[i, last_j]);
                            a[i, last_j] = 0;
                        }
                        else
                        {
                            last_j = j;
                        }
                    }
                }
                last_j = 0;
                for (int j = 0; j < a.GetLength(1); j++)//整理
                {
                    if (a[i, j] != 0)
                    {
                        a[i, last_j] = a[i, j];
                        if (last_j != j)
                            a[i, j] = 0;
                        last_j++;
                    }
                }
            }
            return a;
        }  //向左合并

        public static bool IsEquals(short[,] a, short[,] b)
        {
            bool res = true;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (b[i, j] != a[i, j])
                    {
                        res = false;
                        break;
                    }
                }
                if (!res)
                    break;
            }
            return res;
        }  //判断两个数组是否相等

        public static bool CanMove(short[,] a)
        {
            int s = PublicVar.score;
            bool res = false;
            short[,] b = CopyToB(a);
            b = Merge(b);
            if (!IsEquals(a, b))
                res = true;
            b = CopyToB(a);
            b = SquareRot90(b, 1);
            b = Merge(b);
            b = SquareRot90(b, -1);
            if (!IsEquals(a, b))
                res = true;
            b = CopyToB(a);
            b = SquareRot90(b, 2);
            b = Merge(b);
            b = SquareRot90(b, -2);
            if (!IsEquals(a, b))
                res = true;
            b = CopyToB(a);
            b = SquareRot90(b, 3);
            b = Merge(b);
            b = SquareRot90(b, -3);
            if (!IsEquals(a, b))
                res = true;
            PublicVar.score = s;
            return res;
        }  //判断是否还可以移动

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
