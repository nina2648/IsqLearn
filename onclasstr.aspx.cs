using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;

public partial class onclasstr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["TeacherName"].ToString();
        Label2.Text = Session["CourseID"].ToString();
        //Label3.Text = Request.Url.Segments[1];
        Button1.Style["Visibility"] = "hidden";

    }




    protected void Button1_Click1(object sender, EventArgs e)
    {
        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection cn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        cn.Open();

        //第四步：建立DataAdapter
        String sqlstr = "UPDATE course SET Status = '0' WHERE CourseID='" + Label2.Text + "'";

        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

        //第五步：取得資料並填入 DataSet

        DataSet ds = new DataSet("ds_course");
        oleda.Fill(ds, "ds_course");


        //關閉資料庫連線
        cn.Close();

    }
}