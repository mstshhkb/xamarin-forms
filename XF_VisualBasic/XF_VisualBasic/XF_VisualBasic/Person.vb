Public Class Person
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _birthday As DateTime
    Public Property Birthday() As DateTime
        Get
            Return _birthday
        End Get
        Set(ByVal value As DateTime)
            _birthday = value
        End Set
    End Property
    Private _image As String
    Public Property Image() As String
        Get
            Return _image
        End Get
        Set(ByVal value As String)
            _image = value
        End Set
    End Property
End Class
