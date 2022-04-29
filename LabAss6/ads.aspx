<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ads.aspx.cs" Inherits="LabAss6.ads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ads 1
        </div>
        <asp:AdRotator ID="AdRotator2" runat="server" DataSourceID="XmlDataSource1" KeywordFilter="ads1" />
        <h2>This is my advertisement page</h2>
        <div>
            Ads 2
        </div>
        <asp:AdRotator ID="AdRotator1" runat="server" DataSourceID="XmlDataSource1" KeywordFilter="ads2" />
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/AdListXMLFile.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
