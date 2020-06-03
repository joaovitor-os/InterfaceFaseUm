using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

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
        TabControl tabControl;
        TabPage tabPagePrincipal;
        TabPage tabPageSecundario;

        ToolTip toolTipNome = new ToolTip();

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

        GroupBox gpSexo;

        Button btnConfirmar;
        Button btnCancelar;
        Button btnOpenFile;

        PictureBox pbImagem;

        LinkLabel linkHelp;

        ListBox listBox;

        ListView listView;

        //CheckedListBox checkedList;

        MonthCalendar mcCalendar;

        DateTimePicker dtPicker;

        ProgressBar pbTest;

        TrackBar track;
        TextBox textBox1;

        public Form1()
        {
            this.Text = "Título da Janela";
            this.BackColor = Color.Azure;

            tabPagePrincipal = new TabPage();
            tabPagePrincipal.Text = "Principal";
            tabPagePrincipal.Size = new Size(900, 550);

            tabPageSecundario = new TabPage();
            tabPageSecundario.Text = "Secundário";
            tabPageSecundario.Size = new Size(900, 550);

            tabControl = new TabControl();
            tabControl.Location = new Point(0, 35);
            tabControl.Size = new Size(900, 550);
            tabControl.Controls.Add(tabPagePrincipal);
            tabControl.Controls.Add(tabPageSecundario);

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

            toolTipNome.AutoPopDelay = 5000;
            toolTipNome.InitialDelay = 1000;
            toolTipNome.ReshowDelay = 500;
            toolTipNome.ShowAlways = true;
            toolTipNome.SetToolTip(txtNome, "Informe o nome");

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
            chbAtivo.Size = new Size(100, 18);
            chbAtivo.Text = "Ativo?";

            gpSexo = new GroupBox();
			gpSexo.Location = new Point(180,220);
			gpSexo.Size = new Size(200,40);
			gpSexo.Text = "Sexo";

			rbSexoMasc = new RadioButton();
			rbSexoMasc.Location = new Point(15,15);
			rbSexoMasc.Size = new Size(100,18);
			rbSexoMasc.Text = "Masculino";

			rbSexoFem = new RadioButton();
			rbSexoFem.Location = new Point(120,15);
			rbSexoFem.Size = new Size(70,18);
			rbSexoFem.Text = "Feminino";

			gpSexo.Controls.Add(rbSexoMasc);
			gpSexo.Controls.Add(rbSexoFem);

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

            btnOpenFile = new Button();
            btnOpenFile.Text = "Open File";
            btnOpenFile.Size = new Size(100, 30);
            btnOpenFile.Location = new Point(280, 360);
            btnOpenFile.Click += new EventHandler(this.btnOpenFileClick);

            pbImagem = new PictureBox();
            pbImagem.Size = new Size(100, 100);
            pbImagem.Location = new Point(50, 320);
            pbImagem.ClientSize = new Size(100, 100);
            pbImagem.Load("icon.png");

            linkHelp = new LinkLabel();
            linkHelp.Location = new Point(50, 300);
            linkHelp.Size = new Size(100, 30);
            linkHelp.Text = "Ajuda";
            linkHelp.LinkClicked += new LinkLabelLinkClickedEventHandler(helpLink);

            listBox = new ListBox();
            listBox.Items.Add("Kill Bill");
            listBox.Items.Add("Rei Leão");
            listBox.Items.Add("Coringa");
            listBox.Location = new Point(15, 180);
            listBox.Size = new Size(100, 100);
            //listBox.SelectionMode = SeletionMode.MultiExtended;
            //listBox.MultiColumn = true;
            //listBox.EndUpdate();

            listView = new ListView();
            listView.Location = new Point(15, 180);
            listView.Size = new Size(150, 100);
            listView.View = View.Details;
            ListViewItem filme1 = new ListViewItem("Kill Bill");
            filme1.SubItems.Add("3");
            filme1.SubItems.Add("2001");
            ListViewItem filme2 = new ListViewItem("Rei Leão");
            filme2.SubItems.Add("2");
            filme2.SubItems.Add("1994");
            ListViewItem filme3 = new ListViewItem("Coringa");
            filme3.SubItems.Add("1");
            filme3.SubItems.Add("2019");
            listView.Items.AddRange(new ListViewItem[] { filme1, filme2, filme3 });
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Estoque", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            /*
            checkedList = new CheckedListBox();
            checkedList.Location = new Point(15, 180);
            checkedList.Size = new Size(150, 100);
            string[] filmes = { "Kill Bill", "Rei Leão", "Coringa" };
            checkedList.Items.AddRange(filmes);
            //checkedList.SelectionMode = SelectionMode.One
            //checkedList.CheckOnClick = true;
            //checkedList.CheckedItems;
            */

            mcCalendar = new MonthCalendar();
            mcCalendar.Location = new Point(400, 15);
            //mcCalendar.MaxSelectionCount = 4;
            //mcCalendar.MinDate = new DateTime(2019,05,10);
            //mcCalendar.MaxDate = new DateTime(2020,12,31);
            //mcCalendar.SelectionRange = new SelectionRange(new DateTime (2020,05,16), new DateTime(2020,05,19));

            dtPicker = new DateTimePicker();
            dtPicker.Location = new Point(675, 15);
            dtPicker.Size = new Size(300, 15);
            //dtPicker.Format = DateTimePickerFormat.Time;
            //dtPicker.Format = DateTimePickerFormat.Custom;
            //dtPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            //dtPicker.ShowCheckBox = true;
            //dtPicker.ShowUpDown = true;

            pbTest = new ProgressBar();
            pbTest.Location = new Point(400, 200);
            //pbTest.Value = 50;
            //pbTest.Style = ProgressBarStyle.Marquee;
            //pbTest.MarqueeAnimationSpeed = 30;

            track = new TrackBar();
            track.Location = new System.Drawing.Point(8, 8);
            track.Size = new System.Drawing.Size(224, 45);
            track.Maximum = 30;
            track.TickFrequency = 5;
            track.LargeChange = 5;
            track.SmallChange = 5;
            track.Scroll += new EventHandler(track_Scroll);

            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(300, 300);

            // Create ToolStripPanel controls.
            /*ToolStripPanel tspTop = new ToolStripPanel();
            ToolStripPanel tspBottom = new ToolStripPanel();
            ToolStripPanel tspLeft = new ToolStripPanel();
            ToolStripPanel tspRight = new ToolStripPanel();
            // Dock the ToolStripPanel controls to the edges of the form.
            tspTop.Dock = DockStyle.Top;
            tspBottom.Dock = DockStyle.Bottom;
            tspLeft.Dock = DockStyle.Left;
            tspRight.Dock = DockStyle.Right;
            // Create ToolStrip controls to move among the 
            // ToolStripPanel controls.
            // Create the "Top" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsTop = new ToolStrip();
            tsTop.Items.Add("Top");
            tsTop.Items.Add("Novo Item");
            tspTop.Join(tsTop);
            // Create the "Bottom" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsBottom = new ToolStrip();
            tsBottom.Items.Add("Bottom");
            tspBottom.Join(tsBottom);
            // Create the "Right" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsRight = new ToolStrip();
            tsRight.Items.Add("Right");
            tspRight.Join(tsRight);
            // Create the "Left" ToolStrip control and add
            // to the corresponding ToolStripPanel.
            ToolStrip tsLeft = new ToolStrip();
            tsLeft.Items.Add("Left");
            tspLeft.Join(tsLeft);*/

            // Create a MenuStrip control with a new window.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Window");
            ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("New", null, new EventHandler(windowNewMenu_Click));
            ToolStripMenuItem windowSaveMenu = new ToolStripMenuItem("Save");
            windowSaveMenu.Click += new EventHandler(windowsSaveMenu_Click);
            windowMenu.DropDownItems.Add(windowNewMenu);
            windowMenu.DropDownItems.Add(windowSaveMenu);
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;

            // Assign the ToolStripMenuItem that displays 
            // the list of child forms.
            ms.MdiWindowListItem = windowMenu;

            // Add the window ToolStripMenuItem to the MenuStrip.
            ms.Items.Add(windowMenu);

            // Dock the MenuStrip to the top of the form.
            ms.Dock = DockStyle.Top;

            // The Form.MainMenuStrip property determines the merge target.
            this.MainMenuStrip = ms;

            // Add the ToolStripPanels to the form in reverse order.
            /*this.Controls.Add(tspRight);
            this.Controls.Add(tspLeft);
            this.Controls.Add(tspBottom);
            this.Controls.Add(tspTop);*/

            // Add the MenuStrip last.
            // This is important for correct placement in the z-order.
            this.Controls.Add(ms);

            tabPageSecundario.Controls.Add(track);
            tabPageSecundario.Controls.Add(textBox1);

            tabPagePrincipal.Controls.Add(lb_nome);
            tabPagePrincipal.Controls.Add(lb_Dtnasc);
            tabPagePrincipal.Controls.Add(lb_CPF);
            tabPagePrincipal.Controls.Add(lb_Diasdev);
            tabPagePrincipal.Controls.Add(txtNome);
            tabPagePrincipal.Controls.Add(txtDtnasc);
            tabPagePrincipal.Controls.Add(txtCPF);
            tabPagePrincipal.Controls.Add(cbDiasdev);
            tabPagePrincipal.Controls.Add(numDiasDev);
            tabPagePrincipal.Controls.Add(chbAtivo);
            tabPagePrincipal.Controls.Add(gpSexo);
            tabPagePrincipal.Controls.Add(btnConfirmar);
            tabPagePrincipal.Controls.Add(btnCancelar);
            tabPagePrincipal.Controls.Add(btnOpenFile);
            tabPagePrincipal.Controls.Add(pbImagem);
            tabPagePrincipal.Controls.Add(linkHelp);
            //tabPagePrincipal.Controls.Add(listBox);
            tabPagePrincipal.Controls.Add(listView);
            //tabPagePrincipal.Controls.Add(checkedList);
            tabPagePrincipal.Controls.Add(mcCalendar);
            tabPagePrincipal.Controls.Add(dtPicker);
            tabPagePrincipal.Controls.Add(pbTest);
            this.Controls.Add(tabControl);
            this.Size = new Size(1000, 450);
        }

        private void windowNewMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New!!!!");
        }
        private void windowsSaveMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save!!!!");
        }
        private void track_Scroll(object sender, EventArgs e)
        { // Display the trackbar value in the text box. 
            textBox1.Text = "" + track.Value;
        }

        private void helpLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkHelp.LinkVisited = true;

            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\Chrome.exe");
        }

        private void btnConfirmarClick(object sender, EventArgs e)
        {
            string nomeFilmes = "";

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                pbTest.PerformStep();
            }

            string sexo = "Indefinido";
            foreach (var controle in this.gpSexo.Controls)
            {
                RadioButton radio = controle as RadioButton;

                if (radio != null && radio.Checked)
                {
                    sexo = radio.Text;
                }
            }

            foreach (var element in listBox.SelectedItems)
                nomeFilmes += element;

            MessageBox.Show(
                $"Nome.: {this.txtNome.Text}\n" +
                $"Data Nasc.: {this.txtDtnasc.Text}\n" +
                $"C.P.F.: {this.txtCPF.Text}\n" +
                $"Dias Dev.: {this.cbDiasdev.Text}" +
                $"Ativo.: {(this.chbAtivo.Checked ? "Ativo" : "Inativo")}\n" +
                $"Sexo.: {(this.rbSexoMasc.Checked ? "Masculino" : this.rbSexoFem.Checked ? "Feminino" : "Indefinido")}\n" +
                $"Sexo.: { sexo }\n" +
                $"Filmes.: { nomeFilmes }\n" +
                $"Calendário Inicial: {this.mcCalendar.SelectionRange.Start}\n" +
                $"Calendário Final: {this.mcCalendar.SelectionRange.End}\n" +
                $"Picker.: {this.dtPicker.Value}",
                "Cliente",
                MessageBoxButtons.OK
            );

            //pbTest.PerformStep();
        }


        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFileClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = @"C:\";
            //dialog.Multiselect = true;
            dialog.Title = "Selecionar arquivos...";
            dialog.Filter = "Arquivo de Texto (*.TXT; *.RTF) |abrirarquivo.txt";
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                StreamReader arquivo = new StreamReader(dialog.FileName);
                string conteudo = arquivo.ReadLine();
                arquivo.Dispose();

                MessageBox.Show(conteudo);
            }
        }
    }
}