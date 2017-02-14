using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class MasterGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            RadGrid1.DataSource = GetDataTable("SELECT * FROM Customers");
        }
    }

    protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
    {
        GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
        switch (e.DetailTableView.Name)
        {
            case "Orders":
                {
                    string CustomerID = dataItem.GetDataKeyValue("CustomerID").ToString();
                    e.DetailTableView.DataSource = GetDataTable("SELECT * FROM Orders WHERE CustomerID = '" + CustomerID + "'");
                    break;
                }

            case "OrderDetails":
                {
                    string OrderID = dataItem.GetDataKeyValue("OrderID").ToString();
                    e.DetailTableView.DataSource = GetDataTable("SELECT * FROM [Order Details] WHERE OrderID = " + OrderID);
                    break;
                }
        }
    }

    public DataTable GetDataTable(string query)
    {
        String ConnString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConnString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(query, conn);

        DataTable myDataTable = new DataTable();

        conn.Open();
        try
        {
            adapter.Fill(myDataTable);
        }
        finally
        {
            conn.Close();
        }

        return myDataTable;
    }

    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RadGrid1.MasterTableView.Items[0].Expanded = true;
            RadGrid1.MasterTableView.Items[0].ChildItem.NestedTableViews[0].Items[0].Expanded = true;
        }
    }
}