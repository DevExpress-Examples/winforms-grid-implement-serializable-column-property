Imports DevExpress.XtraEditors
Imports System
Imports System.ComponentModel

Namespace Q242361

    Public Partial Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim list = New BindingList(Of Item)()
            For i As Integer = 0 To 5 - 1
                list.Add(New Item() With {.ID = i, .Name = "Name" & i, .Description = "Description" & i})
            Next

            myGridControl1.DataSource = list
        End Sub

        Private Const LayoutPath As String = "..\..\layout.xml"

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            myGridView1.SaveLayoutToXml(LayoutPath)
        End Sub

        Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
            myGridView1.RestoreLayoutFromXml(LayoutPath)
        End Sub
    End Class

    Public Class Item

        Public Property ID As Integer

        Public Property Name As String

        Public Property Description As String
    End Class
End Namespace
