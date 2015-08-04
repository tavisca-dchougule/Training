<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AuthenticationForm.Account.Login" %>

<%@ Register Src="~/Control/LoginUserControl.ascx" TagPrefix="uc1" TagName="LoginUserControl" %>





<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
<uc1:LoginUserControl runat="server" ID="LoginUserControl" />    
<br />


    </asp:Content>
