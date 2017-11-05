using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;



namespace SurveillanceAnalyserX
{
    class VideoHandler
    {
        public static string FFMPEG { get; set; } = ConfigurationManager.AppSettings["FFMPEG"];
        public static string ImgReducer { get; set; } = ConfigurationManager.AppSettings["ImgReducer"];
        public static double FramePerSecond { get; set; } = Convert.ToDouble( ConfigurationManager.AppSettings["FramePerSecond"]);
        public static string Threshhold { get; set; } = ConfigurationManager.AppSettings["Threshhold"];


        public static string GetVideoName(string vFileName)
        {
            string toReturn = "";
            for(int i=0;i<vFileName.Length&&vFileName[i]!='.'; i++)
            {
                toReturn += vFileName[i];
            }
            return toReturn;
        }
        public static void CatchImg(string vFileName,string ImgSavePath)
        {
            if (Directory.Exists(ImgSavePath) == false)
            {
                Directory.CreateDirectory(ImgSavePath);
            }
            else
            {
                Console.WriteLine("覆盖" + ImgSavePath + "中的文件");
                foreach(var file in new DirectoryInfo(ImgSavePath).GetFiles())
                {
                    file.Delete();
                }
            }
            try
            {
                if(File.Exists(FFMPEG)==false)
                {
                    throw new Exception("FFMPEG不存在");
                }
                if(File.Exists(vFileName)==false)
                {
                    throw new Exception("视频不存在");
                }
                string Command = " -i " + vFileName + " -r " + FramePerSecond + " -q:v 2 " + ImgSavePath+"/%06d.jpg";
                //Console.WriteLine("ffmpeg " + Command);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = FFMPEG;
                p.StartInfo.Arguments = Command;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                p.Start();
                p.Close();
                p.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ReduceImg(string ImgSavePath)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = ImgReducer;
            p.StartInfo.Arguments = new DirectoryInfo(ImgSavePath).GetFiles().Length+" "+ ImgSavePath+" "+Threshhold;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            p.Start();
            p.Close();
            p.Dispose();
        }
        
    }
}
