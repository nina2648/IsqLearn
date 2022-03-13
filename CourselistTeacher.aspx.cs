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

public partial class Courselist : System.Web.UI.Page
{


    String nw = DateTime.Today.DayOfWeek.ToString("d");    //當日星期
    String nd1 = DateTime.Today.Date.ToString("yyyyMMdd");
    String nd2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
    String ntime = DateTime.Now.ToString("HH");
    protected void Page_Load(object sender, EventArgs e)
    {
        Hidden1.Value = "";

        Label2.Text = Session["TeacherName"].ToString();

        Button1.Style["Visibility"] = "hidden";
        Button2.Style["Visibility"] = "hidden";
        Button3.Style["Visibility"] = "hidden";
        Button4.Style["Visibility"] = "hidden";
        Button5.Style["Visibility"] = "hidden";
        Button6.Style["Visibility"] = "hidden";
        Button7.Style["Visibility"] = "hidden";
        Button8.Style["Visibility"] = "hidden";
        Button9.Style["Visibility"] = "hidden";
        Button10.Style["Visibility"] = "hidden";
        Button11.Style["Visibility"] = "hidden";
        Button12.Style["Visibility"] = "hidden";
        Button13.Style["Visibility"] = "hidden";
        Button14.Style["Visibility"] = "hidden";
        
        if (!IsPostBack)
        {

            string w = "";

            switch (title.Text)
            {
                case "當日課程":
                    w = nw;
                    break;
                case "星期一":
                    w = "1";
                    break;
                case "星期二":
                    w = "2";
                    break;
                case "星期三":
                    w = "3";
                    break;
                case "星期四":
                    w = "4";
                    break;
                case "星期五":
                    w = "5";
                    break;
                case "星期六":
                    w = "6";
                    break;
                case "星期日":
                    w = "7";
                    break;
            }
            if (w == nw)
            {
                Hidden1.Value = "yes";
            }
            else
            {
                Hidden1.Value = "";
            }

            //第一步：設定連線字串
            String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

            //第二步：建立資料庫連線物件
            SqlConnection cn = new SqlConnection(strConnectionString);

            //第三步：開啟資料庫連線
            cn.Open();

            //第四步：建立DataAdapter
            ; String connect = "Select * From [course] WHERE TeacherID='" + Session["TeacherID"] + "'　 AND (DATEPART(WEEKDAY, course.StartDate) - 1 = '" + nw + "')";
            SqlDataAdapter oleda1 = new SqlDataAdapter(connect, cn);


            //第五步：取得資料並填入 DataSet

            DataSet ds = new DataSet("ds_course");
            oleda1.Fill(ds, "ds_course");


            //第六步：設定 DataSource
            ListBox1.DataSource = ds.Tables[0];
            ListBox2.DataSource = ds.Tables[0];
            ListBox3.DataSource = ds.Tables[0];
            ListBox4.DataSource = ds.Tables[0];


            ListBox1.DataValueField = "Course";
            ListBox2.DataValueField = "CourseID";
            ListBox3.DataValueField = "Status";
            ListBox4.DataValueField = "Class";

            ListBox1.DataBind();
            ListBox2.DataBind();
            ListBox3.DataBind();
            ListBox4.DataBind();
            //關閉資料庫連線
            cn.Close();
            try
            {
                for (int x = 0; x <= 6; x++)
                {
                    if (ListBox3.Items[x].ToString() == "1")
                    {
                        switch (x.ToString())
                        {
                            case "0":
                                Button1.Style["Visibility"] = "visible";
                                Button8.Style["Visibility"] = "visible";
                                Button1.Text = ListBox1.Items[x].Text;
                                Button8.Text = ListBox4.Items[x].Text;
                                break;
                            case "1":
                                Button2.Style["Visibility"] = "visible";
                                Button9.Style["Visibility"] = "visible";
                                Button2.Text = ListBox1.Items[x].Text;
                                Button9.Text = ListBox4.Items[x].Text;
                                break;
                            case "2":
                                Button3.Style["Visibility"] = "visible";
                                Button10.Style["Visibility"] = "visible";
                                Button3.Text = ListBox1.Items[x].Text;
                                Button10.Text = ListBox4.Items[x].Text;
                                break;
                            case "3":
                                Button4.Style["Visibility"] = "visible";
                                Button11.Style["Visibility"] = "visible";
                                Button4.Text = ListBox1.Items[x].Text;
                                Button11.Text = ListBox4.Items[x].Text;
                                break;
                            case "4":
                                Button5.Style["Visibility"] = "visible";
                                Button12.Style["Visibility"] = "visible";
                                Button5.Text = ListBox1.Items[x].Text;
                                Button12.Text = ListBox4.Items[x].Text;
                                break;
                            case "5":
                                Button6.Style["Visibility"] = "visible";
                                Button13.Style["Visibility"] = "visible";
                                Button6.Text = ListBox1.Items[x].Text;
                                Button13.Text = ListBox4.Items[x].Text;
                                break;
                            case "6":
                                Button7.Style["Visibility"] = "visible";
                                Button14.Style["Visibility"] = "visible";
                                Button7.Text = ListBox1.Items[x].Text;
                                Button14.Text = ListBox4.Items[x].Text;
                                break;
                        }
                    }
                    else if (ListBox3.Items[x].ToString() != null)
                    {
                        switch (x.ToString())
                        {
                            case "0":
                                Button1.Style["Visibility"] = "visible";
                                Button8.Style["Visibility"] = "visible";
                                Button1.Text = ListBox1.Items[x].Text;
                                Button8.Text = ListBox4.Items[x].Text;
                                break;
                            case "1":
                                Button2.Style["Visibility"] = "visible";
                                Button9.Style["Visibility"] = "visible";
                                Button2.Text = ListBox1.Items[x].Text;
                                Button9.Text = ListBox4.Items[x].Text;
                                break;
                            case "2":
                                Button3.Style["Visibility"] = "visible";
                                Button10.Style["Visibility"] = "visible";
                                Button3.Text = ListBox1.Items[x].Text;
                                Button10.Text = ListBox4.Items[x].Text;
                                break;
                            case "3":
                                Button4.Style["Visibility"] = "visible";
                                Button11.Style["Visibility"] = "visible";
                                Button4.Text = ListBox1.Items[x].Text;
                                Button11.Text = ListBox4.Items[x].Text;
                                break;
                            case "4":
                                Button5.Style["Visibility"] = "visible";
                                Button12.Style["Visibility"] = "visible";
                                Button5.Text = ListBox1.Items[x].Text;
                                Button12.Text = ListBox4.Items[x].Text;
                                break;
                            case "5":
                                Button6.Style["Visibility"] = "visible";
                                Button13.Style["Visibility"] = "visible";
                                Button6.Text = ListBox1.Items[x].Text;
                                Button13.Text = ListBox4.Items[x].Text;
                                break;
                            case "6":
                                Button7.Style["Visibility"] = "visible";
                                Button14.Style["Visibility"] = "visible";
                                Button7.Text = ListBox1.Items[x].Text;
                                Button14.Text = ListBox4.Items[x].Text;
                                break;
                        }
                    }
                }
                
            }
            catch { }

        }
        
    }
    public void classchoose()
    {

        this.ListBox2.SelectedIndex = this.ListBox1.SelectedIndex;
        this.ListBox3.SelectedIndex = this.ListBox1.SelectedIndex;
        this.ListBox4.SelectedIndex = this.ListBox1.SelectedIndex;

        for (int x = 0; x <= 6; x++)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.ListBox2.SelectedIndex = this.ListBox1.SelectedIndex;
                this.ListBox3.SelectedIndex = this.ListBox1.SelectedIndex;
                this.ListBox4.SelectedIndex = this.ListBox1.SelectedIndex;


                //第一步：設定連線字串

                String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

                //第二步：建立資料庫連線物件

                SqlConnection cn = new SqlConnection(strConnectionString);

                //第三步：開啟資料庫連線

                cn.Open();

                //第四步：建立DataAdapter


                String sqlstr = "UPDATE course SET Status = '1' WHERE TeacherID = '" + Session["TeacherID"] + "' AND CourseID='" + ListBox2.SelectedValue + "'"; //UPDATE course SET Status = '1' WHERE TeacherID = 'T003' AND DATEPART(WEEKDAY, course.StartDate) -1 = '3'                

                SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

                //第五步：取得資料並填入 DataSet

                DataSet ds = new DataSet("ds_course");
                oleda.Fill(ds, "ds_course");


                //關閉資料庫連線
                cn.Close();

                this.ListBox2.SelectedIndex = this.ListBox1.SelectedIndex;
                this.ListBox3.SelectedIndex = this.ListBox1.SelectedIndex;
                this.ListBox4.SelectedIndex = this.ListBox1.SelectedIndex;

                Session["TeacherLessonID"] = ListBox2.SelectedValue + nd1;  //單課堂ID
                Session["CourseID"] = ListBox2.SelectedValue;

                TeacherLessonID.Value = Session["TeacherLessonID"].ToString();

                createlesson();
                Session["CourseID"] = ListBox2.SelectedValue;
            }
            else
            {
                Response.Redirect("CourselistTeacher.aspx");
            }


        }
    }

    protected void createlesson()
    {
        try { 
            //第一步：設定連線字串

            String strConnectionString2 = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

            //第二步：建立資料庫連線物件

            SqlConnection cn2 = new SqlConnection(strConnectionString2);

            //第三步：開啟資料庫連線

            cn2.Open();

            //第四步：建立DataAdapter
            String sqlstr2 = "INSERT INTO lesson (LessonID,CourseID,LessonTime)VALUES ('" + Session["TeacherLessonID"] + "','" + ListBox2.SelectedValue + "','" + nd2 + "');";
            SqlDataAdapter oleda2 = new SqlDataAdapter(sqlstr2, cn2);

            //第五步：取得資料並填入 DataSet
            DataSet ds2 = new DataSet("ds_course");
            oleda2.Fill(ds2, "ds_course");


            //關閉資料庫連線
            cn2.Close();
            Session["CourseID"] = ListBox2.SelectedValue;

            Response.Redirect("onclasstr.aspx");
            }
            catch{
            Session["CourseID"] = ListBox2.SelectedValue;
            Response.Redirect("onclasstr.aspx");
            }
    
    
}
   

    public void Weekday(string w)
    {

        switch (w)
        {
            case "Mon":
                w = "1";
                title.Text = "星期一";
                break;
            case "Tue":
                w = "2";
                title.Text = "星期二";
                break;
            case "Wed":
                w = "3";
                title.Text = "星期三";
                break;
            case "Thu":
                w = "4";
                title.Text = "星期四";
                break;
            case "Fri":
                w = "5";
                title.Text = "星期五";
                break;
            case "Sat":
                w = "6";
                title.Text = "星期六";
                break;
            case "Sun":
                w = "0";
                title.Text = "星期日";
                break;
            default:
                w = nw;
               title.Text = "當日課程";
                break;
        }
        string ww = "";

        switch (title.Text)
        {
            case "當日課程":
                ww = nw;
                break;
            case "星期一":
                ww = "1";
                break;
            case "星期二":
                ww = "2";
                break;
            case "星期三":
                ww = "3";
                break;
            case "星期四":
                ww = "4";
                break;
            case "星期五":
                ww = "5";
                break;
            case "星期六":
                ww = "6";
                break;
            case "星期日":
                ww = "7";
                break;
        }
        if (ww == nw)
        {
            Hidden1.Value = "yes";
        }
        else {
            Hidden1.Value = "";
        }


        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection cn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        cn.Open();

        //第四步：建立DataAdapter
        String sqlstr = "Select * From [course] WHERE TeacherID='" + Session["TeacherID"].ToString() + "' AND (DATEPART(WEEKDAY,course.StartDate)-1='" + w + "')";

        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

        //第五步：取得資料並填入 DataSet

        DataSet ds = new DataSet("ds_course");
        oleda.Fill(ds, "ds_course");

        //第六步：設定 DataSource
        ListBox1.DataSource = ds.Tables[0];
        ListBox2.DataSource = ds.Tables[0];
        ListBox3.DataSource = ds.Tables[0];
        ListBox4.DataSource = ds.Tables[0];
        

        ListBox1.DataValueField = "Course";
        ListBox2.DataValueField = "CourseID";
        ListBox3.DataValueField = "Status";
        ListBox4.DataValueField = "Class";
       
        ListBox1.DataBind();
        ListBox2.DataBind();
        ListBox3.DataBind();
        ListBox4.DataBind();
       
        //關閉資料庫連線
        cn.Close();


        try
        {
            for (int x = 0; x <= 6; x++)
            {
                if (ListBox3.Items[x].ToString() == "1")
                {
                    switch (x.ToString())
                    {
                        case "0":
                            Button1.Style["Visibility"] = "visible";
                            Button8.Style["Visibility"] = "visible";
                            Button1.Text = ListBox1.Items[x].Text;
                            Button8.Text = ListBox4.Items[x].Text;
                            break;
                        case "1":
                            Button2.Style["Visibility"] = "visible";
                            Button9.Style["Visibility"] = "visible";
                            Button2.Text = ListBox1.Items[x].Text;
                            Button9.Text = ListBox4.Items[x].Text;
                            break;
                        case "2":
                            Button3.Style["Visibility"] = "visible";
                            Button10.Style["Visibility"] = "visible";
                            Button3.Text = ListBox1.Items[x].Text;
                            Button10.Text = ListBox4.Items[x].Text;
                            break;
                        case "3":
                            Button4.Style["Visibility"] = "visible";
                            Button11.Style["Visibility"] = "visible";
                            Button4.Text = ListBox1.Items[x].Text;
                            Button11.Text = ListBox4.Items[x].Text;
                            break;
                        case "4":
                            Button5.Style["Visibility"] = "visible";
                            Button12.Style["Visibility"] = "visible";
                            Button5.Text = ListBox1.Items[x].Text;
                            Button12.Text = ListBox4.Items[x].Text;
                            break;
                        case "5":
                            Button6.Style["Visibility"] = "visible";
                            Button13.Style["Visibility"] = "visible";
                            Button6.Text = ListBox1.Items[x].Text;
                            Button13.Text = ListBox4.Items[x].Text;
                            break;
                        case "6":
                            Button7.Style["Visibility"] = "visible";
                            Button14.Style["Visibility"] = "visible";
                            Button7.Text = ListBox1.Items[x].Text;
                            Button14.Text = ListBox4.Items[x].Text;
                            break;
                    }
                }
                else if (ListBox3.Items[x].ToString() != null)
                {
                    switch (x.ToString())
                    {
                        case "0":
                            Button1.Style["Visibility"] = "visible";
                            Button8.Style["Visibility"] = "visible";
                            Button1.Text = ListBox1.Items[x].Text;
                            Button8.Text = ListBox4.Items[x].Text;
                            break;
                        case "1":
                            Button2.Style["Visibility"] = "visible";
                            Button9.Style["Visibility"] = "visible";
                            Button2.Text = ListBox1.Items[x].Text;
                            Button9.Text = ListBox4.Items[x].Text;
                            break;
                        case "2":
                            Button3.Style["Visibility"] = "visible";
                            Button10.Style["Visibility"] = "visible";
                            Button3.Text = ListBox1.Items[x].Text;
                            Button10.Text = ListBox4.Items[x].Text;
                            break;
                        case "3":
                            Button4.Style["Visibility"] = "visible";
                            Button11.Style["Visibility"] = "visible";
                            Button4.Text = ListBox1.Items[x].Text;
                            Button11.Text = ListBox4.Items[x].Text;
                            break;
                        case "4":
                            Button5.Style["Visibility"] = "visible";
                            Button12.Style["Visibility"] = "visible";
                            Button5.Text = ListBox1.Items[x].Text;
                            Button12.Text = ListBox4.Items[x].Text;
                            break;
                        case "5":
                            Button6.Style["Visibility"] = "visible";
                            Button13.Style["Visibility"] = "visible";
                            Button6.Text = ListBox1.Items[x].Text;
                            Button13.Text = ListBox4.Items[x].Text;
                            break;
                        case "6":
                            Button7.Style["Visibility"] = "visible";
                            Button14.Style["Visibility"] = "visible";
                            Button7.Text = ListBox1.Items[x].Text;
                            Button14.Text = ListBox4.Items[x].Text;
                            break;
                    }
                }


            }
        }
        catch { }
    }

    

    protected void Mon_Click(object sender, EventArgs e)
    {
        Weekday(Mon.Text);
    }

    protected void Tue_Click(object sender, EventArgs e)
    {
        Weekday(Tue.Text);
    }

    protected void Wed_Click(object sender, EventArgs e)
    {
        Weekday(Wed.Text);
    }

    protected void Thu_Click(object sender, EventArgs e)
    {
        Weekday(Thu.Text);
    }

    protected void Fri_Click(object sender, EventArgs e)
    {
        Weekday(Fri.Text);
    }
    protected void Sat_Click(object sender, EventArgs e)
    {
        Weekday(Sat.Text);
    }

    protected void Sun_Click(object sender, EventArgs e)
    {
        Weekday(Sun.Text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 0;    
        classchoose();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 1;
        classchoose();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 2;
        classchoose();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 3;
        classchoose();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 4;
        classchoose();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 5;
        classchoose();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedIndex = 6;
        classchoose();
    }   
}