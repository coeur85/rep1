<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="_repItem.ascx.vb" Inherits="rep1._repItem" %>


<br />
<table>
    <thead>
        <tr>
            <td style="text-align:left">
                
                <%--<div style="float:left"><asp:CheckBox ID="cb_brName" runat="server"  OnCheckedChanged="cb_brName_CheckedChanged" /></div>

                <div style="float:left"><asp:CheckBox ID="cb_rpItem" runat="server"
                    OnCheckedChanged="cb_rpItem_CheckedChanged"  /></div>--%>
                Branch Name : <asp:Label ID="lbl_branchName" runat="server"></asp:Label>
                <input type="checkbox" id="cb_reptem" runat="server" onchange="cbChange(this);" checked="checked"/>
                <label  runat="server" id="lbl_for" />
                
                   
            </td>
            <td style="text-align:right">
                Results: <asp:Label ID="lbl_res" runat="server"></asp:Label>
            </td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td colspan ="2">
                <asp:GridView ID="gv_item" runat="server" Width="600px" CellPadding="4" ForeColor="#333333"
                    GridLines="None" OnRowDataBound="gv_item_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <time class="timeago" id="lbl_timeStamp" runat="server"></time>

            </td>
            <td>
                <asp:Label ID="lbl_jobStatus" runat="server" />
                 <time class="timeago" id="lbl_next" runat="server"></time>
            </td>
        </tr>
    </tbody>
</table>

<br />
