using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Prom_FMED
{
    public partial class Form1 : Form
    {
        double _promedio;
        public Form1()
        {
            InitializeComponent();
        }

        public double Promediar()
        {
            double counter = 0;
            double _sumatoriaNotas = 0;
            string _nota;
            string line;
            int _posINI, _posFIN, _longNotas;
            double _promedio = 0.000;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@".\listado.dat");
            while ((line = file.ReadLine()) != null)
            {
                _posINI = line.IndexOf("<");
                _posFIN = line.IndexOf(">");
                _longNotas = _posFIN - _posINI - 1;

                _nota = line.Substring(_posINI + 1, _longNotas);

                if (Int32.Parse(_nota) > 10)
                {
                    MessageBox.Show("Ha cargado notas incorrectas");
                }
                else 
                {
                    _sumatoriaNotas += double.Parse(_nota);
                    counter++;
                }
            }

            file.Close();
            
            _promedio = _sumatoriaNotas / counter;

            _promedio = Math.Round(_promedio, 2);

            return _promedio;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _promedio = Promediar();

            if (checkBox1.Checked)
            {
                _promedio++;
            }

            this.textBox1.Text = _promedio.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 _listado = new Form2();

            _listado.Show();
        }
    }
}
