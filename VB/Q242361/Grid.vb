Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports System.ComponentModel
Imports DevExpress.Utils.Serializing

Namespace DXSample
    Public Class MyGridControl
        Inherits GridControl

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New MyGridViewInfoRegistrator())
        End Sub
    End Class

    Public Class MyGridView
        Inherits GridView

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal grid As GridControl)
            MyBase.New(grid)
        End Sub

        Friend Const MyGridViewName As String = "MyGridView"

        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return MyGridViewName
            End Get
        End Property

        Protected Overrides Function CreateColumnCollection() As GridColumnCollection
            Return New MyGridColumnCollection(Me)
        End Function
    End Class

    Public Class MyGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return MyGridView.MyGridViewName
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New MyGridView(grid)
        End Function
    End Class

    Public Class MyGridColumnCollection
        Inherits GridColumnCollection

        Public Sub New(ByVal view As ColumnView)
            MyBase.New(view)
        End Sub

        Protected Overrides Function CreateColumn() As GridColumn
            Return New MyGridColumn()
        End Function
    End Class

    Public Class MyGridColumn
        Inherits GridColumn

        Public Sub New()
            MyBase.New()
        End Sub


        Private oldVisibleIndex_Renamed As Integer = -1
        <XtraSerializableProperty, XtraSerializablePropertyId(LayoutIdLayout)> _
        Public Property OldVisibleIndex() As Integer
            Get
                Return oldVisibleIndex_Renamed
            End Get
            Set(ByVal value As Integer)
                If value = -1 Then
                    Return
                End If
                oldVisibleIndex_Renamed = value
            End Set
        End Property

        Protected Overrides Sub Assign(ByVal column As GridColumn)
            MyBase.Assign(column)
            Dim source As MyGridColumn = TryCast(column, MyGridColumn)
            If source Is Nothing Then
                Return
            End If
            OldVisibleIndex = source.OldVisibleIndex
        End Sub

        Public Overrides Property VisibleIndex() As Integer
            Get
                Return MyBase.VisibleIndex
            End Get
            Set(ByVal value As Integer)
                oldVisibleIndex_Renamed = value
                MyBase.VisibleIndex = value
            End Set
        End Property

        Public Overrides Property Visible() As Boolean
            Get
                Return MyBase.Visible
            End Get
            Set(ByVal value As Boolean)
                If Not MyBase.Visible AndAlso value AndAlso VisibleIndex = -1 Then
                    VisibleIndex = OldVisibleIndex
                End If
                MyBase.Visible = value
            End Set
        End Property
    End Class
End Namespace