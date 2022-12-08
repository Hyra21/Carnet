using CRUD.BD;
using SACI;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CRUD.Objects
{
    internal class EventoConsultas
    { 
        private ConexionMySql mConexion;
        private List<Evento> mEventos;

        public EventoConsultas()
        {
            mConexion = new ConexionMySql();
            mEventos = new List<Evento>();
        }

        public bool agregarEvento(Evento mEvento)
        {
            string INSERT = "INSERT INTO evento (Codigo, Nombre, Exponente, Descripcion, NumeroSellos, Fecha, Lugar, " +
                                                "HorarioInicio, HorarioFin, Matricula_Administrador, Correo_Director)" +
                                                " values (@Codigo, @Nombre, @Exponente, @Descripcion, @NumeroSellos, @Fecha, @Lugar, " +
                                                " @HorarioInicio, @HorarioFin, @Matricula_Administrador, @Correo_Director);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@Codigo", mEvento.codigo));
            mCommand.Parameters.Add(new MySqlParameter("@Nombre", mEvento.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@Exponente", mEvento.ponente));
            mCommand.Parameters.Add(new MySqlParameter("@Descripcion", mEvento.descripcion));
            mCommand.Parameters.Add(new MySqlParameter("@NumeroSellos", mEvento.sellos));
            mCommand.Parameters.Add(new MySqlParameter("@Fecha", mEvento.fecha));
            mCommand.Parameters.Add(new MySqlParameter("@Lugar", mEvento.lugar));
            mCommand.Parameters.Add(new MySqlParameter("@HorarioInicio", mEvento.horarioInicio));
            mCommand.Parameters.Add(new MySqlParameter("@HorarioFin", mEvento.horarioFin));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public bool modificarEvento(Evento mEvento)
        {
            string UPDATE = " UPDATE evento " +
                "SET Nombre = @Nombre, " +
                "Exponente = @Exponente, " +
                "Descripcion = @Descripcion " +
                "NumeroSellos = @NumeroSellos" +
                "Fecha = @Fecha" +
                "Lugar = @Lugar" +
                "HorarioInicio = @HorarioInicio" +
                "HorarioFin = @HorarioFin" +
                "WHERE Codigo = @Codigo";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@Codigo", mEvento.codigo));
            mCommand.Parameters.Add(new MySqlParameter("@Nombre", mEvento.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@Exponente", mEvento.ponente));
            mCommand.Parameters.Add(new MySqlParameter("@Descripcion", mEvento.descripcion));
            mCommand.Parameters.Add(new MySqlParameter("@NumeroSellos", mEvento.sellos));
            mCommand.Parameters.Add(new MySqlParameter("@Fecha", mEvento.fecha));
            mCommand.Parameters.Add(new MySqlParameter("@Lugar", mEvento.lugar));
            mCommand.Parameters.Add(new MySqlParameter("@HorarioInicio", mEvento.horarioInicio));
            mCommand.Parameters.Add(new MySqlParameter("@HorarioFin", mEvento.horarioFin));

            return mCommand.ExecuteNonQuery() > 0;
        }

        public bool eliminarEvento(Evento mEvento)
        {
            string DELETE = " DELETE FROM evento WHERE Codigo=@Codigo";
            MySqlCommand mCommand = new MySqlCommand(DELETE, mConexion.getConexion());
            mCommand.Parameters.Add(new MySqlParameter("@id", mEvento.codigo));
            return mCommand.ExecuteNonQuery() > 0;
        }

        public List<Evento> consultarEventos(string filtro)
        {
            string CONSULTA = "SELECT * FROM evento";

            MySqlDataReader mReader = null;
            Evento mEvento;
            try
            {
                if (filtro != "")
                {
                    CONSULTA += " WHERE " +
                        "id LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "precio LIKE '%" + filtro + "%' OR " +
                        "cantidad LIKE '%" + filtro + "%';";
                }

                MySqlCommand mCommand = new MySqlCommand(CONSULTA);
                mCommand.Connection = mConexion.getConexion();
                mReader = mCommand.ExecuteReader();

                
                while (mReader.Read())
                {
                    mEvento = new Evento();
                    mEvento.codigo = mReader.GetInt16("Codigo");
                    mEvento.nombre = mReader.GetString("Nombre");
                    mEvento.ponente = mReader.GetString("Exponente");
                    mEvento.descripcion = mReader.GetString("Descripcion");
                    mEvento.sellos = mReader.GetInt16("NumeroSellos");
                    mEvento.fecha = mReader.GetString("Fecha");
                    mEvento.lugar = mReader.GetString("Lugar");
                    mEvento.horarioInicio = mReader.GetString("HorarioInicio");
                    mEvento.horarioFin = mReader.GetString("HorarioFin");
                    mEventos.Add(mEvento);
                }
                mReader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                mConexion.closeConexion();
            }

            return mEventos;
        }
    }
}
