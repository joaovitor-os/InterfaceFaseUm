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

        ComboBox cbDiasdev;

        CheckBox chbAtivo;

        RadioButton rbSexoMasc;
        RadioButton rbSexoFem;

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
            lb_Dtnasc.Location = new Point(20, 60);

            lb_CPF = new Label();
            lb_CPF.Text = "CPF: ";
            lb_CPF.Location = new Point(20, 100);

            lb_Diasdev = new Label();
            lb_Diasdev.Text = "Dias de Devolução: ";
            lb_Diasdev.AutoSize = true;
            lb_Diasdev.Location = new Point(20, 140);

            txNome = new TextBox();
            txNome.Location = new Point(180, 20);
            txNome.Size = new Size(220, 18);

            txDtnasc = new TextBox();
            txDtnasc.Location = new Point(180, 60);
            txDtnasc.Size = new Size(100, 18);

            txCPF = new TextBox();
            txCPF.Location = new Point(180, 100);
            txCPF.Size = new Size(100, 18);

            cbDiasdev = new ComboBox();
            cbDiasdev.Items.Add("5");
            cbDiasdev.Items.Add("10");
            cbDiasdev.Items.Add("15");
            cbDiasdev.Items.Add("20");
            cbDiasdev.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDiasdev.Location = new Point(180, 140);
            cbDiasdev.Size = new Size(100, 18);

            /* Array simulando banco
            string[] diasDev = { "5", "10", "15", "10"};
            cbDiasdev = new ComboBox();
            foreach(var diaDev in diasDev)
            {
                cbDiasdev.Items.Add(diaDev);
            }
            cbDiasdev.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDiasdev.Location = new Point(180, 140);
            cbDiasdev.Size = new Size(100, 18);
            */

            chbAtivo = new CheckBox();
            chbAtivo.Location = new Point(180, 180);
            chbAtivo.Size = new Size(100,18);
            chbAtivo.Text = "Ativo?";

            rbSexoMasc = new RadioButton();
            rbSexoMasc.Location = new Point(180,220);
            rbSexoMasc.Size = new Size(100,18);
            rbSexoMasc.Text = "Masculino";

            rbSexoFem = new RadioButton();
            rbSexoFem.Location = new Point(300,220);
            rbSexoFem.Size = new Size(100,18);
            rbSexoFem.Text = "Feminino";

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Size = new Size(100, 30);
            btnConfirmar.Location = new Point(180, 260);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.Location = new Point(300, 260);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(lb_nome);
            this.Controls.Add(lb_Dtnasc);
            this.Controls.Add(lb_CPF);
            this.Controls.Add(lb_Diasdev);
            this.Controls.Add(txNome);
            this.Controls.Add(txDtnasc);
            this.Controls.Add(txCPF);
            this.Controls.Add(cbDiasdev);
            this.Controls.Add(chbAtivo);
            this.Controls.Add(rbSexoMasc);
            this.Controls.Add(rbSexoFem);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Size = new Size(450,400);
        }
        
        private void btnConfirmarClick(object sender, EventArgs e)
        {
            Form formulario2 = new Form();
            formulario2.Size = new Size(200,200);
            formulario2.Show();
            /*MessageBox.Show(
                $"Nome: {txNome.Text}\n" +
                $"Data Nasci: {txDtnasc.Text}\n" +
                $"C.P.F: {txCPF.Text}\n" +
                $"Dias Dev: {cbDiasdev.Text}\n",
                "Cliente",
                MessageBoxButtons.OK
            );*/
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}