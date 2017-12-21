Public Class _repItem
    Inherits System.Web.UI.UserControl

    'Public Event cb_branchChanged(sender As Object, e As EventArgs, chechked As Boolean, id As String)
    'Public Event cb_repItemChanged(sender As Object, e As EventArgs, chechked As Boolean, itname As String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Private Sub BindRepItem(b As BranchEnum, itemName As String, isfromHQ As Boolean)
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
                If br.ID <> BranchEnum.Mergem Then
                    tnl.Add(g.getsys_item_prices(br))
                End If
                If br.ID = BranchEnum.AboSloiman Or br.ID = BranchEnum.Wardian Or br.ID = BranchEnum.Falaky Or br.ID = BranchEnum.Fadaly Then
                    itemName = itemName + "_1"
                ElseIf br.ID = BranchEnum.Manshya Then
                    itemName = "ho_" + itemName
                End If

            Else
                tnl = g.getTablesNames(BranchEnum.HQ, itemName)

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



        '  Dim ti As DateTime
        Dim j As New ServerAgentJobs
        If isfromHQ Then
            ' ti = g.getLastSyncDate(itemName, br, hq)
            ' lbl_ls.Text = "Last Sync: " +
            'j = ServerAgentJobs.List(hq).Where(Function(x) x.JobName = itemName And x.Server = br.ServerName).FirstOrDefault
            j = ServerAgentJobs.Job(itemName, hq, br)
        Else
            'ti = g.getLastSyncDate(itemName, hq, br)
            'lbl_ls.Text = "Last Sync: " +
            j = ServerAgentJobs.Job(itemName, br, hq)
        End If
        '<globalization  culture="en-NZ"  uiCulture="en-NZ"/>
        If j IsNot Nothing Then
            lbl_timeStamp.Attributes.Add("datetime", FormatDateTime(j.LastRun))
            lbl_timeStamp.Attributes.Add("title", FormatDateTime(j.LastRun))
            lbl_timeStamp.InnerText = "Last Sync: " + j.LastRun.ToString

            lbl_jobStatus.Text = "Job is:" + j.JobStatues
            If j.JobStatues <> "Running" Then
                If j.NextRun IsNot Nothing Then
                    lbl_next.Attributes.Add("datetime", FormatDateTime(j.NextRun))
                    lbl_next.Attributes.Add("title", FormatDateTime(j.NextRun))
                    lbl_next.InnerText = "Next Sync: " + j.NextRun.ToString
                Else
                    lbl_next.Visible = False
                End If
            Else

                lbl_next.Visible = False
            End If
        Else

            lbl_jobStatus.Text = "job information not found!"
        End If







        gv_item.DataSource = tb
        gv_item.DataBind()






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