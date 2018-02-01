using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public partial class Admin_Category : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static string radio_status = "", Status = "";
    static string Image_Category = "";
    static int Cat_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
       // clear_data();
        BindGrid();
    }

    public void BindGrid()
    {
        SqlCommand cmd = new SqlCommand("SELECT_CATEGORY", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gridCategory.DataSource = ds;
        gridCategory.DataBind();

    }
 
    protected void btSubmit_Click(object sender, EventArgs e)
    { 

        if (uploadImage.HasFile)
        {
            string str = Path.GetExtension(uploadImage.FileName);

            if (str == ".jpg" || str == ".png" || str == ".gif")
            {
                uploadImage.SaveAs(Server.MapPath("~/Category_Images/" + uploadImage.FileName));
                Image_Category = uploadImage.FileName;
            }
            else
                Response.Write("<script>alert('Select Valid File')</script>");
        }
        else
        {
            Response.Write("<script>alert(' Please Select Image ')</script>");
            return;
        }

        if (radioActive.Checked)
        {
            radio_status = radioActive.Text;
        }
        else if (radioDeactive.Checked)
        {
            radio_status = radioDeactive.Text;
        }
        else
        {
            Response.Write("<script>alert('Must Have To Select Status')</script>");
            return;
        }
       

        SqlCommand cmd;

        if (Cat_Id > 0)
        {
            cmd = new SqlCommand("UPDATE_CATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@CATID", Cat_Id);
        }
        else
        {
            cmd = new SqlCommand("INSERT_CATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
        }
        cmd.Parameters.AddWithValue("@CATEGORYNAME", txtCatName.Text);
        cmd.Parameters.AddWithValue("@DESCRYPTION", txtDescription.Text);
        cmd.Parameters.AddWithValue("@IMAGE", Image_Category);
        cmd.Parameters.AddWithValue("@STATUS", radio_status);
        cmd.ExecuteNonQuery();
        con.Close();
        MultiView1.ActiveViewIndex = 1;
        BindGrid();
    }
 
    protected void btInsert_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0 ;
    }
    protected void btGridview_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void gridCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (radio_status == "Active")
        {
            radioActive.Checked = true;
        }
        else
            radioDeactive.Checked = true;

        Cat_Id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "edt")
        {

            SqlCommand cmd = new SqlCommand("CATEGORY_ROWCOMMAND", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@CATID", Cat_Id);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            txtCatName.Text = ds.Tables[0].Rows[0]["CatName"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            Image_Category = ds.Tables[0].Rows[0]["Image"].ToString();
            Status = ds.Tables[0].Rows[0]["status"].ToString();

            imageGet.ImageUrl = "~/Category_Images/" + Image_Category ;

            imageGet.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE_CATEGORY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@catid", Cat_Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        BindGrid();
    }
    public void clear_data()
    {
        txtCatName.Text = "";
        txtDescription.Text = "";
        radioActive.Checked = false;
        radioDeactive.Checked = false;
        uploadImage.Attributes.Clear();
    }
}