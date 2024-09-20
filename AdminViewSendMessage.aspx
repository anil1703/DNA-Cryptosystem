<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewSendMessage.aspx.cs" Inherits="AdminViewSendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="80%" style ="color:White ;" cellpadding="10px" >
        <tr>
            <th>
               <h1 style ="font-size :x-large ;text-align :center ;">
                    Message Details</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
                    AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                    PageSize="5" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" 
                    Width="639px" >
                    <Columns >
                    <asp:BoundField DataField ="msgno" HeaderText ="MessageNo" />
                    <asp:BoundField DataField ="fromid" HeaderText ="FromID" />
                           <asp:BoundField DataField ="toid" HeaderText ="ToID" />
                                  <asp:BoundField DataField ="msgdate" HeaderText ="Message Date" />
                                <%--  <asp:BoundField DataField ="mkey" HeaderText ="Decryption Key" />
                                  <asp:BoundField DataField ="mvcode" HeaderText ="Validation Code" />--%>
                      
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
                </asp:GridView>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

