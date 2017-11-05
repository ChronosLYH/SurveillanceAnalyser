using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.IO;

namespace SurveillanceAnalyserX
{
    class APIRequest
    {
        public static async Task<string> MakeRequest(string imagePath)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "114e8d312be84ba3905abf34638e78f7");

            // Request parameters
            queryString["visualFeatures"] = "Faces";
            //queryString["details"] = "";
            queryString["language"] = "en";
            var uri = "https://api.cognitive.azure.cn/vision/v1.0/analyze?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = ImageToBinary(imagePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }
            return await response.Content.ReadAsStringAsync();

        }
        private static byte[] ImageToBinary(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            return byData;
        }
        private static string StreamToString(Stream fs)
        {
            StreamReader ser = new StreamReader(fs, Encoding.Default);
            return ser.ReadToEnd();
        }
    }
}
