using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF Model
using InoviceProject.Models;
using System.Linq.Dynamic;


namespace InoviceProject
{
    public partial class supplierList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "SUPPLIER_ID";
                Session["SortDirection"] = "ASC";
                GetSupplier();
            }
        }

        protected void GetSupplier()
        {
            using (InoviceConnection db = new InoviceConnection())
            {

                //append the current direction to the Sort Column
                String sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //Get the Product Supplier Details
                var supp = from s in db.supplier_information
                               select new { s.SUPPLIER_ID, s.SUPPLIER_NAME , s.ADDRESS ,s.CITY , s.STATE , s.POSTAL_CODE};

                //bind the Supplier GridView
                grdSupplier.DataSource = supp.AsQueryable().OrderBy(sortString).ToList();
                grdSupplier.DataBind();
            }
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdSupplier.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetSupplier();

        }

        protected void grdSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get selected Supplier ID
            Int32 SUPPLIER_ID = Convert.ToInt32(grdSupplier.DataKeys[e.RowIndex].Values["SUPPLIER_ID"]);

            using (InoviceConnection db = new InoviceConnection())
            {
                //get selected Supplier
                supplier_information objC = (from s in db.supplier_information
                                             where s.SUPPLIER_ID == SUPPLIER_ID
                                             select s).FirstOrDefault();

                //delete
                db.supplier_information.Remove(objC);
                db.SaveChanges();

                //refresh grid
                GetSupplier();
            }
        }

        protected void grdSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdSupplier.PageIndex = e.NewPageIndex;
            GetSupplier();
        }

        protected void grdSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdSupplier.Columns.Count - 1; i++)
                    {
                        if (grdSupplier.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }
            }
        }

        protected void grdSupplier_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetSupplier();

            //toggle the direction
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }
    }
 }
