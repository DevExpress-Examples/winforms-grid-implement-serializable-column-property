# How to implement your own serializable property for the GridColumn


<p>When the GridColumn becomes invisible, it's VisibleIndex property returns -1. This example demonstrates how to implement a property that stores an old visible index, and save its value when one of the GridView.SaveLayoutTo.. methods is called. So, after the layout has been restored, setting the GridColumn.Visible property to true automatically moves this column to the position, where this column was before being hidden.<br />
To accomplish this task, create a GridColumn descendant, and add the necessary property. To notify the XtraSerializer that this property should be serialized, apply the XtraSerializableAttribute attribute to this column.</p><p>Please note, that this example uses an internal functionality, which can be changed in the future. We'll update the example, if this functionality will be changed.</p>


<h3>Description</h3>

<p>To accomplish this task, create a GridColumn descendant, and add the necessary property. To notify the XtraSerializer that this property should be serialized, apply the XtraSerializableAttribute attribute to this column.</p><p>Please note, that this example uses an internal functionality, which can be changed in the future. This example will be updated, if this functionality is  changed.</p>

<br/>


