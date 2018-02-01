<%@ Page Title="" Language="C#" MasterPageFile="~/User/Mst_User.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User_User" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <center>
            <br />
    <br />
     <a class="ken_header" style="font-size:45px;font-family:'Myriad Pro Light';" >USER REGISTRATION</a>
    <br />
            <br />
            
            <table cellspacing="9px" id="ken_tableReg">
                <tr>
                    <td>
                        User Type:
                    </td>
                    <td>
                        <asp:RadioButton runat="server" ID="rdButtonSeller" Text="Seller" GroupName="usertype" />
                        <asp:RadioButton runat="server" ID="rdButtonBuyer" Text="Buyer" GroupName="usertype" />
                    </td>
                        </tr>
                         <tr>
                              <td>
                                  Firstname:
                               </td> 
                               <td>
                                  <asp:TextBox ID="txtBoxFrstName" runat="server" ></asp:TextBox>                           
                               </td>
                           </tr>
                            <tr>
                               <td>
                                  Lastname:
                               </td>
                                <td>
                                     <asp:TextBox ID="txtBoxLstName" runat="server" ></asp:TextBox>  
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
                                   Password:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxPassword" runat="server" TextMode="Password" ></asp:TextBox>
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
                        Date Of Birth: 
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoxDOB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal" runat="server" TargetControlID="txtBoxDOB" />
                    </td>
                </tr>
                          <tr>
                               <td>
                                   Contact No: 
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxMobile" runat="server" ></asp:TextBox>
                                 </td>
                           </tr>
                         <tr>
                               <td>
                                   Address:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="Enter Address" ToolTip="Required" ForeColor="Red" ErrorMessage="Enter Address" ControlToValidate="txtBoxAddress" ValidationGroup="valGp1" > 
                                   </asp:RequiredFieldValidator>
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   Country:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddCountry" runat="server" DataTextField="--Select Country--" AutoPostBack="true" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged1"></asp:DropDownList>
                                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="Select Country" ToolTip="Required" ForeColor="Red" ErrorMessage="Enter Address" ControlToValidate="ddCountry" ValidationGroup="valGp1" >--%> 
                                    
                                 </td>
                           </tr>
                           <tr>
                               <td>
                                   State:
                               </td>
                                 <td>
                                     <asp:DropDownList ID="ddState" runat="server" DataTextField="--Select State--" AutoPostBack="true" OnSelectedIndexChanged="ddState_SelectedIndexChanged"></asp:DropDownList>
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
                                   ZipCode:
                               </td>
                                 <td>
                                     <asp:TextBox ID="txtBoxZipCode" runat="server" ></asp:TextBox>
                                     <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ToolTip="Required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtBoxEmail" ValidationGroup="valGp1"></asp:RegularExpressionValidator>--%>
                                 </td>
                    </tr>
                </table>
                        <center>
                            <br />
                       <br />
                        <asp:Button CssClass="bt"  ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" width="100"/>  
                            </center>
               
           
            <br />
            <br />
           <asp:GridView ID="gvUserRegistration" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUserRegistration_RowCommand">
            <Columns>
                              <asp:BoundField HeaderText="User Type" DataField="UserType" />
                              <asp:BoundField HeaderText="Firstname" DataField="Firstname" />
                              <asp:BoundField HeaderText="Lastname" DataField="Lastname" />
                              <asp:BoundField HeaderText="Password"   DataField="Password" />
                              <asp:BoundField HeaderText="Gender"   DataField="Gender" />
                              <asp:BoundField HeaderText="Address"  DataField="Address" />
                              <asp:BoundField HeaderText="Email"   DataField="Email" />
                              <asp:BoundField HeaderText="Contact No" DataField="Contacts" />
                              <asp:BoundField HeaderText="ZipCode" DataField="ZipCode" />
                              <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkEdit" Text="Edit" runat="server" CommandArgument= '<%#Eval("UserId")%>' CommandName="edt" Width="30">
                                      </asp:LinkButton>          
                                </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Delete">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="linkDelete" Text="Delete" runat="server"  CommandArgument='<%#Eval("UserId")%>' CommandName="dlt">
                                          </asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
            </Columns>
               </asp:GridView>
        </center>
    </div>
</asp:Content>


