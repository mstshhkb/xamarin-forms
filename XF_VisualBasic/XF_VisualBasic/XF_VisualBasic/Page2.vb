Imports Xamarin.Forms
Public Class Page2
    Inherits ContentPage

    Public Sub New()

        Dim persons = New List(Of Person)
        Dim p0 = New Person With {.Name = "新川由実", .Birthday = New DateTime(1992, 05, 13), .Image = "f.png"}
        Dim p1 = New Person With {.Name = "今田義孝", .Birthday = New DateTime(1965, 05, 03), .Image = "m.png"}
        Dim p2 = New Person With {.Name = "浦野次夫", .Birthday = New DateTime(1967, 06, 27), .Image = "m.png"}
        Dim p3 = New Person With {.Name = "鶴田正博", .Birthday = New DateTime(1970, 02, 16), .Image = "m.png"}
        Dim p4 = New Person With {.Name = "大島唯花", .Birthday = New DateTime(1989, 03, 13), .Image = "f.png"}
        Dim p5 = New Person With {.Name = "木下政人", .Birthday = New DateTime(2011, 08, 19), .Image = "c.png"}
        Dim p6 = New Person With {.Name = "岡崎心優", .Birthday = New DateTime(2014, 05, 25), .Image = "c.png"}
        Dim p7 = New Person With {.Name = "角忠", .Birthday = New DateTime(1963, 06, 26), .Image = "m.png"}
        Dim p8 = New Person With {.Name = "西島梢", .Birthday = New DateTime(1976, 10, 21), .Image = "f.png"}
        Dim p9 = New Person With {.Name = "寺本昭三", .Birthday = New DateTime(1985, 06, 21), .Image = "m.png"}
        persons.Add(p0)
        persons.Add(p1)
        persons.Add(p2)
        persons.Add(p3)
        persons.Add(p4)
        persons.Add(p5)
        persons.Add(p6)
        persons.Add(p7)
        persons.Add(p8)
        persons.Add(p9)

        Dim list = New ListView With {.ItemsSource = persons,
            .ItemTemplate = New DataTemplate(GetType(MyCell)),
            .HasUnevenRows = True,
            .SeparatorVisibility = False}

        Me.Title = "Page2"
        Me.Content = list
    End Sub
End Class
