using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Lacteo;
using System.IO;

namespace Win.Lacteo
{
    public partial class FormProductos : Form
    {

        ProductosBL _productos;
        CategoriaBL _categorias;
        TiposBL _tiposBL;

        public FormProductos()
        {
            InitializeComponent();

            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();

            _categorias = new CategoriaBL();
            listaCategoriasBindingSource.DataSource = _categorias.ObtenerCategorias();

            _tiposBL = new TiposBL();
            listaTiposBindingSource.DataSource = _tiposBL.ObtenerTipos();



        }

        private void listaProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();

            var producto = (Producto)listaProductosBindingSource.Current;
;

            if(fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageToByArray(fotoPictureBox.Image);
            }
            else
            {
                producto.Foto = null;
            }


            var resultado = _productos.GuardarProducto(producto);
            if (resultado.Exitoso == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                deshalitarHabilitarBotones(true);
                MessageBox.Show("Producto Guardado!");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.agregarProducto();
            listaProductosBindingSource.MoveLast();

            deshalitarHabilitarBotones(false);
        }

        private void deshalitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)


                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Elmininar(id);
                }
            }
        }

        private void Elmininar(int id)
        {
            
            var resultado = _productos.eliminarProducto(id);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            deshalitarHabilitarBotones(true);
            Elmininar(0);

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void precioTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void existenciaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var producto = (Producto)listaProductosBindingSource.Current;
           
            if (producto != null)

            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }


            }
            else
            {
                MessageBox.Show("Cree un producto antes de asignarle una imagen");
            }
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaIdLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

