using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

namespace ASPxPivotGrid_RuntimeDataBinding {
    public partial class _Default : Page {
        private AccessDataSource ds;
        private ASPxPivotGrid ASPxPivotGrid1;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // Initializes a data source.
            ds = new AccessDataSource("~/nwind.mdb", "SELECT [CategoryName]," +
                "[ProductName], [ProductSales], [ShippedDate] FROM [ProductReports]");

            // Initializes ASPxPivotGrid.
            ASPxPivotGrid1 = new ASPxPivotGrid();

            // Binds ASPxPivotGrid to the data source.
            ASPxPivotGrid1.DataSource = ds;
            
            // Places the Pivot Grid onto a page.
            form1.Controls.Add(ASPxPivotGrid1);

            if (ASPxPivotGrid1.Fields.Count != 0) 
                return;

            // Creates pivot grid fields for all data source fields.
            ASPxPivotGrid1.RetrieveFields();

            // Locates the pivot grid fields in appropriate areas.
            ASPxPivotGrid1.Fields["CategoryName"].Area = PivotArea.RowArea;
            ASPxPivotGrid1.Fields["ProductName"].Area = PivotArea.RowArea;
            ASPxPivotGrid1.Fields["ShippedDate"].Area = PivotArea.ColumnArea;
            ASPxPivotGrid1.Fields["ProductSales"].Area = PivotArea.DataArea;

            ASPxPivotGrid1.Fields["ShippedDate"].GroupInterval = PivotGroupInterval.DateYear;
        }
    }
}
