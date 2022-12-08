using CRUD.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACI
{
    public partial class Form1 : Form
    {

        private List<Evento> mEventos;
        private EventoConsultas mEventoConsultas;
        
        public Form1()
        {
            InitializeComponent();
            mEventos = new List<Evento>();
            mEventoConsultas = new EventoConsultas();
            cargarEventos();
        }

        private void cargarEventos(string filtro = "")
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            mEventos.Clear();
            mEventos = mEventoConsultas.consultarEventos(filtro);

            for(int i = 0; i < mEventos.Count(); i++){
                dataGridView1.RowTemplate.Height = 50;
                dataGridView1.Rows.Add(mEventos[i].codigo, mEventos[i].nombre, mEventos[i].ponente, mEventos[i].descripcion,
                    mEventos[i].sellos, mEventos[i].fecha, mEventos[i].lugar, mEventos[i].horarioInicio, mEventos[i].horarioFin);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
