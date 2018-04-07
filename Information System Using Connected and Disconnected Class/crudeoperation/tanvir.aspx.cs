using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crudeoperation
{
    public partial class tanvir : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"data source=.;initial catalog=Project1;integrated security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btndelete.Visible = false;
                //btndelete.Enabled = false;
                //btndelete.Enabled = false;
                btnupdate.Visible = false;
                Displayrecord();
            }
        }

        protected void btncleare_Click(object sender, EventArgs e)
        {
            Clearr();
        }

        private void Clearr()
        {
            hfid.Value = "";
            txtcname.Text = txtpname.Text = txtage.Text = txttype.Text = txtstatus.Text = txtrole.Text = txtteam.Text = "";
            lblsuccess.Text = lblerroe.Text = "";
            btnsave.Text = "Save";
            btndelete.Visible = false;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Sp_insertData", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.Parameters.AddWithValue("@Cid", (hfid.Value==""?0:Convert.ToInt32(hfid.Value)));
            sqlcmd.Parameters.AddWithValue("@Country_name", txtcname.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_name", txtpname.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_age", txtage.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Game_Type", txttype.Text.Trim());

            sqlcmd.Parameters.AddWithValue("@Player_Status", txtstatus.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_Role", txtrole.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Major_Team", txtteam.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            //string info = hfid.Value;
            Clearr();
            //      if (info == "")
            //          lblsuccess.Text = "Save SuccessFully";

            lblsuccess.Text = "Save SuccessFully";
            //else

            //lblsuccess.Text = "Update SuccessFully";

            Displayrecord();
            btncleare.Visible = true;
            btnupdate.Visible = false;

        }

        private void Displayrecord()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlad = new SqlDataAdapter("displayall", sqlcon);
            sqlad.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtle = new DataTable();
            sqlad.Fill(dtle);
            sqlcon.Close();
            GridView1.DataSource = dtle;
            GridView1.DataBind();
        }

        protected void viewButton1_Click(object sender, EventArgs e)
            

    
        {
            txtcname.Text = txtpname.Text = txtage.Text = txttype.Text = txtstatus.Text = txtrole.Text = txtteam.Text = "";

            int Cid = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlad = new SqlDataAdapter("displaybyid", sqlcon);
            sqlad.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlad.SelectCommand.Parameters.AddWithValue("@cid", Cid);
            DataTable dtle = new DataTable();
            sqlad.Fill(dtle);
            sqlcon.Close();
            hfid.Value = Cid.ToString();
            txtcname.Text = dtle.Rows[0]["Country_name"].ToString();
            txtpname.Text = dtle.Rows[0]["Player_name"].ToString();
            txtage.Text = dtle.Rows[0]["Player_age"].ToString();
            txttype.Text = dtle.Rows[0]["Game_Type"].ToString();

            txtstatus.Text = dtle.Rows[0]["Player_Status"].ToString();
            txtrole.Text = dtle.Rows[0]["Player_Role"].ToString();
            txtteam.Text = dtle.Rows[0]["Major_Team"].ToString();
            //btnsave.Text = "Update";
            btndelete.Visible = true;
            btnsave.Visible = true;
            btncleare.Visible = false;
            btnupdate.Visible = true;
           
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {

            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Sp_datadelete", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Cid", Convert.ToInt32(hfid.Value));

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Clearr();
            Displayrecord();
            lblsuccess.Text = "Delete Successfully";
            btnsave.Visible = true;
            btncleare.Visible = true;
            btndelete.Visible = false;
            btnupdate.Visible = false;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
           

            Displayrecord();


            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Sp_UpdateData", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Cid", (hfid.Value == "" ? 0 : Convert.ToInt32(hfid.Value)));
            sqlcmd.Parameters.AddWithValue("@Country_name", txtcname.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_name", txtpname.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_age", txtage.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Game_Type", txttype.Text.Trim());

            sqlcmd.Parameters.AddWithValue("@Player_Status", txtstatus.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Player_Role", txtrole.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@Major_Team", txtteam.Text.Trim());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            //string info = hfid.Value;
            Clearr();
            //      if (info == "")
            //          lblsuccess.Text = "Save SuccessFully";

            lblsuccess.Text = "Save SuccessFully";
            //else

            //lblsuccess.Text = "Update SuccessFully";
            lblsuccess.Text = "Update SuccessFully";
            btnsave.Visible = true;
            btncleare.Visible = true;
            btndelete.Visible = false;
            btnupdate.Visible = false;

            Displayrecord();

        }
    }
}