<%@ Page Title="" Language="C#" MasterPageFile="~/User/Mst_User.master" AutoEventWireup="true" CodeFile="ViewProducts.aspx.cs" Inherits="User_ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <center>

        <br />
    <a style="font-size:45px;font-family:'Myriad Pro Light';">VIEW PRODUCT</a>
<br />
        <br />
    <table id="ken_tableReg" cellspacing="9px">
        <tr>
            <td>
                Category:
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td>
                SubCategory:
            </td>
            <td>
                <asp:DropDownList ID="ddlSubcategory" runat="server" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td>

                <asp:Button CssClass="bt"  ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            </td>
        </tr>
    </table>
        </center>
    <asp:DataList ID="dlProducts" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" OnItemCommand="dlProducts_ItemCommand" Font-Names="Verdana" Font-Size="Small" Width="600px">
        <ItemStyle ForeColor="Black"/>
        <ItemTemplate>
            <div id="pricePlans">
                <ul id="plans">
                    <li class="plan">
                        <ul class="planContainer">
                            <li class="button">
                                <asp:LinkButton ID="lnkProduct" runat="server" CommandArgument='<%#Eval("productid") %>'>
                                </asp:LinkButton>
                            </li>
                            <li class="title">
                                <asp:Image ID="imgProducts" runat="server" Width="200px" ImageUrl='<%#Eval("product_image","~/Product_Images/{0}") %>' />
                            </li>

                            <ul class="button">
                                <li><span>
                                    <asp:Label ID="lblproductname" runat="server" Text='<%#Eval("productname") %>'>
                                    </asp:Label><br />
                                </span></li>
                                <li><span>Rs:
                 <asp:Label ID="lblprice" runat="server" Text='<%#Eval("price") %>'>
                 </asp:Label>
                                </span></li>
                            </ul>
                        </ul>
                    </li>
                </ul>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

