using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reppt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        selectpage.Text = Request.QueryString["ppt"];
        ppt();
    }
    private void ppt()
    {
        ckppt.Src = "http://192.192.155.110/img/" + selectpage.Text + ".png";
    }
}