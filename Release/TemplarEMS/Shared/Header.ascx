<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="TemplarEMS.Shared.Header" %>
<style type="text/css">
    .auto-style1 {
        width: 51%;
    }
    .auto-style2 {
        width: 255px;
    }
</style>

<asp:Panel ID="Panel1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:LinkButton ID="LinkButtonChangePassword" runat="server" OnClick="LinkButtonChangePassword_Click">ChangePassword</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButtonLogout" runat="server" OnClick="LinkButtonLogout_Click">Logout</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>


