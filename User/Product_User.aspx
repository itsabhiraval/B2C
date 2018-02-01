<%@ Page Title="" Language="C#" MasterPageFile="~/User/Mst_User.master" AutoEventWireup="true" CodeFile="Product_User.aspx.cs" Inherits="User_Product_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center>
         <br />
    <br />
     <a class="ken_header" style="font-size:45px;font-family:'Myriad Pro Light';" >USER PRODUCTS</a>
    <br />
            <br />
    <table  cellspacing="9px" id="ken_tableReg" >
        <tr>
            <td width="250px"><asp:Label ID="lblCategory" runat="server" Text="Category : "></asp:Label></td>
            <td><asp:DropDownList ID="dropCategory" runat="server" OnSelectedIndexChanged="dropCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblSubCategory" runat="server" Text="Sub-Category : "></asp:Label></td>
            <td><asp:DropDownList ID="dropSubCategory" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblProduct" runat="server" Text="Product Name : "></asp:Label></td>
            <td><asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
                <ajaxToolkit:TextBoxWatermarkExtender ID="txt1" runat="server" Enabled="true" TargetControlID="txtProduct" WatermarkText="Enter Product Name" WatermarkCssClass="txtwatermark" />
                              
            <asp:RequiredFieldValidator ID="reqProduct" runat="server" ControlToValidate="txtProduct" ForeColor="Red" ErrorMessage="Enter The Product Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescryption" runat="server" Text="Description : "></asp:Label></td>
            <td><asp:TextBox ID="txtDescryption" runat="server" TextMode="MultiLine" Height="200px" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescyption" runat="server" ControlToValidate="txtDescryption" ForeColor="Red" ErrorMessage="Enter The Description"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label></td>
            <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="true" TargetControlID="txtPrice" WatermarkText="Enter Product Price" WatermarkCssClass="txtwatermark" />
              <asp:RequiredFieldValidator ID="reqPrice" runat="server" ControlToValidate="txtPrice" ForeColor="Red" ErrorMessage="Enter The Price Of Product"></asp:RequiredFieldValidator>  
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblQuantities" runat="server" Text="Quantities"></asp:Label></td>
            <td><asp:TextBox ID="txtQuantities" runat="server"></asp:TextBox>
             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="true" TargetControlID="txtQuantities" WatermarkText="Enter Product Quantity" WatermarkCssClass="txtwatermark" />   
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
        <asp:Button CssClass="bt"  ID="btSubmit" Text="Submit" runat="server" OnClick="btSubmit_Click" />
 
        
    </center>
</asp:Content>

