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

public partial class User_Product_User : System.Web.UI.Page
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
        }
        if (Session["UserId"] == null)
        {
            Response.Redirect("user_login.aspx");
        }
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
      
           cmd = new SqlCommand("INSERT_PRODUCT", con);
           cmd.CommandType = CommandType.StoredProcedure;
           con.Open();
     
        cmd.Parameters.AddWithValue("@CatId", dropCategory.SelectedIndex);
        cmd.Parameters.AddWithValue("@USERID", Session["UserId"]);
        cmd.Parameters.AddWithValue("@SUBCAT", dropSubCategory.SelectedIndex);
        cmd.Parameters.AddWithValue("@PRODUCTNAME", txtProduct.Text);
        cmd.Parameters.AddWithValue("@DESCRIPTION", txtDescryption.Text);
        cmd.Parameters.AddWithValue("@PRICE", txtPrice.Text);
        cmd.Parameters.AddWithValue("@QUNTITIES", txtQuantities.Text);
        cmd.Parameters.AddWithValue("@IMAGE", Image_Product);
        cmd.Parameters.AddWithValue("@STATUS",radio_Status);
        cmd.ExecuteNonQuery();
        con.Close();
        Clear_Data();
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
    protected void dropCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategory();
    }
}
