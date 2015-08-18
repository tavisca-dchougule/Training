<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DemoWidget.ascx.cs" Inherits="TemplarWidgets.DemoWidgets.DemoWidget" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 174px;
    }
    .auto-style3 {
        width: 171px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="Field Cant Be Empty." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Field Cant Be Empty." ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </td>
        <td class="auto-style3">
            <input id="Reset1" type="reset" value="reset" /></td>
        <td>
            <asp:Label ID="LabelDisplay" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
</table>

