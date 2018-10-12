using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static _2048_WinForm.PublicVar;
using System.Media;

namespace _2048_WinForm
{
    /// <summary>
    /// 保存全局变量
    /// </summary>
    public static class PublicVar
    {
        /// <summary>
        /// 存储游戏数据的数组
        /// </summary>
        public static short[,] num = new short[4, 4];

        /// <summary>
        /// 上一回合数据的数组
        /// </summary>
        public static short[,] lastNum = new short[4, 4];

        /// <summary>
        /// 已经经过的时间
        /// </summary>
        public static int time = 0;

        /// <summary>
        /// 得分
        /// </summary>
        public static int score = 0;

        /// <summary>
        /// 上个回合的分数
        /// </summary>
        public static int lastScore = 0;

        /// <summary>
        /// 游戏区域显示数字的容器
        /// </summary>
        public static PictureBox[,] pictureBoxes = new PictureBox[4, 4];

        /// <summary>
        /// 主窗体
        /// </summary>
        public static MainForm mainForm;
        public static SettingForm settingForm;

        /// <summary>
        /// 背景音乐对象
        /// </summary>
        public static SoundPlayer backgroundMusicPlayer = new SoundPlayer();

        public static int primaryScreenWidth = Screen.PrimaryScreen.Bounds.Width;   //获取屏幕分辨率
        public static int primaryScreenHeight = Screen.PrimaryScreen.Bounds.Height;
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
            mainForm = new MainForm();
            settingForm = new SettingForm();


            Trace.WriteLine("屏幕分辨率："+primaryScreenWidth+"*"+primaryScreenHeight);

            int pictureBoxSize = 2 * primaryScreenHeight / 15;
            int pictureBoxesLocationWidth = (primaryScreenWidth - primaryScreenHeight) / 2 + primaryScreenHeight / 6;
            int pictureBoxesLocationHeight = primaryScreenHeight / 4;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pictureBoxes[i, j] = new PictureBox
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = false,
                        Size = new System.Drawing.Size(pictureBoxSize, pictureBoxSize),
                        Location = new System.Drawing.Point(pictureBoxesLocationWidth + j * (pictureBoxSize + primaryScreenHeight / 30), pictureBoxesLocationHeight + i * (pictureBoxSize + primaryScreenHeight / 30)),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Enabled = false,
                        //BackColor = System.Drawing.Color.Transparent
                    };
                    mainForm.Controls.Add(pictureBoxes[i, j]);
                }
            }  //初始化pictureBox

            

            switch (Properties.Settings.Default.backgroundImageIndex)
            {
                case 0:
                    mainForm.BackgroundImage = Properties.Resources.backgroundImage1;
                    break;
                case 1:
                    mainForm.BackgroundImage = Properties.Resources.backgroundImage2;
                    break;
            }

            Start();

            Application.Run(mainForm);
            Console.Read();
        }

        /// <summary>
        /// 游戏初始化
        /// </summary>
        public static void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    num[i, j] = 0;
                    lastNum[i, j] = 0;
                }
            }  //初始化数组变量

            time = 0;             //初始化计分计时
            score = 0;

            num = SetNewNum(num);  //放置开始的两个点
            num = SetNewNum(num);
            //num = SetMyNum();            //去掉注释以调试程序

            lastNum = CopyToB(num);
            mainForm.SetGameArea(num);
        }

        /// <summary>
        /// 用于调试时手动设置初始值
        /// </summary>
        /// <returns>手动设置的数组</returns>
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
        }  

        /// <summary>
        /// 表示一个二维数组中的位置
        /// </summary>
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

        /// <summary>
        /// 放置随机数字
        /// </summary>
        /// <param name="a">要放置数字的数组</param>
        /// <returns>放置好数字的数组</returns>
        public static short[,] SetNewNum(short[,] a)
        {
            Point rp = RandomPoint(a);
            if (rp != null)
                a[rp.X, rp.Y] = 2;
            return a;
        }

        /// <summary>
        /// 查找返回随机空位置
        /// </summary>
        /// <param name="a">要查找的数组</param>
        /// <returns>找到的随机空位置</returns>
        public static Point RandomPoint(short[,] a)
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

        /// <summary>
        /// 复制一个数组
        /// </summary>
        /// <param name="a">要复制的数组</param>
        /// <returns>复制出的数组</returns>
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

        /// <summary>
        /// 旋转一个二维数组
        /// </summary>
        /// <param name="a">要旋转的数组</param>
        /// <param name="rotNum">顺时针旋转圈数</param>
        /// <returns>旋转后的数组</returns>
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
        } 

        /// <summary>
        /// 游戏逻辑向左合并
        /// </summary>
        /// <param name="a">要操作的数组</param>
        /// <returns>操作后的数组</returns>
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
                            score += a[i, j] + a[i, last_j];
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
        }  

        /// <summary>
        /// 判断两个数组是否相等
        /// </summary>
        /// <param name="a">第一个数组</param>
        /// <param name="b">第二个数组</param>
        /// <returns>是否相等</returns>
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
        }  

        /// <summary>
        /// 游戏逻辑判断是否可以移动
        /// </summary>
        /// <param name="a">要判断的数组</param>
        /// <returns>是否可以移动</returns>
        public static bool CanMove(short[,] a)
        {
            int s = score;
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
            score = s;
            return res;
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
