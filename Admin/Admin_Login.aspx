<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Admin_Login" %>
<asp:Content ID="containt1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <center>
     <br />
    <br />
     <a class="ken_header">ADMIN LOGIN</a>
    <br />
         <br />
    <br />
         <br />
  
    <form id="form1">
    <table cellspacing="9px" id="ken_table" width="32%">
        <tr>
            <td>         
                 <asp:Label ID="lblEMail" runat="server" Text="Email : " Font-Names="Buxton Sketch" ></asp:Label>  
                 <br />
           
                <asp:TextBox width="100%" ID="txtEmail" runat="server"  BackColor="White" BorderColor="#3A5795" ForeColor="Black"></asp:TextBox>
                <%--<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="true" TargetControlID="txtEmail" WatermarkText="Enter Your Email" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password : " Font-Names="Buxton Sketch" ></asp:Label>
                <br />
               
                <asp:TextBox width="100%" ID="txtPassword" runat="server" TextMode="Password"  BackColor="White" BorderColor="#3A5795" ></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td>
                <center>
          <p>
       <br />
            <asp:Button CssClass="bt"  ID="btLogIn" runat="server" OnClick="btLogIn_Click" Text="LOGIN" Width="80%" />
          </p>
                </center>
            </td>
        </tr>
    </table>
        
    </form>
        </center>
    </asp:Content>
      
<%-- Add content controls here --%>
