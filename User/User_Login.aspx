<%@ Page Title="" Language="C#" MasterPageFile="~/User/Mst_User.master" AutoEventWireup="true" CodeFile="User_Login.aspx.cs" Inherits="User_User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 

    <br />
    <br />
    <center>
     <a class="ken_header">USER LOGIN</a>
        </center>
    <br />
    <br />
    <br />
        <center>
    <table cellspacing="12px" id="ken_table" width="30%">
        <tr>
            <td>         
                 <asp:Label ID="lblEMail" runat="server" Text="Email :" Font-Names="Buxton Sketch"></asp:Label>  
                 <br />
                 
                <asp:TextBox  width="100%" ID="txtEmail" runat="server" BackColor="White" BorderColor="#3A5795" ForeColor="Black"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label   ID="lblPassword" runat="server" Text="Password :" Font-Names="Buxton Sketch"></asp:Label>
                <br />
             
                <asp:TextBox  width="100%" ID="txtPassword" runat="server" TextMode="Password" BackColor="White" BorderColor="#3A5795"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                <center>
          <p>
    <br />
            <asp:Button CssClass="bt"  ID="btLogIn" runat="server" OnClick="btLogIn_Click"  Text="LOGIN"  Width="80%"  />
          </p>
                </center>
            </td>
        </tr>
    </table>
        </center>
</asp:Content>

