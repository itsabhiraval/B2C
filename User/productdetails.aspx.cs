using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class User_productdetails : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

    static int productid;
    static int sellerid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["productid"] != null)
        {
            productid = Convert.ToInt32(Request.QueryString["productid"]);
        }
        else
        {
            Response.Redirect("viewproducts.aspx");
        }
        BindProductDetails();
    }

    public void BindProductDetails()
    {
        SqlDataAdapter ad = new SqlDataAdapter("select * from productmaster where productid="+productid+"",con);
        DataSet ds= new DataSet();
        ad.Fill(ds);

        productid = Convert.ToInt32(ds.Tables[0].Rows[0]["productid"]);

        imgProduct.ImageUrl = "~/Product_Images/" + ds.Tables[0].Rows[0]["Product_image"].ToString();
        lblProductName.Text = ds.Tables[0].Rows[0]["Productname"].ToString();
        lblPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
        lblDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();



        sellerid = Convert.ToInt32(ds.Tables[0].Rows[0]["userid"]);
        SqlDataAdapter ad1 = new SqlDataAdapter("select * from registerMaster where userid=" + sellerid + "", con);
        DataSet ds1 = new DataSet();
        ad1.Fill(ds1);
        lblSellerName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds1.Tables[0].Rows[0]["Lastname"].ToString();
        lblSellerAddress.Text = ds1.Tables[0].Rows[0]["address"].ToString();
        lblSellerEmail.Text = ds1.Tables[0].Rows[0]["email"].ToString();
        lblSellerNumber.Text = ds1.Tables[0].Rows[0]["contacts"].ToString();
    }
    protected void btnSendReq_Click(object sender, EventArgs e)
    {
        SqlDataAdapter ad1 = new SqlDataAdapter("select * from registerMaster where userid=" + sellerid + "", con);
        DataSet ds1 = new DataSet();
        ad1.Fill(ds1);
        GetBuyerDetails(ds1);
            }
    protected void SendEmail(string toAddress, string subject, string body)
        {
            using (MailMessage mm = new MailMessage("testdummyb2c@gmail.com", toAddress))
            {
                mm.Subject = subject;
                mm.Body = body;
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("testdummyb2c@gmail.com", "Dummy@123#");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }

    void GetBuyerDetails(DataSet ds)
    {
        lblSellerName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString();
        lblSellerAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
        lblSellerEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
        lblSellerNumber.Text = ds.Tables[0].Rows[0]["contacts"].ToString();

        if (Session["userid"] != null)
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from registermaster where userid="+Session["userid"]+"",con);
            DataSet ds1 = new DataSet();
            ad.Fill(ds1);
            SendEmail(ds.Tables[0].Rows[0]["email"].ToString(), "Request From Buyer for Product", "You got Buyer for your product : " + lblProductName.Text + " From " + ds1.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds1.Tables[0].Rows[0]["Lastname"].ToString() + " Email : " + ds1.Tables[0].Rows[0]["email"].ToString() + " Contact No.: " + ds1.Tables[0].Rows[0]["contacts"].ToString());
        }
        else
        {
            Response.Redirect("user_login.aspx");
        }


    }

}