using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class DigitalClock : UserControl
    {
        //delegate và event
        public delegate void MyProcess(int time);
        public event MyProcess SetTime;

        private int m;
        private int s;

        private int time=0;

        public void setM(int mm)
        {
            this.m = mm;
        }

        public void setS(int ss)
        {
            this.s = ss;
        }

        public int getM()
        {
            return this.m;
        }

        public int getS()
        {
            return this.s;
        }
        public DigitalClock()
        {
            InitializeComponent();
            time = 0;
        }

       

        public void changePicture(PictureBox temp, int index)
        {
            switch (index)
            {
                case 0:
                    temp.Image = User_Control.Properties.Resources._0;
                    break;
                case 1:
                    temp.Image = User_Control.Properties.Resources._1;
                    break;
                case 2:
                    temp.Image = User_Control.Properties.Resources._2;
                    break;
                case 3:
                    temp.Image = User_Control.Properties.Resources._3;
                    break;
                case 4:
                    temp.Image = User_Control.Properties.Resources._4;
                    break;
                case 5:
                    temp.Image = User_Control.Properties.Resources._5;
                    break;
                case 6:
                    temp.Image = User_Control.Properties.Resources._6;
                    break;
                case 7:
                    temp.Image = User_Control.Properties.Resources._7;
                    break;
                case 8:
                    temp.Image = User_Control.Properties.Resources._8;
                    break;
                case 9:
                    temp.Image = User_Control.Properties.Resources._9;
                    break;
            }
            temp.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time += 1;
            int m1=0, m2=0, s1=0, s2=0;
            int x = time % 60;
            int y = time / 60;
            s2 = x % 10;
            s1 = x / 10;
            m2 = y % 10;
            m1 = y / 10;
            changePicture(pictureBox1, m1);
            changePicture(pictureBox2, m2);
            changePicture(pictureBox4, s1);
            changePicture(pictureBox5, s2);

            SetTime(time);
        }

        public void Start()
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
                time = 0;
                changePicture(pictureBox1, 0);
                changePicture(pictureBox2, 0);
                changePicture(pictureBox4, 0);
                changePicture(pictureBox5, 0);
            }
                
            timer.Enabled = true;
        }

        public void Stop()
        {
            time = 0;
            
            changePicture(pictureBox1, 0);
            changePicture(pictureBox2, 0);
            changePicture(pictureBox4, 0);
            changePicture(pictureBox5, 0);
            timer.Enabled = false;
        }

        public void Pause()
        {
            timer.Enabled = false;
        }

        public void Resume()
        {
            time += 1;
            int m1 = 0, m2 = 0, s1 = 0, s2 = 0;
            int x = time % 60;
            int y = time / 60;
            s2 = x % 10;
            s1 = x / 10;
            m2 = y % 10;
            m1 = y / 10;
            changePicture(pictureBox1, m1);
            changePicture(pictureBox2, m2);
            changePicture(pictureBox4, s1);
            changePicture(pictureBox5, s2);
            timer.Enabled = true;
        }

    }
}
