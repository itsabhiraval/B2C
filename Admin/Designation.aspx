<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Designation.aspx.cs" Inherits="Admin_Designation" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    
    <div >
         
           
               <Center> 
             <br />
            <a class="ken_header" >DESIGNATION</a>
            <br />
            <br />  
                    <br /> 
                   <asp:MultiView ID="multiDesig" runat="server" ActiveViewIndex="0"> 
                       <asp:View id="view1" runat="server"> 
                       <table  cellspacing="9px" id="ken_tableReg" >
                           <tr>
                               <td>
                                  Department:
                               </td>
                                <td>
                                     <asp:DropDownList ID="ddDept" runat="server" ></asp:DropDownList>  
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" Text="*" ToolTip="Required" ForeColor="Red" ControlToValidate="ddDept">
                                   </asp:RequiredFieldValidator> 
                                </td>
                           </tr>
                           <tr>
                               <td>
                                  Designation:
                               </td> 
                               <td>
                                  <asp:TextBox ID="txtBoxDesigName" runat="server" ></asp:TextBox>  
                                   <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" Text="*" ToolTip="Required" ForeColor="Red" ControlToValidate="txtBoxDesigName">
                                   </asp:RequiredFieldValidator> 
                               </td>
                           </tr>
                            <tr>
                               <td>
                                  Description:
                               </td>
                                <td>
                                     <asp:TextBox ID="txtBoxDesc" runat="server" TextMode="MultiLine"></asp:TextBox>  
                                </td>
                           </tr> 
                            <tr>
                               <td>
                                  Status:
                               </td>
                                <td>
                                     <asp:TextBox ID="txtBoxStatus" runat="server"  ></asp:TextBox>  
                                </td>
                           </tr>
                           <tr>
                               </table>
                                   </center>
               <br /><br />
               <center>
                                  
                                  <asp:Button CssClass="bt" runat="server" ID="btnInsert" Text="Submit"  OnClick="btnInsert_Click"/>
                                  
                                  <asp:Button  CssClass="bt" runat="server" ID="btnUpdate" Text="Update"  OnClick="btnUpdate_Click" />
  
                                  <asp:Button CausesValidation="False" CssClass="bt" runat="server" ID="btn" Text="GoTo Table"   OnClick="btnGoToTable_Click" />
  
                    </center>
               </asp:View>
             <asp:View id="view2" runat="server">
                <center>
                           <asp:GridView CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gvDesig" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDesig_RowCommand">
                               <Columns>
                                    <asp:BoundField HeaderText="DesigName" DataField="DesigName" />
                                     <asp:BoundField HeaderText="Description" DataField="Description" />
                                     <asp:BoundField HeaderText="Status" DataField="Status" />
                                   <asp:BoundField HeaderText="Department" DataField="DeptName" />
                                   <asp:TemplateField HeaderText="Edit">
                                       <ItemTemplate>
                                           <asp:LinkButton Text="Edit" ID="linkEdit" runat="server" CommandName="edt" CommandArgument='<%#Eval("DesigId") %>'></asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Delete">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="linkDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("DesigId") %>'></asp:LinkButton> 
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                 <br /><br /><br />
                 <asp:Button  CssClass="bt"  id="btnBack" runat="server" text="Back" OnClick="btnBack_Click" />
                    </center>
                 </asp:View>
                     </div>
                   </asp:MultiView>
</asp:Content>