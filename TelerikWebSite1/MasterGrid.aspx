<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterGrid.aspx.cs" Inherits="MasterGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="demo-container no-bg">
        <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server" ShowStatusBar="true" AutoGenerateColumns="False"
            PageSize="7" AllowSorting="True" AllowMultiRowSelection="False" AllowPaging="True"
            OnDetailTableDataBind="RadGrid1_DetailTableDataBind" OnNeedDataSource="RadGrid1_NeedDataSource"
            OnPreRender="RadGrid1_PreRender">
            <PagerStyle Mode="NumericPages"></PagerStyle>
            <MasterTableView DataKeyNames="CustomerID" AllowMultiColumnSorting="True">
                <DetailTables>
                    <telerik:GridTableView DataKeyNames="OrderID" Name="Orders" Width="100%">
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="OrderID" Name="OrderDetails" Width="100%">
                                <Columns>
                                    <telerik:GridBoundColumn SortExpression="UnitPrice" HeaderText="Unit Price" HeaderButtonType="TextButton"
                                        DataField="UnitPrice">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="Quantity" HeaderText="Quantity" HeaderButtonType="TextButton"
                                        DataField="Quantity">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="Discount" HeaderText="Discount" HeaderButtonType="TextButton"
                                        DataField="Discount">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="OrderID" HeaderText="OrderID" HeaderButtonType="TextButton"
                                DataField="OrderID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="OrderDate" HeaderText="Date Ordered" HeaderButtonType="TextButton"
                                DataField="OrderDate" UniqueName="OrderDate" DataFormatString="{0:D}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn SortExpression="Freight" HeaderText="Freight" HeaderButtonType="TextButton"
                                DataField="Freight" UniqueName="Freight">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </telerik:GridTableView>
                </DetailTables>
                <Columns>
                    <telerik:GridBoundColumn SortExpression="CustomerID" HeaderText="CustomerID" HeaderButtonType="TextButton"
                        DataField="CustomerID">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="ContactName" HeaderText="Contact Name" HeaderButtonType="TextButton"
                        DataField="ContactName">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="CompanyName" HeaderText="Company" HeaderButtonType="TextButton"
                        DataField="CompanyName">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    </form>
</body>
</html>
