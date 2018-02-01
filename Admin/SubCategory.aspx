<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="SubCategory.aspx.cs" Inherits="Admin_SubCategory" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <br />
        <a class="ken_header">SUB-CATEGORY</a>
        <br />
        <br />
        <asp:MultiView ID="MultiSubCategory" runat="server" ActiveViewIndex="0">
            <asp:View ID="view1" runat="server">
        <br />
        <br />
    <table  cellspacing="9px" id="ken_tableReg" >
        <tr>
            <td><asp:Label ID="lblCategory" Text="Category : " runat="server"></asp:Label></td>
            <td><asp:DropDownList ID="dropCategory" runat="server" ></asp:DropDownList></td>
        </tr>
          <tr>
            <td><asp:Label ID="lblSubCategoryName" Text="Sub-Category Name :" runat="server"></asp:Label></td>
            <td><asp:TextBox ID="txtSubCategory" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqSubCategory" runat="server" ControlToValidate="txtSubCategory" ForeColor="Red" ErrorMessage="Enter The Sub-Category"></asp:RequiredFieldValidator>  
            </td>
        </tr>
          <tr>
            <td><asp:Label ID="lblDescription" Text="Description" runat="server"></asp:Label></td>
            <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqDecription" runat="server" ControlToValidate="txtDescription" ForeColor="Red" ErrorMessage="Enter The Descryption about Sub-Category"></asp:RequiredFieldValidator>  
            </td>
        </tr>
          <tr>

            <td><asp:Label ID="lblImage" Text="Image : " runat="server"></asp:Label></td>
            <td><asp:FileUpload ID="uploadImage" runat="server" />
                <asp:Image ID="imageSubCat" runat="server" Height="150px" Visible="false" />
            </td>
        </tr>
          <tr>
            <td><asp:Label ID="lblStatus" Text="Status : " runat="server"></asp:Label></td>
            <td><asp:RadioButton ID="radioActive" Text="Active" GroupName="a1" runat="server" />
                <asp:RadioButton ID="radioDeactive" Text="Deactive" GroupName="a1" runat="server" /></td>
        </tr>
    </table>
        <br />
                <br />
        <asp:Button CssClass="bt" ID="btSubmit" Text="Submit" runat="server" OnClick="btSubmit_Click"/> 
        <asp:Button CssClass="bt" ID="btGridView" Text="GridView" runat="server" OnClick="btGridView_Click" CausesValidation="false" />
        </asp:View>
            <asp:View ID="view2" runat="server">                 
        <br />
        <br />
        <br />               
        <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gridSubCat" runat="server" AutoGenerateColumns="false" OnRowCommand="gridSubCategory_RowCommand">
           <Columns>
               <asp:BoundField HeaderText="SubCatID" DataField="SubCatID" />
               <asp:BoundField HeaderText="CatId" DataField="CatId" />
               <asp:BoundField HeaderText="Category Name" DataField="CatName" />
               <asp:BoundField HeaderText="Sub-Category Name" DataField="SubCatName" />
               <asp:BoundField HeaderText="Description" DataField="Description" />
              <asp:TemplateField HeaderText="Image" >
                    <ItemTemplate>
                        <asp:Image ID="Cat_Image" runat="server" ImageUrl='<%#Eval("Image","~/SubCategory_Images/{0}") %>' Height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" Text="Edit" runat="server"  Width="100px" CommandName="edt" CommandArgument='<%#Eval("SubCatId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" Text="Delete" runat="server" Width="100px" CommandName="dlt" CommandArgument='<%#Eval("SubCatId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
           </Columns>
        </asp:GridView>             
            <br />
            <br />
        <asp:Button CssClass="bt" id="btInsert" runat="server"  text="Insert" OnClick="btInsert_Click"/>
        </asp:View>
            </asp:MultiView>
    </center>
</asp:Content>
<%-- Add content controls here --%>
