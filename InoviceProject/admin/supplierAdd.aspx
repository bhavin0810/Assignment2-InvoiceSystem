<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="supplierAdd.aspx.cs" Inherits="InoviceProject.supplierAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Supplier Details</h1>        
        
        <div class="form-group">
            <label for="txtName" class="control-label col-sm-2">Name:</label>
            <asp:TextBox ID="txtName" runat="server" required MaxLength="50" />
        </div>
        
        <div class="form-group">
            <label for="txtAddress" class="control-label col-sm-2">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" required MaxLength="50" />
        </div>
        
        <div class="form-group">
            <label for="txtCity" class="control-label col-sm-2">City:</label>
            <asp:TextBox ID="txtCity" runat="server" required MaxLength="50" />
        </div>
        
        <div class="form-group">
            <label for="txtState" class="control-label col-sm-2">State:</label>
            <asp:TextBox ID="txtState" runat="server" required MaxLength="50" />
        </div>
        
        <div class="form-group">
            <label for="txtPostalCode" class="control-label col-sm-2">Postal Code:</label>
            <asp:TextBox ID="txtPostalCode" runat="server" required MaxLength="10" />
        </div>
        
        <div class="col-sm-2 col-sm-offset-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                 OnClick="btnSave_Click" />
        </div>


    </div>
</asp:Content>
