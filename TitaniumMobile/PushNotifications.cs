using System.Net;
using RestSharp;
using System.Configuration;

namespace LabOfClouds.Library.TitaniumMobile
{
    public class PushNotifications
    {
        public string ApiKey { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        private RestClient _restClient;
        private IRestRequest _restRequest;

        public PushNotifications()
        {
            ApiKey = ConfigurationManager.AppSettings["ti.apiKey"];
            User = ConfigurationManager.AppSettings["ti.user"];
            Password = ConfigurationManager.AppSettings["ti.password"];

            Login();
        }

        #region Private Methods

        private void Login()
        {
            _restClient = new RestClient("https://api.cloud.appcelerator.com")
            {
                CookieContainer = new CookieContainer()
            };

            _restRequest = new RestRequest("/v1/users/login.json?key={appkey}", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            _restRequest.AddUrlSegment("appkey", ApiKey);
            _restRequest.AddBody(new
            {
                login = User,
                password = Password
            });

            _restClient.Execute(_restRequest);
        }

        #endregion

        #region Public Methods

        public void SendPush(string channel, string title, string message, string ids = "everyone")
        {
            _restClient.BaseUrl = "https://api.cloud.appcelerator.com";
            _restRequest.Resource = "/v1/push_notification/notify.json?key={appkey}";
            _restRequest.Method = Method.POST;
            _restRequest.AddUrlSegment("appkey", ApiKey);

            _restRequest.AddParameter("channel", channel);
            _restRequest.AddParameter("to_ids", ids);
            _restRequest.AddParameter("payload", "{ \"title\" : \"" + title + "\",\"vibrate\":true, \"alert\" : \"" + message + "\", \"sound\" : \"default\"}");
            _restClient.Execute(_restRequest);
        }

        #endregion
    }
}