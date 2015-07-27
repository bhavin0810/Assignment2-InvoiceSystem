<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="orderList.aspx.cs" Inherits="InoviceProject.order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Order Lists</h1>
    <a href="orderAdd.aspx">Add Order</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdOrder" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="ORDER_ID" OnRowDeleting="grdOrder_RowDeleting" AllowPaging="true"
        OnPageIndexChanging="grdOrder_PageIndexChanging" PageSize="3" AllowSorting="true"
        OnSorting="grdOrder_Sorting" OnRowDataBound="grdOrder_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="ORDER_ID" HeaderText="Order ID" SortExpression="ORDER_ID" />
            <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" />
            <asp:BoundField DataField="ORDER_DATE" HeaderText="Order Date" SortExpression="ORDER_DATE" />
            <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category Name" SortExpression="CATEGORY_NAME" />
            <asp:BoundField DataField="NAME" HeaderText="Product Name" SortExpression="NAME" />
            <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" SortExpression="QUANTITY" />
            <asp:BoundField DataField="UNIT_PRICE" HeaderText="Unit Price" SortExpression="UNIT_PRICE" />
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" />

            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/OrderAdd.aspx" 
                DataNavigateUrlFields="ORDER_ID" DataNavigateUrlFormatString="OrderAdd.aspx?ORDER_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />

        </Columns>
    </asp:GridView>
</asp:Content>
