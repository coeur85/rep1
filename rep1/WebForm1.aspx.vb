Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then Exit Sub

        Dim g As New GetClass
        cb_1.DataSource = g.getRepItem(BrachesEnum.HQ)
        cb_1.DataTextField = "RepName"
        cb_1.DataValueField = ""
        cb_1.DataBind()

        Dim item As ListItem

        For Each item In cb_1.Items
            item.Attributes.Add("onchange", "cbChange(this);")
            item.Attributes.Add("calss", item.Text)

        Next

        cb_2.DataSource = g.getRepItem(BrachesEnum.HQ)
        cb_2.DataTextField = "RepName"
        cb_2.DataValueField = ""
        cb_2.DataBind()



    End Sub

End Class