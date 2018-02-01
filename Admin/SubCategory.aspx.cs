using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SubCategory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static string radio_status = "";
    static string Image_SubCategory = "";
    static int SubCat_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
        }
        
        BindGrid();
    }

    public void BindGrid()
    {
        SqlCommand cmd = new SqlCommand("SELECT_SUBCAT", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gridSubCat.DataSource = ds;
        gridSubCat.DataBind();
    }

    public void BindCategory()
    {
        SqlCommand cmd = new SqlCommand("SELECT_CATEGORY", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        dropCategory.DataTextField = "CatName";
        dropCategory.DataValueField = "CatId";
        dropCategory.DataSource = ds;
        dropCategory.DataBind();

        dropCategory.Items.Insert(0, new ListItem("--SELECT CATEGORY--", "0"));
    }

    public void Clear_Data()
    {
        dropCategory.Items.Clear();
        txtSubCategory.Text = "";
        txtDescription.Text = "";
        uploadImage.Attributes.Clear();
        radioActive.Checked = false;
        radioDeactive.Checked = false;
    }
    
    protected void gridSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (radio_status == "Active")
        {
            radioActive.Checked = true;
        }
        else
            radioDeactive.Checked = true;
        
        SubCat_id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "edt")
        {
            BindCategory();
            SqlCommand cmd = new SqlCommand("GET_SUBCAT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@SubCatID", SubCat_id);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            dropCategory.Text = ds.Tables[0].Rows[0]["catid"].ToString();
            txtSubCategory.Text = ds.Tables[0].Rows[0]["subcatname"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            string Sub_image = ds.Tables[0].Rows[0]["image"].ToString();
            radio_status = ds.Tables[0].Rows[0]["status"].ToString();

            imageSubCat.ImageUrl = "~/SubCategory_Images/" + Sub_image;

            imageSubCat.Visible = true;
            MultiSubCategory.ActiveViewIndex = 0;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE_SUBCAT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@SubCatID", SubCat_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        BindGrid();

    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (dropCategory.SelectedIndex == 0)
        {

            Response.Write("<script>alert('Please select Category')</script>");
            return;
        }

        if (uploadImage.HasFile)
        {
            string str = Path.GetExtension(uploadImage.FileName);

            if (str == ".jpg" || str == ".png" || str == ".gif")
            {
                uploadImage.SaveAs(Server.MapPath("~/SubCategory_Images/" + uploadImage.FileName));
                Image_SubCategory = uploadImage.FileName;
            }
            else
            {
                Response.Write("<script>alert('Select Valid File')</script>");
                return;
            }
        }
        else
        {
            Response.Write("<script>alert(' Please Select Image')</script>");
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
            Response.Write("<script>alert('Please Select Status')</script>");
        }

        SqlCommand cmd;


        if (SubCat_id > 0)
        {
            cmd = new SqlCommand("UPDATE_SUBCAT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@SUBCATID", SubCat_id);
        }
        else
        {
            cmd = new SqlCommand("INSERT_SUBCAT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
        }
        cmd.Parameters.AddWithValue("@CATID", dropCategory.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@SUBCATNAME", txtSubCategory.Text);
        cmd.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text);
        cmd.Parameters.AddWithValue("@IMAGE", Image_SubCategory);
        cmd.Parameters.AddWithValue("@STATUS", radio_status);
        cmd.ExecuteNonQuery();
        con.Close();
        MultiSubCategory.ActiveViewIndex = 1;
        BindGrid();
        Clear_Data();
    }
    protected void btGridView_Click(object sender, EventArgs e)
    {
        MultiSubCategory.ActiveViewIndex = 1;
    }
    protected void btInsert_Click(object sender, EventArgs e)
    {
        MultiSubCategory.ActiveViewIndex = 0;
    }
}