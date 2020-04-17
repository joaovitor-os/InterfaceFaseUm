using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InterfaceFaseUm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Form1 : Form
    {

        Label lb_nome;
        Label lb_Dtnasc;
        Label lb_CPF;
        Label lb_Diasdev;

        TextBox txNome;
        TextBox txDtnasc;
        TextBox txCPF;
        TextBox txDiasdev;

        Button btnConfirmar;
        Button btnCancelar;

        public Form1()
        {
            this.Text = "Título da Janela";
            this.BackColor = Color.Azure;

            lb_nome = new Label();
            lb_nome.Text = "Nome: ";
            lb_nome.Location = new Point(20, 20);

            lb_Dtnasc = new Label();
            lb_Dtnasc.Text = "Data de Nascimento: ";
            lb_Dtnasc.AutoSize = true;
            lb_Dtnasc.Location = new Point(20, 40);

            lb_CPF = new Label();
            lb_CPF.Text = "CPF: ";
            lb_CPF.Location = new Point(20, 60);

            lb_Diasdev = new Label();
            lb_Diasdev.Text = "Dias de Devolução: ";
            lb_Diasdev.AutoSize = true;
            lb_Diasdev.Location = new Point(20, 80);

            txNome = new TextBox();
            txNome.Location = new Point(180, 20);
            txNome.Size = new Size(100, 18);

            txDtnasc = new TextBox();
            txDtnasc.Location = new Point(180, 40);
            txDtnasc.Size = new Size(100, 18);

            txCPF = new TextBox();
            txCPF.Location = new Point(180, 60);
            txCPF.Size = new Size(100, 18);

            txDiasdev = new TextBox();
            txDiasdev.Location = new Point(180, 80);
            txDiasdev.Size = new Size(100, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.Location = new Point(30, 130);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Location = new Point(140, 130);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(lb_nome);
            this.Controls.Add(lb_Dtnasc);
            this.Controls.Add(lb_CPF);
            this.Controls.Add(lb_Diasdev);
            this.Controls.Add(txNome);
            this.Controls.Add(txDtnasc);
            this.Controls.Add(txCPF);
            this.Controls.Add(txDiasdev);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        
        private void btnConfirmarClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Nome: {txNome.Text}\n" +
                $"Data Nasci: {txDtnasc.Text}\n" +
                $"C.P.F: {txCPF.Text}\n" +
                $"Dias Dev: {txDiasdev.Text}\n",
                "Cliente",
                MessageBoxButtons.OK
            );
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}