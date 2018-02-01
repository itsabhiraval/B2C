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

public partial class Admin_City : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcountry();
            bindstate();
    
        }
        bindgrid();
    }
    protected void btnCity_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("city_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@CountryId", ddCountry.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@StateID", ddState.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@CityName", tbCity.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        bindgrid();
        clearData();
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
        bindstate();
    }
    void bindstate()
    {
        SqlCommand cmd = new SqlCommand("BINDSTATE", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@countryID",ddCountry.SelectedItem.Value);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddState.DataValueField = "StateId";
        ddState.DataTextField = "StateName";
        ddState.DataSource = ds;
        ddState.DataBind();
        ddState.Items.Insert(0, new ListItem("-- SELECT STATE--", "0"));
    }

    public void clearData()
    {
        ddCountry.SelectedIndex = 0;
        ddState.SelectedIndex = 0;
        tbCity.Text = "";
        rbActive.Checked = false;
        rbDeactive.Checked = false;
    }

    void bindgrid()
    {
        SqlCommand cmd1 = new SqlCommand("city_select", con);
        cmd1.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gvCity.DataSource = ds;
        gvCity.DataBind();

    }
    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindstate();
    }
    protected void btGridview_Click(object sender, EventArgs e)
    {
        multiCity.ActiveViewIndex = 1;
    }
    protected void btBack_Click(object sender, EventArgs e)
    {
        multiCity.ActiveViewIndex = 0;
    }
}