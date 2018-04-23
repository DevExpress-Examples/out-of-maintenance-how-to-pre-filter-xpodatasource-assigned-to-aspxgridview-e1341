namespace AdventureWorks {
    using System;
    using DevExpress.Xpo;
    
    
    [Persistent("Sales.SalesOrderHeader")]
    public class OrderHeader : XPLiteObject {
        public OrderHeader(Session session) : base(session) { }

        [Persistent("SalesOrderNumber"), Key]
        string orderNumber = null;

        [PersistentAlias("orderNumber")]
        public string OrderNumber {
            get { return orderNumber; }
        }

        decimal _subTotal;
        public decimal SubTotal {
            get { return _subTotal; }
            set { SetPropertyValue("SubTotal", ref _subTotal, value); }
        }

        DateTime _modifiedDate;
        public DateTime ModifiedDate {
            get { return _modifiedDate; }
            set { SetPropertyValue("ModifiedDate", ref _modifiedDate, value); }
        }

        Territory _territory;
        [Persistent("TerritoryID")]
        public Territory Territory {
            get { return _territory; }
            set { SetPropertyValue("Territory", ref _territory, value); }
        }

        Customer _customer;
        [Persistent("CustomerID")]
        public Customer Customer {
            get { return _customer; }
            set { SetPropertyValue("Customer", ref _customer, value); }
        }

        Address _shipToAddress;
        [Persistent("ShipToAddressID")]
        public Address ShipToAddress {
            get { return _shipToAddress; }
            set { SetPropertyValue("ShipToAddress", ref _shipToAddress, value); }
        }
    }

    [Persistent("Sales.Customer")]
    public class Customer : XPLiteObject {
        public Customer(Session session) : base(session) { }

        [Persistent, Key(true)]
        int CustomerID = 0;

        [PersistentAlias("CustomerID")]
        public int ID {
            get { return CustomerID; }
        }

        Territory _territory;
        [Persistent("TerritoryID"), Association("Territory-Customer")]
        public Territory Territory {
            get { return _territory; }
            set { SetPropertyValue("Territory", ref _territory, value); }
        }

        string _accountNumber;
        public string AccountNumber {
            get { return _accountNumber; }
            set { SetPropertyValue("AccountNumber", ref _accountNumber, value); }
        }

        string _customerType;
        public string CustomerType {
            get { return _customerType; }
            set { SetPropertyValue("CustomerType", ref _customerType, value); }
        }
    }

    [Persistent("Sales.SalesPerson")]
    public class SalesPerson : XPLiteObject {
        public SalesPerson(Session session) : base(session) { }

        [Persistent, Key(true)]
        int SalesPersonID = 0;

        [PersistentAlias("SalesPersonID")]
        public int ID {
            get { return SalesPersonID; }
        }

        Territory _territory;
        [Persistent("TerritoryID")]
        public Territory Territory {
            get { return _territory; }
            set { SetPropertyValue("Territory", ref _territory, value); }
        }
    }

    [Persistent("Sales.SalesTerritory")]
    public class Territory : XPLiteObject {
        public Territory(Session session) : base(session) { }

        [Persistent, Key(true)]
        int TerritoryID = 0;

        [PersistentAlias("TerritoryID")]
        public int ID {
            get { return TerritoryID; }
        }

        string _mame;
        public string Name {
            get { return _mame; }
            set { SetPropertyValue("Name", ref _mame, value); }
        }

        string _group;
        public string Group {
            get { return _group; }
            set { SetPropertyValue("Group", ref _group, value); }
        }

        string _countryRegionCode;
        public string CountryRegionCode {
            get { return _countryRegionCode; }
            set { SetPropertyValue("CountryRegionCode", ref _countryRegionCode, value); }
        }

        [Association("Territory-Customer")]
        public XPCollection<Customer> Customers {
            get { return GetCollection<Customer>("Customers"); }
        }

        [Association("Territory-States")]
        public XPCollection<StateProvince> States {
            get { return GetCollection<StateProvince>("States"); }
        }
    }

    [Persistent("Person.StateProvince")]
    public class StateProvince : XPLiteObject {
        public StateProvince(Session session) : base(session) { }

        [Persistent, Key(true)]
        int StateProvinceID = 0;

        [PersistentAlias("StateProvinceID")]
        public int ID {
            get { return StateProvinceID; }
        }

        string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        string _stateCode;
        [Persistent("StateProvinceCode")]
        public string StateCode {
            get { return _stateCode; }
            set { SetPropertyValue("StateCode", ref _stateCode, value); }
        }

        Territory _territory;
        [Persistent("TerritoryID"), Association("Territory-States")]
        public Territory Territory {
            get { return _territory; }
            set { SetPropertyValue("Territory", ref _territory, value); }
        }

        [Association("State-Addresses")]
        public XPCollection<Address> Addresses {
            get { return GetCollection<Address>("Addresses"); }
        }
    }

    [Persistent("Person.Address")]
    public class Address : XPLiteObject {
        public Address(Session session) : base(session) { }

        [Persistent, Key(true)]
        int AddressID = 0;

        [PersistentAlias("AddressID")]
        public int ID {
            get { return AddressID; }
        }

        StateProvince _state;
        [Persistent("StateProvinceID"), Association("State-Addresses")]
        public StateProvince State {
            get { return _state; }
            set { SetPropertyValue("State", ref _state, value); }
        }

        string _city;
        public string City {
            get { return _city; }
            set { SetPropertyValue("City", ref _city, value); }
        }


        string _addressLine1;
        public string AddressLine1 {
            get { return _addressLine1; }
            set { SetPropertyValue("AddressLine1", ref _addressLine1, value); }
        }
    }
}
