using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Admin_Master : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static int Admid;
    static string rdbtn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindcountry();
            bindDepartment();
            bindDesignation();
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
        cmd.Parameters.AddWithValue("@countryID",ddCountry.SelectedItem.Value);
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
        cmd.Parameters.AddWithValue("@stateid",ddState.SelectedItem.Value);
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddCity.DataValueField = "cityid";
        ddCity.DataTextField = "cityname";
        ddCity.DataSource = ds;
        ddCity.DataBind();
        ddCity.Items.Insert(0, new ListItem("--Select City--", "0"));
    }


    
    public void bindDepartment()
    {
        SqlCommand cmd = new SqlCommand("Select_Department", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddDept.DataTextField = "DeptName";
        ddDept.DataValueField = "DeptId";
        ddDept.DataSource = ds;
        ddDept.DataBind();
        ddDept.Items.Insert(0, new ListItem("--Select Department--", "0"));
        ddDesig.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }
    public void bindDesignation()
    {

       SqlCommand cmd = new SqlCommand("SelectDepartment_ddl", con);
        cmd.CommandType = CommandType.StoredProcedure;
       con.Open();
        cmd.Parameters.AddWithValue("@deptid", ddDept.SelectedItem.Value);
       cmd.ExecuteNonQuery();
        con.Close();
       SqlDataAdapter ad = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();
       ad.Fill(ds);
       ddDesig.DataTextField = "DesigName";
       ddDesig.DataValueField = "DesigId";
        ddDesig.DataSource = ds;
        ddDesig.DataBind();
        ddDesig.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkUserEmailExist() || checkUsernameExist())
        {
            SqlCommand cmd;
            if (Admid > 0)
            {
                cmd = new SqlCommand("Update_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id", Admid);
            }
            else
            {
                cmd = new SqlCommand("InsertIntoAdminUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
            }
            
            cmd.Parameters.AddWithValue("@Firstname", txtBoxFrstName.Text);
            cmd.Parameters.AddWithValue("@Lastname", txtBoxLstName.Text);
            cmd.Parameters.AddWithValue("@username", txtBoxUsrName.Text);
            cmd.Parameters.AddWithValue("@password", txtBoxPassword.Text);
            if (rdButtonFemale.Checked)
            {
                cmd.Parameters.AddWithValue("@gender", rdButtonFemale.Text);
            }
            else if (rdButtonMale.Checked)
            {
                cmd.Parameters.AddWithValue("@gender", rdButtonMale.Text);
            }
            else
            {
                Response.Write("<script>alert('Please Select Gender')</script>");
                return;
            }

            cmd.Parameters.AddWithValue("@address", txtBoxAddress.Text);
            cmd.Parameters.AddWithValue("@email", txtBoxEmail.Text);
            cmd.Parameters.AddWithValue("@mobile", txtBoxMobile.Text);
            cmd.Parameters.AddWithValue("@role", txtBoxRole.Text);
            cmd.Parameters.AddWithValue("@status", txtBoxStatus.Text);
            cmd.Parameters.AddWithValue("@country", ddCountry.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@state", ddState.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@city", ddCity.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@depart", ddDept.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@desig", ddDesig.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@join", txtBoxJoiningDate.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            multiAdmin_master.ActiveViewIndex = 0;
        }
        else
            Response.Write("<script>alert('Email And Username Already Exist')</script>");
        bindgrid();
     clrData();
    }

    public bool checkUserEmailExist()
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select * from Adminusers where Email='"+txtBoxEmail.Text+"'",con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        if(ds.Tables[0].Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    public bool checkUsernameExist()
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select * from Adminusers where Username='"+txtBoxUsrName.Text+"'",con);
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
        SqlDataAdapter ad = new SqlDataAdapter("SelectDataFromAdminusers", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        gvAdminUsers.DataSource = ds;
        gvAdminUsers.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        multiAdmin_master.ActiveViewIndex = 0;
        clrData();
    }
    protected void btnbtnGoToTable_Click(object sender, EventArgs e)
    {
        multiAdmin_master.ActiveViewIndex = 1;
    }
    protected void gvAdminUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "edt")
        {
            bindDepartment();
            bindDesignation();

            Admid = Convert.ToInt32(e.CommandArgument);
            SqlCommand cmd = new SqlCommand("SelectFromAdminusers", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Admid", Admid);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            txtBoxFrstName.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            txtBoxLstName.Text = ds.Tables[0].Rows[0]["Lastname"].ToString();
            txtBoxUsrName.Text = ds.Tables[0].Rows[0]["Username"].ToString();
            txtBoxAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtBoxEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtBoxMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            rdbtn = ds.Tables[0].Rows[0]["Gender"].ToString();
            txtBoxJoiningDate.Text = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
            txtBoxRole.Text = ds.Tables[0].Rows[0]["role"].ToString();
            txtBoxStatus.Text = ds.Tables[0].Rows[0]["status"].ToString();

            if (rdbtn == "Female")
            {
                rdButtonFemale.Checked = true;
            }
            else
            {
                rdButtonMale.Checked = true;
            }

            if (rdButtonFemale.Checked)
            {
                rdButtonFemale.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            }
            else
            {
                rdButtonMale.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            }
                multiAdmin_master.ActiveViewIndex = 0;

            }
            else
            {
                SqlCommand cmd = new SqlCommand("delete from Adminusers where AdminId=" + e.CommandArgument + "", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                bindgrid();
            }
        }
    
    public void clrData()
    {
        txtBoxAddress.Text = "";
        ddCity.SelectedIndex = 0;
        ddCountry.SelectedIndex = 0;
        ddState.SelectedIndex = 0;
        ddDept.SelectedIndex = 0;
        ddDesig.SelectedIndex = 0;
        txtBoxEmail.Text = "";
        txtBoxFrstName.Text = "";
        txtBoxLstName.Text = "";
        txtBoxJoiningDate.Text = "";
        txtBoxMobile.Text = "";
        txtBoxPassword.Text = "";
        txtBoxRole.Text = "";
        txtBoxStatus.Text = "";
        txtBoxUsrName.Text = "";
        rdButtonFemale.Checked = false;
        rdButtonMale.Checked = false;
    }
  
    protected void ddDept_SelectedIndexChanged1(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("SelectDepartment_ddl", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@deptid",ddDept.SelectedItem.Value);
        cmd.ExecuteNonQuery();
        con.Close();
        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ddDesig.DataTextField = "DesigName";
        ddDesig.DataValueField = "DesigId";
        ddDesig.DataSource = ds;
        ddDesig.DataBind();
        ddDesig.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }
    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindstate();
    }
    protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity();
    }
}
