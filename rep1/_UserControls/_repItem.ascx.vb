Public Class _repItem
    Inherits System.Web.UI.UserControl

    'Public Event cb_branchChanged(sender As Object, e As EventArgs, chechked As Boolean, id As String)
    'Public Event cb_repItemChanged(sender As Object, e As EventArgs, chechked As Boolean, itname As String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Private Sub BindRepItem(b As BrachesEnum, itemName As String, isfromHQ As Boolean)
        Dim it As New GetClass.Init

        Dim hq = it.HQ
        Dim br = it.withID(b)
        Dim tb As New DataTable
        Try
            br.Connection.Open()
        Catch ex As Exception
            tb.Columns.Add("Error")
            tb.Rows.Add("error connection to " + br.BranchName + " server")
            lbl_branchName.Text = br.BranchName

            'cb_brName.Text = br.BranchName
            'cb_brName.ToolTip = br.ID
            'cb_rpItem.Text = itemName
            'cb_rpItem.Checked = False
            'cb_brName.Checked = False

            'cb_rpItem.Enabled = False
            'cb_brName.Enabled = False


            lbl_res.Text = "Connection error !"
            gv_item.DataSource = tb
            gv_item.DataBind()
            Exit Sub
        End Try



        tb.Columns.Add("Table Name")
        tb.Columns.Add("HQ")
        tb.Columns.Add(br.BranchName)
        tb.Columns.Add("Statues")
        tb.Columns.Add("Diffrent")

        Dim tnl = New List(Of TablesNames)
        Dim g As New GetClass

        If isfromHQ = True Then
            If itemName = "PO" Then
                tnl = g.getPo_rep(br)
                itemName = br.CodeName + "_po"
            ElseIf itemName = "pur_request_items" Then
                tnl.Add(g.getPur_request_items(br))


            ElseIf itemName = "sys_item_prices" Then
                If br.ID <> BrachesEnum.Mergem Then
                    tnl.Add(g.getsys_item_prices(br))
                End If
                If br.ID = BrachesEnum.AboSloiman Or br.ID = BrachesEnum.Wardian Then
                    itemName = itemName + "_1"
                ElseIf br.ID = BrachesEnum.Manshya Then
                    itemName = "ho_" + itemName
                End If

            Else
                tnl = g.getTablesNames(BrachesEnum.HQ, itemName)

            End If
        Else
            tnl = g.getTablesNames(br.ID, itemName)
        End If



        Dim n1, n2, n3, miss, t As Integer




        Dim s As String
        For Each l In tnl

            n1 = g.GetRowCount(hq, l.TableName, l.WhereCondtion)
            n2 = g.GetRowCount(br, l.TableName, l.WhereCondtion)
            n3 = n1 - n2
            If n3 = 0 Then
                s = "Ok"
            Else
                s = "Error"
                miss += n3
                t += 1
            End If
            tb.Rows.Add(l.TableName, n1, n2, s, n3)

        Next
        ' gv_item.Columns.Clear()

        If tb.Rows.Count = 0 Then
            tb.Columns.Clear()
            tb.Columns.Add(br.BranchName)
            tb.Rows.Add("branch " + br.BranchName + " is not applicable for type " + itemName + " of replication")
            lbl_res.Text = "Perfect !"
        Else


            If isfromHQ = False Then
                miss = miss * -1
            End If


            If miss = 0 Then
                lbl_res.Text = "Perfect !"
            ElseIf miss > 0 Then
                lbl_res.Text = "Missing " + miss.ToString + " record in " + t.ToString + " tables!"
            Else
                lbl_res.Text = "Negative values were found"
            End If
        End If
        lbl_branchName.Text = br.BranchName '+ ", " + itemName

        If itemName.Contains("_po") Then
            cb_reptem.Value = "PO"
        Else
            cb_reptem.Value = itemName
        End If

        lbl_for.Attributes.Add("for", cb_reptem.ClientID)
        lbl_for.InnerHtml = itemName



        Dim ti As DateTime
        If isfromHQ Then
            ti = g.getLastSyncDate(itemName, br, hq)
            '  lbl_ls.Text = "Last Sync: " +
        Else
            ti = g.getLastSyncDate(itemName, hq, br)
            '    lbl_ls.Text = "Last Sync: " + 

        End If
        '<globalization  culture="en-NZ"  uiCulture="en-NZ"/>
        lbl_timeStamp.Attributes.Add("datetime", FormatDateTime(ti))
        lbl_timeStamp.Attributes.Add("title", FormatDateTime(ti))
        lbl_timeStamp.InnerText = "Last Sync: " + ti.ToString


        'cb_brName.Text = br.BranchName
        'cb_brName.ToolTip = br.ID
        'cb_rpItem.Text = itemName
        'cb_rpItem.Checked = True
        'cb_brName.Checked = True
        'cb_rpItem.Enabled = True

        'cb_brName.Enabled = True
        gv_item.DataSource = tb
        gv_item.DataBind()
        '  gv_item.Columns(2).HeaderText = br.BranchName





    End Sub









    Private _brid As Integer
    Public Property BranchID() As Integer
        Get
            Return _brid
        End Get
        Set(ByVal value As Integer)
            _brid = value

            If ItemName <> "" Then
                BindRepItem(BranchID, ItemName, isHQ)
            End If


        End Set
    End Property
    Private _itName As String
    Public Property ItemName() As String
        Get
            Return _itName
        End Get
        Set(ByVal value As String)
            _itName = value

            If BranchID > 0 Then
                BindRepItem(BranchID, ItemName, isHQ)
            End If
        End Set
    End Property

    Private _isHQ As Boolean
    Public Property isHQ() As Boolean
        Get
            Return _isHQ
        End Get
        Set(ByVal value As Boolean)
            _isHQ = value
        End Set
    End Property

    Protected Sub gv_item_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If e.Row.Cells.Count > 2 Then
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center
            Else
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            End If

        End If

    End Sub

    'Protected Sub cb_brName_CheckedChanged(sender As Object, e As EventArgs)
    '    RaiseEvent cb_branchChanged(sender, e, cb_brName.Checked, cb_brName.ToolTip)
    '    '  cb_brName.Focus()
    'End Sub

    'Protected Sub cb_rpItem_CheckedChanged(sender As Object, e As EventArgs)
    '    RaiseEvent cb_repItemChanged(sender, e, cb_rpItem.Checked, cb_rpItem.Text)
    '    '  cb_rpItem.Focus()
    'End Sub
End Class


Public Class ReptearBinder
    Private _brid As Integer
    Public Property BrID() As Integer
        Get
            Return _brid
        End Get
        Set(ByVal value As Integer)
            _brid = value
        End Set
    End Property
    Private _repitemName As String
    Public Property repItemName() As String
        Get
            Return _repitemName
        End Get
        Set(ByVal value As String)
            _repitemName = value
        End Set
    End Property
End Class