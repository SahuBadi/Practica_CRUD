using CapaEntidad;
using capaNegocio;
namespace capaPresentacion
{
    public partial class frClientes : Form
    {
        CNCliente cNCliente = new CNCliente();
        
        public frClientes()
        {
            InitializeComponent();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos(); 
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNCliente.ConsultaClientes().Tables["tbl"];

        }

         private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            CargarDatos();
        }

        private void LimpiarForm()
        {
            txtId.Value = 0;
            txtNombre.Text = "";
            txtApellido.Text = string.Empty;
            pickFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = String.Empty;

            if (ofdFoto.ShowDialog() == DialogResult.OK) 
            {
                pickFoto.Load(ofdFoto.FileName);
            }
            ofdFoto.FileName = String.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado;
            CECliente cECliente = new CECliente();
            cECliente.Id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text;
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = pickFoto.ImageLocation;

            Resultado = cNCliente.ValidarDatos(cECliente);
            if (Resultado == false)
            {
                return;
            }
            if (cECliente.Id == 0)
            {
                cNCliente.CrearCliente(cECliente);
            }
            else
            {
                cNCliente.EditarCliente(cECliente);
            }

            CargarDatos();
            LimpiarForm();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            if (MessageBox.Show("¿Desea eliminar el registro?", "Título",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CECliente cE = new CECliente();
                cE.Id = (int)txtId.Value;
                cNCliente.EliminarCliente(cE);
            }
            CargarDatos();
            LimpiarForm();
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            pickFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString());
        }
    }
}