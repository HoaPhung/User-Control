using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Control
{
    public partial class Form1 : Form
    {
        int mm, ss;
        int timeStop = 0;
        public Form1()
        {
            InitializeComponent();
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnResume.Enabled = false;
            this.digitalClock.SetTime += DigitalClock_SetTime;
            
        }

        private void DigitalClock_SetTime(int time)
        {
            if (time == timeStop)
            {
                Application.Exit();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            digitalClock.Start();
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnResume.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            digitalClock.Stop();
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnResume.Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            digitalClock.Pause();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnResume.Enabled = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            digitalClock.Resume();
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

       

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnResume.Enabled = false;

            String tempM = numberM.Value.ToString();
            String tempS = numberS.Value.ToString();
            //int mm, ss;
            Int32.TryParse(tempM, out mm);
            Int32.TryParse(tempS, out ss);
            timeStop = mm * 30 + ss;
        }
    }
}
