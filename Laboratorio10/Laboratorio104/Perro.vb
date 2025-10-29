Public Class Perro
    'Declara las variables para la clase
    Public nombre As String
    Public raza As String
    Public altura As String

    Public Function comer(carne As String) As String ' Utiliza e imprime los datos ingresados en el programa principal
        Return nombre + " mide " + altura + " y comerá " + carne
    End Function
    Public Sub dormir()

    End Sub
    Public Sub ladrar()

    End Sub
    Public Function calcularCosto(costo As Double, impuesto As Double)
        Dim preciototal As Double
        preciototal = costo + (costo * impuesto)
        Return preciototal
    End Function
    Public Sub New()

    End Sub
    Public Sub New(nombre As String, raza As String, altura As String) 'Reconoce las variables del programa principal
        Me.nombre = nombre
        Me.raza = raza
        Me.altura = altura
    End Sub
End Class
