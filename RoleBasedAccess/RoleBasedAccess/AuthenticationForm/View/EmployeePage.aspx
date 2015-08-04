<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="AuthenticationForm.WebForm2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <asp:GridView ID="GridViewRemark" runat="server" OnPageIndexChanging="GridViewRemark_SelectedIndexChanging" OnSelectedIndexChanged="GridViewRemark_SelectedIndexChanged" AllowPaging="True" PageSize="3" AllowCustomPaging="True">
        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PageButtonCount="4" PreviousPageText="Prev" />
    </asp:GridView>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="OnChangePassword_Click">Change Password</asp:LinkButton>

    <asp:Label ID="LabelFetchRemark" runat="server" Visible="False"></asp:Label>

</asp:Content>

