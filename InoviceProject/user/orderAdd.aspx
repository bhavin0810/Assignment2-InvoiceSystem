<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="orderAdd.aspx.cs" Inherits="InoviceProject.orderAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

        <h1>Order Details</h1>        
        
        <div class="form-group">
            <label for="txtOrderDate" class="col-sm-2">Order Date:</label>
            <asp:TextBox ID="txtOrderDate" runat="server" required TextMode="Date" />
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Proper Date"
            ControlToValidate="txtOrderDate" CssClass="label label-danger"
            Type="Date" MinimumValue="2000-01-01" MaximumValue="12/31/2999"></asp:RangeValidator>            
        </div>
    
        <div class="form-group">
            <label for="ddlCategory" class="control-label col-sm-2">Category Name:</label>
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true"
                 DataTextField="CATEGORY_NAME" DataValueField="ID" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlProduct" class="control-label col-sm-2">Product Name:</label>
            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" 
                 DataTextField="NAME" DataValueField="PRODUCT_ID" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label for="lblPrice" class="control-label col-sm-2">Unit Price:</label>
            <asp:Label ID="lblPrice" runat="server"></asp:Label>            
        </div>

        <div class="form-group">
            <label for="txtQuantity" class="control-label col-sm-2">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" required TextMode="Number" AutoPostBack="true"  OnTextChanged="txtQuantity_TextChanged" />
            <asp:RangeValidator ID="rvQuantity" runat="server" 
                    ErrorMessage="Quantity must be Integer and zeor or Higher"
                    MinimumValue="0" MaximumValue="999999999"
                    CssClass="label label-danger" 
                    ControlToValidate="txtQuantity"
                    Type="Integer" Display="Dynamic"></asp:RangeValidator>
        </div>

        <div class="form-group">
            <label for="lblTotal" class="control-label col-sm-2">Total:</label>
            <asp:Label ID="lblTotal" runat="server"></asp:Label>            
        </div>

        <div class="col-sm-2 col-sm-offset-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                 OnClick="btnSave_Click" />
        </div>

    </div>
</asp:Content>
