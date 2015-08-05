<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRAddRemark.aspx.cs" Inherits="AuthenticationForm.WebForm1" %>

<%@ Register Src="~/Control/HRAddRemarkTab.ascx" TagPrefix="uc1" TagName="HRAddRemarkTab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
         
<div class="container">
  <ul class="nav nav-tabs">
   
 
    <li><a href="HRAddEmployee.aspx">Add Employee</a></li>
    <li><a  href="HRAddRemark.aspx">Add Remark</a></li>

  </ul>
  </div>
    <uc1:HRAddRemarkTab runat="server" ID="HRAddRemarkTab" />
    

</asp:Content>


