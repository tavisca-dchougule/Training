<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRAddEmployeeTab.ascx.cs" Inherits="AuthenticationForm.HRAddEmployeeTab" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 180px;
        text-align: right;
    }
    .auto-style3 {
        width: 179px;
    }
    .auto-style4 {
        width: 180px;
        text-align: right;
        height: 26px;
    }
    .auto-style5 {
        width: 179px;
        height: 26px;
    }
    .auto-style6 {
        height: 26px;
    }
    #Reset1 {
        text-align: left;
        width: 74px;
        margin-left: 38px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style4">Title:</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxTitle" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="Title Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">First Name:</td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="First NameCant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Last Name:</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Last Name Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Email Id:</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Invalid Email." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Designation:"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxDesignation" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="AddEmployee" runat="server" ControlToValidate="TextBoxDesignation" ErrorMessage="Designation Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="ButtonEmpSubmit" ValidationGroup="AddEmployee" runat="server" Text="Submit" OnClick="ButtonEmpSubmit_Click" />
        </td>
        <td class="auto-style3">
            <input id="Reset1" type="reset" value="reset" /></td>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="OnChangePassword_Click">Change Password</asp:LinkButton>
            <asp:Label ID="LabelCreateEmployee" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
</table>

