Imports Xamarin.Forms

Public Class MyCell
    Inherits ViewCell

    Public Sub New()

        Dim img = New Image With {.WidthRequest = 80,
            .HeightRequest = 80,
            .BackgroundColor = Device.OnPlatform(Color.FromHex("ececec"), Color.Default, Color.Default)}
        img.SetBinding(Image.SourceProperty, "Image")
        Dim name As New Label With {.TextColor = Color.Default,
            .FontSize = Device.GetNamedSize(NamedSize.Large, GetType(Label))}
        name.SetBinding(Label.TextProperty, "Name")
        Dim birthday As New Label With {.TextColor = Color.Accent}
        birthday.SetBinding(Label.TextProperty,
                            New Binding("Birthday", stringFormat:="{0:yyyy年MM月dd日生まれ}"))

        Dim subCell = New StackLayout With {.Spacing = 10,
            .VerticalOptions = LayoutOptions.CenterAndExpand}
        subCell.Children.Add(name)
        subCell.Children.Add(birthday)

        Dim mainCell = New StackLayout With {.Orientation = StackOrientation.Horizontal,
            .Spacing = 10,
            .Padding = 5}
        mainCell.Children.Add(img)
        mainCell.Children.Add(subCell)

        Me.View = mainCell

    End Sub
End Class