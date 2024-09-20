<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteAllRecords.aspx.cs" Inherits="DeleteAllRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
</p>
<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
    onclick="LinkButton1_Click">Delete All Records</asp:LinkButton>
<br />
<br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Homepage.aspx" 
        Font-Bold="True">Back</asp:HyperLink>
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
</asp:Content>

