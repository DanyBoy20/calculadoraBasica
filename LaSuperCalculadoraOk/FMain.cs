using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaSuperCalculadoraOk
{
    public partial class FMain : Form
    {
        private decimal Operand;
        private string OperandTxt; // variable que ira agregando los numeros segun se tecleen
        private string Operator;

        public FMain()
        {
            InitializeComponent();
            Reset();
        }

        private void SetOperandTxt(string value) // metodo que añadira los valores a la variable
        {
            // si el valor es un numero
            if(value == "9" || value == "8" || value == "7" || value == "6" || value == "5" ||
               value == "4" || value == "3" || value == "2" || value == "1" || value == "0")
            {
                if (OperandTxt == "0")
                    OperandTxt = "";

                OperandTxt = OperandTxt + value; // cada que se dispara el metodo, se añade el valor del parametro
                TxtResult.Text = OperandTxt; // lo mostramos en pantalla
            }
            // si el valor es un operador
            else if(value == "+" || value == "-" || value == "*" || value == "/")
            {
                if(Operator != "" && OperandTxt != "")
                {
                    DoOperation();
                }
                Operator = value;

                if(OperandTxt != "")
                {
                    Operand = decimal.Parse(OperandTxt);
                    OperandTxt = "";
                }
                
            } 
            else if(value == "=")
            {
                if (Operator != "" && OperandTxt != "")
                {
                    DoOperation();
                }
            }
            // si el valor es la tecla eliminar: <--
            else if (value == "\b")
            {
                Delete();
            }
            // si el valor es la tecla de escape
            else if(value == "\u001b")
            {
                Reset();
            }
            // si el valor es decimal 
            else if(value == "." || value == ",")
            {
                // indexof devuelve el indice del caracter pasado por parametro
                // si no lo encuentra devlvera -1, de ahi la condicion, si es menor que cero
                // no se a tecleado el punto para decimales, con esto validamos que se 
                // ingrese varias veces el punto de decimales
                if(OperandTxt.IndexOf(".") < 0)
                {
                    OperandTxt = OperandTxt + ".";
                    TxtResult.Text = OperandTxt;
                }
            }
        }

        private void DoOperation()
        {
            decimal result = 0;
            if(Operator == "+")
            {
                result = Operand + decimal.Parse(OperandTxt);
            }
            else if(Operator == "-")
            {
                result = Operand - decimal.Parse(OperandTxt);
            }
            else if(Operator == "*")
            {
                result = Operand * decimal.Parse(OperandTxt);
            }
            else if (Operator == "/")
            {
                result = Operand / decimal.Parse(OperandTxt);
            }
            Operator = "";
            OperandTxt = result.ToString();
            TxtResult.Text = OperandTxt;
        }

        private void Delete()
        {
            if(OperandTxt.Length > 1)
            {
                // extrae una cadena a partir de un indice y la longitud
                // ejemplo: "HOLA" (substring(0, HOLA.Length -1)
                // extraeria a partir de lindice 0 (la H), hasta la longitud (4) - 1 (3) = HOL
                OperandTxt = OperandTxt.Substring(0, OperandTxt.Length - 1);
            }
            else
            {
                OperandTxt = "0";
            }            
            TxtResult.Text = OperandTxt;
        }

        private void Reset()
        {
            OperandTxt = "0";
            Operand = 0;
            Operator = "";
            TxtResult.Text = "0";
        }

        private void BtnNumber9_Click(object sender, EventArgs e)
        {
            SetOperandTxt("9"); // ejecuto la funcion y le paso el valor a añadir
        }

        private void BtnNumber8_Click(object sender, EventArgs e)
        {
            SetOperandTxt("8");
        }

        private void BtnNumber7_Click(object sender, EventArgs e)
        {
            SetOperandTxt("7");
        }

        private void BtnNumber6_Click(object sender, EventArgs e)
        {
            SetOperandTxt("6");
        }

        private void BtnNumber5_Click(object sender, EventArgs e)
        {
            SetOperandTxt("5");
        }

        private void BtnNumber4_Click(object sender, EventArgs e)
        {
            SetOperandTxt("4");
        }

        private void BtnNumber3_Click(object sender, EventArgs e)
        {
            SetOperandTxt("3");
        }

        private void BtnNumber2_Click(object sender, EventArgs e)
        {
            SetOperandTxt("2");
        }

        private void BtnNumber1_Click(object sender, EventArgs e)
        {
            SetOperandTxt("1");
        }

        private void BtnNumber0_Click(object sender, EventArgs e)
        {
            SetOperandTxt("0");
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            SetOperandTxt("=");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SetOperandTxt("+");
        }

        private void FMain_KeyPress(object sender, KeyPressEventArgs e)
        {            
            SetOperandTxt(e.KeyChar.ToString()); // captura lo que se teclea, y es el parametro del metodo
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BtnDec_Click(object sender, EventArgs e)
        {
            SetOperandTxt(".");
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            SetOperandTxt("/");
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            SetOperandTxt("*");
        }

        private void BtnSubstract_Click(object sender, EventArgs e)
        {
            SetOperandTxt("-");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
