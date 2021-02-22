using BLrentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Rentas
{
    public partial class FormProductos : Form
    {
        ProductosBL _productos;

        public FormProductos()
        {
            InitializeComponent();
            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show (producto)
        }
    }
}
