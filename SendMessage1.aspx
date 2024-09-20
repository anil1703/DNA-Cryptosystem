<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage1.aspx.cs" Inherits="SendMessage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" style ="color :White; " cellpadding="10px"  width="80%" >
        <tr>
            <th colspan="2">
                 <h1 style ="font-size :x-large ;text-align :center ;">
                    Send Message</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                From EmailID</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                To EMailID</td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Content</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Height="61px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password to Encrypt</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="126px"></asp:TextBox>
            </td>
        </tr>
       <%-- <tr>
            <td style="text-align: right">
                Validation Code</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td style="text-align: right">
                Sending Date</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Encrypt" 
                    onclick="Button1_Click" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Encrypted Data</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="287px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Send" 
                   Font-Bold="True" style="margin-left: 0px" onclick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>



