using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        double valorVisor = 0, valorAnterior = 0;
        string operacao = "";
        bool primeiraOperacao = true, botaoIgual = false;

        public frmCalculadora()
        {
            InitializeComponent();
        }
        
        private void ClicouBotao_Click(object sender, EventArgs e)
        {

            if ( txtVisor.Text == "0" || botaoIgual == true )
            {
                txtVisor.Clear();
                botaoIgual = false;
            }

            Button botaoAcionado = (Button)sender;

            switch (botaoAcionado.Name)
            {
                case "btn1":
                    txtVisor.Text += "1";
                    break;

                case "btn2":
                    txtVisor.Text += "2";
                    break;

                case "btn3":
                    txtVisor.Text += "3";
                    break;

                case "btn4":
                    txtVisor.Text += "4";
                    break;

                case "btn5":
                    txtVisor.Text += "5";
                    break;

                case "btn6":
                    txtVisor.Text += "6";
                    break;

                case "btn7":
                    txtVisor.Text += "7";
                    break;

                case "btn8":
                    txtVisor.Text += "8";
                    break;

                case "btn9":
                    txtVisor.Text += "9";
                    break;

                case "btn0":
                    txtVisor.Text += "0";
                    break;

                case "btnVirgula":
                    if ( txtVisor.Text == "" )
                    {
                        txtVisor.Text += "0,";
                    }
                    else
                    {
                        txtVisor.Text += ",";
                    }
                    break;

                default:
                    break;

            }

        }

        public double Calculo()
        {
            switch ( operacao )
            {
                case " + ":
                    valorAnterior = valorAnterior + valorVisor;
                    break;

                case " - ":
                    valorAnterior = valorAnterior - valorVisor;
                    break;

                case " x ":
                    valorAnterior = valorAnterior * valorVisor;
                    break;

                case " / ":
                    valorAnterior = valorAnterior / valorVisor;
                    break;

                case " √ ":
                    valorAnterior = Math.Sqrt(valorVisor);
                    break;

                default:
                    break;  
            }

            return valorAnterior;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            valorVisor = Convert.ToDouble(txtVisor.Text);
            txtHistorico.Text += operacao + txtVisor.Text;
            txtVisor.Text = Convert.ToString(Calculo());
            txtHistorico.Text += " = " + txtVisor.Text;
            valorAnterior = Convert.ToDouble(txtVisor.Text);
            botaoIgual = true;
            primeiraOperacao = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
            txtHistorico.Clear();
            valorAnterior = 0;
            valorVisor = 0;
            operacao = "";
            primeiraOperacao = true;
            botaoIgual = false;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
        }



        private void btnSomar_Click(object sender, EventArgs e)
        {
            if ( primeiraOperacao )
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if ( botaoIgual == false )
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = " + ";
                primeiraOperacao = false;
            }
            else
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += operacao + txtVisor.Text;
                txtVisor.Text = Convert.ToString(valorAnterior + valorVisor);
                operacao = " + ";
                txtHistorico.Text += " = " + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;


            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if (botaoIgual == false)
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = " - ";
                primeiraOperacao = false;
            }
            else
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += operacao + txtVisor.Text;
                txtVisor.Text = Convert.ToString(Calculo());
                operacao = " - ";
                txtHistorico.Text += " = " + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;


            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if (botaoIgual == false)
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = " x ";
                primeiraOperacao = false;
            }
            else
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += operacao + txtVisor.Text;
                txtVisor.Text = Convert.ToString(Calculo());
                operacao = " x ";
                txtHistorico.Text += " = " + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;


            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if (botaoIgual == false)
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = " / ";
                primeiraOperacao = false;
            }
            else
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += operacao + txtVisor.Text;
                txtVisor.Text = Convert.ToString(Calculo());
                operacao = " / ";
                txtHistorico.Text += " = " + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;


            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if (botaoIgual == false)
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = " √ ";
                primeiraOperacao = false;
            }
            else
            {
                valorVisor = Convert.ToDouble(txtVisor.Text);
                txtHistorico.Text += operacao + txtVisor.Text;
                txtVisor.Text = Convert.ToString(Calculo());
                operacao = " √ ";
                txtHistorico.Text += " = " + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;


            }
        }


    }
}
