<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Main.Master"
    CodeBehind="Default.aspx.vb" Inherits="rep1._Default" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/_UserControls/_repItem.ascx" TagPrefix="uc1" TagName="_repItem" %>
<%@ Register Src="~/_UserControls/_repItemRepter.ascx" TagPrefix="uc1" TagName="_repItemRepter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
    <table style="font-family:Tahoma; font-size:small" id="tbl_form">
        <thead>

        </thead>

        <tr>
            <td>Select Branch</td>
            <td><asp:DropDownList ID="dd_branch" runat="server" AutoPostBack="true">
                
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan ="2">
                <br />
            </td>
        </tr>
        

        <tr>
        <td colspan="2">

                <asp:CheckBoxList ID="cbl_repItems" runat="server" RepeatColumns="3">

                </asp:CheckBoxList>
             
            </td>
        </tr>
        <tr>
            <td colspan ="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan ="2" style="text-align:right">
                <asp:LinkButton ID="lb_selectAll" runat="server" 
                    Text="invert selection" Visible="false" OnClick="lb_selectAll_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan ="2">
                <br />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:CheckBoxList runat="server" ID="cbl_branches" RepeatColumns="3" RepeatDirection="Horizontal">

                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan ="2" style="text-align:center">
                <br />
                <asp:Button ID="btn_go" runat="server" Text="Go !" Visible="false" />
                 <br />
                <asp:Button ID="btn_goonlyError" runat="server" Text="show only invalied data!" Visible="false" />
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                <%--<asp:Repeater ID="rep_rep" runat="server" >
                    <ItemTemplate>
                        <uc1:_repItem runat="server" id="_repItem" BranchID='<%#Bind("BrID") %>' ItemName='<%#Bind("repItemName") %>' />
                    </ItemTemplate>
                </asp:Repeater>--%>
                <uc1:_repItemRepter runat="server" id="rep_rep" />
            </td>
        </tr>

    </table>

    </center>

    <script type="text/javascript">

        function cbChange(cb){

           // alert(cb.id);

            $('input[type = checkbox]').each(function () {
                if (this.value == cb.value && this.id != cb.id)
                {
                   // alert('match found');
                    $(this).prop('checked', $('#' + cb.id).is(":checked") );
                }
            });

            }




    </script>
</asp:Content>



