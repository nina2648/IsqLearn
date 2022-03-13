using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
        //記住密碼
        //使用者姓名(登出)
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["name"] = Button1.Text;
        string constr = WebConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=192.192.155.110;Initial Catalog=ilearn;Persist Security Info=True;User ID=ilearn;Password=aft193;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM studentinfo WHERE StudentID=@StudentID AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@StudentID", user.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", pass.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["StudentID"] = user.Text.Trim();
                    Session["Password"] = pass.Text.Trim();
                    SqlConnection conn = new SqlConnection("server=192.192.155.110;database=ilearn;uid=ilearn;pwd=aft193");
                    conn.Open();
                    SqlCommand s_com = new SqlCommand();
                    s_com.CommandText = "select StudentName from studentinfo where StudentID ='" + user.Text + "'";
                    s_com.Connection = conn;

                    SqlDataReader s_read = s_com.ExecuteReader();
                    while (s_read.Read()) // 迴圈會執行到沒有下一筆資料為止
                    {
                        Label2.Text = s_read["StudentName"].ToString();
                        Session["StudentName"] = Label2.Text.Trim();
                    }
                    Response.Write("<script>alert('登入成功')</script>");
                    Response.Redirect("CourselistStudent.aspx");
                }
                else
                {
                    Response.Write("<script>alert('登入錯誤')</script>");
                }


            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            SqlConnection conn = new SqlConnection("server=192.192.155.110;database=ilearn;uid=ilearn;pwd=aft193");
            conn.Open();
            SqlCommand ss_com = new SqlCommand();
            ss_com.CommandText = "select School from studentinfo where StudentID ='" + user.Text + "'";
            ss_com.Connection = conn;

            SqlDataReader ss_read = ss_com.ExecuteReader();
            while (ss_read.Read()) // 迴圈會執行到沒有下一筆資料為止
            {
                Label2.Text = ss_read["School"].ToString();
                Session["School"] = Label2.Text.Trim();
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["name"] = Button2.Text;
        string constr = WebConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=192.192.155.110;Initial Catalog=ilearn;Persist Security Info=True;User ID=ilearn;Password=aft193;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM teacherinfo WHERE TeacherID=@TeacherID AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@TeacherID", user.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", pass.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["TeacherID"] = user.Text.Trim();
                    SqlConnection conn = new SqlConnection("server=192.192.155.110;database=ilearn;uid=ilearn;pwd=aft193");
                    conn.Open();
                    SqlCommand s_com = new SqlCommand();
                    s_com.CommandText = "select TeacherName from teacherinfo where TeacherID ='" + user.Text + "'";
                    s_com.Connection = conn;

                    SqlDataReader s_read = s_com.ExecuteReader();
                    while (s_read.Read()) // 迴圈會執行到沒有下一筆資料為止
                    {
                        Label2.Text = s_read["TeacherName"].ToString();
                        Session["TeacherName"] = Label2.Text.Trim();
                    }
                    Response.Write("<script>alert('登入成功')</script>");
                    Response.Redirect("CourselistTeacher.aspx");
                }
                else { Response.Write("<script>alert('登入錯誤')</script>"); }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            SqlConnection conn = new SqlConnection("server=192.192.155.110;database=ilearn;uid=ilearn;pwd=aft193");
            conn.Open();
            SqlCommand ss_com = new SqlCommand();
            ss_com.CommandText = "select School from teacherinfo where TeacherID ='" + user.Text + "'";
            ss_com.Connection = conn;

            SqlDataReader ss_read = ss_com.ExecuteReader();
            while (ss_read.Read()) // 迴圈會執行到沒有下一筆資料為止
            {
                Label2.Text = ss_read["School"].ToString();
                Session["School"] = Label2.Text.Trim();
            }
        }
    }
}