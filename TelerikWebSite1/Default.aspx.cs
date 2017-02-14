using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data.SqlClient;

public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataForRadGrid1();
        }
    }
    protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
    {
        LoadDataForRadGrid1();
    }
    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        LoadDataForRadGrid1();
    }
    protected void RadGrid1_SortCommand(object sender, GridSortCommandEventArgs e)
    {
        LoadDataForRadGrid1();
    }

    private void LoadDataForRadGrid1()
    {
        RadGrid1.DataSource = GetDataTable();
    }

    public DataTable GetDataTable()
    {
        string query = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, PostalCode FROM Customers";

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
}
