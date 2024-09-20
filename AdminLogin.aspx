<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center" width="80%" style ="color :White ; " cellpadding="10px">
<tr>
<th colspan ="2">
<br /><h1 style ="font-size :x-large ; text-align :center ;">Admin Login</h1><br />
</th>
</tr>
<tr>
<td style ="text-align :right ;">
    UserName</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">
    Password</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Login</asp:LinkButton>
</td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</td>
</tr>
</table>
</asp:Content>

