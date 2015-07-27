<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="InoviceProject.productList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Product Lists</h1>
    <a href="productAdd.aspx">Add Product</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdProduct" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="PRODUCT_ID" OnRowDeleting="grdProduct_RowDeleting" AllowPaging="true"
        OnPageIndexChanging="grdProduct_PageIndexChanging" PageSize="3" AllowSorting="true"
        OnSorting="grdProduct_Sorting" OnRowDataBound="grdProduct_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="PRODUCT_ID" HeaderText="Product ID" SortExpression="PRODUCT_ID" />
            <asp:BoundField DataField="NAME" HeaderText="Product Name" SortExpression="NAME" />
            <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category Name" SortExpression="CATEGORY_NAME" />
            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Supplier Name" SortExpression="SUPPLIER_NAME" />
            <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" SortExpression="QUANTITY" />
            <asp:BoundField DataField="UNIT_PRICE" HeaderText="Unit Price" SortExpression="UNIT_PRICE" />

            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/productAdd.aspx" 
                DataNavigateUrlFields="PRODUCT_ID" DataNavigateUrlFormatString="productAdd.aspx?PRODUCT_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>


</asp:Content>
