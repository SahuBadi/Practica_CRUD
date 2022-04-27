using CapaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CECliente cliente) 
        {
            bool Resultado = true;

            if (cliente.Nombre == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre es un campo obligatorio.");
            }
            if(cliente.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El apellido es un campo obligatorio.");
            }
            if (cliente.Foto == null)
            {
                Resultado=false;
                MessageBox.Show("La Foto de perfil es un campo obligatorio.");
            }

            return Resultado;
        }

        public void PruebaMySql()
        {
            cDCliente.PruebaConexion();
        }
        public void CrearCliente(CECliente cE)
        {
            cDCliente.InsercionDatos(cE);
        }

        public DataSet ConsultaClientes()
        {
            return cDCliente.ConsultaDatos();
        }

        public void EditarCliente(CECliente cE)
        {
            cDCliente.ModificacionDatos(cE);
        }

        public void EliminarCliente(CECliente cE)
        {
            cDCliente.BorradoDatos(cE);
        }
    }
}