using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crudeoperation
{
    public partial class reportdisplay : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"data source=.;initial catalog=Project1;integrated security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             ShowReport();
        }

        private void ShowReport()
        {
            ReportViewer1.Reset();

  
            DataTable dt = GetData(TextBox1.Text);
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Add(ds);
           
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
          
            ReportParameter param = new ReportParameter();
            new ReportParameter("Player name", TextBox1.Text);
          
               
           


            
            ReportViewer1.LocalReport.SetParameters(param);
         
            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetData(string p)
        {

            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
          
            SqlDataAdapter sqlad = new SqlDataAdapter("sp_playersearchh", sqlcon);
            sqlad.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
          
            sqlad.SelectCommand.Parameters.AddWithValue("@Player_name", TextBox1.Text.Trim());
            sqlad.Fill(dt);
            TextBox1.Text="";
            return dt;
         





           
        }
    }
}