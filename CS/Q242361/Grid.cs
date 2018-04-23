using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel;
using DevExpress.Utils.Serializing;

namespace DXSample {
    public class MyGridControl : GridControl {
        public MyGridControl() : base() { }

        protected override void RegisterAvailableViewsCore(InfoCollection collection) {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }
    }

    public class MyGridView : GridView {
        public MyGridView() : base() { }
        public MyGridView(GridControl grid) : base(grid) { }

        internal const string MyGridViewName = "MyGridView";

        protected override string ViewName { get { return MyGridViewName; } }

        protected override GridColumnCollection CreateColumnCollection() {
            return new MyGridColumnCollection(this);
        }
    }

    public class MyGridViewInfoRegistrator : GridInfoRegistrator {
        public MyGridViewInfoRegistrator() : base() { }

        public override string ViewName { get { return MyGridView.MyGridViewName; } }

        public override BaseView CreateView(GridControl grid) {
            return new MyGridView(grid);
        }
    }

    public class MyGridColumnCollection : GridColumnCollection {
        public MyGridColumnCollection(ColumnView view) : base(view) { }

        protected override GridColumn CreateColumn() {
            return new MyGridColumn();
        }
    }

    public class MyGridColumn : GridColumn {
        public MyGridColumn() : base() { }

        private int oldVisibleIndex = -1;
        [XtraSerializableProperty, XtraSerializablePropertyId(LayoutIdLayout)]
        public int OldVisibleIndex {
            get { return oldVisibleIndex; }
            set {
                if (value == -1) return;
                oldVisibleIndex = value; 
            }
        }

        protected override void Assign(GridColumn column) {
            base.Assign(column);
            MyGridColumn source = column as MyGridColumn;
            if (source == null) return;
            OldVisibleIndex = source.OldVisibleIndex;
        }

        public override int VisibleIndex {
            get { return base.VisibleIndex; }
            set {
                oldVisibleIndex = value;
                base.VisibleIndex = value;
            }
        }

        public override bool Visible {
            get { return base.Visible; }
            set {
                if (!base.Visible && value && VisibleIndex == -1)
                    VisibleIndex = OldVisibleIndex;
                base.Visible = value;
            }
        }
    }
}