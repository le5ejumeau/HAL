using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Http
{
    public static class HttpUtils
    {

        public static void SendRequest()
        {
            HttpWebRequest httpWReq =
                (HttpWebRequest)WebRequest.Create("http://domain.com/page.aspx");

          
            string postData = "username=user";
            postData += "&password=pass";
            byte[] data = new ASCIIEncoding().GetBytes(postData);

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;

            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

    }
}
