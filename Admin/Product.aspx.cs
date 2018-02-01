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

public partial class Admin_Product : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static int Product_id ;
    static string radio_Status = "";
    static string Image_Product = "";
    static string Status = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           Clear_Data();
           BindCategory();
           BindSubCategory();
        }
      BindGrid();
    }

    public void BindGrid()
    {
        SqlCommand cmd = new SqlCommand("SELECT_PRODUCT",con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gridProduct.DataSource = ds;
        gridProduct.DataBind();
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

    public void BindSubCategory()
    {
        SqlCommand cmd = new SqlCommand("BINDSUBCATEGORY", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CATID", dropCategory.SelectedIndex);
      

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        dropSubCategory.DataTextField = "SubCatName";
        dropSubCategory.DataValueField = "SubCatId";
        dropSubCategory.DataSource = ds;
        dropSubCategory.DataBind();

        dropSubCategory.Items.Insert(0, new ListItem("--SELECT SUB-CATEGORY --", "0"));
    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (dropCategory.SelectedIndex == 0)
        {

            Response.Write("<script>alert('Please select Category')</script>");
            return;
        }

        if (dropSubCategory.SelectedIndex == 0)
        {

            Response.Write("<script>alert('Please select Sub-Category')</script>");
            return;
        }

        if (uploadImage.HasFile)
        {
            string str = Path.GetExtension(uploadImage.FileName);

            if (str == ".jpg" || str == ".png" || str == ".gif")
            {
                uploadImage.SaveAs(Server.MapPath("~/Product_Images/" + uploadImage.FileName));
                Image_Product = uploadImage.FileName;
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
            radio_Status = radioActive.Text;
        }
        else if (radioDeactive.Checked)
        {
            radio_Status = radioDeactive.Text;
        }
        else
        {
            Response.Write("<script>alert('Please Select Status')</script>");
        }
   

        SqlCommand cmd ;


        if (Product_id > 0)
        {
            cmd = new SqlCommand("UPDATE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@PROID", Product_id);
        }
        else
        {
           cmd = new SqlCommand("INSERT_PRODUCT", con);
           cmd.CommandType = CommandType.StoredProcedure;
           con.Open();
        }
        
        cmd.Parameters.AddWithValue("@CatId", dropCategory.SelectedIndex);
        cmd.Parameters.AddWithValue("@USERID",0);
        cmd.Parameters.AddWithValue("@SUBCAT", dropSubCategory.SelectedIndex);
        cmd.Parameters.AddWithValue("@PRODUCTNAME", txtProduct.Text);
        cmd.Parameters.AddWithValue("@DESCRIPTION", txtDescryption.Text);
        cmd.Parameters.AddWithValue("@PRICE", txtPrice.Text);
        cmd.Parameters.AddWithValue("@QUNTITIES", txtQuantities.Text);
        cmd.Parameters.AddWithValue("@IMAGE", Image_Product);
        cmd.Parameters.AddWithValue("@STATUS",radio_Status);
        cmd.ExecuteNonQuery();
        con.Close();

        BindGrid();
        Clear_Data();
        multiProduct.ActiveViewIndex = 1;

    }
    public void Clear_Data()
    {
        dropCategory.Items.Clear();
        dropSubCategory.Items.Clear();
        txtProduct.Text = "";
        txtDescryption.Text = "";
        txtPrice.Text = "";
        txtQuantities.Text = "";
        uploadImage.Attributes.Clear();
        radioActive.Checked = false;
        radioDeactive.Checked = false;
    }
    protected void gridProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        BindCategory();
        BindSubCategory();

        if (radio_Status == "Active")
        {
            radioActive.Checked = true;
        }
        else
            radioDeactive.Checked = true;

        Product_id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "edt")
        {

            SqlCommand cmd = new SqlCommand("GET_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@PRODUCTID", Product_id);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            dropCategory.Text = ds.Tables[0].Rows[0]["CatId"].ToString();
            dropSubCategory.Text = ds.Tables[0].Rows[0]["SubCatId"].ToString();
            txtProduct.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
            txtDescryption.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
            txtQuantities.Text = ds.Tables[0].Rows[0]["Quantities"].ToString();
            Image_Product = ds.Tables[0].Rows[0]["Product_Image"].ToString();
            Status = ds.Tables[0].Rows[0]["Availablestatus"].ToString();

            imageProduct.ImageUrl = "~/Product_Images/" + Image_Product;

            imageProduct.Visible = true;
            multiProduct.ActiveViewIndex = 0;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@catid", Product_id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
       
        BindGrid();
    }
    protected void btInsert_Click(object sender, EventArgs e)
    {
        multiProduct.ActiveViewIndex = 0;
    }
    protected void btGridview_Click(object sender, EventArgs e)
    {
        multiProduct.ActiveViewIndex = 1;
    }
    protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategory();
    }
}