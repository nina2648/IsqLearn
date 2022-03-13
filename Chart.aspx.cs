using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class Chart2 : System.Web.UI.Page
{
    int yn = 1;//有資料
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Session["TeacherName"].ToString();
        Label1.Text = Session["TeacherID"].ToString();
        Label3.Text = "";
        // fbpage();
    }
    private void BindChart()
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
                    google.load('visualization', '1', {packages: ['corechart']});
google.load('visualization', '1', { packages: ['orgchart'] });
google.charts.load('current', {'packages':['table']});
      google.charts.setOnLoadCallback(drawTable);</script>
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
                                    tooltip: { trigger: 'selection' },
                                    colors: ['#264653', '#2a9d8f', '#e9c46a', '#e76f51'],
                                    title: '即時回饋資料圖表'   ,
                                    backgroundColor: 'transparent',
                                    sliceVisibilityThreshold:0 ,
                                    chartArea:{width:'85%',height:'85%'},
                                   fontSize:20
                                    };  ");


            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart')); 

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
                ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsfastData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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
            strScript.Append(@"var table = new google.visualization.Table(document.getElementById('piepage')); 

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
                  ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsnoiseData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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
                   ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsDUData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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
                  ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dselseData.Rows)
            {

                strScript.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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


    private void BindChart2()
    {

        DataTable dsChartData2 = new DataTable();
        StringBuilder strScript2 = new StringBuilder();

        DataTable dsfastData2 = new DataTable();
        DataTable dsnoiseData2 = new DataTable();
        DataTable dsOKData2 = new DataTable();
        DataTable dselseData2 = new DataTable();
        DataTable dssDUData2 = new DataTable();

        try
        {

            dsChartData2 = GetChartData2();

            dsfastData2 = GetfastData();
            dsnoiseData2 = GetnoiseData();
            dsOKData2 = GetOKData();
            dselseData2 = GetelseData();
            dssDUData2 = GetsDUData();

            strScript2.Append(@" <head><style>
.small-font {
    font-size:20px;
    height: 10px;
text-align:center;
}
  </style> 


<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {  
                    var data = google.visualization.arrayToDataTable([
                    ['fbname', 'total'],");


            //第二張圖表
            foreach (DataRow row in dsChartData2.Rows)
            {
                strScript2.Append("['" + row["fbname"] + "'," + row["total"] + "],");
            }
            strScript2.Remove(strScript2.Length - 1, 1);
            strScript2.Append("]);");

            strScript2.Append(@" var options = {
                    tooltip: { trigger: 'selection' },
                                   colors: ['#264653', '#2a9d8f', '#f4a261', '#e9c46a', '#e76f51'],
                                    title: '重講後回饋資料圖表',
                                    backgroundColor: 'transparent',
                                   sliceVisibilityThreshold:0 ,
                                    chartArea:{width:'85%',height:'85%'},
                                    fontSize:20
                                   
                                  
                                    };   ");

            strScript2.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart2'));

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
                  ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsfastData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage2')); 
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
                  ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsnoiseData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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



            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage2')); 

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
                 ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dsOKData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage2')); 

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
if(topping=='還是不懂')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dssDUData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage2')); 

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
if(topping=='其他')
{
 chart.setAction({
          id: 'readpage',
          text: '查看回饋頁數',

          action:
            function drawChart() { 
                    var data = google.visualization.arrayToDataTable([
                 ['學生回饋頁碼', '人數'],");

            foreach (DataRow row in dselseData2.Rows)
            {

                strScript2.Append("['" + row["ImgPage"] + "'," + row["count"] + "],");
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


            strScript2.Append(@"var chart = new google.visualization.Table(document.getElementById('piepage2')); 

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







            chart.draw(data, options);
                                 
                                }  

                            google.setOnLoadCallback(drawChart);

                            ");


            strScript2.Append(" </script></head>");

            ltScripts2.Text = strScript2.ToString();
        }
        catch
        {
        }
        finally
        {
            dsChartData2.Dispose();

            dsfastData2.Dispose();
            dsnoiseData2.Dispose();
            dsOKData2.Dispose();
            dssDUData2.Dispose();
            dselseData2.Dispose();

            strScript2.Clear();
        }
    }

    private DataTable GetChartData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("GetPieChartData1", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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

    private DataTable GetChartData2()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("GetPieChartData2", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getfastpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getnoisepage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getDUpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getOKpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getsDUpage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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
            SqlDataAdapter sqlCmd = new SqlDataAdapter("getelsepage", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.Add("@lessonid", SqlDbType.NChar, 50).Value = Label7.Text;

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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String index = (e.CommandArgument).ToString();
        Label3.Text = index;//課程名稱

        Label4.Visible = false;
        Button2.Visible = true;

        DataSet lessonData = new DataSet();

        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();

        String sqlstr = "SELECT CourseID FROM course WHERE Course='" + Label3.Text + "' AND TeacherID = '" + Label1.Text + "'";

        SqlCommand cmd = new SqlCommand(sqlstr, sqlCon);

        //取得所選取的courseID
        SqlDataReader rd;
        rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            Label5.Text = rd[0].ToString();
        }

        lessonselect();
        dateselect();
        stufb();

        if (yn == 1)
        {
            BindChart2();
            BindChart();
        }


        sqlCon.Close();
    }
    private void stufb()//從學生回饋計算總回饋數
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();

        String sqlstr = "select * from studentfeedback WHERE  LessonID = '" + Label7.Text + "'";
        SqlDataAdapter oleda = new SqlDataAdapter(sqlstr, sqlCon);
        DataSet ds = new DataSet("FbFast");
        oleda.Fill(ds, "FbFast");

        String sqlSDU = "select count(FbDU)as count from studentfeedback WHERE  LessonID ='" + Label7.Text + "'AND FbOK='0' AND FbDU='1'";
        SqlDataAdapter oledaSDU = new SqlDataAdapter(sqlSDU, sqlCon);
        DataSet dsSDU = new DataSet("FbFast");
        oledaSDU.Fill(dsSDU, "FbFast");

        String sqlOK = "select * from studentfeedback WHERE  LessonID ='" + Label7.Text + "'AND FbOK='1' AND FbDU='1'";
        SqlDataAdapter oledaOK = new SqlDataAdapter(sqlOK, sqlCon);
        DataSet dsOK = new DataSet("FbFast");
        oledaOK.Fill(dsOK, "FbFast");

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
            int OKnum = int.Parse(dsOK.Tables[0].Compute("Sum(FbOK)", null).ToString());//學生回饋懂了加總
            int sDUnum = int.Parse(dsSDU.Tables[0].Rows[0]["count"].ToString());//學生回饋不懂-懂了

            //
            String sqlcount = "SELECT * FROM fbsum WHERE [Identity]='1' AND LessonID = '" + Label7.Text + "'";

            SqlDataAdapter oleda1 = new SqlDataAdapter(sqlcount, sqlCon);


            DataSet ds1 = new DataSet("FbFast");
            oleda1.Fill(ds1, "FbFast");

            if (ds1.Tables[0].Rows.Count == 0)//如果fbsum沒有這堂課的資料就新增
            {
               
                String sqlinsert = "INSERT INTO fbsum(CourseID,Course,LessonID,fbname,fbtype,total,[Identity])" +
                       "VALUES('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','太吵',' FbNoise ','" + noisenum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','太快',' FbFast ','" + fastnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','不懂',' FbDU ','" + DUnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','懂了',' FbOK ','" + OKnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','還是不懂',' FbsDU ','" + sDUnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','其他',' FbElse ','" + elsenum + "','1')"
                       ;

                SqlDataAdapter oleda2 = new SqlDataAdapter(sqlinsert, sqlCon);
                DataSet ds2 = new DataSet("FbFast");
                oleda2.Fill(ds2, "FbFast");

            }
            else//如果fbsum有這堂課的資料就更新資料
            {
                String selet2 = "select * from studentfeedback WHERE  LessonID = '" + Label7.Text + "'";
                SqlDataAdapter selet2da = new SqlDataAdapter(selet2, sqlCon);
                DataSet seletds = new DataSet("selet2");
                selet2da.Fill(seletds, "selet2");

                if (seletds.Tables[0] != ds.Tables[0])
                {
                    String sql = "DELETE FROM fbsum WHERE [Identity]='1' AND LessonID = '" + Label7.Text + "'";
                    SqlDataAdapter deleteda = new SqlDataAdapter(sql, sqlCon);
                    DataSet deleteds = new DataSet("delete");
                    deleteda.Fill(deleteds, "delete");

                    String sqlinsert = "INSERT INTO fbsum(CourseID,Course,LessonID,fbname,fbtype,total,[Identity])" +
                       "VALUES('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','太吵',' FbNoise ','" + noisenum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','太快',' FbFast ','" + fastnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','不懂',' FbDU ','" + DUnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','懂了',' FbOK ','" + OKnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','還是不懂',' FbsDU ','" + sDUnum + "','1')" +
                       ",('" + Label5.Text + "','" + Label3.Text + "','" + Label7.Text + "','其他',' FbElse ','" + elsenum + "','1')"
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

    private void lessonselect()//抓離現在時間最近的lessonID
    {

        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String lessonsql = "SELECT MAX(studentfeedback.LessonID) AS Expr1 FROM studentfeedback INNER JOIN lesson ON studentfeedback.LessonID = lesson.LessonID WHERE studentfeedback.CourseID='" + Label5.Text + "'";
        SqlCommand lessoncmd = new SqlCommand(lessonsql, sqlCon);
        //取得最近時間的lessonID
        SqlDataReader lessonrd;
        lessonrd = lessoncmd.ExecuteReader();
        if (lessonrd.Read())
        {
            Label7.Text = lessonrd[0].ToString();
        }
    }
    private void dateselect() //取得圖表的時間
    {
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ilearnConnectionString"].ConnectionString);
        sqlCon.Open();
        String lessonsql = "SELECT LessonTime FROM lesson WHERE LessonID='" + Label7.Text + "'";
        SqlCommand lessoncmd = new SqlCommand(lessonsql, sqlCon);

        SqlDataReader lessonrd;
        lessonrd = lessoncmd.ExecuteReader();
        if (lessonrd.Read())
        {
            date.Text = Convert.ToDateTime(lessonrd[0]).ToString("yyyy/MM/dd");
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
       
        Button2.Visible = false;
        Label8.Visible = true;
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
            Label7.Text = lessontimerd[0].ToString();
        }
        lessontimerd.Close();


        String selet2 = "select Course from course WHERE CourseID='" + Label5.Text + "'";
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
            BindChart2();
            BindChart();
        }
    }
}
    
