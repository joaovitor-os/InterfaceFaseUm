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

        RichTextBox txtNome;

        TextBox txtDtnasc;

        MaskedTextBox txtCPF;

        ComboBox cbDiasdev;

        NumericUpDown numDiasDev;

        CheckBox chbAtivo;

        RadioButton rbSexoMasc;
        RadioButton rbSexoFem;

        Button btnConfirmar;
        Button btnCancelar;

        PictureBox pbImagem;

        LinkLabel linkHelp;

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

            txtNome = new RichTextBox();
            txtNome.Location = new Point(180, 20);
            txtNome.Size = new Size(220, 18);

            txtDtnasc = new TextBox();
            txtDtnasc.Location = new Point(180, 60);
            txtDtnasc.Size = new Size(100, 18);

            txtCPF = new MaskedTextBox();
            txtCPF.Location = new Point(180, 100);
            txtCPF.Size = new Size(100, 18);
            txtCPF.Mask = "000,000,000-00";

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

            numDiasDev = new NumericUpDown();
            numDiasDev.Location = new Point(280, 140);
            numDiasDev.Size = new Size(110, 18);
            numDiasDev.Maximum = 20;
            numDiasDev.Minimum = 5;
            numDiasDev.Increment = 5;
            numDiasDev.Enabled = false;

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

            pbImagem = new PictureBox();
            pbImagem.Size = new Size(100, 100);
            pbImagem.Location = new Point(50, 320);
            pbImagem.ClientSize = new Size(100, 100); 
            pbImagem.Load("icon.png");

            linkHelp = new LinkLabel();
            linkHelp.Location = new Point(50, 200);
            linkHelp.Size = new Size(100,30);
            linkHelp.Text = "Ajuda";
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(helpLink);

            this.Controls.Add(lb_nome);
            this.Controls.Add(lb_Dtnasc);
            this.Controls.Add(lb_CPF);
            this.Controls.Add(lb_Diasdev);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtDtnasc);
            this.Controls.Add(txtCPF);
            this.Controls.Add(cbDiasdev);
            this.Controls.Add(numDiasDev);
            this.Controls.Add(chbAtivo);
            this.Controls.Add(rbSexoMasc);
            this.Controls.Add(rbSexoFem);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(pbImagem);
            this.Controls.Add(linkHelp);
            this.Size = new Size(450,400);
        }

        private void helpLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkHelp.LinkVisited = true;

            System.Diagnostics.Process.Start("IExplore.exe", "www.google.com");
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