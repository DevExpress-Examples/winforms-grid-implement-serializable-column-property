<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128629983/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1951)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Implement a serializable property for the grid column

> **Important**
>
> This example uses internal APIs that may change in newer versions.

The [VisibleIndex](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Columns.GridColumn.VisibleIndex) property returns **-1** if a column is hidden. This example demonstrates how to implement a serializable property that stores the visible index of a column before the column is hidden. This allows you to save and restore the position of hidden columns when saving/loading the grid layout.

### Implementation Details

* Create a `GridColumn` descendant (`MyGridColumn`).
* Implement a new property and apply the `XtraSerializableAttribute` attribute:
  
  ```csharp
  private int oldVisibleIndex = -1;
  [XtraSerializableProperty, XtraSerializablePropertyId(LayoutIdLayout)]
  public int OldVisibleIndex {
      get { return oldVisibleIndex; }
      set {
          if (value == -1) return;
          oldVisibleIndex = value; 
      }
  }
  ```


## Files to Review

* [Grid.cs](./CS/Q242361/Grid.cs) (VB: [Grid.vb](./VB/Q242361/Grid.vb))
