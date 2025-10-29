Imports System 'A diferencia de C# que usa using

Public Module Program 'A diferencia de C# que usa namespace
    Public Sub Main(args() As String)

        Dim perrito As Perro = New Perro()
        perrito.nombre = "Chizu"
        perrito.raza = "Pastor Alemán"
        perrito.altura = "0.70 cm"

        Console.WriteLine(perrito.comer("Carne")) 'Se utiliza la función comer

        Dim perrito2 As Perro = New Perro()
        perrito2.nombre = "Lasy"
        perrito2.altura = "0.60 cm"

        Console.WriteLine(perrito2.comer("Pollo"))

        Dim perrito3 As Perro = New Perro("Peluchin", "Poodle", "0.50")

        Console.WriteLine(perrito3.comer("Pan"))
    End Sub

End Module