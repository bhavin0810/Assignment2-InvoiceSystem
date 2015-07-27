<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="supplierList.aspx.cs" Inherits="InoviceProject.supplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Supplier Lists</h1>
    <a href="supplierAdd.aspx">Add Supplier</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdSupplier" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="SUPPLIER_ID" OnRowDeleting="grdSupplier_RowDeleting" AllowPaging="true"
        OnPageIndexChanging="grdSupplier_PageIndexChanging" PageSize="3" AllowSorting="true"
        OnSorting="grdSupplier_Sorting" OnRowDataBound="grdSupplier_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="SUPPLIER_ID" HeaderText="Supplier ID" SortExpression="SUPPLIER_ID" />
            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="Name" SortExpression="SUPPLIER_NAME" />
            <asp:BoundField DataField="ADDRESS" HeaderText="Address" SortExpression="ADDRESS" />
            <asp:BoundField DataField="CITY" HeaderText="City" SortExpression="CITY" />
            <asp:BoundField DataField="STATE" HeaderText="State" SortExpression="STATE" />
            <asp:BoundField DataField="POSTAL_CODE" HeaderText="Postal Code" SortExpression="POSTAL_CODE" />

            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/supplierAdd.aspx" 
                DataNavigateUrlFields="SUPPLIER_ID" DataNavigateUrlFormatString="supplierAdd.aspx?SUPPLIER_ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

</asp:Content>
