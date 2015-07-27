using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add Security References
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

//reference the EF Model
using InoviceProject.Models;
using System.Linq.Dynamic;

namespace InoviceProject
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "ORDER_ID";
                Session["SortDirection"] = "ASC";
                GetOrder();
            }
        }

        protected void GetOrder()
        {

            //Getting Authenticated User
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("admin"))
                {
                    using (InoviceConnection db = new InoviceConnection())
                    {

                        //append the current direction to the Sort Column
                        String sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                        //Get the Product Details
                        var order = (from o in db.order_master
                                     select new { o.ORDER_ID, o.AspNetUser.UserName, o.ORDER_DATE, o.category_information.CATEGORY_NAME, o.product_information.NAME, o.QUANTITY, o.UNIT_PRICE, total = o.UNIT_PRICE * o.QUANTITY });

                        //bind the Product GridView
                        grdOrder.DataSource = order.AsQueryable().OrderBy(sortString).ToList();
                        grdOrder.DataBind();
                    }
                }
                else
                {
                    using (InoviceConnection db = new InoviceConnection())
                    {
                        //Get Loggedin UserId
                        String USER_ID = HttpContext.Current.User.Identity.GetUserId();

                        //append the current direction to the Sort Column
                        String sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                        //Get the Product Details
                        var order = (from o in db.order_master
                                     where o.USER_ID == USER_ID
                                     select new { o.ORDER_ID, o.AspNetUser.UserName, o.ORDER_DATE, o.category_information.CATEGORY_NAME, o.product_information.NAME, o.QUANTITY, o.UNIT_PRICE, total = o.UNIT_PRICE * o.QUANTITY });

                        //bind the Product GridView
                        grdOrder.DataSource = order.AsQueryable().OrderBy(sortString).ToList();
                        grdOrder.DataBind();
                    }
                }
            }

        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdOrder.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetOrder();                    
        }

        protected void grdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get selected Product ID
            Int32 ORDER_ID = Convert.ToInt32(grdOrder.DataKeys[e.RowIndex].Values["ORDER_ID"]);

            using (InoviceConnection db = new InoviceConnection())
            {
                //get selected Product
                order_master objC = (from o in db.order_master
                                            where o.ORDER_ID == ORDER_ID
                                            select o).FirstOrDefault();

                //delete
                db.order_master.Remove(objC);
                db.SaveChanges();

                //refresh grid
                GetOrder();
            }
        }

        protected void grdOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdOrder.PageIndex = e.NewPageIndex;
            GetOrder();
        }

        protected void grdOrder_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetOrder();

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

        protected void grdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdOrder.Columns.Count - 1; i++)
                    {
                        if (grdOrder.Columns[i].SortExpression == Session["SortColumn"].ToString())
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
    }
}