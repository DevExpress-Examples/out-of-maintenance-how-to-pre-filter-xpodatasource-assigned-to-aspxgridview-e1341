Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo

Namespace ServerModeWithParameters
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private XpoSession As DevExpress.Xpo.Session

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			XpoSession = XpoHelper.GetNewSession()
			ASPxComboBox1.DataSource = GetCustomerTypes()

			XpoDataSource1.Session = XpoSession
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxComboBox1.DataBind()
		End Sub

		Private Function GetCustomerTypes() As Object
			Dim view As New XPView(XpoSession, GetType(AdventureWorks.Customer))
			view.AddProperty("CustomerType", "CustomerType", True)
			Return view
		End Function

		Protected Sub ASPxGridView1_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
			Session("CustomerType") = ASPxComboBox1.Text
		End Sub
	End Class
End Namespace
