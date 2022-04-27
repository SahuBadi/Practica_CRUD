using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data;

namespace capaDatos {
    public class CDCliente
    {
        string CadenaConexion = "Server=localhost;User=root;Password=12345;Port=3306;database=curso_cs";

        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return;
            }
            mySqlConnection.Close();
            MessageBox.Show("Conexión establecida. ");
        }

        public void InsercionDatos(CECliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `cliente` (`nombre`, `apellido`, `foto`) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro añadido. ");
        }
        public void ModificacionDatos(CECliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `cliente` SET `nombre`='" + cE.Nombre + "', `apellido`='" + cE.Apellido + "', `foto`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "' WHERE  `id`="+ cE.Id+";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro modificado. ");
        }
        public void BorradoDatos(CECliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `cliente` WHERE  `id`="+ cE.Id+";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro eliminado. ");
        }
        public DataSet ConsultaDatos()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `cliente` LIMIT 1000;";
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            DataSet dataSet = new DataSet();
            Adaptador.Fill(dataSet, "tbl");

            return dataSet;
        }

        public DataSet ConsultaDatosFila(CECliente cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `cliente` where id=" + cE.Id + ";";
            MySqlDataAdapter Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            DataTable dt = new DataTable();
            DataSet dataSet = new DataSet();
            Adaptador.Fill(dataSet, "tbl");

            return dataSet;
        }


    }



}

