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

public partial class Admin_Country : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clearData();
            bindgrid();
        }
        bindgrid();
    }
    protected void btnCountry_Click(object sender, EventArgs e)
    {
        string status = "";

        if (rbActive.Checked == true)
            status = rbActive.Text;
        else if (rbDeactive.Checked == true)
            status = rbDeactive.Text;


        SqlCommand cmd = new SqlCommand("country_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@CountryName", tbCountry.Text);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.ExecuteNonQuery();
        con.Close();

        clearData();

        bindgrid();
    }
    void bindgrid()
    {
        SqlCommand cmd1 = new SqlCommand("country_select", con);
        cmd1.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gvCountry.DataSource = ds;
        gvCountry.DataBind();

    }
    public void clearData()
    {
        tbCountry.Text = "";
        rbActive.Checked = false;
        rbDeactive.Checked = false;
    }
}