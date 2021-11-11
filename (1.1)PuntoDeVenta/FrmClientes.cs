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
    public partial class FrmClientes : Form
    {
        public int id = 0;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            AgregarClientes();
            TodosCliente();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
            TodosCliente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
            TodosCliente();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            TodosCliente();
        }

        private void TodosCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                //SELECT * FROM Clientes
                var clientes = context.Clientes.ToList();
                dgvClientes.DataSource = clientes;
            }
        }

        private void AgregarClientes()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                var cliente = new Clientes();
                cliente.Nombre = txtNombre.Text;
                cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                cliente.Sexo = rbFemenino.Checked ? "Femenino" : "Masculino";
                cliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                cliente.RFC = txtRFC.Text;

                //Notificamos a EFC el agregar un cliente
                context.Clientes.Add(cliente);

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
                    var cliente = context.Clientes.First(x => x.Id == id);
                    if (cliente != null)
                    {
                        cliente.Nombre = txtNombre.Text;
                        cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                        cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                        cliente.Sexo = rbFemenino.Checked ? "Femenino" : "Masculino";
                        cliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        cliente.RFC = txtRFC.Text;
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
                    var cliente = context.Clientes.First(x => x.Id == id);
                    if (cliente != null)
                    {
                        context.Remove(cliente);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            if (dgvClientes.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbFemenino.Checked = true;
            }
            else
            {
                rbMasculino.Checked = true;
            }
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvClientes.CurrentRow.Cells[5].Value.ToString());
            txtRFC.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
