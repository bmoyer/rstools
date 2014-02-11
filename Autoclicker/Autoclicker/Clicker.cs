using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsInput;
using System.Runtime.InteropServices;
using System.IO;

namespace Autoclicker
{
    class Clicker
    {
        //[DllImport("InputSimulator.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        double interval;
        double baseInterval;
        bool randomize;
        int fuzzStrength;
        Timer timer = new Timer();


        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            /*
            TextWriter tw = new StreamWriter("fuzztest.txt",true);

            tw.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);

            // close the stream
            tw.Close();*/


        }

        public Clicker(double i, bool r, int s)
        {
            randomize = r;
            interval = Math.Round(i, 3);
            fuzzStrength = s;



            timer.Interval = Convert.ToInt32(1000 * interval);
            baseInterval = timer.Interval;
            timer.Tick += timer_Tick;

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.randomize)
            {

                timer.Interval = Convert.ToInt32(baseInterval + (randomizeClicks(fuzzStrength) * 1000));

            }

            LeftClick(Cursor.Position.X, Cursor.Position.Y);


            Form1 f = Application.OpenForms[0] as Form1;
            f.changeTimeDisplay(timer.Interval);
            
        }

        public void Start(object sender, EventArgs e)
        {
            timer.Enabled = true;

        }

        public void Stop(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        public double randomizeClicks(int f)
        {
            Random random = new Random();

            int fuzzStrength = f;

            int randomNumber = random.Next(-1 * fuzzStrength, fuzzStrength);
            double dec = randomNumber * .01;

            return dec;

        }

        public void updateTimeDisplay(Form1 owner)
        {
            owner.changeTimeDisplay(timer.Interval);

        }
    }
}
