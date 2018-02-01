using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Department : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static int depid;
    protected void Page_Load(object sender, EventArgs e)
    {
        bindGrid();
    }

    public void bindGrid()
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select_Department", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        gvDepartment.DataSource = ds;
        gvDepartment.DataBind();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        SqlCommand cmd ;

        if (depid > 0)
        {
            cmd = new SqlCommand("Update_Department", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@deptid", depid);
        }
        else 
        {
            cmd = new SqlCommand("Insert_Into_Department", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
        }    
        cmd.Parameters.AddWithValue("@deptname", txtBoxDeptName.Text);
        cmd.Parameters.AddWithValue("@desc", txtBoxDesc.Text);
        cmd.Parameters.AddWithValue("@status", txtBoxStatus.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        bindGrid();
        clrData();
        
    }
    protected void btnGoToTbl_Click(object sender, EventArgs e)
    {
        multiDepartment.ActiveViewIndex = 1;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        multiDepartment.ActiveViewIndex = 0;
        clrData();
    }
    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        depid = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "edt")
         {
             SqlCommand cmd = new SqlCommand("Select_From_Department",con);

             cmd.CommandType = CommandType.StoredProcedure;
             con.Open();
             cmd.Parameters.AddWithValue("@DeptId",depid);
             cmd.ExecuteNonQuery();
             con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            txtBoxDeptName.Text = ds.Tables[0].Rows[0]["DeptName"].ToString();
            txtBoxDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtBoxStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            multiDepartment.ActiveViewIndex = 0;
        }
             else
             {
                 SqlCommand cmd = new SqlCommand("DltFromDept", con);

                 cmd.CommandType = CommandType.StoredProcedure;
                 con.Open();
                 cmd.Parameters.AddWithValue("@DeptId", depid);
                 cmd.ExecuteNonQuery();
                 con.Close();
                 bindGrid();
    }
}
    public void clrData()
    {
        txtBoxStatus.Text = "";
        txtBoxDesc.Text = "";
        txtBoxDeptName.Text = "";
    }
}