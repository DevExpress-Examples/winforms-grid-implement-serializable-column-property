using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Q242361 {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);

        }

        private const string LayoutPath = @"..\..\layout.xml";
        private void simpleButton1_Click(object sender, EventArgs e) {
            myGridView1.SaveLayoutToXml(LayoutPath);
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            myGridView1.RestoreLayoutFromXml(LayoutPath);
        }
    }
}