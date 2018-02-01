using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_User : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static string rdBtnUserType;
    static int UserId;
    static string rdBtnGender;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bindcountry();
        }
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
        ddCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
        ddState.Items.Insert(0, new ListItem("--Select State--", "0"));
        ddCity.Items.Insert(0, new ListItem("--Select City--", "0"));


    }
    void bindstate()
    {
        SqlCommand cmd = new SqlCommand("state_bycountry", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@countryID", ddCountry.SelectedItem.Value);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddState.DataValueField = "StateId";
        ddState.DataTextField = "StateName";
        ddState.DataSource = ds;
        ddState.DataBind();
        ddState.Items.Insert(0, new ListItem("--Select State--", "0"));
        ddCity.Items.Insert(0, new ListItem("--Select City--", "0"));

    }

    void bindcity()
    {
        SqlCommand cmd = new SqlCommand("city_selectbystateid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@stateid", ddState.SelectedItem.Value);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddCity.DataValueField = "cityid";
        ddCity.DataTextField = "cityname";
        ddCity.DataSource = ds;
        ddCity.DataBind();
        ddCity.Items.Insert(0, new ListItem("--Select City--", "0"));
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rdButtonBuyer.Checked)
        {
            rdBtnUserType = rdButtonBuyer.Text;
        }
        else
            rdBtnUserType = rdButtonSeller.Text;
        if (rdButtonMale.Checked)
            rdBtnGender = rdButtonMale.Text;
        else
            rdBtnGender = rdButtonFemale.Text;

        SqlCommand cmd = new SqlCommand("InsertIntoUser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        if (rdBtnUserType != null)
            cmd.Parameters.AddWithValue("@UserType", rdBtnUserType.ToString());
        else
        {
            Response.Write("<script>alert('Please Select Usertype')</script>");
            return;
        }
        cmd.Parameters.AddWithValue("@Firstname", txtBoxFrstName.Text);
        cmd.Parameters.AddWithValue("@Lastname", txtBoxLstName.Text);
        cmd.Parameters.AddWithValue("@email", txtBoxEmail.Text);
        cmd.Parameters.AddWithValue("@password", txtBoxPassword.Text);
        if (rdBtnGender != null)
            cmd.Parameters.AddWithValue("@gender", rdBtnGender.ToString());
        else
        {
            Response.Write("<script>alert('Please Select Gender')</script>");
            return;
        }
        cmd.Parameters.AddWithValue("@dob",Convert.ToDateTime(txtBoxDOB.Text));
        cmd.Parameters.AddWithValue("@Contacts", txtBoxMobile.Text);
        cmd.Parameters.AddWithValue("@address", txtBoxAddress.Text);
        cmd.Parameters.AddWithValue("@country", ddCountry.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@state", ddState.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@city", ddCity.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@zipcode", txtBoxZipCode.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        bindgrid();
        clrData();
    }
    public void bindgrid()
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select * from RegisterMaster", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        gvUserRegistration.DataSource = ds;
        gvUserRegistration.DataBind();
    }
    public void clrData()
    {
        txtBoxAddress.Text = "";
        txtBoxDOB.Text = "";
        txtBoxEmail.Text = "";
        txtBoxFrstName.Text = "";
        txtBoxLstName.Text = "";
        txtBoxMobile.Text = "";
        txtBoxPassword.Text = "";
        txtBoxZipCode.Text = "";
        rdButtonBuyer.Checked = false;
        rdButtonSeller.Checked = false;
        rdButtonMale.Checked = false;
        rdButtonFemale.Checked = false;
    }
    protected void gvUserRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            UserId = Convert.ToInt32(e.CommandArgument);
            SqlCommand cmd = new SqlCommand("SelectFromRegisterMastr", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            txtBoxFrstName.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            txtBoxLstName.Text = ds.Tables[0].Rows[0]["Lastname"].ToString();
            txtBoxEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtBoxPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
            txtBoxAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtBoxMobile.Text = ds.Tables[0].Rows[0]["Contacts"].ToString();
            txtBoxZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
            rdBtnGender = ds.Tables[0].Rows[0]["Gender"].ToString();
            if (rdBtnGender == "Female")
            {
                rdButtonFemale.Checked = true;
            }
            else
            {
                rdButtonMale.Checked = true;
            }
            rdBtnUserType = ds.Tables[0].Rows[0]["UserType"].ToString();
            if (rdBtnUserType == "Seller")
            {
                rdButtonSeller.Checked = true;
            }
            else
            {
                rdButtonBuyer.Checked = true;
            }
        }
        else
        {
            SqlCommand cmd = new SqlCommand("delete from RegisterMaster where UserId=" +e.CommandArgument+ "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindgrid();
        }
    }
    protected void ddCountry_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bindstate();
    }
    protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity();
    }
}