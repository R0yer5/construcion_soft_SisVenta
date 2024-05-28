using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionWindows.Mantenimiento
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            ClienteBL clienteBL = new ClienteBL();
            dgvCliente.DataSource = clienteBL.Listar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodCliente.Text == String.Empty)
            {
                MessageBox.Show("Por favor ingrese el código del cliente a actualizar");
                txtCodCliente.Focus();

            }
            else
            {
                Cliente cliente = new Cliente();
                cliente.CodCliente = txtCodCliente.Text.Trim();
                cliente.Apellidos = txtApellido.Text.Trim();
                cliente.Nombres = txtNombre.Text.Trim();
                cliente.Direccion = txtDireccion.Text.Trim();

                ClienteBL clienteBL = new ClienteBL();
                if (clienteBL.Actualizar(cliente))
                {
                    MessageBox.Show("Cliente actualizado correctamente");
                    Listar();

                    txtCodCliente.Clear();
                    txtApellido.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                }
                else
                {
                    MessageBox.Show("Error: No se pudo actualizar el cliente");
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (txtCodCliente.Text == String.Empty)
            {
                MessageBox.Show("Por favor ingrese codigo a eliminar");
                txtCodCliente.Focus();
            }
            else
            {
                string codCliente = txtCodCliente.Text.Trim();
                ClienteBL clienteBL = new ClienteBL();
                if (clienteBL.Eliminar(codCliente))
                {
                    MessageBox.Show("Cliente eliminado correctamente");
                    Listar();

                    txtCodCliente.Clear();
                    txtApellido.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                }
                else
                    MessageBox.Show("Error: No se elimino cliente");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteBL clienteBL = new ClienteBL();
            cliente.CodCliente = txtCodCliente.Text.Trim();
            cliente.Apellidos = txtApellido.Text.Trim();
            cliente.Nombres = txtNombre.Text.Trim();
            cliente.Direccion = txtDireccion.Text.Trim();

            if (clienteBL.Agregar(cliente) == true)
            {
                MessageBox.Show("Datos correctamente agregados");

                Listar();

            }
            else
            {
                MessageBox.Show("Error al agregar Cliente");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                txtBuscar.Focus();
                MessageBox.Show("Ingrese un codigo a buscar: Busqueda Exacta");
            }
            else
            {

                ClienteBL clienteBl = new ClienteBL();
                dgvCliente.DataSource = clienteBl.Buscar(txtBuscar.Text.Trim());
            }
        }
    }
}
