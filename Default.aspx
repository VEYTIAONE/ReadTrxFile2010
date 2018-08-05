<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReadTrxFile.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .text
        {
            font-family:Verdana;
            font-size:x-small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdTestResult" runat="server" CssClass="text"  AutoGenerateColumns="false" CellPadding="5"
            GridLines="Both" SelectedIndex="0">
            <Columns>
                <asp:BoundField DataField="ProcessedFileName" HeaderText="Processed File Name" />
                <asp:BoundField DataField="TestID" HeaderText="Test Run ID" />
                <asp:BoundField DataField="TestName" HeaderText="Test Name" />
                <asp:BoundField DataField="TestOutcome" HeaderText="Test Outcome" />
                <asp:BoundField DataField="ErrorMessage" HeaderText="Error Message" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
