Imports System.Diagnostics
Imports System.Data.SqlClient


Partial Class Account_Login
    Inherits System.Web.UI.Page

    Dim connectionString As String = "Data Source=SIMON;Initial Catalog=BetaSYS39414;Persist Security Info=True;User ID=sking;Password=pxdrlgyu"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
    End Sub

    Protected Sub LoginButton_Click(sender As Object, e As System.EventArgs)


        Dim accountName As String = LoginUser.UserName
        Dim password As String = LoginUser.Password

        Dim con1 As New SqlConnection(connectionString)
        Dim cmdLogin As New SqlCommand("SELECT * FROM UserTable WHERE Username = '" + accountName + "' ", con1)

        Debug.Print("SELECT * FROM User WHERE Username = '" + accountName + "'")

        con1.Open()

        Dim rd As SqlDataReader = cmdLogin.ExecuteReader()



        If rd.HasRows() Then
            While rd.Read()
                Dim UserID As String = String.Format(rd("UserID"))
                'Dim DataAdapter As SqlDataAdapter

                Dim con2 As SqlConnection

                con2 = New SqlConnection(connectionString)


                Debug.Print("UserID =" + UserID)

                Dim cmdSession As New SqlCommand("INSERT INTO Session (UserID, Active)" _
                                                 + "VALUES (@UserID, @Active) ", con2)
                cmdSession.Parameters.AddWithValue("@UserID", UserID)
                cmdSession.Parameters.AddWithValue("@Active", 1)


                'SqlCommand.Parameters.AddWithValue("@last", last_name)

                con2.Open()
                If (cmdSession.ExecuteNonQuery().Equals(1)) Then
                    Debug.Print("created session for UserID " + UserID)
                Else
                    Debug.Print("NOPE")
                End If

                Debug.Print("valid login")
                Response.Redirect("../About.aspx")

                con2.Close()
            End While
            
        Else
            Debug.Print("INVALID login. Try again please")
        End If






        Debug.Print("accountName {0} and password {1}", accountName, password)

        con1.Close()




    End Sub
End Class