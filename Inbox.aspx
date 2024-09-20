<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%" style ="color :White ;" cellpadding="10px"  >
        <tr>
            <th colspan="2">
               <h1 style ="font-size :x-large ;text-align :center ;">
                    Inbox</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" Width="438px" 
                        DataKeyNames ="mkey" onrowcommand="GridView1_RowCommand" >
               <Columns >
               <asp:HyperLinkField DataTextField ="msgdate" DataNavigateUrlFields = "msgno" DataNavigateUrlFormatString ="ViewMessage.aspx?mno={0}&MType=Other" HeaderText ="MessageDate" ControlStyle-ForeColor ="Red"  />
                <asp:BoundField DataField ="fromid" HeaderText ="From" />
                <asp:ImageField DataImageUrlField ="msg"  DataImageUrlFormatString ="temp/{0}" HeaderText ="Message">
                <ControlStyle Width ="50" Height ="50" />
                </asp:ImageField>
                <asp:ButtonField Text ="Get" HeaderText ="Get Key" CommandName ="gk" />
                 
           
               


                </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></center>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <center>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns ="False" 
                    BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" Width="438px" 
                        DataKeyNames ="mkey" onrowcommand="GridView2_RowCommand" >
               <Columns >
               <asp:HyperLinkField DataTextField ="msgdate" DataNavigateUrlFields = "msgno" DataNavigateUrlFormatString ="ViewMessage.aspx?mno={0}&MType=Message" HeaderText ="MessageDate" ControlStyle-ForeColor ="Red"  />
                <asp:BoundField DataField ="fromid" HeaderText ="From" />
          
             <asp:ButtonField Text ="Get" HeaderText ="Get Key" CommandName ="gk" />
                 
               


                </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></center>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

