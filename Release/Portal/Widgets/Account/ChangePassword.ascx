<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="TemplarEMS.Account.ChangePassword" %>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 146px;
        }
        .auto-style2 {
            width: 171px;
        }
        .auto-style3 {
            width: 358px;
        }
    </style>
    <asp:Panel ID="Panel1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ChangePassword" runat="server" ControlToValidate="TextBoxOldPassword" ErrorMessage="Field Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ChangePassword" runat="server" ControlToValidate="TextBoxOldPassword" ErrorMessage="Field Cant be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Conform Password"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBoxConformPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" ValidationGroup="ChangePassword" runat="server" ControlToCompare="TextBoxNewPassword" ControlToValidate="TextBoxConformPassword" ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="ButtonSubmitChangePassword" ValidationGroup="ChangePassword" runat="server" Text="Submit" OnClick="Submit_Button_Clicked" />
                </td>
                <td class="auto-style3">
                    <input id="Reset1" type="reset" value="reset" />
                </td>
                <td>
                    <asp:Label ID="LabelChangePassword" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
</asp:Panel>



