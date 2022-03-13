using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name;
        name = Session["name"].ToString();

        if (Session["name"].ToString() == "學生登入")
        {
            Label3.Text = Session["StudentID"].ToString();
            Label1.Text = Session["StudentName"].ToString();
            Label2.Text = Session["School"].ToString();
        }
        else if (Session["name"].ToString() == "教師登入")
        {
            Label3.Text = Session["TeacherID"].ToString();
            Label1.Text = Session["TeacherName"].ToString();
            Label2.Text = Session["School"].ToString();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("password.aspx");
    }
}