<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Category" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center> 
    <br />
    <a class="ken_header">CATEGORY</a>
    <br />
    <br />   
         <br />   
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
    <table cellspacing="9px" id="ken_tableReg">
        <tr>
            <td><asp:Label ID="lblCatName" Text="Category Name : " runat="server"></asp:Label></td>
            <td><asp:TextBox ID="txtCatName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqCatName" runat="server" ControlToValidate="txtCatName" ErrorMessage="Enter Category Name" ToolTip="Enter Category Name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescription" Text="Description" runat="server"></asp:Label></td>
            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Enter The Description" ToolTip="Enter The Description" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblImage" Text="Image : " runat="server"></asp:Label></td>
            <td><asp:FileUpload ID="uploadImage" runat="server" />
                <asp:Image ID="imageGet" runat="server" Height="150px" Visible="false" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblStatus" Text="Status : " runat="server"></asp:Label></td>
            <td><asp:RadioButton ID="radioActive" Text="Active" GroupName="a1" runat="server" />
                <asp:RadioButton ID="radioDeactive" Text="Deactive" GroupName="a1" runat="server" />
            </td>
        </tr>
    </table>
        <br />
                <br />
        <asp:Button CssClass="bt" ID="btSubmit" Text="Submit" runat="server" OnClick="btSubmit_Click" />
                <asp:Button CssClass="bt" ID="btGridview" Text="Gridview" runat="server" OnClick="btGridview_Click" CausesValidation="false" />
                </asp:View>
            <asp:View ID="View2" runat="server">
        <br />
        <br />
        <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gridCategory" runat="server" AutoGenerateColumns="False" OnRowCommand="gridCategory_RowCommand"   >
            <Columns>
                <asp:BoundField HeaderText="CatID" DataField="CatID"/>
                <asp:BoundField HeaderText="Category Name" DataField="CatName" />
                <asp:BoundField HeaderText="Description" DataField="Description" />
                <asp:TemplateField HeaderText="Image" >
                    <ItemTemplate>
                        <asp:Image ID="Cat_Image" runat="server" ImageUrl='<%#Eval("Image","~/Category_Images/{0}") %>' Height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="linlEdit" Text="Edit" runat="server"  Width="100px" CommandName="edt" CommandArgument='<%#Eval("CatId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" Text="Delete" runat="server" Width="100px" CommandName="dlt" CommandArgument='<%#Eval("CatId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        </asp:GridView>
                <br /><br />
                <asp:Button CssClass="bt" ID="btInsert" runat="server" Text="Insert"  OnClick="btInsert_Click"/>
                 </asp:View>
            </asp:MultiView>
        </center>



</asp:Content>

<%-- Add content controls here --%>
