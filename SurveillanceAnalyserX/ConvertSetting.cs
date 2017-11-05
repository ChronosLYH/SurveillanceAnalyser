using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveillanceAnalyserX
{
    public partial class ConvertSetting : Form
    {
        public bool confirmed = false;
        public ConvertSetting()
        {
            InitializeComponent();
            textBox1.Text = VideoHandler.FramePerSecond.ToString();
            textBox2.Text = Form1.ImgSavePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoHandler.FramePerSecond = Convert.ToDouble(textBox1.Text);
            Form1.ImgSavePath = textBox2.Text;
            confirmed = true;
            this.Close();
        }
    }
}
