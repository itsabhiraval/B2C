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

public partial class Admin_Advertisement : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
    static string radio_status = "";
    static string Image_Advertisement = "";
    static int Add_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Clear_Data();
            BindGrid();
        }

    }

    public void BindGrid()
    {
        SqlCommand cmd = new SqlCommand("SELECT_ADVERTISMENT", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        gridAdvertisement.DataSource = ds;
        gridAdvertisement.DataBind();
    }
    public void Clear_Data()
    {
        txtAddress.Text = "";
        txtContactName.Text = "";
        txtSubject.Text = "";
        txtDescription.Text = "";
        txtEmail.Text = "";
        txtContactNo.Text = "";
        uploadImage.Attributes.Clear();

    }

    protected void gridAdvertisement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Add_id = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "edt")
        {

            SqlCommand cmd = new SqlCommand("GET_ADVERTISEMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ADDID", Add_id);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            txtSubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            txtContactName.Text = ds.Tables[0].Rows[0]["contactname"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            string Add_image = ds.Tables[0].Rows[0]["add_img"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["contactno"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();

            Image_Add.ImageUrl = "~/Advertisement_Images/" + Add_image;

            Image_Add.Visible = true;
            multiAdvertisment.ActiveViewIndex = 0;
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE_ADVERTISMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ADDID", Add_id);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
        }
       
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        if (uploadImage.HasFile)
        {
            string str = Path.GetExtension(uploadImage.FileName);

            if (str == ".jpg" || str == ".png" || str == ".gif")
            {
                Image_Advertisement = uploadImage.FileName;
                uploadImage.SaveAs(Server.MapPath("~/Advertisement_Images/" + Image_Advertisement));
            }
            else
                Response.Write("<script>alert('Select Valid File')</script>");
        }
        else
        {
            Response.Write("<script>alert('Please Selct Image')</script>");
            return;
        }

        SqlCommand cmd;


        if (Add_id > 0)
        {
            cmd = new SqlCommand("UPDATE_ADVERTISMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ADDID", Add_id);
        }
        else
        {
            cmd = new SqlCommand("INSERT_ADVERTISMENT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
        }

        cmd.Parameters.AddWithValue("@SUBJECT", txtSubject.Text);
        cmd.Parameters.AddWithValue("@CONTACTNAME", txtContactName.Text);
        cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
        cmd.Parameters.AddWithValue("@ADDIMAGE", Image_Advertisement);
        cmd.Parameters.AddWithValue("@CONTACTNO", txtContactNo.Text);
        cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Text);
        cmd.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text);
        cmd.ExecuteNonQuery();
        con.Close();

        multiAdvertisment.ActiveViewIndex = 1;
        BindGrid();
        Clear_Data();
    }
    protected void btGridView_Click(object sender, EventArgs e)
    {
        multiAdvertisment.ActiveViewIndex = 1;
    }
    protected void btInsert_Click(object sender, EventArgs e)
    {
        multiAdvertisment.ActiveViewIndex = 0;
    }
}