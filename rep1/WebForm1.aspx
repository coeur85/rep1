<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/Main.Master" CodeBehind="WebForm1.aspx.vb" Inherits="rep1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">

        function cbChange(cb){

           // alert($('#' + cb.id).is(":checked"))

            $('input[type = checkbox]').each(function () {
                if (this.value == cb.value && this.id != cb.id)
                {
                    //alert('match found');
                    $(this).prop('checked', $('#' + cb.id).is(":checked") );
                }
            });

            }




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:CheckBoxList ID="cb_1" runat="server" ></asp:CheckBoxList>
    <hr />
     <asp:CheckBoxList ID="cb_2" runat="server" ></asp:CheckBoxList>
    
</asp:Content>
