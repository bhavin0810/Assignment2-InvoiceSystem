<%@ Page Title="" Language="C#" MasterPageFile="~/invoice.Master" AutoEventWireup="true" CodeBehind="categoryList.aspx.cs" Inherits="InoviceProject.categoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Product Category Lists</h1>
    <a href="categoryAdd.aspx">Add Product Category</a>

    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="10" Text="10" />
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover sort display" 
        DataKeyNames="ID" OnRowDeleting="grdCategory_RowDeleting" AllowPaging="true"
        OnPageIndexChanging="grdCategory_PageIndexChanging" PageSize="3" AllowSorting="true"
        OnSorting="grdCategory_Sorting" OnRowDataBound="grdCategory_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Category ID" SortExpression="ID" />
            <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category Name" SortExpression="CATEGORY_NAME" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/categoryAdd.aspx" 
                DataNavigateUrlFields="ID" DataNavigateUrlFormatString="categoryAdd.aspx?ID={0}" />
            <asp:CommandField DeleteText="Delete" HeaderText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>

</asp:Content>
