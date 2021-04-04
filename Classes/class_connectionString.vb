Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class class_connectionString
    Public cn, cnFailsafe As New SqlConnection
    Public cmd, cmdFailsafe As New SqlCommand

    Public Sub connect()
        If Not cn.State = Data.ConnectionState.Open Then
            cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\DataItems\KVKDhalai_CashBook.mdf" & ";Integrated Security=True;User Instance=True")
            cmd.Connection = cn
            cn.Open()
        End If
    End Sub

    Public Sub disconnect()
        If cn.State = Data.ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Sub connectFailsafe()
        If Not cnFailsafe.State = Data.ConnectionState.Open Then
            cnFailsafe = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Failsafe\KVKDhalai_CashBook.mdf" & ";Integrated Security=True;User Instance=True")
            cmdFailsafe.Connection = cnFailsafe
            cnFailsafe.Open()
        End If
    End Sub

    Public Sub disconnectFailsafe()
        If cnFailsafe.State = Data.ConnectionState.Open Then
            cnFailsafe.Close()
        End If
    End Sub

    Public Sub softwareValidity(ByRef a)
        If System.DateTime.Today.Year > 2015 Then
            MessageBox.Show("Please contact developer c4subhajit@gmail.com", "Validity Expired.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            a.Close()
        End If
    End Sub

End Class
