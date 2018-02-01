<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Advertisement.aspx.cs" Inherits="Admin_Advertisement" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
    <br />
    <a class="ken_header">ADVERTISEMENT</a>
    <br />
    <br />

      <asp:MultiView ID="multiAdvertisment" runat="server" ActiveViewIndex="0">
         <asp:View ID="view1" runat="server">
             <center>
         <table cellspacing="9px" id="ken_tableReg">
          <tr>
              <td><asp:Label ID="lblSubject" Text="Subject : " runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="reqSubject" runat="server" ControlToValidate="txtSubject" ErrorMessage="Enter Subject" ToolTip="Enter Subject"  ForeColor="red"></asp:RequiredFieldValidator>
              </td>
              
          </tr>
           <tr>
              <td><asp:Label ID="lblContactName" Text="Contact Name : " runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="reqContact" runat="server" ControlToValidate="txtContactName"  ErrorMessage="Enter Contact Name" ToolTip="Enter Contact Name"  ForeColor="red"></asp:RequiredFieldValidator>
              </td>
          </tr>
           <tr>
              <td><asp:Label ID="lblEmail" text="Email : " runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Must Have To Enter Email" ToolTip="Must Have To Enter Email"  ForeColor="red"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="regularEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"  ErrorMessage="Enter Particular Email" ToolTip="Enter Particular Email" ForeColor="red"/>
              </td>
          </tr>
           <tr>
              <td><asp:Label ID="lblImage" Text="Image" runat="server"></asp:Label></td>
              <td><asp:FileUpload ID="uploadImage" runat="server" />
              <asp:Image ID="Image_Add" runat="server" Height="150px" Visible="false" />
              </td>
          </tr>
           <tr>
              <td><asp:Label ID="lblContactNo" Text="Contact No :" runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="reqContactNo" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Must Have To Enter Number" ToolTip="Must Have To Enter Number"  ForeColor="red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="regularContactNo" runat="server" ValidationExpression="[0-9]{10}" ControlToValidate="txtContactNo"  ErrorMessage="Enter Particular Number" ToolTip="Enter Particular Number" ForeColor="red"/>
              </td>
          </tr>
           <tr>
              <td><asp:Label ID="lblAddress" Text="Address : " runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtAddress"  ErrorMessage="Enter Address" ToolTip="Enter Address"  ForeColor="red"></asp:RequiredFieldValidator>
              </td>
          </tr>
           <tr>
              <td><asp:Label ID="lblDescription" Text="Description : " runat="server"></asp:Label></td>
              <td><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="txtDescription"  ErrorMessage="Enter Description" ToolTip="Enter Description"  ForeColor="red"></asp:RequiredFieldValidator>
              </td>
          </tr>
      </table>
      </center>
      <br />
                <br />
      <asp:Button  CssClass="bt" ID ="btSubmit" Text="Submit" runat="server" OnClick="btSubmit_Click" />
      <asp:Button CssClass="bt" ID="btGridView" runat="server" Text="GridView" OnClick="btGridView_Click" CausesValidation="false" />
     </asp:View>
      <br />
      <br />
          <asp:View ID="view2" runat="server">
      <br />
      <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gridAdvertisement" runat="server" AutoGenerateColumns="false" OnRowCommand="gridAdvertisement_RowCommand">
          <Columns>
              <asp:BoundField HeaderText="Add_ID" DataField="Add_id" />
              <asp:BoundField HeaderText="Subject" DataField="Subject" />
              <asp:BoundField HeaderText="Contact Name" DataField="ContactName" />
              <asp:BoundField HeaderText="Email" DataField="Email" />
              <asp:TemplateField HeaderText="Image" >
                    <ItemTemplate>
                        <asp:Image ID="Adve_Image" runat="server" ImageUrl='<%#Eval("Add_Img","~/Advertisement_Images/{0}") %>' Height="150px" />
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:BoundField HeaderText="Contact No" DataField="ContactNo" />
              <asp:BoundField HeaderText="Address" DataField="Address" />
              <asp:BoundField HeaderText="Description" DataField="Description" />
              <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkEdit" Text="Edit" runat="server"  Width="100px" CommandName="edt" CommandArgument='<%#Eval("Add_Id")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDelete" Text="Delete" runat="server" Width="100px" CommandName="dlt" CommandArgument='<%#Eval("Add_Id")%>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
          </Columns>
      </asp:GridView>
              <br />
              <br />
              <asp:Button CssClass="bt" ID="btInsert" Text="Insert" runat="server" OnClick="btInsert_Click" />
              </asp:View>
          </asp:MultiView>
    </center>
</asp:content>
<%-- Add content controls here --%>
