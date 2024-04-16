using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_simples_2
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }
        enum Operacoes
        {
            Soma,
            Subtrai,
            Divide,
            Multiplica,
            Nenhuma
        }
        enum Aparencia
        {
            ModoEscuro,Normal
        }

        static Operacoes ultimaOperacao = Operacoes.Nenhuma;

        private void ButtonNumeros(object sender, EventArgs e)
        {
            Display.Text += (sender as Button).Text;
        }
        private void DEL_Click(object sender, EventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length -1, 1);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Multiplica;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            Display.Text += (sender as Button).Text;

        }

        private void Soma_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            Display.Text += (sender as Button).Text;
        }

        private void FazerCalculo(Operacoes ultimaOperacao)
        {
            List<double> ListaDeNumeros = new List<double>();

            switch (ultimaOperacao)
            {
                case Operacoes.Soma:
                    ListaDeNumeros = Display.Text.Split('+').Select(double.Parse).ToList();
                    Display.Text = (ListaDeNumeros[0] + ListaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Subtrai:
                    ListaDeNumeros = Display.Text.Split('-').Select(double.Parse).ToList();
                    Display.Text = (ListaDeNumeros[0] - ListaDeNumeros[1]).ToString();

                    break;
                case Operacoes.Divide:
                    ListaDeNumeros = Display.Text.Split('/').Select(double.Parse).ToList();
                    Display.Text = (ListaDeNumeros[0] / ListaDeNumeros[1]).ToString();

                    break;
                case Operacoes.Nenhuma:
                    break;
                case Operacoes.Multiplica:
                    ListaDeNumeros = Display.Text.Split('*').Select(double.Parse).ToList();
                    Display.Text = (ListaDeNumeros[0] * ListaDeNumeros[1]).ToString();

                    break;
                default:
                    break;
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Subtrai;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            Display.Text += (sender as Button).Text;
        }

        private void Divisao_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Divide;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            Display.Text += (sender as Button).Text;

        }

        private void CE_Click(object sender, EventArgs e)
        {
            Display.Clear();
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao != Operacoes.Nenhuma)
            {
                FazerCalculo(ultimaOperacao);
            }
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void ModoEscuro(object sender, EventArgs e)
        {
            if (BackColor == Color.Black)
            {
                BackColor = Color.White;
                ForeColor  = Color.Black;
            }
            else
            {
                BackColor = Color.Black; 
                ForeColor = Color.White;
            }
            if(Display.BackColor == Color.Black)
            {
                Display.BackColor = Color.White;
                Display.ForeColor = Color.Black;
            }
            else
            {
                Display.BackColor = Color.Black;
                Display.ForeColor = Color.White;
            }
        }

        private void Virgula(object sender, EventArgs e)
        {
            if(Display.Text.Contains(","))
            {
                return;
            }
            else
            {
                Display.Text += ",";
            }
        }
    }
}
