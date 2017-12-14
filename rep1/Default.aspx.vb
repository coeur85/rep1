Public Class _Default
    Inherits System.Web.UI.Page
    'Dim br As New List(Of BranchsClass)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        dd_branch.DataSource = br
        dd_branch.DataTextField = "BranchName"
        dd_branch.DataValueField = "ID"
        dd_branch.DataBind()

        dd_branch.Items.Insert(0, New ListItem With {.Text = "-----", .Value = 0})

    End Sub

    Protected Sub dd_branch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_branch.SelectedIndexChanged
        Dim g As New GetClass
        rep_rep.DataSource = Nothing
        Select Case dd_branch.SelectedValue
            Case 0
                cbl_branches.Visible = False
                cbl_repItems.Visible = False
                lb_selectAll.Visible = False
                btn_go.Visible = False
                Exit Sub

            Case 201

                cbl_repItems.DataSource = g.getRepItem(BrachesEnum.HQ)
                cbl_repItems.DataTextField = "RepName"
                cbl_repItems.Visible = True
                cbl_repItems.DataBind()



                cbl_branches.Visible = True

                cbl_branches.DataSource = br
                cbl_branches.DataTextField = "BranchName"
                cbl_branches.DataValueField = "ID"
                cbl_branches.DataBind()
                cbl_branches.Items.RemoveAt(0)


            Case Else '  Case BrachesEnum.AboSloiman, BrachesEnum.Manshya, BrachesEnum.Wardian, BrachesEnum.Mergem
                cbl_branches.Visible = False
                cbl_repItems.DataSource = g.getRepItem(dd_branch.SelectedValue)
                cbl_repItems.DataTextField = "RepName"
                cbl_repItems.Visible = True
                cbl_repItems.DataBind()


                lb_selectAll.Visible = True



        End Select
        lb_selectAll.Visible = True
        btn_go.Visible = True
    End Sub

    Protected Sub btn_go_Click(sender As Object, e As EventArgs) Handles btn_go.Click

        Dim g As New GetClass
        Dim rl As New List(Of ReptearBinder)
        Select Case dd_branch.SelectedValue
            Case 201
                rep_rep.isHqBranch = True

                Dim int As New GetClass.Init
                Dim hq = int.HQ
                'Dim bl As New List(Of BranchsClass)
                For i = 0 To cbl_branches.Items.Count
                    If i = cbl_branches.Items.Count Then Exit For

                    If cbl_branches.Items(i).Selected Then
                        For i2 = 0 To cbl_repItems.Items.Count
                            If i2 = cbl_repItems.Items.Count Then Exit For
                            If cbl_repItems.Items(i2).Selected = True Then
                                rl.Add(New ReptearBinder With {.BrID = cbl_branches.Items(i).Value,
                                    .repItemName = cbl_repItems.Items(i2).Text})
                            End If

                        Next

                    End If


                Next


            Case Else ' Case BrachesEnum.AboSloiman, BrachesEnum.Manshya, BrachesEnum.Wardian, BrachesEnum.Mergem
                rep_rep.isHqBranch = False
                For i2 = 0 To cbl_repItems.Items.Count
                    If i2 = cbl_repItems.Items.Count Then Exit For
                    If cbl_repItems.Items(i2).Selected = True Then
                        rl.Add(New ReptearBinder With {.BrID = dd_branch.SelectedValue,
                            .repItemName = cbl_repItems.Items(i2).Text})
                    End If

                Next

                ' Case BrachesEnum.Mergem





        End Select

        If rl.Count = 0 Then
            msgBox.show("nothing is selected !")
        Else
            rep_rep.DataSource = rl

        End If


    End Sub

    Public ReadOnly Property br As List(Of BranchsClass)
        Get
            br = New List(Of BranchsClass)
            Dim int As New GetClass.Init
            br.Add(int.HQ)
            br.Add(int.AboSliman)
            br.Add(int.Manshya)
            br.Add(int.Wardian)
            br.Add(int.Mergem)
            br.Add(int.Falaky)
            Return br
        End Get
    End Property

    Protected Sub lb_selectAll_Click(sender As Object, e As EventArgs)

        For i = 0 To cbl_repItems.Items.Count - 1
            cbl_repItems.Items(i).Selected = Not cbl_repItems.Items(i).Selected
        Next

    End Sub

    'Protected Sub rep_rep_cb_branchChanged(sender As Object, e As EventArgs, chechked As Boolean, idz As String)
    '    '  msgBox.show(chechked.ToString)
    '    For i = 0 To cbl_branches.Items.Count - 1

    '        If cbl_branches.Items(i).Value = idz Then
    '            cbl_branches.Items(i).Selected = chechked
    '            Exit Sub
    '        End If

    '    Next

    'End Sub

    'Protected Sub rep_rep_cb_repItemChanged(sender As Object, e As EventArgs, chechked As Boolean, itname As String)
    '    '   msgBox.show(chechked.ToString)
    '    For i = 0 To cbl_repItems.Items.Count - 1

    '        If cbl_repItems.Items(i).Text = itname Then
    '            cbl_repItems.Items(i).Selected = chechked
    '            Exit Sub
    '        End If

    '    Next
    'End Sub

End Class