<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="InoviceProject.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>User Registration</h1>
    <h5>All fields are required</h5>

    <div class="form-group-lg">
        <asp:Label ID="lblStatus" runat="server" CssClass="label label-danger" />
    </div>
    <div class="form-group">
        <label for="txtUsername" class="col-sm-2">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" required/>
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="password" required/>
    </div>
    <div class="form-group">
        <label for="txtConfirm" class="col-sm-2">Confirm:</label>
        <asp:TextBox id="txtConfirm" runat="server" TextMode="password" required/>
        <asp:CompareValidator runat="server" Operator="Equal" ControlToValidate="txtPassword"
            ControlToCompare="txtConfirm" CssClass="label label-danger" ErrorMessage="Passwords must match" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button id="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" 
            OnClick="btnRegister_Click" />
    </div>

</asp:Content>
