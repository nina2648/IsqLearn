using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class password : System.Web.UI.Page
{
    SqlConnection myConn = new SqlConnection(@"Data Source=192.192.155.110;Initial Catalog=ilearn;Persist Security Info=True;User ID=ilearn;Password=aft193;");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (pwd1.Text.Trim() == pwd2.Text.Trim())
        {
            DataTable dt = new DataTable();
            pass.Text = Session["Password"].ToString();

            if (dt.Rows.Count == 0)
            {

                myConn.Open();

                String strSQL = "UPDATE studentinfo SET Password='" + pwd1.Text + "' WHERE Password='" + pass.Text + "'";
                SqlCommand sqlCmm = new SqlCommand(strSQL, myConn);
                sqlCmm.Parameters.Add("@Password", SqlDbType.VarChar).Value = Session["Password"].ToString();
                //SqlCommand cmdLiming = new SqlCommand(strSQL, myConn);
                sqlCmm.ExecuteNonQuery();
                SqlDataAdapter oleda = new SqlDataAdapter("SELECT * FROM studentinfo", myConn);
                DataSet ds = new DataSet("ds_studentinfo");
                oleda.Fill(ds, "ds_studentinfo");
                new SqlDataAdapter(sqlCmm).Fill(ds);
                Response.Write("< script > alert(‘修改成功’) </ script >");
                Response.Redirect("Account.aspx");
            }
            else
            {
                pwd2.Text = "";
                pass.Text = "";
                Page.ClientScript.RegisterStartupScript(GetType(), "CallShowAlert", "ShowAlert(\"請重新輸入帳號密碼\",\"warning\");", true);
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "CallShowAlert", "ShowAlert(\"請檢查密碼是否一致\",\"warning\");", true);
        }



        /*if (TextBox1.Text.Trim() == TextBox2.Text.Trim())
        {
            DataTable dt = new DataTable();
            pass.Text = Session["Password"].ToString();

            if (dt.Rows.Count > 0)
            {
                string newpwd = TextBox1.Text.Trim();
                DataTable Adt = new DataTable();
                string newpass = TextBox2.Text.Trim();
                SqlCommand sqlCmm = new SqlCommand();
                sqlCmm = new SqlCommand("Update studentinfo SET Password=@userpass  Where Password=@Password", myConn);
                sqlCmm.Parameters.Add("@userpass", SqlDbType.VarChar).Value = newpass;
                sqlCmm.Parameters.Add("@sha", SqlDbType.VarChar).Value = newpwd;
                sqlCmm.Parameters.Add("@Password", SqlDbType.VarChar).Value = Session["Password"].ToString();
                new SqlDataAdapter(sqlCmm).Fill(Adt);
                Response.Redirect("Account.aspx");
            }
            else
            {
                TextBox2.Text = "";
                pass.Text = "";
                Page.ClientScript.RegisterStartupScript(GetType(), "CallShowAlert", "ShowAlert(\"請重新輸入帳號密碼\",\"warning\");", true);
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "CallShowAlert", "ShowAlert(\"請檢查密碼是否一致\",\"warning\");", true);
        }*/

    }
}