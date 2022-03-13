using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class stuChart : System.Web.UI.Page
{
    int yn = 1;//有資料
    string lessonid, courseid, course;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["StudentID"].ToString();
        Label2.Text = Session["StudentName"].ToString();
      

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        piechart.Style["Display"] = "Block";
        Button2.Visible = true;
        String index = (e.CommandArgument).ToString();
        course = index;//課程
        Label3.Text = course;
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String courseidsql = "SELECT course.CourseID FROM course INNER JOIN courseselection ON course.CourseID = courseselection.CourseID WHERE (courseselection.StudentID = '" + Label1.Text + "') AND (course.Course = '" + course + "')";
        SqlCommand courseidcmd = new SqlCommand(courseidsql, sqlCon);

        SqlDataReader courseidrd;
        courseidrd = courseidcmd.ExecuteReader();
        if (courseidrd.Read())
        {
            courseid = courseidrd[0].ToString();
            Label4.Text = courseid;
        }
        lessonselect();
        stufb();
        dateselect();
        Label3.Visible = true;
        date.Visible = true;
        PIE.Visible = true;
        COLUMN.Visible = true;
        BindpieChart();
        BindColumnChart();
    }
    private void lessonselect()//抓離現在時間最近的lessonID
    {
       
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String lessonsql = "SELECT MAX(studentfeedback.LessonID) AS Expr1 FROM studentfeedback INNER JOIN lesson ON studentfeedback.LessonID = lesson.LessonID WHERE studentfeedback.CourseID='" + courseid + "'";
        SqlCommand lessoncmd = new SqlCommand(lessonsql, sqlCon);
        //取得最近時間的lessonID
        SqlDataReader lessonrd;
        lessonrd = lessoncmd.ExecuteReader();
        if (lessonrd.Read())
        {
            lessonid = lessonrd[0].ToString();
        }
    }

    private void dateselect() //取得圖表的時間
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String lessonsql = "SELECT LessonTime FROM lesson WHERE LessonID='" + lessonid + "'";
        SqlCommand lessoncmd = new SqlCommand(lessonsql, sqlCon);

        SqlDataReader lessonrd;
        lessonrd = lessoncmd.ExecuteReader();
        if (lessonrd.Read())
        {
            date.Text = Convert.ToDateTime(lessonrd[0]).ToString("yyyy/MM/dd");
        }

    }


    private void stufb()//從學生回饋計算總回饋數
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();

        String sqlstr = "select * from studentfeedback WHERE StudentID='" + Label1.Text + "' AND LessonID = '" + lessonid + "'";
        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, sqlCon);
        DataSet ds = new DataSet("FbFast");
        oleda.Fill(ds, "FbFast");
        if (ds.Tables[0].Rows.Count == 0)//如果學生回饋中沒有資料
        {
            yn = 0;//沒有資料
            Response.AddHeader("Refresh", "0");
            Response.Write("<script>alert('沒有回饋資料!')</script>");
        }
        else
        {
            
            int fastnum = int.Parse(ds.Tables[0].Compute("Sum(FbFast)", null).ToString());//學生回饋太快加總
            int noisenum = int.Parse(ds.Tables[0].Compute("Sum(FbNoise)", null).ToString());//學生回饋太吵加總
            int DUnum = int.Parse(ds.Tables[0].Compute("Sum(FbDU)", null).ToString());//學生回饋不懂加總
            int elsenum = int.Parse(ds.Tables[0].Compute("Sum(FbElse)", null).ToString());//學生回饋其他加總
            int OKnum = int.Parse(ds.Tables[0].Compute("Sum(FbOK)", null).ToString());//學生回饋懂了加總
            int sDUnum = int.Parse(ds.Tables[0].Compute("Sum(FbDU)", null).ToString()) - int.Parse(ds.Tables[0].Compute("Sum(FbOK)", null).ToString());//學生回饋不懂-懂了

            //
            //
            String sqlcount = "SELECT * FROM fbsum WHERE  LessonID = '" + lessonid + "'AND [Identity] = '0'";

            SqlDataAdapter oleda1 = new SqlDataAdapter(sqlcount, sqlCon);


            DataSet ds1 = new DataSet("FbFast");
            oleda1.Fill(ds1, "FbFast");
            // Label6.Text = ds1.Tables[0].Rows.Count.ToString();//fbsum內的資料筆數判斷裡面有無資料

            if (ds1.Tables[0].Rows.Count == 0)//如果fbsum沒有這堂課的資料就新增//學生計算資料identity=0
            {
                String sqlinsert = "INSERT INTO fbsum(CourseID,Course,LessonID,fbname,fbtype,total,[Identity])" +
                       "VALUES('" + courseid + "','" + course + "','" + lessonid + "','太吵',' FbNoise ','" + noisenum + "','0')" +
                       ",('" + courseid + "','" + course + "','" + lessonid + "','太快',' FbFast ','" + fastnum + "','0')" +
                       ",('" + courseid + "','" + course + "','" + lessonid + "','不懂',' FbDU ','" + DUnum + "','0')" +
                       ",('" + courseid + "','" + course + "','" + lessonid + "','懂了',' FbOK ','" + OKnum + "','0')" +
                       ",('" + courseid + "','" + course + "','" + lessonid + "','還是不懂',' FbsDU ','" + sDUnum + "','0')" +
                       ",('" + courseid + "','" + course + "','" + lessonid + "','其他',' FbElse ','" + elsenum + "','0')"
                       ;

                SqlDataAdapter oleda2 = new SqlDataAdapter(sqlinsert, sqlCon);
                DataSet ds2 = new DataSet("FbFast");
                oleda2.Fill(ds2, "FbFast");

            }
            else//如果fbsum有這堂課的資料就更新資料
            {
                String selet2 = "select * from studentfeedback WHERE LessonID = '" + lessonid + "'";
                SqlDataAdapter selet2da = new SqlDataAdapter(selet2, sqlCon);
                DataSet seletds = new DataSet("selet2");
                selet2da.Fill(seletds, "selet2");

                if (seletds.Tables[0] != ds.Tables[0])
                {
                    String sql = "DELETE FROM fbsum  WHERE [Identity]='0'  AND LessonID = '" + lessonid + "'";
                    SqlDataAdapter deleteda = new SqlDataAdapter(sql, sqlCon);
                    DataSet deleteds = new DataSet("delete");
                    deleteda.Fill(deleteds, "delete");

                    String sqlinsert = "INSERT INTO fbsum(CourseID,Course,LessonID,fbname,fbtype,total,[Identity])" +
                      "VALUES('" + courseid + "','" + course + "','" + lessonid + "','太吵',' FbNoise ','" + noisenum + "','0')" +
                      ",('" + courseid + "','" + course + "','" + lessonid + "','太快',' FbFast ','" + fastnum + "','0')" +
                      ",('" + courseid + "','" + course + "','" + lessonid + "','不懂',' FbDU ','" + DUnum + "','0')" +
                      ",('" + courseid + "','" + course + "','" + lessonid + "','懂了',' FbOK ','" + OKnum + "','0')" +
                      ",('" + courseid + "','" + course + "','" + lessonid + "','還是不懂',' FbsDU ','" + sDUnum + "','0')" +
                      ",('" + courseid + "','" + course + "','" + lessonid + "','其他',' FbElse ','" + elsenum + "','0')"
                      ;

                    SqlDataAdapter oleda2 = new SqlDataAdapter(sqlinsert, sqlCon);


                    DataSet ds2 = new DataSet("FbFast");
                    oleda2.Fill(ds2, "FbFast");
                }
                else
                {
                }
            }
            sqlCon.Close();
        }
    }


    private void BindColumnChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        DataTable dsfastData = new DataTable();
        DataTable dsnoiseData = new DataTable();
        DataTable dsDUData = new DataTable();
        DataTable dselseData = new DataTable();


        try
        {
            dsChartData = GetChartData();

            dsfastData = GetfastData();
            dsnoiseData = GetnoiseData();
            dsDUData = GetDUData();
            dselseData = GetelseData();

            strScript.Append(@"<head>
           <style>
.small-font {
    font-size:20px;
    height: 10px;
text-align:center;
}
  </style> 

<script type='text/javascript'>
                  google.charts.load('current', {'packages':['bar']});
      google.charts.setOnLoadCallback(drawChart);</script>
                    <script type='text/javascript'>




                    function drawChart() {  
                    var data = google.visualization.arrayToDataTable([
                   ['fbname', 'total'],");

            foreach (DataRow row in dsChartData.Rows)
            {

                strScript.Append("['" + row["fbname"] + "'," + row["total"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {
backgroundColor: 'transparent',


                              colors: ['#1b9e77', '#d95f02', '#7570b3'],
                                  fontSize:20,
                                   animation: {  //載入動畫
            startup: true,
            duration: 1000,
            easing: 'out',
              },
vAxes: [{ //設定雙y軸的最大值跟最小值，若只需要單ㄧy軸用vAxis
            minValue: 1, //若圖表想從0開始，要設定最小值1
            maxValue: 15
        }, {
            minValue: 17,
            maxValue: 30
        }],
                                    };  ");


            strScript.Append(@"var chart = new google.visualization.ColumnChart(document.getElementById('Columnchart')); 

  function selectHandler() 
                          {
                       var selectedItem = chart.getSelection()[0];

                        if (selectedItem) 
                        { 
                          var topping = data.getValue(selectedItem.row, 0);

       if(topping=='太快')
                          {

    chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',
          action:
            function drawTable() { 
                    var datatable = google.visualization.arrayToDataTable([
                   ['學生回饋頁碼'],");

            foreach (DataRow row in dsfastData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");
            strScript.Append(@"var table = new google.visualization.Table(document.getElementById('piepage2')); 

      function selectHandler1() 
                          {
                       var selectedItem1 = table.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = datatable.getValue(selectedItem1.row, 0);
         
 ");


            strScript.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(table, 'select', selectHandler1); 

       table.draw(datatable, options);
}
        });

}

if(topping=='太吵')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                   ['學生回饋頁碼'],");

            foreach (DataRow row in dsnoiseData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");
            strScript.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");
            strScript.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 

function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });
}
if(topping=='不懂')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                   ['學生回饋頁碼'],");

            foreach (DataRow row in dsDUData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");


            strScript.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 

      function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });

}
if(topping=='其他')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                   ['學生回饋頁碼'],");

            foreach (DataRow row in dselseData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");


            strScript.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 

      function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });

}

 }
                             } 
                        google.visualization.events.addListener(chart, 'select', selectHandler); 

                             chart.draw(data, options);}
                     
                            google.setOnLoadCallback(drawChart);

                            ");


            strScript.Append(" </script></head>");

            ltScripts.Text = strScript.ToString();

        }

        catch
        {
        }
        finally
        {

            dsChartData.Dispose();
            dsfastData.Dispose();
            dsnoiseData.Dispose();
            dsDUData.Dispose();
            dselseData.Dispose();
            strScript.Clear();
        }
    }

    private void BindpieChart()
    {
        DataTable dspieChartData = new DataTable();

        StringBuilder strScript2 = new StringBuilder();

        DataTable dsfastData2 = new DataTable();
        DataTable dsnoiseData2 = new DataTable();
        DataTable dsOKData2 = new DataTable();


        try
        {
            dspieChartData = GetpieChartData();
            dsfastData2 = GetfastData();
            dsnoiseData2 = GetnoiseData();
            dsOKData2 = GetOKData();


            strScript2.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});
google.charts.load('current', {'packages':['table']});
      google.charts.setOnLoadCallback(drawTable);</script>
                    <script type='text/javascript'>


                   
                    function drawChart() {  
                    var data = google.visualization.arrayToDataTable([
                   ['fbname', 'total'],");

            foreach (DataRow row in dspieChartData.Rows)
            {

                strScript2.Append("['" + row["fbname"] + "'," + row["total"] + "],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@" var options = {
                   
                                    tooltip: { trigger: 'selection' },
                                     colors: ['#264653', '#2a9d8f', '#f4a261', '#e9c46a', '#e76f51'],
                                    title: '回饋資料圖表'   ,
                                    backgroundColor: 'transparent',
                                    sliceVisibilityThreshold:0 ,
                                    chartArea:{width:'85%',height:'85%'},
                                   fontSize:20
                                    };  ");


            strScript2.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart')); 

  function selectHandler() 
                          {
                       var selectedItem = chart.getSelection()[0];

                        if (selectedItem) 
                        { 
                          var topping = data.getValue(selectedItem.row, 0);
       if(topping=='太快')
                          {

    chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                  ['回饋頁碼'],");

            foreach (DataRow row in dsfastData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 
         function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript2.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });
}

if(topping=='太吵')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                  ['回饋頁碼'],");

            foreach (DataRow row in dsnoiseData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");



            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 

      function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript2.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });

}

if(topping=='懂了')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                 ['學生回饋頁碼'],");

            foreach (DataRow row in dsOKData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@"var options={
allowHtml: true, 
    cssClassNames: { 
     tableCell: 'small-font' ,
headerCell:'small-font'
    } 
};");


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage')); 

      function selectHandler1() 
                          {
                       var selectedItem1 = chart.getSelection()[0];

                        if (selectedItem1) 
                        { 
                          var topping1 = data.getValue(selectedItem1.row, 0);");



            strScript2.Append(@" var yes = confirm('是否查看第'+topping1+'頁教材');

if (yes) {
window.open('reppt.aspx?ppt='+topping1+'','回饋確認',config='height=500, width=600, top=0, left=0,toolbar=no, menubar=no, scrollbars=no, Resizable=no,location=no, status=no');


} else {
    alert('你按了取消按鈕');
}
}
						  }
						   google.visualization.events.addListener(chart, 'select', selectHandler1); 

       chart.draw(data, options);
}

        });

}



}
                             } 
                        google.visualization.events.addListener(chart, 'select', selectHandler); 








                             chart.draw(data, options);}
                     
                            google.setOnLoadCallback(drawChart);

                            ");


            strScript2.Append(" </script>");

            ltScripts2.Text = strScript2.ToString();
        }
        catch
        {
        }
        finally
        {

            dspieChartData.Dispose();
            strScript2.Clear();
        }
    }

    private DataTable GetpieChartData()
    {
        DataSet dspieData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("GetstuPieChartData1", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;

            sqlCon.Open();

            sqlCmd.Fill(dspieData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dspieData.Tables[0];
    }

    private DataTable GetChartData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("GetstuPieChartData1", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    private DataTable GetfastData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetfastpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    private DataTable GetnoiseData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetnoisepage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    private DataTable GetDUData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetDUpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }

    private DataTable GetOKData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetOKpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    private DataTable GetsDUData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetsDUpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    private DataTable GetelseData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stugetelsepage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = lessonid;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
    protected void PIE_Click(object sender, EventArgs e)
    {
        PIE.Enabled = false;
        COLUMN.Enabled = true;
        Columnchart.Style["Display"] = "None"; //隐藏
        piechart.Style["Display"] = "Block"; //顯示
    }

    protected void COLUMN_Click(object sender, EventArgs e)
    {
        PIE.Enabled = true;
        COLUMN.Enabled = false;
        Columnchart.Style["Display"] = "Block"; //顯示
        piechart.Style["Display"] = "None"; //隐藏
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        timeselect.Visible = true;
    }

    protected void timeselect_SelectedIndexChanged(object sender, EventArgs e)
    {

        date.Text = timeselect.SelectedValue.ToString();
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String lessontimesql = "SELECT LessonID FROM lesson WHERE LessonTime='" + timeselect.SelectedValue.ToString() + "'";
        SqlCommand lessontimecmd = new SqlCommand(lessontimesql, sqlCon);
        //取得最近時間的lessonID
        SqlDataReader lessontimerd;
        lessontimerd = lessontimecmd.ExecuteReader();
        if (lessontimerd.Read())
        {
            lessonid = lessontimerd[0].ToString();
        }
        lessontimerd.Close();


        String selet2 = "select Course from course WHERE CourseID='" + courseid + "'";
        SqlCommand coursecmd = new SqlCommand(selet2, sqlCon);
        //取得最近時間的lessonID
        SqlDataReader courserd;
        courserd = coursecmd.ExecuteReader();
        if (courserd.Read())
        {
            Label3.Text = courserd[0].ToString();
        }

        stufb();
        if (yn == 1)
        {
            BindpieChart();
            BindColumnChart();
        }
    }

   /* protected void Button3_Click(object sender, EventArgs e)
    {
        Columnchart.Style["Display"] = "None";
        piechart.Style["Display"] = "None";
        allchart.Style["Display"] = "Block";
        PIE.Visible = false;
        COLUMN.Visible = false;

        DataTable dsallChartData = new DataTable();

        StringBuilder strScript2 = new StringBuilder();

        try
        {
            dsallChartData = GetallData();

            strScript2.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']});
google.charts.load('current', {'packages':['table']});
      google.charts.setOnLoadCallback(drawTable);</script>
                    <script type='text/javascript'>


                   
                    function drawChart() {  
                    var data = google.visualization.arrayToDataTable([
                   ['category', 'count'],");

            foreach (DataRow row in dsallChartData.Rows)
            {

                strScript2.Append("['" + row["category"] + "'," + row["count"] + "],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@" var options = {
                   
                                    tooltip: { trigger: 'selection' },
                                     colors: ['#264653', '#2a9d8f', '#f4a261', '#e9c46a', '#e76f51'],
                                    title: '即時回饋資料圖表'   ,
                                    backgroundColor: 'transparent',
                                    sliceVisibilityThreshold:0 ,
                                    chartArea:{width:'85%',height:'85%'},
                                   fontSize:20
                                    };  ");


            strScript2.Append(@"var chart = new google.visualization.PieChart(document.getElementById('allchart')); 

        chart.setAction({
          id: 'readpage',
          text: '詳細資料',
          action:  

        var table = new google.visualization.Table(document.getElementById('piepage'));

        table.draw(data, {showRowNumber: true, width: '100%', height: '100%'});
      }
        });

                             chart.draw(data, options);}
                     
                            google.setOnLoadCallback(drawChart);

                            ");


            strScript2.Append(" </script>");

            ltScripts2.Text = strScript2.ToString();
        }
        catch
        {
        }
        finally
        {

            dsallChartData.Dispose();
            strScript2.Clear();
        }
    }*/
    private DataTable GetallData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("stuallcategory", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@studentid", SqlDbType.NChar, 50).Value = Label1.Text;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
}