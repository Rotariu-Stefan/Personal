using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Threading;

namespace Playa
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer pl;
        bool playin;
        int time;

        public Form1()
        {
            InitializeComponent();
            pl = new WindowsMediaPlayer();
            playin = false;
            progressBar1.Value = 0;
            time = 0;
        }

        private void bopen_Click(object sender, EventArgs e)
        {
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                pl.URL = ofDialog.FileName;
                lsname.Text = System.IO.Path.GetFileNameWithoutExtension(ofDialog.FileName);
                pl.settings.volume = 50;
                pl.controls.play();
                playin = true;
                bplay.Text = "pause";

                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        private void bplay_Click(object sender, EventArgs e)
        {
            if (playin)
            {
                pl.controls.pause();
                bplay.Text = "play";
                playin = false;
                timer1.Stop();
            }
            else
            {
                pl.controls.play();
                bplay.Text = "pause";
                playin = true;
                timer1.Start();
            }
        }

        private void bstop_Click(object sender, EventArgs e)
        {
            pl.controls.stop();
            bplay.Text = "play";
            playin = false;
            timer1.Stop();
            progressBar1.Value = 0;
            ltime.Text = "00:00";
        }

        private void progressBar1_MouseClick(object sender, MouseEventArgs e)
        {
            progressBar1.Value = (int)((double)(e.X - 12) / 440 * time);
            pl.controls.currentPosition = progressBar1.Value;
            ltime.Text = (progressBar1.Value / 60).ToString() + ":" + (progressBar1.Value % 60).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                time = (int)pl.currentMedia.duration;
                progressBar1.Maximum = time + 1;
            }
            else
            {
                progressBar1.Value++;
                ltime.Text = (progressBar1.Value / 60).ToString() + ":" + (progressBar1.Value % 60).ToString();
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    bstop_Click(this, new EventArgs());
                    if (chrepeat.Checked == true)
                        bplay_Click(this, new EventArgs());
                }
            }
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pl.settings.volume = tvolume.Value * 10;
        }
    }
}
