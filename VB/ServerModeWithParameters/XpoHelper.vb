Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public NotInheritable Class XpoHelper
	Private Sub New()
	End Sub
	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

	Private Shared fDataLayer As IDataLayer
	Private Shared ReadOnly Property DataLayer() As IDataLayer
		Get
			If fDataLayer Is Nothing Then
				SyncLock lockObject
					fDataLayer = GetDataLayer()
				End SyncLock
			End If
			Return fDataLayer
		End Get
	End Property

	Private Shared Function GetDataLayer() As IDataLayer
		' set XpoDefault.Session to null to prevent accidental use of XPO default session
		XpoDefault.Session = Nothing

		Dim conn As String = MSSqlConnectionProvider.GetConnectionString("(local)", "AdventureWorks")
		Dim dict As XPDictionary = New ReflectionDictionary()
		Dim store As IDataStore = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists)
		dict.GetDataStoreSchema(GetType(AdventureWorks.Customer).Assembly)
		Dim dl As IDataLayer = New ThreadSafeDataLayer(dict, store)

		Return dl
	End Function
End Class
