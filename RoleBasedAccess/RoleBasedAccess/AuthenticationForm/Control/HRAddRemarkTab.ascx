<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRAddRemarkTab.ascx.cs" Inherits="AuthenticationForm.HRAddRemarkTab" %>
<style type="text/css">
    #Reset1 {
        text-align: left;
        width: 74px;
        margin-left: 38px;
    }
    .auto-style1 {
        width: 50%;
        height: 98px;
    }
    .auto-style3 {
        width: 129px;
    }
    .auto-style4 {
        width: 105px;
    }
    .auto-style5 {
        width: 105px;
        height: 56px;
        text-align: right;
    }
    .auto-style6 {
        width: 129px;
        height: 56px;
    }
    .auto-style7 {
        width: 105px;
        text-align: right;
        height: 26px;
    }
    #TextArea1 {
        height: 35px;
        width: 182px;
    }
    #TextAreaRemark {
        width: 158px;
    }
    #Button1 {
        width: 70px;
    }
    .auto-style8 {
        width: 108px;
        height: 56px;
    }
    .auto-style9 {
        width: 108px;
    }
    .auto-style10 {
        width: 108px;
        height: 26px;
    }
    .auto-style11 {
        width: 129px;
        height: 26px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style5">Select Employee:</td>
        <td class="auto-style8">
            <asp:DropDownList ID="DropDownListEmp" runat="server" Height="28px" Width="163px">
                <asp:ListItem>Select Employee</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="auto-style6">
            <asp:Label ID="LabelAddRemark" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style7">Enter Remark:</td>
        <td class="auto-style10">
            <asp:TextBox ID="TextBoxRemark" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style11">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddRemark" runat="server" ControlToValidate="TextBoxRemark" ErrorMessage="Remark Cant be Empty" ForeColor="Red" style="text-align: left"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Button ID="ButtonSubmitRemark" runat="server" OnClick="ButtonSubmitRemark_Click" ValidationGroup="AddRemark" Text="Submit" Width="78px" style="text-align: right" />
        </td>
        <td class="auto-style9">
            <input id="Reset1" type="reset" value="reset" /></td>
        <td class="auto-style3">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="OnChangePassword_Click">Change Password</asp:LinkButton>
        </td>
    </tr>
</table>

