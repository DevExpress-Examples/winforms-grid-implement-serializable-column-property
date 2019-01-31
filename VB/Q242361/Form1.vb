Imports Microsoft.VisualBasic
Imports DevExpress.XtraEditors
Imports System
Imports System.ComponentModel

Namespace Q242361
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim list = New BindingList(Of Item)()
			For i As Integer = 0 To 4
				list.Add(New Item() With {.ID = i, .Name = "Name" & i, .Description = "Description" & i})
			Next i
			myGridControl1.DataSource = list
		End Sub

		Private Const LayoutPath As String = "..\..\layout.xml"
		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			myGridView1.SaveLayoutToXml(LayoutPath)
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			myGridView1.RestoreLayoutFromXml(LayoutPath)
		End Sub
	End Class
	Public Class Item
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
	End Class
End Namespace