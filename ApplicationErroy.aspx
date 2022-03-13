private void DealErroy()
{
HttpException erroy = new HttpException();
string strCode = erroy.ErrorCode.ToString();
string strMsg = erroy.Message;
erroy.HelpLink = "sss";
Response.Write("ErrorCode:" + strCode + "<br>");
Response.Write("Message:" + strMsg + "<br>");
Response.Write("HelpLink:" + erroy.HelpLink + "<br>");
Response.Write("Source:" + erroy.Source + "<br>");
Response.Write("TargetSite:" + erroy.TargetSite + "<br>");
Response.Write("InnerException:" + erroy.InnerException + "<br>");
Response.Write("StackTrace:" + erroy.StackTrace + "<br>");
Response.Write("GetHtmlErrorMessage:" + erroy.GetHtmlErrorMessage() + "<br>");
Response.Write("erroy.GetHttpCode().ToString():" + erroy.GetHttpCode().ToString() +"<br>");

Response.Write("erroy.Data.ToString()::" + erroy.Data.ToString() + "<br>");
}