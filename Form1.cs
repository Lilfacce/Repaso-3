using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repaso_3;

namespace Repaso_3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Propietarios> propietarios = new List<Propietarios>();
        List<Propiedades> propiedades = new List<Propiedades>();
        List<Reporte> reportes = new List<Reporte>();
        public void MostrarReporte()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }
        public void CargarPropietarios()
        {

            string fileName = "Propietarios.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {

                Propietarios propietario = new Propietarios();
                propietario.Dpi = Convert.ToInt32(reader.ReadLine());
                propietario.Nombre = (reader.ReadLine());
                propietario.Apellido = (reader.ReadLine());


                //Guardar el empleado en la lista de Empleados
                propietarios.Add(propietario);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        public void CargarPropiedades()
        {

            string fileName = "Propiedades.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {

                Propiedades propiedad = new Propiedades();
                propiedad.NumeroCasa = Convert.ToInt32(reader.ReadLine());
                propiedad.Dpi = Convert.ToInt32(reader.ReadLine());
                propiedad.Cuota = Convert.ToDecimal(reader.ReadLine());


                //Guardar el empleado en la lista de Empleados
                propiedades.Add(propiedad);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportes.Clear();
            //Ya deben estar llenas todas las listas
            //Recorre cada alquiler
            foreach (var propietario in propietarios)
            {
                //obtiene los datos del cliente que alquilo el vehiculo
                Propiedades propiedad = propiedades.Find(c => c.Dpi == propietario.Dpi);


                //Meter todos los datos obtenidos a la lista reporte
                Reporte reporte = new Reporte();
                reporte.Name = propietario.Nombre;
                reporte.Second_name = propietario.Apellido;
                reporte.Casa = propiedad.NumeroCasa;
                reporte.CuotaMan = propiedad.Cuota;

                reportes.Add(reporte);
            }



            MostrarReporte();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
            CargarPropietarios();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void buttonAscender_Click(object sender, EventArgs e)
        {
            reportes = reportes.OrderBy(p => p.CuotaMan).ToList();
            MostrarReporte();
            dataGridView1.ForeColor = Color.DarkGreen;
        }

        private void buttonDescender_Click(object sender, EventArgs e)
        {
            reportes = reportes.OrderByDescending(p => p.CuotaMan).ToList();
            MostrarReporte();
            dataGridView1.ForeColor = Color.DarkRed;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            decimal CuotaMayor = propiedades.Max(a => a.Cuota);
            foreach (var reporte in reportes)
            {
                if (CuotaMayor == reporte.CuotaMan)
                {
                    label3.Text = reporte.Name.ToString();
                }
            }
            label4.Text = "Q. " + CuotaMayor.ToString();

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
