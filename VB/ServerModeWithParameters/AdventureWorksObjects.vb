Imports Microsoft.VisualBasic
	Imports System
	Imports DevExpress.Xpo
Namespace AdventureWorks


	<Persistent("Sales.SalesOrderHeader")> _
	Public Class OrderHeader
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent("SalesOrderNumber"), Key> _
		Private orderNumber_Renamed As String = Nothing

		<PersistentAlias("orderNumber")> _
		Public ReadOnly Property OrderNumber() As String
			Get
				Return orderNumber_Renamed
			End Get
		End Property

		Private _subTotal As Decimal
		Public Property SubTotal() As Decimal
			Get
				Return _subTotal
			End Get
			Set(ByVal value As Decimal)
				SetPropertyValue("SubTotal", _subTotal, value)
			End Set
		End Property

		Private _modifiedDate As DateTime
		Public Property ModifiedDate() As DateTime
			Get
				Return _modifiedDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("ModifiedDate", _modifiedDate, value)
			End Set
		End Property

		Private _territory As Territory
		<Persistent("TerritoryID")> _
		Public Property Territory() As Territory
			Get
				Return _territory
			End Get
			Set(ByVal value As Territory)
				SetPropertyValue("Territory", _territory, value)
			End Set
		End Property

		Private _customer As Customer
		<Persistent("CustomerID")> _
		Public Property Customer() As Customer
			Get
				Return _customer
			End Get
			Set(ByVal value As Customer)
				SetPropertyValue("Customer", _customer, value)
			End Set
		End Property

		Private _shipToAddress As Address
		<Persistent("ShipToAddressID")> _
		Public Property ShipToAddress() As Address
			Get
				Return _shipToAddress
			End Get
			Set(ByVal value As Address)
				SetPropertyValue("ShipToAddress", _shipToAddress, value)
			End Set
		End Property
	End Class

	<Persistent("Sales.Customer")> _
	Public Class Customer
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent, Key(True)> _
		Private CustomerID As Integer = 0

		<PersistentAlias("CustomerID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return CustomerID
			End Get
		End Property

		Private _territory As Territory
		<Persistent("TerritoryID"), Association("Territory-Customer")> _
		Public Property Territory() As Territory
			Get
				Return _territory
			End Get
			Set(ByVal value As Territory)
				SetPropertyValue("Territory", _territory, value)
			End Set
		End Property

		Private _accountNumber As String
		Public Property AccountNumber() As String
			Get
				Return _accountNumber
			End Get
			Set(ByVal value As String)
				SetPropertyValue("AccountNumber", _accountNumber, value)
			End Set
		End Property

		Private _customerType As String
		Public Property CustomerType() As String
			Get
				Return _customerType
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CustomerType", _customerType, value)
			End Set
		End Property
	End Class

	<Persistent("Sales.SalesPerson")> _
	Public Class SalesPerson
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent, Key(True)> _
		Private SalesPersonID As Integer = 0

		<PersistentAlias("SalesPersonID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return SalesPersonID
			End Get
		End Property

		Private _territory As Territory
		<Persistent("TerritoryID")> _
		Public Property Territory() As Territory
			Get
				Return _territory
			End Get
			Set(ByVal value As Territory)
				SetPropertyValue("Territory", _territory, value)
			End Set
		End Property
	End Class

	<Persistent("Sales.SalesTerritory")> _
	Public Class Territory
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent, Key(True)> _
		Private TerritoryID As Integer = 0

		<PersistentAlias("TerritoryID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return TerritoryID
			End Get
		End Property

		Private _mame As String
		Public Property Name() As String
			Get
				Return _mame
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _mame, value)
			End Set
		End Property

		Private _group As String
		Public Property Group() As String
			Get
				Return _group
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Group", _group, value)
			End Set
		End Property

		Private _countryRegionCode As String
		Public Property CountryRegionCode() As String
			Get
				Return _countryRegionCode
			End Get
			Set(ByVal value As String)
				SetPropertyValue("CountryRegionCode", _countryRegionCode, value)
			End Set
		End Property

		<Association("Territory-Customer")> _
		Public ReadOnly Property Customers() As XPCollection(Of Customer)
			Get
				Return GetCollection(Of Customer)("Customers")
			End Get
		End Property

		<Association("Territory-States")> _
		Public ReadOnly Property States() As XPCollection(Of StateProvince)
			Get
				Return GetCollection(Of StateProvince)("States")
			End Get
		End Property
	End Class

	<Persistent("Person.StateProvince")> _
	Public Class StateProvince
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent, Key(True)> _
		Private StateProvinceID As Integer = 0

		<PersistentAlias("StateProvinceID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return StateProvinceID
			End Get
		End Property

		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _name, value)
			End Set
		End Property

		Private _stateCode As String
		<Persistent("StateProvinceCode")> _
		Public Property StateCode() As String
			Get
				Return _stateCode
			End Get
			Set(ByVal value As String)
				SetPropertyValue("StateCode", _stateCode, value)
			End Set
		End Property

		Private _territory As Territory
		<Persistent("TerritoryID"), Association("Territory-States")> _
		Public Property Territory() As Territory
			Get
				Return _territory
			End Get
			Set(ByVal value As Territory)
				SetPropertyValue("Territory", _territory, value)
			End Set
		End Property

		<Association("State-Addresses")> _
		Public ReadOnly Property Addresses() As XPCollection(Of Address)
			Get
				Return GetCollection(Of Address)("Addresses")
			End Get
		End Property
	End Class

	<Persistent("Person.Address")> _
	Public Class Address
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Persistent, Key(True)> _
		Private AddressID As Integer = 0

		<PersistentAlias("AddressID")> _
		Public ReadOnly Property ID() As Integer
			Get
				Return AddressID
			End Get
		End Property

		Private _state As StateProvince
		<Persistent("StateProvinceID"), Association("State-Addresses")> _
		Public Property State() As StateProvince
			Get
				Return _state
			End Get
			Set(ByVal value As StateProvince)
				SetPropertyValue("State", _state, value)
			End Set
		End Property

		Private _city As String
		Public Property City() As String
			Get
				Return _city
			End Get
			Set(ByVal value As String)
				SetPropertyValue("City", _city, value)
			End Set
		End Property


		Private _addressLine1 As String
		Public Property AddressLine1() As String
			Get
				Return _addressLine1
			End Get
			Set(ByVal value As String)
				SetPropertyValue("AddressLine1", _addressLine1, value)
			End Set
		End Property
	End Class
End Namespace
