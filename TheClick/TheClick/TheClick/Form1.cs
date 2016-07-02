using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TheClick
{
    public partial class Form1 : Form
    {
        Point mousePoint = new Point();
        Point ClickPoint = new Point();
        Random rnd = new Random();

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            //mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = Cursor.Position.ToString();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (Timer.Enabled == false)
            {
                Timer.Start();
                mousePoint = MousePosition;
            }

            else
            {
                Timer.Stop();
                this.Close();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            ClickPoint.X = mousePoint.X + (rnd.Next(0, 10));
            ClickPoint.Y = mousePoint.Y + (rnd.Next(0, 10));
            Cursor.Position = ClickPoint;
            DoMouseClick();
        }

    }
}
