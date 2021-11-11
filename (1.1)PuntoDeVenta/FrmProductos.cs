using _1._1_PuntoDeVenta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_PuntoDeVenta
{
    public partial class FrmProductos : Form
    {
        public int id = 0;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
            TodosProducto();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
            TodosProducto();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
            TodosProducto();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            TodosProducto();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var producto = context.Productos.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
                dgvProductos.DataSource = producto;
            }
        }

        private void TodosProducto()
        {
            using (var context = new ApplicationDbContext())
            {
                //SELECT * FROM Productos
                var producto = context.Productos.ToList();
                dgvProductos.DataSource = producto;
            }
        }

        private void AgregarProducto()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                var producto = new Productos();
                producto.Nombre = txtNombre.Text;
                producto.Marca = txtMarca.Text;
                producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                producto.PrecioCompra = Convert.ToInt32(txtPrecioCompra.Text);
                producto.PrecioVenta = Convert.ToInt32(txtPrecioVenta.Text);
                
                //Notificamos a EFC el agregar un cliente
                context.Productos.Add(producto);

                //Guarda los cambios
                context.SaveChanges();
            }
        }

        private void ModificarCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                if (id != 0)
                {
                    //buscar con un ORM
                    var producto = context.Productos.First(x => x.Id == id);
                    if (producto != null)
                    {
                        producto.Nombre = txtNombre.Text;
                        producto.Marca = txtMarca.Text;
                        producto.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        producto.PrecioCompra = Convert.ToInt32(txtPrecioCompra.Text);
                        producto.PrecioVenta = Convert.ToInt32(txtPrecioVenta.Text);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void EliminarCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                if (id != 0)
                {
                    //buscar con un ORM
                    var producto = context.Productos.First(x => x.Id == id);
                    if (producto != null)
                    {
                        context.Remove(producto);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtMarca.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioCompra.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
        }


    }
}
