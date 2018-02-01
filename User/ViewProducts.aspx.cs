using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class User_ViewProducts : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindCategory(); bindProducts();
        }
    }

    public void bindProducts()
    {
        SqlDataAdapter ad;
        if (ddlSubcategory.SelectedItem.Value != "0")
            ad = new SqlDataAdapter("select * from productmaster where subcatid=" + ddlSubcategory.SelectedItem.Value , con);
        else
            ad = new SqlDataAdapter("select * from productmaster", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        dlProducts.DataSource = ds;
        dlProducts.DataBind();
    }
    protected void lnkProduct_Click(object sender, EventArgs e)
    {

    }
    protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Response.Redirect("productdetails.aspx?productid=" + e.CommandArgument);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategory();
    }
    public void bindCategory()
    {
        SqlDataAdapter ad = new SqlDataAdapter("select * from categorymaster", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        ddlCategory.DataValueField = "catid";
        ddlCategory.DataTextField = "catname";
        ddlCategory.DataSource = ds;
        ddlCategory.DataBind();

        ddlCategory.Items.Insert(0, new ListItem("--Select Category", "0"));
        ddlSubcategory.Items.Insert(0, new ListItem("--Select SubCategory", "0"));
    }
    public void BindSubCategory()
    {
        SqlDataAdapter ad = new SqlDataAdapter("select * from SubCategoryMaster where catid=" + ddlCategory.SelectedItem.Value + "", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        ddlSubcategory.DataValueField = "subcatid";
        ddlSubcategory.DataTextField = "subcatname";
        ddlSubcategory.DataSource = ds;
        ddlSubcategory.DataBind();

        ddlSubcategory.Items.Insert(0, new ListItem("--Select Sub-Category", "0"));
    }
    protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindProducts();
    }
    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewproducts.aspx");
    }
}