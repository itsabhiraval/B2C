using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Designation : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static int desigid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDepartment();
        }
        bindGrid();
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
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Insert_Into_Designation", con);

        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        cmd.Parameters.AddWithValue("@designame",txtBoxDesigName.Text);
        cmd.Parameters.AddWithValue("@desc", txtBoxDesc.Text);
        cmd.Parameters.AddWithValue("@status", txtBoxStatus.Text);
        cmd.Parameters.AddWithValue("@deptId", ddDept.SelectedItem.Value);
        cmd.ExecuteNonQuery();
        con.Close();
        bindGrid();
        clrData();
        multiDesig.ActiveViewIndex = 1;
    }
    public void bindGrid()
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select_Designation_Department", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        gvDesig.DataSource = ds;
        gvDesig.DataBind();
    }
    protected void btnGoToTable_Click(object sender, EventArgs e)
    {
         multiDesig.ActiveViewIndex = 1;
    }
    protected void gvDesig_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            desigid = Convert.ToInt32(e.CommandArgument);
            SqlCommand cmd = new SqlCommand("Select_From_Designaton", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@DesigId", desigid);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            txtBoxDesigName.Text = ds.Tables[0].Rows[0]["DesigName"].ToString();
            txtBoxDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtBoxStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            bindDepartment();
            ddDept.SelectedValue = ds.Tables[0].Rows[0]["DeptId"].ToString();
            multiDesig.ActiveViewIndex = 0;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("delete from DesignationMaster where DesigId= " + e.CommandArgument + "", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindGrid();
        }

    }
    public void clrData()
    {
        txtBoxDesigName.Text = "";
        txtBoxDesc.Text = "";
        txtBoxStatus.Text = "";
        ddDept.SelectedIndex = 0;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        multiDesig.ActiveViewIndex = 0;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("Update_Designation", con);

        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@desigid", desigid);
        cmd.Parameters.AddWithValue("@designame", txtBoxDesigName.Text);
        cmd.Parameters.AddWithValue("@desc", txtBoxDesc.Text);
        cmd.Parameters.AddWithValue("@status", txtBoxStatus.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        bindGrid();
        clrData();
        multiDesig.ActiveViewIndex = 1;
    }
}