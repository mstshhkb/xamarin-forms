Imports Xamarin.Forms

Public Class App
    Inherits Application

    Public Sub New()
        Dim navi = New NavigationPage(New Page1)
        navi.BarBackgroundColor = Color.FromHex("3498db")
        navi.BarTextColor = Color.White
        MainPage = navi
    End Sub
End Class
