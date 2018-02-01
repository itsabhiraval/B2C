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

public partial class Admin_Regestration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
    static string  usertype = "",gender = "";
    static int id, regestration_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcountry();
            bindstate();
            bindcity();
            clearData();
        }
        bindgrid();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rbBuyer.Checked == false && rbseller.Checked == false)
        {
            Response.Write("<script>alert('Select User Type')</script>");
            return;
        }
        if (rbMale.Checked == false && rbFemale.Checked == false)
        {
            Response.Write("<script>alert('Select Your Gender')</script>");
            return;
        }
        if (getExistingUser())
        {
            rb_usertype();
            rb_gender();
            SqlCommand cmd;



            cmd = new SqlCommand("regestration_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@UserType", usertype);
            cmd.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", tbLastName.Text);
            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
            cmd.Parameters.AddWithValue("@Password", tbPassword.Text);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@DOB", tbDOB.Text);
            cmd.Parameters.AddWithValue("@Contacts", tbContact.Text);
            cmd.Parameters.AddWithValue("@Address", tbAddress.Text);
            cmd.Parameters.AddWithValue("@CountryId", ddCountry.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@StateId", ddState.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@CityId", ddCity.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Zipcode", tbZipCode.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
            clearData();
            Response.Write("<script>alert('Successfully Registred')</script>");
        }
        else
        {
            Response.Write("<script>alert('Email ID already exist')</script>");
        }
    }

    public bool getExistingUser()
    {
        SqlDataAdapter ad = new SqlDataAdapter("select * from RegisterMaster where email='" + tbEmail.Text + "'", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    void bindgrid()
    {
        SqlCommand cmd = new SqlCommand("regestration_select", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gvRegestration.DataSource = ds;
        gvRegestration.DataBind();

    }
    void rb_usertype()
    {
        if (rbBuyer.Checked)
        {
            usertype = rbBuyer.Text;
        }
        else
            usertype = rbseller.Text;
    }
    void rb_gender()
    {
        if (rbMale.Checked)
        {
            gender = rbMale.Text;
        }
        else
            gender = rbFemale.Text;
    }
    protected void gvRegestration_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
            SqlCommand cmd = new SqlCommand("delete_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@registrationid", e.CommandArgument);
            cmd.ExecuteNonQuery();
            con.Close();
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
        ddCountry.Items.Insert(0,new ListItem("-- SELECT COUNTRY--","0"));
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
    void bindcity()
    {
        SqlCommand cmd = new SqlCommand("bindcity", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@stateid", ddState.SelectedItem.Value);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddCity.DataValueField = "CityID";
        ddCity.DataTextField = "CityName";
        ddCity.DataSource = ds;
        ddCity.DataBind();
        ddCity.Items.Insert(0, new ListItem("-- SELECT CITY--", "0"));
    }
   
    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindstate();
    }
    protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity();
    }

    protected void btGridview_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btBack_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    public void clearData()
    {
        tbFirstName.Text = "";
        tbLastName.Text = "";
        tbPassword.Text = "";
        tbZipCode.Text = "";
        tbEmail.Text = "";
        tbAddress.Text = "";
        tbContact.Text = "";
        tbDOB.Text = "";
        rbBuyer.Checked = false;
        rbseller.Checked = false;
        rbMale.Checked = false;
        rbFemale.Checked = false;
        ddCountry.SelectedIndex = 0;
        ddCity.SelectedIndex = 0;
        ddState.SelectedIndex = 0;
    }
}