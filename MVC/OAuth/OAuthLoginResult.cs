using Microsoft.Web.WebPages.OAuth;
using System.Web.Mvc;

namespace LabOfClouds.Library.MVC.OAuth
{
    public class OAuthLoginResult : ActionResult
    {
        public OAuthLoginResult(string provider, string returnUrl)
        {
            Provider = provider;
            ReturnUrl = returnUrl;
        }

        public string Provider { get; private set; }
        public string ReturnUrl { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
        }
    }
}