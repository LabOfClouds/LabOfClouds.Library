using System.Collections.Generic;

namespace LabOfClouds.Library.Social
{
    public class Facebook
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public Facebook(string apiKey, string apiSecret)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        public int CountPageLikes(string pageName)
        {
            int count = 0;
            string url = "https://graph.facebook.com/" + pageName;

            try
            {
                string jsonString = new System.Net.WebClient().DownloadString(url);
                var obj1 = new System.Web.Script.Serialization.JavaScriptSerializer();
                var objDic = (Dictionary<string, object>)obj1.Deserialize<object>(jsonString);

                object value;
                bool success = objDic.TryGetValue("likes", out value);

                if (success)
                    count = (int)value;
            }
            catch
            {
                
            }

            return count;
        }
    }
}