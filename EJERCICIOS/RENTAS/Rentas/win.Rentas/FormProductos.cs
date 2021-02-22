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
            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;
            var resultado = _productos.GuardarProducto(producto);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show("OCURRIO UN ERROR GUARDANDO EL PRODUCTO");
            }
            
        }

        private void listaProductosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();
            DeshabilitarHabilitarBotones(false);

        }

        private void DeshabilitarHabilitarBotones (bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButton1Cancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
                if (idTextBox.Text != "")
            {
                var id = Convert.ToInt32(idTextBox.Text);
                Eliminar(id);
            }
        }

        private void Eliminar (int id)
        {
            
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("OCURRIO UN ERROR AL ELIMINAR EL PRODUCTO");
            }



        }



        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1Cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
