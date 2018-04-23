Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid

Namespace ASPxPivotGrid_RuntimeDataBinding
	Partial Public Class _Default
		Inherits Page
		Private ds As AccessDataSource
		Private ASPxPivotGrid1 As ASPxPivotGrid
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			' Initializes a data source.
			ds = New AccessDataSource("~/nwind.mdb", "SELECT [CategoryName]," & _
				"[ProductName], [ProductSales], [ShippedDate] FROM [ProductReports]")

			' Initializes ASPxPivotGrid.
			ASPxPivotGrid1 = New ASPxPivotGrid()

			' Binds ASPxPivotGrid to the data source.
			ASPxPivotGrid1.DataSource = ds

			' Places the Pivot Grid onto a page.
			form1.Controls.Add(ASPxPivotGrid1)

			If ASPxPivotGrid1.Fields.Count <> 0 Then
				Return
			End If

			' Creates pivot grid fields for all data source fields.
			ASPxPivotGrid1.RetrieveFields()

			' Locates the pivot grid fields in appropriate areas.
			ASPxPivotGrid1.Fields("CategoryName").Area = PivotArea.RowArea
			ASPxPivotGrid1.Fields("ProductName").Area = PivotArea.RowArea
			ASPxPivotGrid1.Fields("ShippedDate").Area = PivotArea.ColumnArea
			ASPxPivotGrid1.Fields("ProductSales").Area = PivotArea.DataArea

			ASPxPivotGrid1.Fields("ShippedDate").GroupInterval = PivotGroupInterval.DateYear
		End Sub
	End Class
End Namespace
