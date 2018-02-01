using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class User_Mst_User : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static string UserType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select * from registermaster where userid=" + Session["UserId"] + "", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                if (UserType == "Seller")
                {
                    lnkpro.Visible = true;
                }
                else
                {
                    lnkpro.Visible = false;
                }
                lblUser.Text = "Welcome " + ds.Tables[0].Rows[0]["firstname"].ToString();
            }
        }
        else
        {
            btnLogout.Text = "Login";
            lnkpro.Visible = false;
        }

    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        lnkpro.Visible = false;

        lblUser.Text = "Welcome Guest"; Response.Redirect("user_login.aspx");
    }
}
