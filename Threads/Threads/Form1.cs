using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Threads
{
    public partial class Form1 : Form
    {
        static Mutex mutex = new Mutex();
        static DateTime today =new DateTime();
        int h, m, s;
        static string currents, currentm, currenth;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            Thread Threads = new Thread(Update_Seconds);
            InitializeComponent();
            timer.Start();
            timer.Interval = 100;
            timer.Tick += new EventHandler(StartThreads);
            timer.Tick += new EventHandler(Update_Time);


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

            public void Update_Seconds() {
            mutex.WaitOne();
            today = DateTime.Now;
            s = today.Second;
            if (s > 10)
            {
                currents = Convert.ToString(s);
            }
            else
            {
                currents = "0" + Convert.ToString(s);
            }
            Thread.Sleep(100);
            mutex.ReleaseMutex();

        }
        public void StartThreads(object sender, EventArgs e)
            {
            Thread Threads = new Thread(Update_Seconds);
            Thread Threadm = new Thread(Update_Minutes);
            Thread Threadh = new Thread(Update_Hours);
            Threads.Start();
            Threadm.Start();
            Threadh.Start();
        }
        public void Update_Minutes()
        {
            mutex.WaitOne();
            today = DateTime.Now;
            m = today.Minute;
            if (m > 10)
            {
                currentm = Convert.ToString(m);
            }
            else
            {
                currentm = "0" + Convert.ToString(m);
            }
            Thread.Sleep(100);
            mutex.ReleaseMutex();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        public void Update_Hours()
        {
            mutex.WaitOne();
            today = DateTime.Now;
            h = today.Hour;
            if (h > 10)
            {
                currenth = Convert.ToString(h);
            }
            else
            {
                currenth = "0" + Convert.ToString(h);
            }
            Thread.Sleep(100);
            mutex.ReleaseMutex();
        }
        public void Update_Time(object sender, EventArgs e) {
            label1.Text = currenth;
            label2.Text = currentm;
            label3.Text = currents;
        }
            private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
