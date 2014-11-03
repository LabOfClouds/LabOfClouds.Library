using System.Web;

namespace LabOfClouds.Library.MVC.Security
{
    public static class SessionInfo
    {
        public static T User<T>()
        {
            var user = (T)HttpContext.Current.Session["User"];

            if (user == null)
            {
                HttpContext.Current.Response.Redirect("~/Session/Logout");
            }

            return user;
        }

        public static void SetUser<T>(T user)
        {
            HttpContext.Current.Session["User"] = user;
        }
    }
}