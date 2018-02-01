<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Admin_Regestration" %>

<asp:Content ID="content4" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%-- Add content controls here --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <center>
             <br />
            
            <a class="ken_header" >REGISTRATION</a>
            <br />
            <br /> 
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0"> 
              <asp:View ID="View1" runat="server">
            <table cellspacing="9px" id="ken_tableReg">
                <tr>
                    <td>
                        <asp:Label ID="lblUserType" runat="server" Text="User Type : "></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rbBuyer" runat="server" Text="Buyer" GroupName="usertype"></asp:RadioButton>
                        <asp:RadioButton ID="rbseller" runat="server" Text="Seller" GroupName="usertype"></asp:RadioButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name : "></asp:Label>
                    </td>
                    <td >
                        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter First Name" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                   </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email ID : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email ID" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Password" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                   <td>
                        <asp:Label ID="lblGerder" runat="server" Text="Gender : "></asp:Label>
                   </td> 
                    <td>
                        <asp:RadioButton ID="rbMale" runat="server" Text="Male" GroupName="rbGender"></asp:RadioButton>
                        <asp:RadioButton ID="rbFemale" runat="server" Text="Female" GroupName="rbGender"></asp:RadioButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="Birthdate : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDOB" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Date of Birth" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblContact" runat="server" Text="Phone Number : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbContact" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Contact Number" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="170px">
                        <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Address" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       <asp:UpdatePanel ID="update1" runat="server">
                           <ContentTemplate>
                        <table width="100%" cellspacing="9px">
                              <tr>
                    <td width="170px">
                        <asp:Label ID="lblCountry" runat="server" Text="Country :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblState" runat="server" Text="State :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddState_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Text="City :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddCity" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                        </table>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
              
                 <tr>
                    <td>
                        <asp:Label ID="lblZipCode" runat="server" Text="Zip Code :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbZipCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  </table>
            <br /><br />
                        <asp:Button CssClass="bt" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                   <asp:Button CausesValidation="false" ID="btGridview" runat="server" Text="GridView" OnClick="btGridview_Click" CssClass="bt" />
</asp:View>
                <asp:View runat="server" ID="view2">
                <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="gvRegestration" runat="server" OnRowCommand="gvRegestration_RowCommand" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="UserType" DataField="UserType" />
                        <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                        <asp:BoundField HeaderText="LastName" DataField="LastName" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Password" DataField="Password" />
                        <asp:BoundField HeaderText="Gender" DataField="Gender" />
                        <asp:BoundField HeaderText="DOB" DataField="DOB" />
                        <asp:BoundField HeaderText="Contacts" DataField="Contacts" />
                        <asp:BoundField HeaderText="Address" DataField="Address" />
                        <asp:BoundField HeaderText="Country Name" DataField="CountryName" />
                        <asp:BoundField HeaderText="State Name" DataField="StateName" /> 
                        <asp:BoundField HeaderText="City Name" DataField="CityName" />
                        <asp:BoundField HeaderText="ZipCode" DataField="Zipcode" />
                         
                        <asp:TemplateField HeaderText="DELETE">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdlt" Text="DELETE" runat="server" CommandName="DLT" CommandArgument='<%#Eval("UserId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                   </Columns>
            </asp:GridView>
                    <br /><br />
                    <asp:Button ID="btBack" Text="Insert" runat="server" CssClass="bt" OnClick="btBack_Click"/>
                    </asp:View>
                </asp:MultiView>
        </center>
    </div>
</asp:Content>
