using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Security;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;


public partial class Courselist : System.Web.UI.Page
{

    String nw = DateTime.Today.DayOfWeek.ToString("d");    //當日星期
    String nd1 = DateTime.Today.Date.ToString("yyyyMMdd");
    String nd2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
    String ntime = DateTime.Now.ToString("HH");

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        scriptManager.RegisterPostBackControl(this.Button1);
        scriptManager.RegisterPostBackControl(this.Button2);
        scriptManager.RegisterPostBackControl(this.Button3);
        scriptManager.RegisterPostBackControl(this.Button4);
        scriptManager.RegisterPostBackControl(this.Button5);
        scriptManager.RegisterPostBackControl(this.Button6);
        scriptManager.RegisterPostBackControl(this.Button7);
        scriptManager.RegisterPostBackControl(this.Button8);
        scriptManager.RegisterPostBackControl(this.Button9);
        scriptManager.RegisterPostBackControl(this.Button10);
        scriptManager.RegisterPostBackControl(this.Button11);
        scriptManager.RegisterPostBackControl(this.Button12);
        scriptManager.RegisterPostBackControl(this.Button13);
        scriptManager.RegisterPostBackControl(this.Button14);
        Label2.Text = Session["StudentName"].ToString();
        con1.Style["Visibility"] = "hidden";
        con2.Style["Visibility"] = "hidden";
        con3.Style["Visibility"] = "hidden";
        con4.Style["Visibility"] = "hidden";
        con5.Style["Visibility"] = "hidden";
        con6.Style["Visibility"] = "hidden";
        con7.Style["Visibility"] = "hidden";
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
        Timer1.Enabled = true;
        if (!IsPostBack)
        {

            //第一步：設定連線字串
            String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

            //第二步：建立資料庫連線物件
            SqlConnection cn = new SqlConnection(strConnectionString);

            //第三步：開啟資料庫連線
            cn.Open();

            //第四步：建立DataAdapter
            String sqlstr = "SELECT * FROM [course] Join [courseselection] on course.CourseID = courseselection.CourseID WHERE (courseselection.StudentID = '" + Session["StudentID"] + "')　  AND (DATEPART(WEEKDAY, course.StartDate) - 1 = '" + nw + "')";
            SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

            //第五步：取得資料並填入 DataSet

            DataSet ds = new DataSet("ds_course");
            oleda.Fill(ds, "ds_course");

            //第六步：設定 DataSource
            ListBox1.DataSource = ds.Tables[0];
            ListBox2.DataSource = ds.Tables[0];
            ListBox3.DataSource = ds.Tables[0];
            ListBox4.DataSource = ds.Tables[0];
            ListBox5.DataSource = ds.Tables[0];
            


            ListBox1.DataValueField = "Course";
            ListBox2.DataValueField = "CourseID";
            ListBox3.DataValueField = "Status";
            ListBox4.DataValueField = "Class";
            ListBox5.DataValueField = "TeacherID";
            

            ListBox1.DataBind();
            ListBox2.DataBind();
            ListBox3.DataBind();
            ListBox4.DataBind();
            ListBox5.DataBind();
           
            Tname(nw);

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
                                con1.Style["Visibility"] = "visible";
                                Button1.Text = ListBox1.Items[0].Text;
                                Button8.Text = ListBox4.Items[0].Text + "  " + ListBox8.Items[0].Text;
                                break;
                            case "1":
                                Button2.Style["Visibility"] = "visible";
                                Button9.Style["Visibility"] = "visible";
                                con2.Style["Visibility"] = "visible";
                                Button2.Text = ListBox1.Items[x].Text;
                                Button9.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "2":
                                Button3.Style["Visibility"] = "visible";
                                Button10.Style["Visibility"] = "visible";
                                con3.Style["Visibility"] = "visible";
                                Button3.Text = ListBox1.Items[x].Text;
                                Button10.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "3":
                                Button4.Style["Visibility"] = "visible";
                                Button11.Style["Visibility"] = "visible";
                                con4.Style["Visibility"] = "visible";
                                Button4.Text = ListBox1.Items[x].Text;
                                Button11.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "4":
                                Button5.Style["Visibility"] = "visible";
                                Button12.Style["Visibility"] = "visible";
                                con5.Style["Visibility"] = "visible";
                                Button5.Text = ListBox1.Items[x].Text;
                                Button12.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "5":
                                Button6.Style["Visibility"] = "visible";
                                Button13.Style["Visibility"] = "visible";
                                con6.Style["Visibility"] = "visible";
                                Button6.Text = ListBox1.Items[x].Text;
                                Button13.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "6":
                                Button7.Style["Visibility"] = "visible";
                                Button14.Style["Visibility"] = "visible";
                                con7.Style["Visibility"] = "visible";
                                Button7.Text = ListBox1.Items[x].Text;
                                Button14.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
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
                                Button1.Text = ListBox1.Items[0].Text;
                                Button8.Text = ListBox4.Items[0].Text + "  " + ListBox8.Items[0].Text;
                                break;
                            case "1":
                                Button2.Style["Visibility"] = "visible";
                                Button9.Style["Visibility"] = "visible";
                                Button2.Text = ListBox1.Items[x].Text;
                                Button9.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "2":
                                Button3.Style["Visibility"] = "visible";
                                Button10.Style["Visibility"] = "visible";
                                Button3.Text = ListBox1.Items[x].Text;
                                Button10.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "3":
                                Button4.Style["Visibility"] = "visible";
                                Button11.Style["Visibility"] = "visible";
                                Button4.Text = ListBox1.Items[x].Text;
                                Button11.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "4":
                                Button5.Style["Visibility"] = "visible";
                                Button12.Style["Visibility"] = "visible";
                                Button5.Text = ListBox1.Items[x].Text;
                                Button12.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "5":
                                Button6.Style["Visibility"] = "visible";
                                Button13.Style["Visibility"] = "visible";
                                Button6.Text = ListBox1.Items[x].Text;
                                Button13.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                            case "6":
                                Button7.Style["Visibility"] = "visible";
                                Button14.Style["Visibility"] = "visible";
                                Button7.Text = ListBox1.Items[x].Text;
                                Button14.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                                break;
                        }
                    }
                }
            }
            catch { }
        }      
    }

    
    protected void lesson()
    {
        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection cn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        cn.Open();

        //第四步：建立DataAdapter
        String sqlstr = "Select * FROM [lesson] WHERE (LessonID='" + Session["StudentLessonID"] + "') AND (DATEPART(WEEKDAY, LessonTime) = '" + nd1 + "')";

        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

        ///第五步：取得資料並填入 DataSet

        DataSet ds = new DataSet("ds_lesson");
        oleda.Fill(ds, "ds_lesson");

        //關閉資料庫連線
        cn.Close();
    }


    public void Weekday(string w)
    {
        switch (w)
        {
            case "Mon":
                w = "1";
                title.Text = "星期一";
                Tname(w);
                break;
            case "Tue":
                w = "2";
                title.Text = "星期二";
                Tname(w);
                break;
            case "Wed":
                w = "3";
                title.Text = "星期三";
                Tname(w);
                break;
            case "Thu":
                w = "4";
                title.Text = "星期四";
                Tname(w);
                break;
            case "Fri":
                w = "5";
                title.Text = "星期五";
                Tname(w);
                break;
            case "Sat":
                w = "6";
                title.Text = "星期六";
                Tname(w);
                break;
            case "Sun":
                w = "0";
                title.Text = "星期日";
                Tname(w);
                break;
        }
        
        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection cn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        cn.Open();

        //第四步：建立DataAdapter
        String sqlstr = "SELECT *FROM [course] Join [courseselection] on course.CourseID = courseselection.CourseID WHERE (courseselection.StudentID = '" + Session["StudentID"].ToString() + "') AND (DATEPART(WEEKDAY,course.StartDate)-1='" + w + "')";

        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

        //第五步：取得資料並填入 DataSet

        DataSet ds = new DataSet("ds_course");
        oleda.Fill(ds, "ds_course");

        //第六步：設定 DataSource
        ListBox1.DataSource = ds.Tables[0];
        ListBox2.DataSource = ds.Tables[0];
        ListBox3.DataSource = ds.Tables[0];
        ListBox4.DataSource = ds.Tables[0];
        ListBox5.DataSource = ds.Tables[0];
       


        ListBox1.DataValueField = "Course";
        ListBox2.DataValueField = "CourseID";
        ListBox3.DataValueField = "Status";
        ListBox4.DataValueField = "Class";
        ListBox5.DataValueField = "TeacherID";
       

        ListBox1.DataBind();
        ListBox2.DataBind();
        ListBox3.DataBind();
        ListBox4.DataBind();
        ListBox5.DataBind();
       


        //關閉資料庫連線
        cn.Close();
        Tname(w);
        suretime();


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
                            con1.Style["Visibility"] = "visible";
                            Button1.Text = ListBox1.Items[0].Text;
                            Button8.Text = ListBox4.Items[0].Text + "  " + ListBox8.Items[0].Text;
                            break;
                        case "1":
                            Button2.Style["Visibility"] = "visible";
                            Button9.Style["Visibility"] = "visible";
                            con2.Style["Visibility"] = "visible";
                            Button2.Text = ListBox1.Items[x].Text;
                            Button9.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "2":
                            Button3.Style["Visibility"] = "visible";
                            Button10.Style["Visibility"] = "visible";
                            con3.Style["Visibility"] = "visible";
                            Button3.Text = ListBox1.Items[x].Text;
                            Button10.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "3":
                            Button4.Style["Visibility"] = "visible";
                            Button11.Style["Visibility"] = "visible";
                            con4.Style["Visibility"] = "visible";
                            Button4.Text = ListBox1.Items[x].Text;
                            Button11.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "4":
                            Button5.Style["Visibility"] = "visible";
                            Button12.Style["Visibility"] = "visible";
                            con5.Style["Visibility"] = "visible";
                            Button5.Text = ListBox1.Items[x].Text;
                            Button12.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "5":
                            Button6.Style["Visibility"] = "visible";
                            Button13.Style["Visibility"] = "visible";
                            con6.Style["Visibility"] = "visible";
                            Button6.Text = ListBox1.Items[x].Text;
                            Button13.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "6":
                            Button7.Style["Visibility"] = "visible";
                            Button14.Style["Visibility"] = "visible";
                            con7.Style["Visibility"] = "visible";
                            Button7.Text = ListBox1.Items[x].Text;
                            Button14.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
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
                            Button1.Text = ListBox1.Items[0].Text;
                            Button8.Text = ListBox4.Items[0].Text + "  " + ListBox8.Items[0].Text;
                            break;
                        case "1":
                            Button2.Style["Visibility"] = "visible";
                            Button9.Style["Visibility"] = "visible";
                            Button2.Text = ListBox1.Items[x].Text;
                            Button9.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "2":
                            Button3.Style["Visibility"] = "visible";
                            Button10.Style["Visibility"] = "visible";
                            Button3.Text = ListBox1.Items[x].Text;
                            Button10.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "3":
                            Button4.Style["Visibility"] = "visible";
                            Button11.Style["Visibility"] = "visible";
                            Button4.Text = ListBox1.Items[x].Text;
                            Button11.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "4":
                            Button5.Style["Visibility"] = "visible";
                            Button12.Style["Visibility"] = "visible";
                            Button5.Text = ListBox1.Items[x].Text;
                            Button12.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "5":
                            Button6.Style["Visibility"] = "visible";
                            Button13.Style["Visibility"] = "visible";
                            Button6.Text = ListBox1.Items[x].Text;
                            Button13.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
                            break;
                        case "6":
                            Button7.Style["Visibility"] = "visible";
                            Button14.Style["Visibility"] = "visible";
                            Button7.Text = ListBox1.Items[x].Text;
                            Button14.Text = ListBox4.Items[x].Text + "  " + ListBox8.Items[x].Text;
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

    protected void Timer1_Tick(object sender, EventArgs e)
    {

        switch (title.Text)
        {
            case "當日課程":
                Weekday(nw);
                break;
            case "星期一":
                Weekday(Mon.Text);
                break;
            case "星期二":
                Weekday(Tue.Text);
                break;
            case "星期三":
                Weekday(Wed.Text);
                break;
            case "星期四":
                Weekday(Thu.Text);
                break;
            case "星期五":
                Weekday(Fri.Text);
                break;
            case "星期六":
                Weekday(Sat.Text);
                break;
            case "星期日":
                Weekday(Sun.Text);
                break;
        }
        suretime();
    }
    public void Tname(string i)
    {
        for (int j=0; j<= ListBox2.Items.Count-1;j++) { 
        //第一步：設定連線字串
        String strConnectionString = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

        //第二步：建立資料庫連線物件
        SqlConnection cn = new SqlConnection(strConnectionString);

        //第三步：開啟資料庫連線
        cn.Open();

        //第四步：建立DataAdapter
        String sqlstr = "select * from(course e join courseselection L on   e.CourseID = L.CourseID AND L.StudentID = '"+Session["StudentID"] +"') join teacherinfo d on  e.TeacherID = d.TeacherID COLLATE Chinese_Taiwan_Stroke_CI_AS  AND(DATEPART(WEEKDAY, e.StartDate) - 1 = '"+i+"') ORDER BY e.CourseID";
        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, cn);

        //第五步：取得資料並填入 DataSet

        DataSet ds = new DataSet("ds_teacherinfo");
        oleda.Fill(ds, "ds_teacherinfo");
        //第六步：設定 DataSource

        ListBox8.DataSource = ds.Tables[0];
        ListBox8.DataValueField = "TeacherName";
        ListBox8.DataBind();

        //關閉資料庫連線
        cn.Close();
        }
    }    
    public void classchoose() {
        string w="";
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
        this.ListBox2.SelectedIndex = this.ListBox1.SelectedIndex;
        this.ListBox3.SelectedIndex = this.ListBox1.SelectedIndex;
        this.ListBox4.SelectedIndex = this.ListBox1.SelectedIndex;
        this.ListBox5.SelectedIndex = this.ListBox1.SelectedIndex;        
        this.ListBox8.SelectedIndex = this.ListBox1.SelectedIndex;
        lesson();
        Session["StudentLessonID"] = ListBox2.SelectedValue + nd1 + Session["StudentID"];
        StudentLessonID.Value = Session["StudentLessonID"].ToString();

        if (ListBox3.SelectedValue == "1" && w==nw)
        {
            Response.Redirect("./Feedback.aspx");
        }
        else
        {
            Response.Write("<script language=javascript>alert('現在不是當日上課時間!');window.location='CourselistStudent.aspx'</script>");

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 0;
        classchoose();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 1;
        classchoose();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 2;
        classchoose();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 3;
        classchoose();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 4;
        classchoose();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 5;
        classchoose();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        this.ListBox1.SelectedIndex = 6;
        classchoose();
    }

    public void suretime()
    {
        string w="";
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
        for (int x = 0; x < ListBox5.Items.Count; x++)
        {
            if (w !=nw){
                String strConnectionString2 = "Data Source=192.192.155.110;  user id = ilearn; password = aft193;";

                //第二步：建立資料庫連線物件

                SqlConnection cn2 = new SqlConnection(strConnectionString2);

                //第三步：開啟資料庫連線

                cn2.Open();

                //第四步：建立DataAdapter


                String sqlstr2 = "UPDATE course SET Status = '0' WHERE TeacherID = '" + ListBox5.Items[x] + "' AND CourseID='" + ListBox2.Items[x] + "'";

                SqlDataAdapter oleda2 = new SqlDataAdapter(sqlstr2, cn2);

                //第五步：取得資料並填入 DataSet

                DataSet ds2 = new DataSet("ds2_course");
                oleda2.Fill(ds2, "ds2_course");


                //關閉資料庫連線
                cn2.Close();
            }
        }
    }

}