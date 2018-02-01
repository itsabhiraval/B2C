<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="Admin_City" %>
<asp:Content ID="content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<%-- Add content controls here --%>
    <div>
        <center>
             <br />
            <a class="ken_header" >CITY</a>
            <br />
            <br />  
                        <br />
            <asp:MultiView ID="multiCity" runat="server" ActiveViewIndex="0">
                <asp:View ID="view1" runat="server">
            <table cellspacing="9px" id="ken_table">
                <tr>
                    <td>
                        <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblState" runat="server" Text="State" AutoPostBack="true"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddState" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text="Enter City:-"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rbActive" runat="server" Text="Active" GroupName="City"></asp:RadioButton>
                        <asp:RadioButton ID="rbDeactive" runat="server" Text="Deactive" GroupName="City"></asp:RadioButton>
                    </td>
                </tr>
                 </table>
            <br />
            <br />
                        <asp:Button CssClass="bt" ID="btnCity" runat="server" OnClick="btnCity_Click" Text="Submit"></asp:Button>
                        <asp:Button CssClass="bt" ID="btGridview" runat="server"    OnClick="btGridview_Click" Text="Gridview" />
                </asp:View>
                <asp:View runat="server" ID="view2">
            <asp:GridView  CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows"
 ID="gvCity" runat="server"></asp:GridView></br></br>
                   <asp:Button ID="btBack" Text="Insert" CssClass="bt" runat="server" OnClick="btBack_Click"/>
                    </asp:View> 

                </asp:MultiView>
        </center>
    </div>
 </asp:Content>
