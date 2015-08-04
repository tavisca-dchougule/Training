<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HrAddEmployee.aspx.cs" Inherits="AuthenticationForm.WebForm3" %>

<%@ Register Src="~/Control/HRAddEmployeeTab.ascx" TagPrefix="uc1" TagName="HRAddEmployeeTab" %>



<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="container">
  <ul class="nav nav-tabs">
  
    <li><a href="HRAddEmployee.aspx">Add Employee</a></li>
    <li><a  href="HRAddRemark.aspx">Add Remark</a></li>

  </ul>
  </div>
<uc1:HRAddEmployeeTab runat="server" ID="HRAddEmployeeTab" />    
</asp:Content>

