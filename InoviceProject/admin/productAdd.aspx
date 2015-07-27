<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="productAdd.aspx.cs" Inherits="InoviceProject.productAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1>Product Details</h1>        
        
        <div class="form-group">
            <label for="txtName" class="control-label col-sm-2">Product Name:</label>
            <asp:TextBox ID="txtName" runat="server" required MaxLength="50" />
        </div>
    
        <div class="form-group">
            <label for="ddlCategory" class="control-label col-sm-2">Category Name:</label>
            <asp:DropDownList ID="ddlCategory" runat="server" 
                 DataTextField="CATEGORY_NAME" DataValueField="ID"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlSupplier" class="control-label col-sm-2">Supplier Name:</label>
            <asp:DropDownList ID="ddlSupplier" runat="server" 
                 DataTextField="SUPPLIER_NAME" DataValueField="SUPPLIER_ID"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtQuantity" class="control-label col-sm-2">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" required TextMode="Number" />
            <asp:RangeValidator ID="rvQuantity" runat="server" 
                    ErrorMessage="Quantity must be Integer and zeor or Higher"
                    MinimumValue="0" MaximumValue="999999999"
                    CssClass="label label-danger" 
                    ControlToValidate="txtQuantity"
                    Type="Integer" Display="Dynamic"></asp:RangeValidator>
        </div>

        <div class="form-group">
            <label for="txtPrice" class="control-label col-sm-2">Unit Price:</label>
            <asp:TextBox ID="txtPrice" runat="server" required TextMode="Number" />
            <asp:RangeValidator ID="rvPrice" runat="server" 
                    ErrorMessage="Price must be zeor or Higher"
                    MinimumValue="0" MaximumValue="999999999"
                    CssClass="label label-danger" 
                    ControlToValidate="txtPrice"
                    Type="Double" Display="Dynamic">
                </asp:RangeValidator>
        </div>

        <div class="col-sm-2 col-sm-offset-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                 OnClick="btnSave_Click" />
        </div>

    </div>

</asp:Content>
