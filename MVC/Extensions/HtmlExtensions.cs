namespace System.Web.Mvc.Html
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ActionValidationSummary(this HtmlHelper html, string action)
        {
            string currentAction = html.ViewContext.RouteData.Values["action"].ToString();

            if (currentAction.ToLower() == action.ToLower())
                return html.ValidationSummary();

            return new MvcHtmlString("<div class=\"validation-summary-valid\" data-valmsg-summary=\"true\"><ul><li style=\"display:none\"></li></ul></div>");
        }
    }
}