using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_Spalania
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void button2_Click(object sender, EventArgs e) // Przycisk Kasuj został wciśnięty
        {

            if(textBox1.TextLength + textBox2.TextLength == 0) // Jeżeli pola textBox1 i textBox2 są puste to:
            {
                MessageBox.Show("Obecnie pola są już puste", "Kasuj Dane", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Zwróc MessageBox z informacją, że pola są już puste
                
            }

            else
            {
                textBox1.Text = "";                             //
                textBox2.Text = "";                             // W przeciwnym wypadku wyczyść oba pola i wynik
                label4.Text = "--,- L/100km"; //
            }
        }
        private void button1_Click(object sender, EventArgs e) // Przycisk Oblicz został wciśnięty
        {

                if (textBox2.Text.Contains(".") || textBox1.Text.Contains("."))                                   // Sprawdź czy w polu textBox1 albo textBox2 znajduje się kropka
                {
                    MessageBox.Show("Zamiast kropki wpisz przecinek", "Oblicz", MessageBoxButtons.OK, MessageBoxIcon.Error);  //
                    textBox1.Text = "";                                                                                       // Jeżeli tak, to zwróc MessageBox z informacją
                    textBox2.Text = "";                                                                                       // o zamianie kropki na przecinek i wyczyść oba pola i wynik
                    label4.Text = "--,- L/100km";                                                           //
                }

                else                                                                                                // Jeżeli w obu polach nie wystąpiły kropki to:
                {

                    if (textBox1.TextLength > 0 & textBox2.TextLength > 0)                                          // Sprawdź czy w polu textBox1 albo textBox2 znajduja sie dane
                    {
                        decimal calc = Convert.ToDecimal(textBox2.Text) / (Convert.ToDecimal(textBox1.Text) / 100); // Obliczenie spalania do zmiennej calc
                        label4.Text = Convert.ToString(calc).Substring(0, 4) + " L/100km";  // Zamień tekst label4 na wartosc calc przekonwertowaną na string i zaokrąglij
                    }

                    else                                                                                            // Jeżeli w obu polach nie wystąpiły dane to
                    {                                                                                               // Wyświetl messageBox z informacja o wprowadzeniu danych
                        MessageBox.Show("Wprowadź dane!", "Oblicz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  // Sprawdź jakie przyciski wciśnięto w textBox1
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && !char.IsControl(e.KeyChar))             // Jeśli jest to licza / przecinek, to pozwól ją wpisać
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // Sprawdź jakie przyciski wciśnięto w textBox2
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && !char.IsControl(e.KeyChar))               // Jeśli jest to licza / przecinek, to pozwól ją wpisać
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
    }
// 23.09.2020, Szymon Jagosz

