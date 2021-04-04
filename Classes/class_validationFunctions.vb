Imports System.Data
Imports System.Data.SqlClient

Public Class class_validationFunctions
    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString

    Public a, c As String
    Public b, e As Control
    Public d As Date
    Public charecter As Char
    Public ascii As Integer
    Public decimal_count, digit_after_decimal, digit_before_decimal As Integer
    Private acctype As String
    Public err_code As Integer

    '==================================================================================
    '==================================================================================
    '                  
    '==================================================================================
    '==================================================================================

    ' LOGIN USER ID AND PASSWORD VALIDATION
    Public Sub idpass_validate(ByVal a, ByRef b)
        If Not a = "" Then
            err_code = 0

            If Not Len(a) < 21 Then
                err_code = 1
                MsgBox("User ID and Password field length limitation is within 20 charecters", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'MODIFY LOGIN PASSWORD VALIDATION
    Public Sub pass_validate(ByVal a, ByVal c, ByRef b)
        If (Not a = "") And (Not c = "") Then
            err_code = 0
            If (Not Len(a) < 21) And (Not Len(c) < 21) Then
                err_code = 1
                MsgBox("Password field length limitation is within 20 charecters", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
            If Not a = c Then
                err_code = 1
                MsgBox("Password and confirm password doesnot match", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'TEXT FIELD VALIDATION
    Public Sub txtField_validate(ByVal a, ByRef b)
        If Not a = "" Then
            err_code = 0
            If Not Len(a) < 251 Then
                err_code = 1
                MsgBox("Field limitation is within 250 charecters", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'AMOUNT VALIDATION
    Public Sub amount_validate(ByVal a, ByRef b)
        If Not a = "" Then
            err_code = 0
            decimal_count = 0
            digit_after_decimal = 0
            For i = 1 To Len(a)
                charecter = GetChar(a, i)
                ascii = Asc(charecter)
                If Not ((ascii >= 48 And ascii <= 57) Or ascii = 46) Then
                    err_code = 1
                    MsgBox("Special charecter(s)/ Alphanumeric(s) not allowed", MsgBoxStyle.OkOnly, "Validation error")
                    b.Focus()
                    Exit Sub
                End If
                If ascii = 46 Then
                    decimal_count += 1
                End If
                If decimal_count > 0 Then
                    digit_after_decimal += 1
                End If
            Next
            If decimal_count > 1 Then
                err_code = 1
                MsgBox("Only one decimal point expected", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
            If digit_after_decimal > 3 Then
                err_code = 1
                MsgBox("Only two digits allowed after decimal point", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
            If Not Len(a) <= 18 Then
                err_code = 1
                MsgBox("Field value limitation within 18 charecters including decimal point", MsgBoxStyle.OkOnly, "Validation error")
                b.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'CASH DETAILS DATE VALIDATION
    Public Sub cashDetailsDate_validate(ByVal d, ByRef b)
        err_code = 0
        Try
            con_cls.connect()
            con_cls.cmd.CommandText = "SELECT MAX(date_rap) FROM CASHBOOK"
            dr = con_cls.cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    If d < CDate(dr.Item(0)) Then
                        err_code = 1
                        MsgBox("New cash details date cannot be earlier to the last cash details date " & dr.Item(0), MsgBoxStyle.OkOnly, "Validation error")
                        b.Focus()
                        dr.Close()
                        con_cls.disconnect()
                        Exit Sub
                    End If
                End If
                dr.Close()
            End If
            con_cls.disconnect()
            If d.Date > System.DateTime.Today Then
                MsgBox("New cash details date cannot be a future date ", MsgBoxStyle.OkOnly, "Validation error")
                err_code = 1
                b.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Validation cashbook details date, exception info")
        End Try
    End Sub

End Class
