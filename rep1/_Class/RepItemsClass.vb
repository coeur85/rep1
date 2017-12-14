﻿Imports System.Data.SqlClient
Public Class GetClass
    Function getRepItem(value As BrachesEnum) As List(Of ItemName)
        getRepItem = New List(Of ItemName)
        If value = BrachesEnum.HQ Then
            getRepItem.Add(New ItemName("PO"))
            getRepItem.Add(New ItemName("HO_Acc_Balance"))
            getRepItem.Add(New ItemName("HO_Acc_basics"))
            getRepItem.Add(New ItemName("HO_Acc_Ledger"))
            getRepItem.Add(New ItemName("HO_Basic_Items"))
            getRepItem.Add(New ItemName("HO_Cashiers"))
            getRepItem.Add(New ItemName("HO_CreditType"))
            getRepItem.Add(New ItemName("HO_Customers"))
            getRepItem.Add(New ItemName("HO_Items_Hierarchy"))
            getRepItem.Add(New ItemName("HO_Optional_Tables"))
            getRepItem.Add(New ItemName("HO_Organaztion_Hierarchy"))
            getRepItem.Add(New ItemName("HO_package_Items"))
            getRepItem.Add(New ItemName("HO_Promotion_Discount"))
            getRepItem.Add(New ItemName("HO_suppliers"))
            getRepItem.Add(New ItemName("HO_User_Permission"))
            '  getRepItem.Add(New ItemName("pur_request_items"))
            getRepItem.Add(New ItemName("sys_item_prices"))
            'getRepItem.Add(New ItemName("HO_Acc_Ledger"))

        ElseIf value = BrachesEnum.AboSloiman Then
            getRepItem.Add(New ItemName("branch_account"))
            getRepItem.Add(New ItemName("branch_inventory"))
            getRepItem.Add(New ItemName("branch_order"))
            getRepItem.Add(New ItemName("branch_order_items"))
            getRepItem.Add(New ItemName("branch_pur_request"))
            getRepItem.Add(New ItemName("branch_pur_request_items"))
            getRepItem.Add(New ItemName("branch_sales"))
            getRepItem.Add(New ItemName("branch_stock_balance"))
        ElseIf value = BrachesEnum.Wardian Then
            getRepItem.Add(New ItemName("branch_account"))
            getRepItem.Add(New ItemName("barnch_stk_order"))
            getRepItem.Add(New ItemName("branch_stk_order_items"))
            getRepItem.Add(New ItemName("branch_inventory"))
            getRepItem.Add(New ItemName("branch_pur_request"))
            getRepItem.Add(New ItemName("pur_request_items"))
            getRepItem.Add(New ItemName("branch_stk_balance"))
            getRepItem.Add(New ItemName("branch_sales_trans"))


        ElseIf value = BrachesEnum.Manshya Then
            getRepItem.Add(New ItemName("branch_account"))
            getRepItem.Add(New ItemName("branch_order"))
            getRepItem.Add(New ItemName("branch_order_items"))
            getRepItem.Add(New ItemName("branch_inventory"))
            getRepItem.Add(New ItemName("branch_pur_request"))
            getRepItem.Add(New ItemName("pur_request_items"))
            getRepItem.Add(New ItemName("branch_stock_balance"))
            getRepItem.Add(New ItemName("branch_sales"))

        ElseIf value = BrachesEnum.Mergem Then
            getRepItem.Add(New ItemName("branch_account"))
            getRepItem.Add(New ItemName("branch_inventory"))
            getRepItem.Add(New ItemName("branch_order"))
            getRepItem.Add(New ItemName("branch_order_items"))
            getRepItem.Add(New ItemName("branch_sales"))
            getRepItem.Add(New ItemName("branch_stock_balance"))

        End If

    End Function
    Function getTablesNames(br As BrachesEnum, repName As String) As List(Of TablesNames)
        getTablesNames = New List(Of TablesNames)
        ' getTablesNames.Add(New TablesNames("", ""))
        If br = BrachesEnum.HQ Then
            Select Case repName
                Case "HO_Acc_Balance"
                    getTablesNames.Add(New TablesNames("[acc_balance]", ""))
                    getTablesNames.Add(New TablesNames("[acc_balance_hed]", ""))
                Case "HO_Acc_basics"
                    getTablesNames.Add(New TablesNames("[acc_integration]", ""))
                    getTablesNames.Add(New TablesNames("[acc_integration_detail]", ""))
                    getTablesNames.Add(New TablesNames("[acc_integration_doc]", ""))
                    getTablesNames.Add(New TablesNames("[acc_integration_header]", ""))
                Case "HO_Acc_Ledger"
                    getTablesNames.Add(New TablesNames("[acc_ledger]", ""))
                    getTablesNames.Add(New TablesNames("[acc_main_codes]", ""))
                    getTablesNames.Add(New TablesNames("[acc_sub_codes]", ""))
                    getTablesNames.Add(New TablesNames("acc_subledger", ""))
                Case "HO_Basic_Items"
                    getTablesNames.Add(New TablesNames("[sys_item]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_change]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_flags]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_modules]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_scales]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_suppliers]", ""))
                    getTablesNames.Add(New TablesNames("[sys_item_units]", ""))
                Case "HO_Cashiers"
                    getTablesNames.Add(New TablesNames("[sal_cashier]", ""))
                Case "HO_CreditType"
                    getTablesNames.Add(New TablesNames("[sys_credittype]", ""))
                    getTablesNames.Add(New TablesNames("[sys_credittype_bank]", ""))
                    getTablesNames.Add(New TablesNames("[sys_credittype_branch]", ""))
                Case "HO_Customers"
                    getTablesNames.Add(New TablesNames("[sys_customer]", ""))
                    getTablesNames.Add(New TablesNames("[sys_customer_credit]", ""))
                    getTablesNames.Add(New TablesNames("[sys_customer_operators]", ""))
                    getTablesNames.Add(New TablesNames("[sys_customertype]", ""))
                Case "HO_Items_Hierarchy"
                    getTablesNames.Add(New TablesNames("[sys_group]", ""))
                    getTablesNames.Add(New TablesNames("[sys_itemclass]", ""))
                    getTablesNames.Add(New TablesNames("[sys_section]", ""))
                    getTablesNames.Add(New TablesNames("[sys_subgroup]", ""))
                Case "HO_Optional_Tables"
                    getTablesNames.Add(New TablesNames("[sys_bank]", ""))
                    getTablesNames.Add(New TablesNames("[sys_bank_accounts]", ""))
                    getTablesNames.Add(New TablesNames("[sys_bank_facility]", ""))
                    getTablesNames.Add(New TablesNames("[sys_bank_facility]", ""))
                    getTablesNames.Add(New TablesNames("[sys_contract_type]", ""))
                    getTablesNames.Add(New TablesNames("[sys_dispatch_types]", ""))
                    getTablesNames.Add(New TablesNames("[sys_doctype]", ""))
                    getTablesNames.Add(New TablesNames("[sys_registry]", ""))
                    getTablesNames.Add(New TablesNames("[sys_systems]", ""))
                    getTablesNames.Add(New TablesNames("[sys_systems_licenses]", ""))
                    getTablesNames.Add(New TablesNames("[sys_systems_version]", ""))
                    getTablesNames.Add(New TablesNames("[sys_transport]", ""))
                    getTablesNames.Add(New TablesNames("[sys_transtype]", ""))
                Case "HO_Organaztion_Hierarchy"
                    getTablesNames.Add(New TablesNames("[sys_branch]", ""))
                    getTablesNames.Add(New TablesNames("[sys_branch_department]", ""))
                    getTablesNames.Add(New TablesNames("[sys_branch_section]", ""))
                    getTablesNames.Add(New TablesNames("[sys_branch_supplier]", ""))
                    getTablesNames.Add(New TablesNames("[sys_branchtype]", ""))
                    getTablesNames.Add(New TablesNames("[sys_company]", ""))
                    getTablesNames.Add(New TablesNames("[sys_companytype]", ""))
                    getTablesNames.Add(New TablesNames("[sys_region]", ""))
                    getTablesNames.Add(New TablesNames("[sys_sector]", ""))
                Case "HO_package_Items"
                    getTablesNames.Add(New TablesNames("[pos_package]", ""))
                    getTablesNames.Add(New TablesNames("[pos_package_items]", ""))
                Case "HO_Promotion_Discount"
                    getTablesNames.Add(New TablesNames("[pos_promotion]", ""))
                    getTablesNames.Add(New TablesNames("[pos_promotion_items]", ""))
                    getTablesNames.Add(New TablesNames("[sys_discount]", ""))
                    getTablesNames.Add(New TablesNames("[sys_discount_branchs]", ""))
                    getTablesNames.Add(New TablesNames("[sys_discount_items]", ""))
                Case "HO_suppliers"
                    getTablesNames.Add(New TablesNames("sys_supplier", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_agents", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_contract", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_discounts", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_price", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_price_items", ""))
                    getTablesNames.Add(New TablesNames("sys_supplier_type", ""))
                Case "sys_item_prices"
                    getTablesNames.Add(New TablesNames("sys_item_prices", ""))
                Case "HO_User_Permission"
                    getTablesNames.Add(New TablesNames("sys_login", ""))
                    getTablesNames.Add(New TablesNames("sys_login_roles", ""))
                    getTablesNames.Add(New TablesNames("sys_permission", ""))
                Case "pur_request_items"
                    getTablesNames.Add(New TablesNames("pur_request_items", ""))

            End Select
        ElseIf br = BrachesEnum.AboSloiman Then
            Select Case repName
                Case "branch_account"
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det", "WHERE branch = 503 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det_local", "WHERE branch = 503 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_hed", "WHERE branch = 503  and [rev_flag] = 1"))
                    getTablesNames.Add(New TablesNames("acc_trn_det", "WHERE location = 503   and journal_type in (2,8,4) and doctype not in (2010,2050)"))
                    getTablesNames.Add(New TablesNames("acc_trn_hed", "WHERE location = 503   and journal_type in (2,8,4) and doctype not in (2010,2050) and [review_flag] = 1"))
                Case "branch_inventory"
                    getTablesNames.Add(New TablesNames("stk_inventory", "WHERE branch = 503 "))
                    getTablesNames.Add(New TablesNames("stk_inventory_items", "WHERE branch = 503 "))
                    getTablesNames.Add(New TablesNames("stk_inventory_prepare", "WHERE branch = 503 "))
                Case "branch_order"
                    getTablesNames.Add(New TablesNames("stk_order", "WHERE branch = 503   and posting = 1"))
                Case "branch_order_items"
                    getTablesNames.Add(New TablesNames("stk_order_items", "WHERE branch = 503 "))
                Case "branch_pur_request"
                    getTablesNames.Add(New TablesNames("pur_request", "WHERE branch =503 and doctype = 1060 and [review] = 1 "))
                Case "branch_pur_request_items"
                    getTablesNames.Add(New TablesNames("pur_request_items", "WHERE branch =503 and doctype = 1060 "))
                Case "branch_sales"
                    getTablesNames.Add(New TablesNames("sal_invoice_payments", "WHERE branch = 503  "))
                    getTablesNames.Add(New TablesNames("sal_invoices", "WHERE branch = 503  "))
                    getTablesNames.Add(New TablesNames("sal_invoices_items", "WHERE branch = 503 "))
                Case "branch_stock_balance"
                    getTablesNames.Add(New TablesNames("stk_mtod", "WHERE branch = 503 and  doctype =0  and transyear >= 2017"))
                    getTablesNames.Add(New TablesNames("sys_closing", "WHERE location  = 503 and  doctype =2913 "))
            End Select
        ElseIf br = BrachesEnum.Manshya Then
            Select Case repName
                Case "branch_account"
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det", "WHERE branch = 502"))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det_local", "WHERE branch = 502"))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_hed", "WHERE branch = 502 and   [rev_flag] = 1"))
                    getTablesNames.Add(New TablesNames("acc_trn_det", "WHERE location  = 502  and journal_type in (2,8,4) and doctype not in (2010,2050)"))
                    getTablesNames.Add(New TablesNames("acc_trn_hed", "WHERE location = 502   and journal_type in (2,8,4) and doctype not in (2010,2050) and [review_flag] = 1"))
                Case "branch_inventory"
                    getTablesNames.Add(New TablesNames("stk_inventory", "WHERE branch = 502 "))
                    getTablesNames.Add(New TablesNames("stk_inventory_items", "WHERE branch = 502 "))
                    getTablesNames.Add(New TablesNames("stk_inventory_prepare", "WHERE branch = 502 "))
                Case "branch_order"
                    getTablesNames.Add(New TablesNames("stk_order", "WHERE branch = 502   and posting = 1"))
                Case "branch_order_items"
                    getTablesNames.Add(New TablesNames("stk_order_items", "WHERE branch = 502 "))
                Case "branch_pur_request"
                    getTablesNames.Add(New TablesNames("pur_request", "WHERE branch =502 and doctype = 1060 and [review] = 1 "))
                Case "pur_request_items"
                    getTablesNames.Add(New TablesNames("pur_request_items", "WHERE branch =502 and doctype = 1060"))
                Case "branch_sales"
                    getTablesNames.Add(New TablesNames("sal_invoice_payments", "WHERE branch = 502  "))
                    getTablesNames.Add(New TablesNames("sal_invoices", "WHERE branch = 502  "))
                    getTablesNames.Add(New TablesNames("sal_invoices_items", "WHERE branch = 502 "))
                Case "branch_stock_balance"
                    getTablesNames.Add(New TablesNames("stk_mtod", "WHERE branch = 502 and  doctype =0  and transyear >= 2017"))
                    getTablesNames.Add(New TablesNames("sys_closing", "WHERE location  = 502 and  doctype =2913 "))
            End Select

        ElseIf br = BrachesEnum.Wardian Then
            Select Case repName
                Case "barnch_stk_order"
                    getTablesNames.Add(New TablesNames("stk_order", "WHERE [branch] = 501  and posting = 1"))
                Case "branch_account"
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det", "WHERE branch = 501 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det_local", "WHERE branch = 501 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_hed", "WHERE branch = 501 "))
                    getTablesNames.Add(New TablesNames("acc_trn_det", "WHERE location = 501   and journal_type in (2,8,4) and doctype not in (2010,2050)"))
                    getTablesNames.Add(New TablesNames("acc_trn_hed", "WHERE location = 501   and journal_type in (2,8,4) and doctype not in (2010,2050)"))
                Case "branch_inventory"
                    getTablesNames.Add(New TablesNames("stk_inventory", "WHERE [branch] =501  "))
                    getTablesNames.Add(New TablesNames("stk_inventory_items", "WHERE [branch] =501 "))
                    getTablesNames.Add(New TablesNames("stk_inventory_prepare", "WHERE [branch] =501  "))
                Case "branch_pur_request"
                    getTablesNames.Add(New TablesNames("pur_request", "WHERE [branch] =501 and [doctype] =1060  and [review] =1 "))
                Case "branch_sales_trans"
                    getTablesNames.Add(New TablesNames("sal_invoice_payments", "WHERE branch = 501  "))
                    getTablesNames.Add(New TablesNames("sal_invoices", "WHERE branch = 501  "))
                    getTablesNames.Add(New TablesNames("sal_invoices_items", "WHERE branch = 501 "))
                Case "branch_stk_balance"
                    getTablesNames.Add(New TablesNames("stk_mtod", "WHERE [branch] =501 and [doctype] =0 and [transyear] >='2017'"))
                    getTablesNames.Add(New TablesNames("sys_closing", "WHERE [location] =501 and [doctype] =2913 "))
                Case "branch_stk_order_items"
                    getTablesNames.Add(New TablesNames("stk_order_items", "WHERE [branch] = 501 "))
                Case "pur_request_items"
                    getTablesNames.Add(New TablesNames("pur_request_items", "WHERE branch =501 and doctype = 1060"))
            End Select
        ElseIf br = BrachesEnum.Mergem Then
            Select Case repName
                Case "branch_account"
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det", "WHERE branch = 202 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_det_local", "WHERE branch = 202 "))
                    getTablesNames.Add(New TablesNames("acc_cash_in_out_hed", "WHERE branch = 202 "))
                    getTablesNames.Add(New TablesNames("acc_trn_det", "WHERE location = 202  and journal_type in (2,4,8) and doctype not in (2010,2050)"))
                    getTablesNames.Add(New TablesNames("acc_trn_hed", "WHERE location = 202  and journal_type in (2,4,8) and doctype not in (2010,2050)  and [review_flag] = 1"))
                Case "branch_inventory"
                    getTablesNames.Add(New TablesNames("stk_inventory", " WHERE branch = 202  "))
                    getTablesNames.Add(New TablesNames("stk_inventory_items", "WHERE branch = 202  "))
                    getTablesNames.Add(New TablesNames("stk_inventory_prepare", "WHERE branch = 202   "))
                Case "branch_order"
                    getTablesNames.Add(New TablesNames("stk_order", "WHERE branch = 202  and posting = 1"))
                Case "branch_order_items"
                    getTablesNames.Add(New TablesNames("stk_order_items", "WHERE branch = 202 "))
                Case "branch_stock_balance"
                    getTablesNames.Add(New TablesNames("stk_mtod", "WHERE branch = 202 and  doctype =0  and transyear >= 2017"))
                    getTablesNames.Add(New TablesNames("sys_closing", "WHERE location = 202 and  doctype = 2913"))
                Case "branch_sales"
                    getTablesNames.Add(New TablesNames("sal_invoice_payments", "WHERE branch = 202  "))
                    getTablesNames.Add(New TablesNames("sal_invoices", "WHERE branch = 202 and posting = 1  "))
                    getTablesNames.Add(New TablesNames("sal_invoices_items", "WHERE branch = 202 "))
            End Select
        End If



    End Function

    Function getPo_rep(br As BranchsClass) As List(Of TablesNames)
        getPo_rep = New List(Of TablesNames)

        getPo_rep.Add(New TablesNames With {.TableName = "[stk_reorder]", .WhereCondtion =
                      "WHERE branch = " + br.ID.ToString + " and doctype = 1010 and [review] = 1"})
        getPo_rep.Add(New TablesNames With {.TableName = "stk_reorder_items", .WhereCondtion =
                      "WHERE branch = " + br.ID.ToString + " and doctype = 1010 "})




    End Function

    Function getPur_request_items(br As BranchsClass) As TablesNames
        getPur_request_items = New TablesNames With {.TableName = "[pur_request_items]", .WhereCondtion = "WHERE branch =" + br.ID.ToString + " And doctype = 1060"}
    End Function

    Function getsys_item_prices(br As BranchsClass) As TablesNames
        getsys_item_prices = New TablesNames

        Select Case br.ID
            Case 503, 501
                getsys_item_prices.TableName = "sys_item_prices"
                getsys_item_prices.WhereCondtion = "WHERE [pricetype] = 1"
            Case 502
                getsys_item_prices.TableName = "sys_item_prices"
                getsys_item_prices.WhereCondtion = "WHERE [pricetype] = 2"
        End Select


    End Function

    Class Init
        Public Overloads Function HQ() As BranchsClass
            HQ = New BranchsClass With {
                .BranchName = "HQ",
                .Connection = New SqlConnection("Data Source=HQ-DB01;Initial Catalog=Retail;Persist Security Info=True;User ID=sa;Password=retipr"),
                .DBname = "Retail",
                .ServerName = "HQ-DB01",
                .ID = 201,
                .CodeName = ""
            }

        End Function
        Public Overloads Function Manshya() As BranchsClass
            Manshya = New BranchsClass With {
                .BranchName = "Manshya",
                .Connection = New SqlConnection("Data Source=MANSH-DB01;Initial Catalog=Retail;Persist Security Info=True;User ID=sa;Password=retipr"),
                .DBname = "Retail",
                .ServerName = "MANSH-DB01",
                .ID = 502,
                .CodeName = "manshia"
            }

        End Function
        Public Overloads Function AboSliman() As BranchsClass
            AboSliman = New BranchsClass With {
                .BranchName = "Abo Soliman",
                .Connection = New SqlConnection("Data Source=ABOSOL-DB01;Initial Catalog=Retail;Persist Security Info=True;User ID=sa;Password=retipr"),
                .DBname = "Retail",
                .ServerName = "ABOSOL-DB01",
             .ID = 503,
             .CodeName = "abosol"
            }

        End Function
        Public Overloads Function Wardian() As BranchsClass
            Wardian = New BranchsClass With {
                .BranchName = "Wardian",
                .Connection = New SqlConnection("Data Source=WARD-DB01;Initial Catalog=Retail;Persist Security Info=True;User ID=sa;Password=retipr"),
                .DBname = "Retail",
                .ServerName = "WARD-DB01",
             .ID = 501,
             .CodeName = "werdian"
            }



        End Function
        Public Overloads Function Mergem() As BranchsClass
            Mergem = New BranchsClass With {
                .BranchName = "Mergem",
                .Connection = New SqlConnection("Data Source=mergh-db01;Initial Catalog=Retail;Persist Security Info=True;User ID=sa;Password=retipr"),
                .DBname = "Retail",
                .ServerName = "mergh-db01",
             .ID = 202,
             .CodeName = "mergem"}



        End Function
        Public Function withID(id As Int16) As BranchsClass
            Select Case id
                Case 502
                    Return Manshya()
                Case 501
                    Return Wardian()
                Case 503
                    Return AboSliman()
                Case 202
                    Return Mergem()
                Case Else
                    Return Nothing

            End Select
        End Function


    End Class

    Function GetRowCount(b As BranchsClass, tableName As String, Optional ByVal where As String = "") As Integer

        Dim sc As New SqlCommand("select count(*) from [serverName].[dbName].[dbo].[tableName]",
                                                           (b.Connection))

        If tableName.Trim.Contains("[") Or tableName.Trim.Contains("]") Then
            tableName = tableName.Trim
        Else
            tableName = "[" + tableName.Trim + "]"
        End If
        sc.CommandText = sc.CommandText.Replace("serverName", b.ServerName)
        sc.CommandText = sc.CommandText.Replace("dbName", b.DBname)
        sc.CommandText = sc.CommandText.Replace("[tableName]", tableName)


        If where <> "" Then
            sc.CommandText += (" " + where)
        End If

        Try

            If sc.Connection.State <> ConnectionState.Open Then
                sc.Connection.Open()
            End If
            GetRowCount = sc.ExecuteScalar
            sc.Connection.Close()
            Return CInt(GetRowCount)
        Catch ex As Exception
            msgBox.show("Error working with branch " + b.BranchName + "\n" + ex.Message)
        End Try

    End Function

    Function getLastSyncDate(pubName As String, PubBr As BranchsClass, SubBR As BranchsClass) As DateTime


        Dim sc As New SqlCommand("select [last_sync_time] from [Retail].[dbo].[MSsubscription_agents]",
                                                         (PubBr.Connection))

        sc.CommandText += ("  where publication = '" + pubName + "' and publisher = '" + SubBR.ServerName + "'")

        If sc.Connection.State <> ConnectionState.Open Then
            sc.Connection.Open()
        End If


        getLastSyncDate = sc.ExecuteScalar()


        Return getLastSyncDate

    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
Public Class ItemName
    Private _itemName As String
    Public Property RepName() As String
        Get
            Return _itemName
        End Get
        Set(ByVal value As String)
            _itemName = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(v As String)
        RepName = v
    End Sub
End Class
Public Class TablesNames
    Private _tableName As String
    Public Property TableName() As String
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value
        End Set
    End Property

    Private _where As String
    Public Property WhereCondtion() As String
        Get
            Return _where
        End Get
        Set(ByVal value As String)
            _where = value
        End Set
    End Property

    Sub New()

    End Sub
    Sub New(t As String, w As String)
        TableName = t
        WhereCondtion = w
    End Sub
End Class
Public Class BranchsClass
    Private _bname As String
    Public Property BranchName() As String
        Get
            Return _bname
        End Get
        Set(ByVal value As String)
            _bname = value
        End Set
    End Property
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _servanem As String
    Public Property ServerName() As String
        Get
            Return _servanem
        End Get
        Set(ByVal value As String)
            _servanem = value
        End Set
    End Property

    Private _dbName As String
    Public Property DBname() As String
        Get
            Return _dbName
        End Get
        Set(ByVal value As String)
            _dbName = value
        End Set
    End Property

    Private _conStr As System.Data.SqlClient.SqlConnection
    Public Property Connection() As System.Data.SqlClient.SqlConnection
        Get
            Return _conStr
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlConnection)
            _conStr = value
        End Set
    End Property

    Private _codeName As String
    Public Property CodeName() As String
        Get
            Return _codeName
        End Get
        Set(ByVal value As String)
            _codeName = value
        End Set
    End Property

End Class
Public Enum BrachesEnum
    HQ = 0
    AboSloiman = 503
    Wardian = 501
    Manshya = 502
    Mergem = 202
End Enum
Public Class msgBox
    Public Shared Sub show(txt As String)
        Dim crpage As Page = TryCast(HttpContext.Current.Handler, Page)
        ScriptManager.RegisterClientScriptBlock(crpage, crpage.GetType, "msg", "alert('" + txt + "');", True)

    End Sub
End Class