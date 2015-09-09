Imports Xamarin.Forms

Public Class Page1
    Inherits ContentPage

    Public Sub New()
        Dim label = New Label With {.XAlign = TextAlignment.Center,
            .FontSize = 20,
            .Text = "Page1 ContentPage"
        }

        Dim button = New Button With {
            .Text = "Move to Next Page.",
            .Command = New Command(Async Sub()
                                       Await Navigation.PushAsync(New Page2)
                                   End Sub)
        }

        Dim stack = New StackLayout With {
            .VerticalOptions = LayoutOptions.Center
            }
        stack.Children.Add(label)
        stack.Children.Add(button)

        Me.Title = "Page1"
        Me.Padding = New Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0)
        Me.Content = stack
    End Sub
End Class
