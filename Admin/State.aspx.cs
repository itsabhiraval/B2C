using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Admin_State : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcountry();
            clearData();

        }
        bindgrid();
    }
    protected void btnState_Click(object sender, EventArgs e)
    {
        string status = "";

        if (rbactive.Checked == true)
            status = rbactive.Text;
        else if (rbDeactive.Checked == true)
            status = rbDeactive.Text;

        SqlCommand cmd = new SqlCommand("state_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@CountryId", ddCountry.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@StateName", tbState.Text);
        cmd.Parameters.AddWithValue("@status",status);
        cmd.ExecuteNonQuery();
        con.Close();
        clearData();
        bindgrid();

    }
    void bindcountry()
    {
        SqlCommand cmd = new SqlCommand("country_select", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddCountry.DataValueField = "CountryId";
        ddCountry.DataTextField = "CountryName";

        ddCountry.DataSource = ds;
        ddCountry.DataBind();
        ddCountry.Items.Insert(0, new ListItem("--SELECT COUNTRY--", "0"));
    }
    void bindgrid()
    {
        SqlCommand cmd1 = new SqlCommand("state_select", con);
        cmd1.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gvState.DataSource = ds;
        gvState.DataBind();

    }

    public void clearData()
    {
        ddCountry.SelectedIndex = 0;
        tbState.Text = "";
        rbactive.Checked = false;
        rbDeactive.Checked = false;
    }

}