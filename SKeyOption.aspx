<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SKeyOption.aspx.cs" Inherits="SKeyOption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border ="1" align="center" style ="color :White; " cellpadding="10px" width ="80%" >
<tr>
<th colspan ="2"><br />  <h1 style ="font-size :x-large ;text-align :center ;">Secret Key Option</h1><br /></th>
</tr>
<tr>
<td style ="text-align :right ;">Select Option</td>
<td>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2" 
        RepeatLayout="Flow">
        <asp:ListItem>Offline</asp:ListItem>
        <asp:ListItem>Online</asp:ListItem>
    </asp:RadioButtonList>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Send</asp:LinkButton>
    </td>
</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

