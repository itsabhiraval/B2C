<%@ Page Title="" Language="C#" MasterPageFile="~/User/Mst_User.master" AutoEventWireup="true" CodeFile="productdetails.aspx.cs" Inherits="User_productdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <font color="Black" size="2">
        <center>
                <a class="ken_header">PRODUCT DETAIL</a>
    <table cellspacing="9px" id="ken_tableReg">
        <tr>
            <td>
    <asp:Image runat="server" ID="imgProduct" Width="200px" />
            </td>
            <td</td>
        </tr>
        <tr>
            <td>
                Product Name:-
            </td>
            <td>
        <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
             </td>
        </tr>
        <tr>
            <td>
                Price:-
            </td>
            <td >
                <asp:Label ID="lblPrice" runat="server" Text="Price :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                     Product Description:-
            </td>
            <td>
                <asp:Label ID="lblDescription" runat="server" Text="Description :"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        
    </table><table cellspacing="10">
            <tr>
                <th><u><font size="5" color="black">Seller Information:-</font></u></th>
            </tr>  
            <tr>
                <td>
                    <center>
                    Seller Name:-
                        </center>
                </td>
                <td>
                    <asp:Label ID="lblSellerName" runat="server" Text="Seller Name : "></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                    <center>
                    Address:-</center>
                </td>
                <td>
                    <asp:Label ID="lblSellerAddress" runat="server" Text="Address : "></asp:Label>
                </td>
            </tr>
            <tr>
                <td><center>
                    Email:-</center>
                </td>
                <td>
                    <asp:Label ID="lblSellerEmail" runat="server" Text="Email : "></asp:Label>
                </td>
            </tr>
            <tr>
                <td><center>
                    Contact:-</center>
                </td>
                <td>
                    <asp:Label ID="lblSellerNumber" runat="server" Text="Phone Number : "></asp:Label>
                </td>
            </tr>
        </table>
            <asp:Button CssClass="bt"  ID="btnSendReq" runat="server" Text="Send Request" OnClick="btnSendReq_Click" />
            </center>   
         </font>

</asp:Content>

