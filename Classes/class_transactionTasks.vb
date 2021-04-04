Imports System.Data
Imports System.Data.SqlClient

Public Class class_transactionTasks

    Dim con_cls As New class_connectionString
    Dim dr As SqlDataReader
    Dim dom, userName, type, remark As String
    Dim t_id As Int64

    Public Sub update_trans_login(ByVal userName, ByVal type, ByVal remark)
        con_cls.connect()
        Try
            con_cls.cmd.CommandText = "SELECT MAX(tid) FROM TTABLELOGIN"
            dr = con_cls.cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    t_id = CInt(dr.Item(0))
                    t_id += 1
                Else
                    t_id = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction ID retrieve Sqlquerry block error")
        End Try
        dr.Close()
        Try
            con_cls.cmd.CommandText = "INSERT INTO TTABLELOGIN (tid,doe,userInfo,type,rem) VALUES (" & t_id & ",'" & System.DateTime.Now & "','" & userName & "','" & type & "','" & remark & "')"
            con_cls.cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction Sqlquerry block error")
        End Try
        con_cls.disconnect()
    End Sub

    Public Sub update_trans_database(ByVal userName, ByVal type, ByVal remark)
        con_cls.connect()
        Try
            con_cls.cmd.CommandText = "SELECT MAX(tid) FROM TTABLEDATABASE"
            dr = con_cls.cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    t_id = CInt(dr.Item(0))
                    t_id += 1
                Else
                    t_id = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction ID retrieve Sqlquerry block error")
        End Try
        dr.Close()
        Try
            con_cls.cmd.CommandText = "INSERT INTO TTABLEDATABASE (tid,doe,userInfo,type,rem) VALUES (" & t_id & ",'" & System.DateTime.Now & "','" & userName & "','" & type & "','" & remark & "')"
            con_cls.cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction Sqlquerry block error")
        End Try
        con_cls.disconnect()
    End Sub

    Public Sub update_trans_cashbook(ByVal userName, ByVal type, ByVal remark)
        con_cls.connect()
        Try
            con_cls.cmd.CommandText = "SELECT MAX(tid) FROM TTABLECASHBOOK"
            dr = con_cls.cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    t_id = CInt(dr.Item(0))
                    t_id += 1
                Else
                    t_id = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction ID retrieve Sqlquerry block error")
        End Try
        dr.Close()
        Try
            con_cls.cmd.CommandText = "INSERT INTO TTABLECASHBOOK (tid,doe,userInfo,type,rem) VALUES (" & t_id & ",'" & System.DateTime.Now & "','" & userName & "','" & type & "','" & remark & "')"
            con_cls.cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction Sqlquerry block error")
        End Try
        con_cls.disconnect()
    End Sub

End Class
