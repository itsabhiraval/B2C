<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Admin_Department" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <center> 
             <br />
       <br />
            <a class="ken_header">DEPARTMENT</a>
            <br /> 
             
     <asp:MultiView ID="multiDepartment" runat="server" ActiveViewIndex="0">

                 <asp:View ID="view1" runat="server">
                     
                      <br />
                       <table  cellspacing="9px" id="ken_tableReg">
                           <tr>
                               <td>
                                  Department Name:
                               </td> 
                               <td>
                                  <asp:TextBox ID="txtBoxDeptName" runat="server" ></asp:TextBox> 
                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" Text="*" ToolTip="Required Name" ForeColor="Red" ControlToValidate="txtBoxDeptName">
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
                    
                                  <asp:Button CausesValidation="False" CssClass="bt" runat="server" ID="btnGoToTbl" Text="GridView" OnClick="btnGoToTbl_Click"/>
                    </center>   
                          
                          </asp:View>                   
                    </div>
           
                
                <asp:View ID="view2" runat="server">
                    <center>
                            <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gvDepartment" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDepartment_RowCommand">
                                <Columns>
                                     <asp:BoundField HeaderText="DepartmentName" DataField="DeptName" />
                                     <asp:BoundField HeaderText="Description" DataField="Description" />
                                     <asp:BoundField HeaderText="Status" DataField="Status" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("DeptId") %>' CommandName="edt">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Delete">
                                           <ItemTemplate>
                                               <asp:LinkButton ID="linkDelete" Text="Delete" runat="server" CommandArgument='<%#Eval("DeptId")%>' CommandName="dlt">
                                                 </asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    <br /><br /><br />
                    <asp:Button CssClass="bt" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </center>
                    </asp:View>
        </asp:MultiView>
</asp:Content>
