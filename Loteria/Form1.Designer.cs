namespace Loteria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cbxLoterias = new ComboBox();
            gpBSelectLoteria = new GroupBox();
            gpBInfoLoteria = new GroupBox();
            txtBoxBuscarResultado = new TextBox();
            lblTimeCoracao = new Label();
            lblAcumulou = new Label();
            btnBuscarResultado = new Button();
            lblDezenas = new Label();
            lblNumConcurso = new Label();
            lblValorEstimado = new Label();
            groupBox1 = new GroupBox();
            lblNumProxConc = new Label();
            lblDataProxConc = new Label();
            gpBGanhadores = new GroupBox();
            tabControl1 = new TabControl();
            textBox1 = new TextBox();
            btnVerificarJogo = new Button();
            btnSalvarJogo = new Button();
            btnApagarJogo = new Button();
            groupBox2 = new GroupBox();
            listView1 = new ListView();
            groupBox3 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAcertos = new Label();
            lblPontos = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            gpBSelectLoteria.SuspendLayout();
            gpBInfoLoteria.SuspendLayout();
            groupBox1.SuspendLayout();
            gpBGanhadores.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // cbxLoterias
            // 
            cbxLoterias.Cursor = Cursors.Hand;
            cbxLoterias.Dock = DockStyle.Fill;
            cbxLoterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxLoterias.FlatStyle = FlatStyle.System;
            cbxLoterias.Font = new Font("Spartan", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxLoterias.FormattingEnabled = true;
            cbxLoterias.Location = new Point(3, 21);
            cbxLoterias.Name = "cbxLoterias";
            cbxLoterias.Size = new Size(322, 32);
            cbxLoterias.TabIndex = 0;
            cbxLoterias.SelectedIndexChanged += cbxLoterias_SelectedIndexChanged;
            // 
            // gpBSelectLoteria
            // 
            gpBSelectLoteria.BackColor = SystemColors.GradientInactiveCaption;
            gpBSelectLoteria.Controls.Add(cbxLoterias);
            gpBSelectLoteria.Cursor = Cursors.Hand;
            gpBSelectLoteria.FlatStyle = FlatStyle.Flat;
            gpBSelectLoteria.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpBSelectLoteria.Location = new Point(3, 59);
            gpBSelectLoteria.Name = "gpBSelectLoteria";
            gpBSelectLoteria.Size = new Size(328, 60);
            gpBSelectLoteria.TabIndex = 2;
            gpBSelectLoteria.TabStop = false;
            gpBSelectLoteria.Text = "SELECIONE A LOTERIA";
            // 
            // gpBInfoLoteria
            // 
            gpBInfoLoteria.BackColor = SystemColors.GradientInactiveCaption;
            gpBInfoLoteria.Controls.Add(txtBoxBuscarResultado);
            gpBInfoLoteria.Controls.Add(lblTimeCoracao);
            gpBInfoLoteria.Controls.Add(lblAcumulou);
            gpBInfoLoteria.Controls.Add(btnBuscarResultado);
            gpBInfoLoteria.Controls.Add(lblDezenas);
            gpBInfoLoteria.Controls.Add(lblNumConcurso);
            gpBInfoLoteria.Dock = DockStyle.Fill;
            gpBInfoLoteria.FlatStyle = FlatStyle.Flat;
            gpBInfoLoteria.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpBInfoLoteria.Location = new Point(3, 3);
            gpBInfoLoteria.Name = "gpBInfoLoteria";
            gpBInfoLoteria.Size = new Size(325, 338);
            gpBInfoLoteria.TabIndex = 3;
            gpBInfoLoteria.TabStop = false;
            gpBInfoLoteria.Text = "AGUARDANDO SELEÇÃO";
            // 
            // txtBoxBuscarResultado
            // 
            txtBoxBuscarResultado.BorderStyle = BorderStyle.FixedSingle;
            txtBoxBuscarResultado.Cursor = Cursors.IBeam;
            txtBoxBuscarResultado.Font = new Font("Spartan SemiBold", 17.9999981F, FontStyle.Bold);
            txtBoxBuscarResultado.Location = new Point(6, 250);
            txtBoxBuscarResultado.Name = "txtBoxBuscarResultado";
            txtBoxBuscarResultado.PlaceholderText = "NÚMERO DO CONCURSO";
            txtBoxBuscarResultado.Size = new Size(313, 36);
            txtBoxBuscarResultado.TabIndex = 12;
            txtBoxBuscarResultado.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTimeCoracao
            // 
            lblTimeCoracao.AutoSize = true;
            lblTimeCoracao.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold);
            lblTimeCoracao.Location = new Point(125, 204);
            lblTimeCoracao.Name = "lblTimeCoracao";
            lblTimeCoracao.Size = new Size(60, 24);
            lblTimeCoracao.TabIndex = 3;
            lblTimeCoracao.Text = "label1";
            // 
            // lblAcumulou
            // 
            lblAcumulou.AutoSize = true;
            lblAcumulou.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAcumulou.Location = new Point(9, 204);
            lblAcumulou.Name = "lblAcumulou";
            lblAcumulou.Size = new Size(59, 24);
            lblAcumulou.TabIndex = 2;
            lblAcumulou.Text = "Label";
            // 
            // btnBuscarResultado
            // 
            btnBuscarResultado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBuscarResultado.BackColor = Color.LimeGreen;
            btnBuscarResultado.Cursor = Cursors.Hand;
            btnBuscarResultado.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            btnBuscarResultado.FlatAppearance.BorderSize = 3;
            btnBuscarResultado.FlatAppearance.MouseDownBackColor = Color.Green;
            btnBuscarResultado.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            btnBuscarResultado.FlatStyle = FlatStyle.Flat;
            btnBuscarResultado.Font = new Font("Spartan", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscarResultado.ForeColor = Color.White;
            btnBuscarResultado.Location = new Point(6, 292);
            btnBuscarResultado.Name = "btnBuscarResultado";
            btnBuscarResultado.Size = new Size(313, 40);
            btnBuscarResultado.TabIndex = 11;
            btnBuscarResultado.Text = "BUSCAR";
            btnBuscarResultado.UseVisualStyleBackColor = false;
            btnBuscarResultado.Click += btnBuscarResultado_Click;
            // 
            // lblDezenas
            // 
            lblDezenas.AutoSize = true;
            lblDezenas.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDezenas.Location = new Point(6, 73);
            lblDezenas.Name = "lblDezenas";
            lblDezenas.Size = new Size(229, 24);
            lblDezenas.TabIndex = 1;
            lblDezenas.Text = "AGUARDANDO SELEÇÃO";
            // 
            // lblNumConcurso
            // 
            lblNumConcurso.AutoSize = true;
            lblNumConcurso.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumConcurso.Location = new Point(3, 22);
            lblNumConcurso.Name = "lblNumConcurso";
            lblNumConcurso.Size = new Size(229, 24);
            lblNumConcurso.TabIndex = 0;
            lblNumConcurso.Text = "AGUARDANDO SELEÇÃO";
            // 
            // lblValorEstimado
            // 
            lblValorEstimado.AutoSize = true;
            lblValorEstimado.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValorEstimado.Location = new Point(6, 92);
            lblValorEstimado.Name = "lblValorEstimado";
            lblValorEstimado.Size = new Size(229, 24);
            lblValorEstimado.TabIndex = 2;
            lblValorEstimado.Text = "AGUARDANDO SELEÇÃO";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(lblNumProxConc);
            groupBox1.Controls.Add(lblValorEstimado);
            groupBox1.Controls.Add(lblDataProxConc);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(691, 121);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "PRÓXIMO CONCURSO";
            // 
            // lblNumProxConc
            // 
            lblNumProxConc.AutoSize = true;
            lblNumProxConc.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumProxConc.Location = new Point(3, 56);
            lblNumProxConc.Name = "lblNumProxConc";
            lblNumProxConc.Size = new Size(229, 24);
            lblNumProxConc.TabIndex = 1;
            lblNumProxConc.Text = "AGUARDANDO SELEÇÃO";
            // 
            // lblDataProxConc
            // 
            lblDataProxConc.AutoSize = true;
            lblDataProxConc.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDataProxConc.Location = new Point(6, 22);
            lblDataProxConc.Name = "lblDataProxConc";
            lblDataProxConc.Size = new Size(229, 24);
            lblDataProxConc.TabIndex = 0;
            lblDataProxConc.Text = "AGUARDANDO SELEÇÃO";
            // 
            // gpBGanhadores
            // 
            gpBGanhadores.BackColor = SystemColors.GradientInactiveCaption;
            gpBGanhadores.Controls.Add(tabControl1);
            gpBGanhadores.Dock = DockStyle.Fill;
            gpBGanhadores.FlatStyle = FlatStyle.Flat;
            gpBGanhadores.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gpBGanhadores.Location = new Point(3, 347);
            gpBGanhadores.Name = "gpBGanhadores";
            gpBGanhadores.Size = new Size(325, 183);
            gpBGanhadores.TabIndex = 5;
            gpBGanhadores.TabStop = false;
            gpBGanhadores.Text = "GANHADORES";
            // 
            // tabControl1
            // 
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Spartan", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(3, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(319, 155);
            tabControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Spartan SemiBold", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "DIGITE AQUI SEU JOGO";
            textBox1.Size = new Size(685, 36);
            textBox1.TabIndex = 6;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // btnVerificarJogo
            // 
            btnVerificarJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVerificarJogo.AutoSize = true;
            btnVerificarJogo.BackColor = Color.LimeGreen;
            btnVerificarJogo.Cursor = Cursors.Hand;
            btnVerificarJogo.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            btnVerificarJogo.FlatAppearance.BorderSize = 3;
            btnVerificarJogo.FlatAppearance.MouseDownBackColor = Color.Green;
            btnVerificarJogo.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            btnVerificarJogo.FlatStyle = FlatStyle.Flat;
            btnVerificarJogo.Font = new Font("Spartan", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerificarJogo.ForeColor = Color.White;
            btnVerificarJogo.Location = new Point(3, 45);
            btnVerificarJogo.Name = "btnVerificarJogo";
            btnVerificarJogo.Size = new Size(685, 40);
            btnVerificarJogo.TabIndex = 7;
            btnVerificarJogo.Text = "CONFERIR JOGO";
            btnVerificarJogo.UseVisualStyleBackColor = false;
            btnVerificarJogo.Click += btnVerificarJogo_Click;
            // 
            // btnSalvarJogo
            // 
            btnSalvarJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSalvarJogo.AutoSize = true;
            btnSalvarJogo.BackColor = Color.CornflowerBlue;
            btnSalvarJogo.Cursor = Cursors.Hand;
            btnSalvarJogo.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            btnSalvarJogo.FlatAppearance.BorderSize = 3;
            btnSalvarJogo.FlatAppearance.MouseDownBackColor = Color.Navy;
            btnSalvarJogo.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
            btnSalvarJogo.FlatStyle = FlatStyle.Flat;
            btnSalvarJogo.Font = new Font("Spartan", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarJogo.ForeColor = Color.White;
            btnSalvarJogo.Location = new Point(3, 91);
            btnSalvarJogo.Name = "btnSalvarJogo";
            btnSalvarJogo.Size = new Size(685, 40);
            btnSalvarJogo.TabIndex = 8;
            btnSalvarJogo.Text = "SALVAR JOGO";
            btnSalvarJogo.UseVisualStyleBackColor = false;
            btnSalvarJogo.Click += btnSalvarJogo_Click;
            // 
            // btnApagarJogo
            // 
            btnApagarJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnApagarJogo.AutoSize = true;
            btnApagarJogo.BackColor = Color.Tomato;
            btnApagarJogo.Cursor = Cursors.Hand;
            btnApagarJogo.FlatAppearance.BorderColor = Color.Red;
            btnApagarJogo.FlatAppearance.BorderSize = 3;
            btnApagarJogo.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
            btnApagarJogo.FlatAppearance.MouseOverBackColor = Color.Salmon;
            btnApagarJogo.FlatStyle = FlatStyle.Flat;
            btnApagarJogo.Font = new Font("Spartan", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApagarJogo.ForeColor = Color.White;
            btnApagarJogo.Location = new Point(3, 137);
            btnApagarJogo.Name = "btnApagarJogo";
            btnApagarJogo.Size = new Size(685, 40);
            btnApagarJogo.TabIndex = 9;
            btnApagarJogo.Text = "APAGAR JOGO SALVO";
            btnApagarJogo.UseVisualStyleBackColor = false;
            btnApagarJogo.Click += btnApagarJogo_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(listView1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.FlatStyle = FlatStyle.Flat;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(3, 546);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(691, 114);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "JOGOS SALVOS";
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.Info;
            listView1.Dock = DockStyle.Fill;
            listView1.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold);
            listView1.Location = new Point(3, 25);
            listView1.Name = "listView1";
            listView1.Size = new Size(685, 86);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.KeyDown += listView1_KeyDown;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.GradientInactiveCaption;
            groupBox3.Controls.Add(tableLayoutPanel1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.FlatStyle = FlatStyle.Flat;
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(3, 130);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(691, 174);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "MEU JOGO";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.BackColor = SystemColors.Info;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblAcertos, 0, 1);
            tableLayoutPanel1.Controls.Add(lblPontos, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(685, 146);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAcertos
            // 
            lblAcertos.AutoSize = true;
            lblAcertos.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold);
            lblAcertos.Location = new Point(4, 73);
            lblAcertos.Name = "lblAcertos";
            lblAcertos.Size = new Size(202, 24);
            lblAcertos.TabIndex = 1;
            lblAcertos.Text = "AGUARDANDO JOGO";
            // 
            // lblPontos
            // 
            lblPontos.AutoSize = true;
            lblPontos.Font = new Font("Spartan SemiBold", 12F, FontStyle.Bold);
            lblPontos.Location = new Point(4, 1);
            lblPontos.Name = "lblPontos";
            lblPontos.Size = new Size(202, 24);
            lblPontos.TabIndex = 0;
            lblPontos.Text = "AGUARDANDO JOGO";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(328, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(gpBSelectLoteria);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(334, 124);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(gpBInfoLoteria, 0, 0);
            tableLayoutPanel2.Controls.Add(gpBGanhadores, 0, 1);
            tableLayoutPanel2.Location = new Point(12, 142);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 64.70588F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35.294117F));
            tableLayoutPanel2.Size = new Size(331, 533);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.BackColor = Color.Transparent;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(groupBox2, 0, 3);
            tableLayoutPanel3.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel3.Controls.Add(groupBox3, 0, 1);
            tableLayoutPanel3.Location = new Point(360, 12);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 41.3680763F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 58.6319237F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 236F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
            tableLayoutPanel3.Size = new Size(697, 663);
            tableLayoutPanel3.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(textBox1);
            flowLayoutPanel2.Controls.Add(btnVerificarJogo);
            flowLayoutPanel2.Controls.Add(btnSalvarJogo);
            flowLayoutPanel2.Controls.Add(btnApagarJogo);
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 310);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(691, 230);
            flowLayoutPanel2.TabIndex = 12;
            flowLayoutPanel2.WrapContents = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.AutoSize = true;
            button1.BackColor = Color.Gold;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Yellow;
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.MouseDownBackColor = Color.Goldenrod;
            button1.FlatAppearance.MouseOverBackColor = Color.Khaki;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Spartan", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 183);
            button1.Name = "button1";
            button1.Size = new Size(685, 40);
            button1.TabIndex = 10;
            button1.Text = "LIMPAR TEXTO";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1067, 684);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loteria APP";
            Load += Form1_Load;
            gpBSelectLoteria.ResumeLayout(false);
            gpBInfoLoteria.ResumeLayout(false);
            gpBInfoLoteria.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gpBGanhadores.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxLoterias;
        private GroupBox gpBSelectLoteria;
        private GroupBox gpBInfoLoteria;
        private Label lblNumConcurso;
        private Label lblDezenas;
        private Label lblValorEstimado;
        private GroupBox groupBox1;
        private Label lblDataProxConc;
        private Label lblNumProxConc;
        private Label lblAcumulou;
        private GroupBox gpBGanhadores;
        private TabControl tabControl1;
        private TextBox textBox1;
        private Button btnVerificarJogo;
        private Button btnSalvarJogo;
        private Button btnApagarJogo;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ListView listView1;
        private Label lblTimeCoracao;
        private Label lblAcertos;
        private Label lblPontos;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button1;
        private Button btnBuscarResultado;
        private TextBox txtBoxBuscarResultado;
    }
}
