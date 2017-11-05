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
    public partial class AnalyseSetting : Form
    {
        public bool confirmed = false;
        public AnalyseSetting()
        {
            InitializeComponent();
            textBox1.Text = VideoHandler.Threshhold;
            textBox2.Text = Form1.SaveFacePath;
            checkBox1.Checked = Form1.DetectFace;
            checkBox2.Checked = Form1.SaveFace;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = dialog.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoHandler.Threshhold = textBox1.Text;
            Form1.SaveFacePath = textBox2.Text;
            Form1.DetectFace = checkBox1.Checked;
            Form1.SaveFace = checkBox2.Checked;
            confirmed = true;
            this.Close();
        }
    }
}
