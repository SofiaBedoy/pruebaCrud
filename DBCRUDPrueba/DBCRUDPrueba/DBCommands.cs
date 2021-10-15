using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCRUDPrueba
{
    public class DBCommands
    {
        static SQLiteConnection conexion;

        //usar este
        public static void CrearBBDDSiNoExiste()
        {
            if (!File.Exists("resultados.sqlite"))
            {
                // Creamos la conexion a la BD. 
                // El Data Source contiene la ruta del archivo de la BD 
                conexion =
                      new SQLiteConnection
                      ("Data Source=resultados.sqlite;Version=3;New=True;Compress=True;");
                SQLiteCommand cmd;

                //usa tablas no script de preguntas

                #region Tablas

                string EQUIPO = "CREATE TABLE \"Equipo\" (	" +
                    "\"id\"	INTEGER NOT NULL,	" +
                    "\"fechaentrada\"	TEXT,	" +
                    "\"marca\"	TEXT,	\"modelo\"	TEXT,	" +
                    "\"serie\"	TEXT,	\"tipo\"	TEXT,	" +
                    "\"procesador\"	TEXT,	" +
                    "\"capacidad\"	TEXT,	" +
                    "\"estado\"	TEXT,	" +
                    "PRIMARY KEY(\"id\"));";

                conexion.Open();
                cmd = new SQLiteCommand(EQUIPO, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                #endregion
            }
            else
            {
                // Creamos la conexion a la BD. 

                // El Data Source contiene la ruta del archivo de la BD 
                conexion =
                      new SQLiteConnection
                      ("Data Source=resultados.sqlite;Version=3;New=False;Compress=True;");
                conexion.Open();
                conexion.Close();
            }
        }
        public static void InsertarComputadora(string fecha, string marca, string modelo, string serie, string tipo,
            string procesador, string capacidad, string estado)
        {
            string insercion;
            SQLiteCommand sql_cmd;

            try
            {
                conexion =
                      new SQLiteConnection
                      ("Data Source=resultados.sqlite;Version=3;New=True;Compress=True;");
                conexion.Open();

                sql_cmd = conexion.CreateCommand();

                insercion = "INSERT INTO Equipo (fechaentrada, marca, modelo, serie, tipo, procesador, capacidad, estado) VALUES" +
                    fecha + "', '" +
                    marca + "', '" +
                    modelo + "', '" +
                    serie + "', '" +
                    tipo + "', '" +
                    procesador + "', '" +
                    capacidad + "', '" +
                    estado + "', '";

                sql_cmd.CommandText = insercion;
                sql_cmd.ExecuteNonQuery();
                conexion.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show("No se ha podido insertar. /n" + e.ToString());
            }
        }


        //usar este
        public static void EliminarDato(string id)
        {
            string borrado;
            SQLiteCommand sql_cmd;

            try
            {
                conexion =
                      new SQLiteConnection
                      ("Data Source=resultados.sqlite;Version=3;New=True;Compress=True;");
                sql_cmd = conexion.CreateCommand();

                conexion.Open();
                borrado = "DELETE FROM Equipo WHERE id = \"" + id + "\";";
                sql_cmd.CommandText = borrado;
                sql_cmd.ExecuteNonQuery();
                conexion.Close();
            }

            catch
            {
                MessageBox.Show("No se ha podido borrar.");
            }
        }

        //usar este
        public static string QueryResultado(string query)
        {
            string result = "";
            conexion =
                      new SQLiteConnection
                      ("Data Source=resultados.sqlite;Version=3;New=True;Compress=True;");
            try
            {
                conexion.Open();
                SQLiteCommand cmd = conexion.CreateCommand();
                cmd.CommandText = query;
                result = cmd.ExecuteScalar().ToString();
            }
            finally
            {
                conexion.Close();
            }
            return result;
        }


        public static DataTable CargarTabla(string comando)
        {
            conexion = new SQLiteConnection
                ("Data Source=resultados.sqlite;Version=3;New=False;Compress=True;");
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();

            conexion.Open();
            // Lanzamos la consulta y preparamos la estructura para leer datos

            sql_cmd = conexion.CreateCommand();
            string CommandText = comando;
            DB = new SQLiteDataAdapter(CommandText, conexion);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];

            conexion.Close();

            return DT;
        }

        
    }
}
