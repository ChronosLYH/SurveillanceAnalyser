using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SurveillanceAnalyserX
{
    struct Data
    {
        public string Age;
        public string Gender;
        public int FrameId;
    }
    class TextHandler
    {
        
        public static List<string> BreakIntoCodes(string data)
        {
            List<string> toReturn = new List<string>();
            string pattern = @"[^\s]+";
            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                toReturn.Add(match.Value);
            }
            return toReturn;
        }
        public static Data ParseJson(string json,int time)
        {
            Data toReturn = new Data();
            string pattern_age = "(age\":)([\\d]+)";
            Match match = Regex.Match(json, pattern_age);
            toReturn.Age = match.Groups[2].Value;
            string pattern_gender = "(gender\":\")([\\w]+)";
            match = Regex.Match(json, pattern_gender);
            toReturn.Gender = match.Groups[2].Value;
            toReturn.FrameId = time;
            return toReturn;
        }
        public static List<string> Flatten(List<Data> datalist)
        {
            List<string> toReturn = new List<string>();
            foreach(Data data in datalist)
            {
                string s = Flatten(data);
                toReturn.Add(s);
            }
            return toReturn;
        }
        public static string Flatten(Data data)
        {
            return data.Gender + " Age:" + data.Age + " FrameId:" + data.FrameId;
        }


    }
}
