using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektZaliczeniowy_JIPP4
{
    class Zegar
    {
        public Timer time = new Timer();

        public int WIDTH = 300;
        public int HEIGHT = 300;
        public int secondHand = 140;
        public int minuteHand = 110;
        public int hourHand = 80;

        public int positionX, positionY;

        public Bitmap bitmap;
        public Graphics graphics;


        public int[] miunuteCrood(int valueMinute, int rotation)
        {
            int[] crood = new int[2];
            valueMinute *= 6; //obrót co minutę o 6 stopni

            if (valueMinute >= 0 && valueMinute <= 180)
            {
                crood[0] = positionX + (int)(rotation * Math.Sin(Math.PI * valueMinute / 180));
                crood[1] = positionY - (int)(rotation * Math.Cos(Math.PI * valueMinute / 180));
            }
            else
            {
                crood[0] = positionX - (int)(rotation * -Math.Sin(Math.PI * valueMinute / 180));
                crood[1] = positionY - (int)(rotation * Math.Cos(Math.PI * valueMinute / 180));
            }

            return crood;
        }

        public int[] hourCrood(int valueHour, int valueMinute, int rotation)
        {
            int[] crood = new int[2];

            //kazda godzina robi obrót o 30 stopni
            //kazda minuta robi obrot o 0.5 stopnia
            int value = (int)((valueHour * 30) + (valueMinute * 0.5));

            if (value >= 0 && value <= 180)
            {
                crood[0] = positionX + (int)(rotation * Math.Sin(Math.PI * value / 180));
                crood[1] = positionY - (int)(rotation * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                crood[0] = positionX - (int)(rotation * -Math.Sin(Math.PI * value / 180));
                crood[1] = positionY - (int)(rotation * Math.Cos(Math.PI * value / 180));
            }

            return crood;
        }

        public void analogClock()
        {
            graphics = Graphics.FromImage(bitmap);

            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handCrood = new int[2];

            graphics.Clear(Color.DarkGray);

            graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

            handCrood = miunuteCrood(ss, secondHand);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(positionX, positionY), new Point(handCrood[0], handCrood[1]));

            handCrood = miunuteCrood(mm, minuteHand);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(positionX, positionY), new Point(handCrood[0], handCrood[1]));

            handCrood = hourCrood(hh % 12, mm, hourHand);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(positionX, positionY), new Point(handCrood[0], handCrood[1]));

        }
    }

}
