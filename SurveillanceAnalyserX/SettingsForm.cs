using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SurveillanceAnalyserX
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            textBox1.Text = VideoHandler.FFMPEG;
            textBox2.Text = VideoHandler.ImgReducer;
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoHandler.FFMPEG = textBox1.Text;
            VideoHandler.ImgReducer = textBox2.Text;
            
            
            this.Close();
        }
    }
}
