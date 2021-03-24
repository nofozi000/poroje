using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace project
{
    class ClassCaptcha
    {
        private static string code;
        private static Random rnd = new Random();
        //create a captcha image method
        public static Image createImage()
        {
            code = randomText();
            Bitmap bitmap = new Bitmap(120, 120, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, 120, 120);
            SolidBrush back = new SolidBrush(Color.LightGray);
            SolidBrush front = new SolidBrush(Color.FromArgb
            (rnd.Next(50, 200),
            rnd.Next(50, 200),
            rnd.Next(50, 200)));
            int counter = 0;
            g.DrawRectangle(pen, rect);
            g.FillRectangle(back, rect);
            string[] fontList = { "Chumbly BRK", "Choktoff", "Coaster", "Cloister Black" };
            for (int i = 0; i < code.Length; i++)
            {
                //g.DrawString(code[i].ToString(),
                //    new Font("Georgia", 10 + rand.Next(14, 18)),
                //    White, new PointF(10 + counter, 10));
                g.DrawString(code[i].ToString(),
                    new Font(fontList[rnd.Next(0, 4)], 10 + rnd.Next(5, 15)),
                    front, new PointF(20 + counter, rnd.Next(15, 100)));
                counter += 20;
            }
            int num = rnd.Next(1, 4);
            randomShapes(g, num);
            g.Dispose();
            return bitmap;
        }
        //create random text
        public static string randomText()
        {
            StringBuilder rndstring = new StringBuilder();
            string smallAlpha = "abcdefghijklmnopqrstuvwxyz";
            string bigAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "1234567890";
            string all = smallAlpha + bigAlpha + numbers;
            rndstring.Append(smallAlpha[rnd.Next(smallAlpha.Length)]);
            rndstring.Append(bigAlpha[rnd.Next(bigAlpha.Length)]);
            rndstring.Append(numbers[rnd.Next(numbers.Length)]);
            rndstring.Append(all[rnd.Next(all.Length)]);
            code = rndstring.ToString();
            return code;
        }
        //find random points
        private static Point[] randompoint()
        {
            Point[] point = { new Point(rnd.Next(10, 100), rnd.Next(10, 100)),
                              new Point(rnd.Next(10, 100), rnd.Next(10, 100))};
            return point;
        }
        //make random shapes
        private static void randomShapes(Graphics g, int num)
        {
            switch (num)
            {
                case 1:
                    {

                        SolidBrush shapeColor = new SolidBrush(Color.FromArgb
                        (rnd.Next(50, 200),
                        rnd.Next(50, 200),
                        rnd.Next(50, 200)));

                        g.DrawLines(new Pen(shapeColor, 2), randompoint());
                        break;
                    }
                case 2:
                    {
                        SolidBrush shapeColor = new SolidBrush(Color.FromArgb
                        (rnd.Next(50, 200),
                        rnd.Next(50, 200),
                        rnd.Next(50, 200)));

                        g.DrawRectangle(new Pen(shapeColor, 2),
                                        new Rectangle(rnd.Next(10, 100), rnd.Next(10, 100),
                                                     rnd.Next(10, 100), rnd.Next(10, 100)));
                        break;
                    }
                case 3:
                    {
                        SolidBrush shapeColor = new SolidBrush(Color.FromArgb
                        (rnd.Next(50, 200),
                        rnd.Next(50, 200),
                        rnd.Next(50, 200)));

                        int redius = rnd.Next(5, 15);
                        g.DrawEllipse(new Pen(shapeColor, 2), rnd.Next(10, 100) - redius,
                            rnd.Next(10, 100) - redius, rnd.Next(10, 100) + redius,
                            rnd.Next(10, 100) + redius);
                        break;
                    }

                default:
                    break;
            }
        }
        public static bool validate(string input)
        {
            if (code.Equals(input))
            {
                return true;
            }
            return false;
        }
    }
}
