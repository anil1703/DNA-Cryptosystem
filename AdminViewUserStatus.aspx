<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewUserStatus.aspx.cs" Inherits="AdminViewUserStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table align="center" border="1" width="80%" style ="color :White ;" cellpadding="10px" >
        <tr>
            <th colspan ="2">
                  <h1 style ="font-size :x-large ;text-align :center ;">
                    View
                    User Status</h1>
            </th>
        </tr>
        <tr>
            <th colspan ="2">
                <center>
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="299px" 
                        Width="302px" AutoGenerateRows ="False" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" >
                    <EditRowStyle BackColor="#000099" ForeColor="White" />
                <Fields >
            <asp:BoundField DataField ="uid" HeaderText ="UserID" />
            <asp:BoundField DataField ="name" HeaderText ="Name" />
            <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
            <asp:BoundField DataField ="emailid" HeaderText ="EmaildID" />
            <asp:BoundField DataField ="designation" HeaderText ="Designation" />
            <asp:BoundField DataField ="rdate" HeaderText ="Registration Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
            <asp:ImageField DataImageUrlField ="sphoto" DataImageUrlFormatString ="Photo/{0}" HeaderText ="Photo">
            <ControlStyle Width ="100" Height ="100" />
            </asp:ImageField>
            <asp:BoundField DataField ="uname" HeaderText ="User Name" />
              
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView></center>
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">Status
        </td> 
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" 
                AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Activated</asp:ListItem>
                <asp:ListItem>NotActivated</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td colspan ="2" style ="text-align :center ;">
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/AdminViewUserDetails.aspx" Font-Bold="True">Back</asp:HyperLink>
            </td>
        </tr>

        <tr>
            <td colspan ="2" style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

