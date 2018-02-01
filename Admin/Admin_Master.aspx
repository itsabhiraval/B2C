<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin_Master.aspx.cs" Inherits="Admin_Admin_Master" %>


<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div>

        <center>
            <br />
            <a class="ken_header">ADMIN REGISTRATION</a>
            <br />
            <br />      

             <asp:MultiView ID="multiAdmin_master" runat="server" ActiveViewIndex="0">
                 <asp:View ID="view1" runat="server">
                       <table cellspacing="9px"  id="ken_tableReg">
                           <tr>
                               <td>
                                  Firstname:
                               </td> 
                               <td>
                                  <asp:TextBox ID="txtBoxFrstName" runat="server" ></asp:TextBox> 
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="Enter Firstname" ToolTip="Required" ForeColor="Red"  ControlToValidate="txtBoxFrstName" ValidationGroup="valGp1" > 
                                   </asp:RequiredFieldValidator>
                               </td>
                           </tr>
                            <tr>
                               <td>
                                  Lastname:
                               </td>
                                <td>
                                     <asp:TextBox ID="txtBoxLstName" runat="server" ></asp:TextBox>  
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Enter Lastname" ToolTip="Required" ForeColor="Red" ErrorMessage="Enter Lastname" ControlToValidate="txtBoxLstName" ValidationGroup="valGp1" > 
                                   </asp:RequiredFieldValidator>
                                </td>
                           </tr> 
                           <tr>
                               <td>
                                   Gender:
                               </td>
                                <td>
                                    <asp:RadioButton ID="rdButtonMale" runat="server" Text="Male" GroupName="gender" />
                                    <asp:RadioButton ID="rdButtonFemale" runat="server" Text="Female" GroupName="gender" />
                                </td>
                           </tr>
                            <tr>
                               <td>
                                   Address:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Country:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddCountry" runat="server" DataTextField="--Select Country--" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   State:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddState" runat="server" DataTextField="--Select State--" OnSelectedIndexChanged="ddState_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                 </td>
                           </tr>
                            <tr>
                               <td>
                                   City:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddCity" runat="server" DataTextField="--Select Country--"></asp:DropDownList>
                                 </td>
                           </tr>
                            <tr>
                               <td>
                                   Email:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxEmail" runat="server" ></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ToolTip="Required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtBoxEmail" ValidationGroup="valGp1"></asp:RegularExpressionValidator>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Username:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxUsrName" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Password:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxPassword" runat="server" TextMode="Password" ></asp:TextBox>
                                 </td>
                           </tr>
                            <tr>
                               <td>
                                   Mobile No:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxMobile" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Department Name:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddDept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddDept_SelectedIndexChanged1" ></asp:DropDownList>                                   
                                     </td>
                           </tr>
                           <tr>
                               <td>
                                   Designation Name:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddDesig" runat="server" AutoPostBack="true"></asp:DropDownList>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Joining Date:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxJoiningDate" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Role:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxRole" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                  Status:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxStatus" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                          </table>
                               <center>
                                   <br />
                                  <asp:Button  CssClass="bt" ID="btnSubmit" runat="server" text="Insert" OnClick="btnSubmit_Click" ValidationGroup="valGp1" />
                 
                                  <asp:Button  CssClass="bt" ID="btnGoToTable" runat="server" text="GridView" OnClick="btnbtnGoToTable_Click" CauseValidation="False" />
                                   </center>
                     </asp:View>
                 <asp:View ID="view2" runat="server">
                         <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gvAdminUsers" runat="server" OnRowCommand="gvAdminUsers_RowCommand" AutoGenerateColumns="false">
                          <Columns>
                              <asp:BoundField HeaderText="Firstname" DataField="Firstname" />
                              <asp:BoundField HeaderText="Lastname" DataField="Lastname" />
                              <asp:BoundField HeaderText="Username" DataField="Username" />
                              <asp:BoundField HeaderText="Gender"   DataField="Gender" />
                              <asp:BoundField HeaderText="Address"  DataField="Address" />
                              <asp:BoundField HeaderText="Email"   DataField="Email" />
                              <asp:BoundField HeaderText="MobileNo" DataField="Mobile" />
                              <asp:TemplateField HeaderText="Edit">
                                  <ItemTemplate>
                                     <asp:LinkButton ID="linkEdit" Text="Edit" runat="server" CommandArgument= '<%#Eval("AdminId")%>' CommandName="edt">
                                      </asp:LinkButton>                                       
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Delete">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="linkDelete" Text="Delete" runat="server"  CommandArgument='<%#Eval("AdminId")%>' CommandName="dlt">
                                          </asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                     <br /><br /><br />
                     <asp:Button CssClass="bt" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                     </asp:View>
                 </asp:MultiView>
                    </center>
    </div>
</asp:Content>
