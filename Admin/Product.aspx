<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <center>
       <br />
       <a class="ken_header">PRODUCT</a>
     <asp:MultiView ID="multiProduct" runat="server" ActiveViewIndex="0">
        <asp:View ID="view1" runat="server">
            <br />
            <br />
    <table  cellspacing="9px" id="ken_tableReg">
        <tr>
            <td><asp:Label ID="lblCategory" runat="server" Text="Category : "></asp:Label></td>
            <td><asp:DropDownList ID="dropCategory" runat="server" OnSelectedIndexChanged="dropCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblSubCategory" runat="server" Text="Sub-Category : "></asp:Label></td>
            <td><asp:DropDownList ID="dropSubCategory" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblProduct" runat="server" Text="Product Name : "></asp:Label></td>
            <td><asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqProduct" runat="server" ControlToValidate="txtProduct" ForeColor="Red" ErrorMessage="Enter The Product Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescryption" runat="server" Text="Descryption : "></asp:Label></td>
            <td><asp:TextBox ID="txtDescryption" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescyption" runat="server" ControlToValidate="txtDescryption" ForeColor="Red" ErrorMessage="Enter The Descryption"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label></td>
            <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="reqPrice" runat="server" ControlToValidate="txtPrice" ForeColor="Red" ErrorMessage="Enter The Price Of Product"></asp:RequiredFieldValidator>  
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblQuantities" runat="server" Text="Quantities"></asp:Label></td>
            <td><asp:TextBox ID="txtQuantities" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqQuantities" runat="server" ControlToValidate="txtQuantities" ForeColor="Red" ErrorMessage="Enter The Quantity of Product"></asp:RequiredFieldValidator>  
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblImage" runat="server" Text="Product Image : "></asp:Label></td>
            <td><asp:FileUpload ID="uploadImage" runat="server"></asp:FileUpload>
                <asp:Image ID="imageProduct" runat="server" Height="150px" Visible="false" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblStatus" runat="server" Text="Status : "></asp:Label></td>
            <td><asp:RadioButton ID="radioActive" runat="server" Text="Active" GroupName="a1"></asp:RadioButton>
                <asp:RadioButton ID="radioDeactive" runat="server" Text="Deactive" GroupName="a1"></asp:RadioButton>
            </td>
        </tr>
    </table>
     <br />
            <br />
        <asp:Button CssClass="bt" ID="btSubmit" Text="Submit" runat="server" OnClick="btSubmit_Click" />
        <asp:Button CssClass="bt" CausesValidation="false" ID ="btGridview" Text="GridView" runat="server" OnClick="btGridview_Click" />
 
        </asp:View>
        <asp:View ID="view2" runat="server">
            <br />
          
     <asp:GridView CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gridProduct" runat="server" AutoGenerateColumns="false" OnRowCommand="gridProduct_RowCommand">
         <Columns>
             <asp:BoundField HeaderText="Product ID" DataField="productid" />
             <asp:BoundField HeaderText="Category ID" DataField="CatId" />
             <asp:BoundField HeaderText="Category Name" DataField="CatName" />
             <asp:BoundField HeaderText="Sub-Category ID" DataField="SubCatId" />
             <asp:BoundField HeaderText="Sub-Category Name" DataField="SubCatName" />
             <asp:BoundField HeaderText="Category ID" DataField="catid" />
             <asp:BoundField HeaderText="Sub-Category ID" DataField="subcatID" />
             <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
             <asp:BoundField HeaderText="Description" DataField="Description" />
             <asp:BoundField HeaderText="Price" DataField="Price" />
             <asp:BoundField HeaderText="Quantities" DataField="Quantities" />
             <asp:TemplateField HeaderText="Image" >
                    <ItemTemplate>
                        <asp:Image ID="Product_Image" runat="server" ImageUrl='<%#Eval("Product_Image","~/Product_Images/{0}") %>' Height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Status" DataField="AvailableStatus" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" Text="Edit" runat="server"  Width="100px" CommandName="edt" CommandArgument='<%#Eval("ProductId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" Text="Delete" runat="server" Width="100px" CommandName="dlt" CommandArgument='<%#Eval("ProductId")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
         </Columns>
     </asp:GridView>  
            <br />
            <br />
     <asp:Button CssClass="bt" ID="btInsert" runat="server" Text="Insert" onclick="btInsert_Click"/>  
        </asp:View>
    </asp:MultiView>
    </center>
</asp:Content>
<%-- Add content controls here --%>
