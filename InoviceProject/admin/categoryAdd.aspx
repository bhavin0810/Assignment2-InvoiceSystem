<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="categoryAdd.aspx.cs" Inherits="InoviceProject.categoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Product Category Details</h1>        

        <div class="form-group">
            <label for="txtName" class="control-label col-sm-2">Category Name:</label>
            <asp:TextBox ID="txtName" runat="server" required MaxLength="20" />
        </div>
    
        <div class="col-sm-2 col-sm-offset-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                 OnClick="btnSave_Click" />
        </div>

    </div>
    

    

</asp:Content>
