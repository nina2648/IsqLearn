using System;
using System.Data;
using System.Data.SqlClient;

public partial class Feedback : System.Web.UI.Page
{
    int pagenum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Session["StudentName"].ToString();

        string name;
        name = Session["name"].ToString();

        if (Session["name"].ToString() == "學生登入")
        {

            
        }

    }
 
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection sqlConn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        sqlConn.Open();

        try
        {
            //獲取對應的ImgID
            //SELECT ImgID FROM PPTImg WHERE ImgPage = page

            //第四步：建立DataAdapter
            String strSQL = "INSERT INTO studentfeedback(CourseID,LessonID,StudentID,FbFast,FbNoise,FbDU,FbOK,FbElse) VALUES('1001','C001','S001','" + Request.Params["fbvaluef"] + "','" + Request.Params["fbvaluen"] + "','" + Request.Params["fbvaluec"] + "','" + Request.Params["fbvalueo"] + "','" + Request.Params["fbvaluee"] + "')";
            SqlDataAdapter oleda = new SqlDataAdapter(strSQL, sqlConn);

            

            //第五步：取得資料並填入 DataSet
            DataSet ds = new DataSet("ds_studentfeedback");
            oleda.Fill(ds, "ds_studentfeedback");

            if (Request.Params["fbvaluee"] == "1")
            {
                try
                {
                    String strSQL2 = "INSERT INTO studentfbmsg(CourseID,LessonID,StudentID,Fbelsemsg) VALUES('1001','C001','S001','" + Request.Params["msg0"] + "')";
                    SqlDataAdapter oleda2 = new SqlDataAdapter(strSQL2, sqlConn);

                    //第五步：取得資料並填入 DataSet
                    DataSet ds2 = new DataSet("ds_studentfbmsg");
                    oleda2.Fill(ds2, "ds_studentfbmsg");
                    this.Response.Write("<script> alert('有else '); </script>");
                }
                catch
                {
                }

            }
            else
            {
                this.Response.Write("<script> alert('無else '); </script>");
            }

            this.Response.Write("<script> alert('成功存入資料庫! '); </script>");
        }
        catch
        {
            this.Response.Write("<script> alert('回饋存入失敗 '); </script>");
        }


        //關閉資料庫連線
        sqlConn.Close();


        //Label1.Text = "承接js傳過來的參數是 " + Request.Params["fbvaluef"] + Request.Params["fbvaluen"] + Request.Params["fbvaluec"] + Request.Params["fbvalueo"]+ Request.Params["fbvaluee"]+ Request.Params["msg0"] ;
        //Label1.Text = "承接js傳過來的參數是 " + Request.Params["a"];
    }
}