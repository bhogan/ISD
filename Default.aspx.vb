
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim connectionString As String = "Data Source=SIMON;Initial Catalog=BetaSYS39414;Persist Security Info=True;User ID=sking;Password=pxdrlgyu"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("ActiveUser") = "" Then
            Response.Redirect("../Account/Login.aspx")
        Else
            Dim SQLC As New Data.SqlClient.SqlCommand("EXEC CheckUserRoles")
            SQLC.Parameters.AddWithValue("@Username", Session("ActiveUser"))

            Dim rd As Data.SqlClient.SqlDataReader = SQLC.ExecuteReader()

            While rd.Read()
                If rd("Title") = "Coach" Then
                    Response.Redirect("../CoachHome.aspx")
                ElseIf rd("Title") = "Admin" Then
                    Response.Redirect("../AdminHome.aspx")
                ElseIf rd("Title") = "Athlete" Then
                    Response.Redirect("../AthleteHome.aspx")
                End If
            End While



        End If

    End Sub
End Class
