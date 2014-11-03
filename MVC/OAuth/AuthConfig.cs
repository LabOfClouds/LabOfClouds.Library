using Microsoft.Web.WebPages.OAuth;

namespace LabOfClouds.Library.MVC.OAuth
{
    public static class AuthConfig
    {
        public static void RegisterAuth(OAuthInfos infos)
        {
            if(infos.FacebookAuth != null)
                OAuthWebSecurity.RegisterFacebookClient(infos.FacebookAuth.AppId, infos.FacebookAuth.AppSecret);

            if (infos.TwitterAuth != null)
                OAuthWebSecurity.RegisterTwitterClient(infos.TwitterAuth.ConsumerKey, infos.TwitterAuth.ConsumerSecret);

            if (infos.GoogleAuth != null)
                OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}