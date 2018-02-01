using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_User_Login : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btLogIn_Click(object sender, EventArgs e)
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select * from RegisterMaster where Email='" + txtEmail.Text + "' and Password='" + txtPassword.Text + "'", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["userid"] = ds.Tables[0].Rows[0]["userid"].ToString();
            if (ds.Tables[0].Rows[0]["UserType"].ToString() == "Seller")
            {
                Response.Redirect("product_user.aspx");
                ((LinkButton)Master.FindControl("lnkpro")).Visible = true;
            }
            else
            {
                Response.Redirect("viewproducts.aspx");

                ((LinkButton)Master.FindControl("lnkpro")).Visible = false;
            }
        }
        else
            Response.Write("<script>alert('Enter Valid Email & Password')</script>");
    }
}