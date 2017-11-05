using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Markup;
using System.Threading;
using System.Configuration;

namespace SurveillanceAnalyserX
{
    public partial class Form1 : Form
    {
        public static string ImgSavePath { get; set; } = ConfigurationManager.AppSettings["ImgSavePath"];
        public static bool DetectFace { get; set; } = false;
        public static bool SaveFace { get; set; } = false;
        public static string SaveFacePath { get; set; } = "";

        public Form1()
        {
            this.AutoScaleMode =  AutoScaleMode.Font;

            //设定字体大小为12px       

            this.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));

            InitializeComponent();
            axWindowsMediaPlayer2.settings.autoStart = false;
            BlockList.Click += new EventHandler(listBox1_Click);
            PersonList.Click += new EventHandler(listBox2_Click);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vFileNameTextBox.Text = dialog.FileName;
            }
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            ConvertSetting form = new ConvertSetting();
            form.FormClosing += new FormClosingEventHandler((s, e1) => {
                if(form.confirmed)
                {
                    VideoHandler.CatchImg(vFileNameTextBox.Text, ImgSavePath);
                }              
            });
            form.Show();

            
        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {
            
        }
        private void LoadList_Box1(List<string> frameList)
        {
            List<string> marks = new List<string>();
            string prev_frame = "000001";
            for(int i=0;i<frameList.Count;i++)
            {
                if(Convert.ToInt32(frameList[i])-Convert.ToInt32(prev_frame)>=2*VideoHandler.FramePerSecond)
                {
                    marks.Add(frameList[i]);
                }
                prev_frame = frameList[i];
            }

            BlockList.Items.Clear();
            BlockList.Items.Add("000001");
            int j = 0;
            foreach(string s in frameList)
            {
                if(j<marks.Count && s==marks[j])
                {
                    string s_mark= s+ " !";
                    BlockList.Items.Add(s_mark);
                    j++;
                }
                else
                {
                    BlockList.Items.Add(s);
                }
                
            }
        }
        private void LoadList_Box2(List<string> frameList)
        {
            PersonList.Items.Clear();
            foreach (string s in frameList)
            {
                PersonList.Items.Add(s);
            }
        }
        private void listBox1_Click (object sender, EventArgs e)
        {
            if(BlockList.SelectedItem==null)
            {
                return;
            }
            string frame = BlockList.SelectedItem.ToString().Substring(0,6);
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition=Convert.ToDouble(frame)/VideoHandler.FramePerSecond-0.5;
        }
        private void listBox2_Click(object sender, EventArgs e)
        {
            if (PersonList.SelectedItem == null)
            {
                return;
            }
            string flatdata = PersonList.SelectedItem.ToString();
            string frame = flatdata.Substring(flatdata.LastIndexOf(':') + 1);
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = Convert.ToDouble(frame) / VideoHandler.FramePerSecond-0.5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnalyseSetting form = new AnalyseSetting();
            form.FormClosing += new FormClosingEventHandler(async (s,e1) =>
            {
                if (form.confirmed==true)
                {
                    
                    if (new DirectoryInfo(ImgSavePath).GetFiles().Length == 0)
                    {
                        MessageBox.Show("未转换");
                        return;
                    }
                    File.Delete("temporary.dat");
                    VideoHandler.ReduceImg(ImgSavePath);
                    while (File.Exists("temporary.dat") == false)
                    {
                        Thread.Sleep(1000);
                    }
                    string data = File.ReadAllText("temporary.dat");
                    File.Delete("temporary.dat");
                    List<string> list = TextHandler.BreakIntoCodes(data);
                    LoadList_Box1(list);
                    bool prev_exists = false;
                    List<Data> datalist = new List<Data>();
                    if (DetectFace)
                    {
                        foreach (string code in list)
                        {
                            string filename = code + ".jpg";
                            string path = ImgSavePath + "/" + filename;
                            string json = await APIRequest.MakeRequest(path);
                            Console.WriteLine(json);
                            Data result = TextHandler.ParseJson(json, Convert.ToInt32(code));
                            if (result.Age != "" && prev_exists == false)
                            {
                                datalist.Add(result);
                                prev_exists = true;
                            }
                            else if (result.Age == "")
                            {
                                prev_exists = false;
                            }
                        }
                    }
                    LoadList_Box2(TextHandler.Flatten(datalist));
                    if (SaveFace)
                    {
                        foreach (Data d in datalist)
                        {
                            string frompath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + Form1.ImgSavePath + "\\" + d.FrameId.ToString().PadLeft(6, '0') + ".jpg";
                            string topath = SaveFacePath + "\\" + d.Gender + "age" + d.Age + "f" + d.FrameId + ".jpg";
                            Console.WriteLine("from:" + frompath);
                            Console.WriteLine("to:" + topath);
                            File.Copy(frompath, topath,true);
                        }
                    }
                    MessageBox.Show("分析完成");
                }
            });
            form.Show();
        }

        private void vFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(vFileNameTextBox.Text!="")
            {
                axWindowsMediaPlayer2.URL = vFileNameTextBox.Text;
                ConvertBtn.Enabled = true;
                AnalyseBtn.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.Show();
        }
    }
}
