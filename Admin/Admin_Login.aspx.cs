using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Login : System.Web.UI.Page
{

       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btLogIn_Click(object sender, EventArgs e)
    {
        SqlDataAdapter ad = new SqlDataAdapter("Select * from Adminusers where Email='" + txtEmail.Text + "' and Password='" + txtPassword.Text + "'", con);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["Email"] = txtEmail.Text;
            Response.Redirect("Category.aspx");
        }
        else
            Response.Write("<script>alert('Enter Valid Email & Password')</script>");
    }
}