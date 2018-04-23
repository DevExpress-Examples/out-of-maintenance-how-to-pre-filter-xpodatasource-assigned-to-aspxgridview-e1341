<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServerModeWithParameters._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Xpo.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dxxpo" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3.Export, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to pre-filter XpoDataSource assigned to ASPxGridView</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Customer type:">
        </dxe:ASPxLabel>
        <dxe:ASPxComboBox ID="ASPxComboBox1" runat="server" TextField="CustomerType" ValueField="CustomerType" AutoPostBack="true">
        </dxe:ASPxComboBox>
        <br />
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XpoDataSource1" KeyFieldName="ID" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
            <Columns>
                <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="Territory!Key" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="AccountNumber" VisibleIndex="3">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CustomerType" VisibleIndex="4">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
        </dxwgv:ASPxGridView>
        &nbsp;&nbsp;
        <dxxpo:XpoDataSource ID="XpoDataSource1" runat="server" ServerMode="True" TypeName="AdventureWorks.Customer" Criteria="[CustomerType] = ?">
            <CriteriaParameters>
                <asp:SessionParameter Name="p0" SessionField="CustomerType" />
            </CriteriaParameters>
        </dxxpo:XpoDataSource>
    </div>
    </form>
</body>
</html>
