using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Http
{
    public class HttpUtils
    {
        public Byte[] Parameters { get; private set; }
        public String Url { get; private set; }

        public HttpUtils(Dictionary<String, String> parameters, String url)
        {
            Parameters = CreatePost(parameters);
            Url = url;
        }

        public byte[] CreatePost(Dictionary<String, String> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return null;

            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters)
                sb.Append(item.Key + "=" + item.Value + "&");

            return new ASCIIEncoding().GetBytes(sb.Remove(sb.Length-1,1).ToString());
        }
        /// <summary>
        /// Retourne un élément XMl
        /// </summary>
        /// <returns></returns>
        public String SendRequest()
        {
            HttpWebRequest httpWReq =
                (HttpWebRequest)WebRequest.Create(Url);

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = Parameters.Length;

            using (Stream stream = httpWReq.GetRequestStream())
                stream.Write(Parameters, 0, Parameters.Length);

            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

    }
}
