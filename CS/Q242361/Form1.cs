using DevExpress.XtraEditors;
using System;
using System.ComponentModel;

namespace Q242361
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new BindingList<Item>();
            for (int i = 0; i < 5; i++)
                list.Add(new Item() { ID = i, Name = "Name" + i, Description = "Description" + i });
            myGridControl1.DataSource = list;
        }

        private const string LayoutPath = @"..\..\layout.xml";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            myGridView1.SaveLayoutToXml(LayoutPath);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            myGridView1.RestoreLayoutFromXml(LayoutPath);
        }
    }
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}