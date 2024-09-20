<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendImage.aspx.cs" Inherits="SendImage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1"  style ="color :White;  " cellpadding="10px"  width ="80%">
        <tr>
            <th colspan="2">
               <h1 style ="font-size :x-large ;text-align :center ;">
                    Send Image</h1>
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
                Select an Image File</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Sending
                File</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Encryption Key</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="126px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
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
            <td style="text-align: center" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

