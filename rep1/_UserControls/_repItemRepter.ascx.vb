Public Class _repItemRepter
    Inherits System.Web.UI.UserControl

    'Public Event cb_branchChanged(sender As Object, e As EventArgs, chechked As Boolean, id As Integer)
    'Public Event cb_repItemChanged(sender As Object, e As EventArgs, chechked As Boolean, itname As String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then Exit Sub





    End Sub



    Private _ds As Object
    Public WriteOnly Property DataSource() As Object

        Set(ByVal value As Object)

            rep_rep.DataSource = value
            rep_rep.DataBind()
        End Set
    End Property

    Private _iHQ As Boolean
    Public Property isHqBranch() As Boolean
        Get
            Return _iHQ
        End Get
        Set(ByVal value As Boolean)
            _iHQ = value
        End Set
    End Property



End Class