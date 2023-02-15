namespace Renamer
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.cbxSubfolders = new System.Windows.Forms.CheckBox();
            this.tabController = new System.Windows.Forms.TabControl();
            this.tabAjustar = new System.Windows.Forms.TabPage();
            this.lblPx = new System.Windows.Forms.Label();
            this.nudAlturaMinima = new System.Windows.Forms.NumericUpDown();
            this.cbxUpscale = new System.Windows.Forms.CheckBox();
            this.cbxAspectRatio = new System.Windows.Forms.CheckBox();
            this.cbxConverterJpg = new System.Windows.Forms.CheckBox();
            this.tabUnificarPaginas = new System.Windows.Forms.TabPage();
            this.txtFolderDuplasUnificarPagina = new System.Windows.Forms.TextBox();
            this.lblUnificar = new System.Windows.Forms.Label();
            this.cbxMoverPaginasUnificadas = new System.Windows.Forms.CheckBox();
            this.tabSepararPaginas = new System.Windows.Forms.TabPage();
            this.txtFolderUnificadasSepararPagina = new System.Windows.Forms.TextBox();
            this.lblSeparar = new System.Windows.Forms.Label();
            this.cbxMoverPaginasSeparadas = new System.Windows.Forms.CheckBox();
            this.tabRenomear = new System.Windows.Forms.TabPage();
            this.cbxMoverArquivos = new System.Windows.Forms.CheckBox();
            this.tabGerarLivros = new System.Windows.Forms.TabPage();
            this.clbTipoArquivoLivros = new System.Windows.Forms.CheckedListBox();
            this.cbxUtilizarArquivoMetadata = new System.Windows.Forms.CheckBox();
            this.cbxApagarImagesOriginais = new System.Windows.Forms.CheckBox();
            this.txtIgnoreFolderImage = new System.Windows.Forms.TextBox();
            this.cbxIgnoreFolderImage = new System.Windows.Forms.CheckBox();
            this.dpxDirecaoLeitura = new System.Windows.Forms.ComboBox();
            this.lblOrdemLeitura = new System.Windows.Forms.Label();
            this.txtNomeArquivoCapa = new System.Windows.Forms.TextBox();
            this.txtDiretorioImagens = new System.Windows.Forms.TextBox();
            this.lblDiretorioImagens = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxSepararPaginas = new System.Windows.Forms.CheckBox();
            this.cbxAjusteArquivos = new System.Windows.Forms.CheckBox();
            this.cbxGerarLivros = new System.Windows.Forms.CheckBox();
            this.cbxUnificarPaginas = new System.Windows.Forms.CheckBox();
            this.cbxRenomear = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxConfiguracoes = new System.Windows.Forms.GroupBox();
            this.cbxUsarCapa = new System.Windows.Forms.CheckBox();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.tabController.SuspendLayout();
            this.tabAjustar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaMinima)).BeginInit();
            this.tabUnificarPaginas.SuspendLayout();
            this.tabSepararPaginas.SuspendLayout();
            this.tabRenomear.SuspendLayout();
            this.tabGerarLivros.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxConfiguracoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Location = new System.Drawing.Point(68, 16);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(393, 23);
            this.txtDiretorio.TabIndex = 0;
            this.txtDiretorio.TextChanged += new System.EventHandler(this.txtDiretorio_TextChanged);
            this.txtDiretorio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiretorio_KeyPress);
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Location = new System.Drawing.Point(467, 16);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDialog.TabIndex = 1;
            this.btnOpenDialog.Text = "...";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diretório:";
            // 
            // btnExecutar
            // 
            this.btnExecutar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExecutar.Location = new System.Drawing.Point(0, 654);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(572, 72);
            this.btnExecutar.TabIndex = 7;
            this.btnExecutar.Text = "EXECUTAR";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // cbxSubfolders
            // 
            this.cbxSubfolders.AutoSize = true;
            this.cbxSubfolders.Checked = true;
            this.cbxSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSubfolders.Location = new System.Drawing.Point(68, 45);
            this.cbxSubfolders.Name = "cbxSubfolders";
            this.cbxSubfolders.Size = new System.Drawing.Size(121, 19);
            this.cbxSubfolders.TabIndex = 10;
            this.cbxSubfolders.Text = "Utilizar Subfolders";
            this.cbxSubfolders.UseVisualStyleBackColor = true;
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.tabAjustar);
            this.tabController.Controls.Add(this.tabUnificarPaginas);
            this.tabController.Controls.Add(this.tabSepararPaginas);
            this.tabController.Controls.Add(this.tabRenomear);
            this.tabController.Controls.Add(this.tabGerarLivros);
            this.tabController.Location = new System.Drawing.Point(0, 356);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(572, 129);
            this.tabController.TabIndex = 12;
            // 
            // tabAjustar
            // 
            this.tabAjustar.Controls.Add(this.lblPx);
            this.tabAjustar.Controls.Add(this.nudAlturaMinima);
            this.tabAjustar.Controls.Add(this.cbxUpscale);
            this.tabAjustar.Controls.Add(this.cbxAspectRatio);
            this.tabAjustar.Controls.Add(this.cbxConverterJpg);
            this.tabAjustar.Location = new System.Drawing.Point(4, 24);
            this.tabAjustar.Name = "tabAjustar";
            this.tabAjustar.Size = new System.Drawing.Size(564, 101);
            this.tabAjustar.TabIndex = 4;
            this.tabAjustar.Text = "Ajustar Arquivos";
            this.tabAjustar.UseVisualStyleBackColor = true;
            // 
            // lblPx
            // 
            this.lblPx.AutoSize = true;
            this.lblPx.Location = new System.Drawing.Point(361, 55);
            this.lblPx.Name = "lblPx";
            this.lblPx.Size = new System.Drawing.Size(20, 15);
            this.lblPx.TabIndex = 28;
            this.lblPx.Text = "px";
            // 
            // nudAlturaMinima
            // 
            this.nudAlturaMinima.Location = new System.Drawing.Point(224, 50);
            this.nudAlturaMinima.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAlturaMinima.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaMinima.Name = "nudAlturaMinima";
            this.nudAlturaMinima.Size = new System.Drawing.Size(131, 23);
            this.nudAlturaMinima.TabIndex = 27;
            this.nudAlturaMinima.Value = new decimal(new int[] {
            2560,
            0,
            0,
            0});
            // 
            // cbxUpscale
            // 
            this.cbxUpscale.AutoSize = true;
            this.cbxUpscale.Checked = true;
            this.cbxUpscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUpscale.Location = new System.Drawing.Point(14, 51);
            this.cbxUpscale.Name = "cbxUpscale";
            this.cbxUpscale.Size = new System.Drawing.Size(204, 19);
            this.cbxUpscale.TabIndex = 26;
            this.cbxUpscale.Text = "Upscale imagem - Altura Mínima:";
            this.cbxUpscale.UseVisualStyleBackColor = true;
            this.cbxUpscale.CheckStateChanged += new System.EventHandler(this.cbxUpscale_CheckStateChanged);
            // 
            // cbxAspectRatio
            // 
            this.cbxAspectRatio.AutoSize = true;
            this.cbxAspectRatio.Checked = true;
            this.cbxAspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAspectRatio.Location = new System.Drawing.Point(159, 15);
            this.cbxAspectRatio.Name = "cbxAspectRatio";
            this.cbxAspectRatio.Size = new System.Drawing.Size(286, 19);
            this.cbxAspectRatio.TabIndex = 25;
            this.cbxAspectRatio.Text = "Corrigir discrepância no aspect ratio da resolução";
            this.cbxAspectRatio.UseVisualStyleBackColor = true;
            this.cbxAspectRatio.CheckStateChanged += new System.EventHandler(this.cbxAspectRatio_CheckStateChanged);
            // 
            // cbxConverterJpg
            // 
            this.cbxConverterJpg.AutoSize = true;
            this.cbxConverterJpg.Checked = true;
            this.cbxConverterJpg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxConverterJpg.Location = new System.Drawing.Point(14, 15);
            this.cbxConverterJpg.Name = "cbxConverterJpg";
            this.cbxConverterJpg.Size = new System.Drawing.Size(126, 19);
            this.cbxConverterJpg.TabIndex = 24;
            this.cbxConverterJpg.Text = "Converter para JPG";
            this.cbxConverterJpg.UseVisualStyleBackColor = true;
            this.cbxConverterJpg.CheckStateChanged += new System.EventHandler(this.cbxConverterJpg_CheckStateChanged);
            // 
            // tabUnificarPaginas
            // 
            this.tabUnificarPaginas.Controls.Add(this.txtFolderDuplasUnificarPagina);
            this.tabUnificarPaginas.Controls.Add(this.lblUnificar);
            this.tabUnificarPaginas.Controls.Add(this.cbxMoverPaginasUnificadas);
            this.tabUnificarPaginas.Location = new System.Drawing.Point(4, 24);
            this.tabUnificarPaginas.Name = "tabUnificarPaginas";
            this.tabUnificarPaginas.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnificarPaginas.Size = new System.Drawing.Size(564, 101);
            this.tabUnificarPaginas.TabIndex = 1;
            this.tabUnificarPaginas.Text = "Unificar Páginas";
            this.tabUnificarPaginas.UseVisualStyleBackColor = true;
            // 
            // txtFolderDuplasUnificarPagina
            // 
            this.txtFolderDuplasUnificarPagina.Location = new System.Drawing.Point(213, 12);
            this.txtFolderDuplasUnificarPagina.Name = "txtFolderDuplasUnificarPagina";
            this.txtFolderDuplasUnificarPagina.Size = new System.Drawing.Size(337, 23);
            this.txtFolderDuplasUnificarPagina.TabIndex = 16;
            this.txtFolderDuplasUnificarPagina.Text = "unificar";
            // 
            // lblUnificar
            // 
            this.lblUnificar.AutoSize = true;
            this.lblUnificar.Location = new System.Drawing.Point(14, 15);
            this.lblUnificar.Name = "lblUnificar";
            this.lblUnificar.Size = new System.Drawing.Size(190, 15);
            this.lblUnificar.TabIndex = 15;
            this.lblUnificar.Text = "Pasta onde se encontra as páginas:";
            // 
            // cbxMoverPaginasUnificadas
            // 
            this.cbxMoverPaginasUnificadas.AutoSize = true;
            this.cbxMoverPaginasUnificadas.Checked = true;
            this.cbxMoverPaginasUnificadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMoverPaginasUnificadas.Location = new System.Drawing.Point(14, 51);
            this.cbxMoverPaginasUnificadas.Name = "cbxMoverPaginasUnificadas";
            this.cbxMoverPaginasUnificadas.Size = new System.Drawing.Size(282, 19);
            this.cbxMoverPaginasUnificadas.TabIndex = 13;
            this.cbxMoverPaginasUnificadas.Text = "Mover páginas unificadas para pasta de imagens";
            this.cbxMoverPaginasUnificadas.UseVisualStyleBackColor = true;
            // 
            // tabSepararPaginas
            // 
            this.tabSepararPaginas.Controls.Add(this.txtFolderUnificadasSepararPagina);
            this.tabSepararPaginas.Controls.Add(this.lblSeparar);
            this.tabSepararPaginas.Controls.Add(this.cbxMoverPaginasSeparadas);
            this.tabSepararPaginas.Location = new System.Drawing.Point(4, 24);
            this.tabSepararPaginas.Name = "tabSepararPaginas";
            this.tabSepararPaginas.Size = new System.Drawing.Size(564, 101);
            this.tabSepararPaginas.TabIndex = 3;
            this.tabSepararPaginas.Text = "Separar Páginas";
            this.tabSepararPaginas.UseVisualStyleBackColor = true;
            // 
            // txtFolderUnificadasSepararPagina
            // 
            this.txtFolderUnificadasSepararPagina.Location = new System.Drawing.Point(244, 12);
            this.txtFolderUnificadasSepararPagina.Name = "txtFolderUnificadasSepararPagina";
            this.txtFolderUnificadasSepararPagina.Size = new System.Drawing.Size(306, 23);
            this.txtFolderUnificadasSepararPagina.TabIndex = 22;
            this.txtFolderUnificadasSepararPagina.Text = "separar";
            // 
            // lblSeparar
            // 
            this.lblSeparar.AutoSize = true;
            this.lblSeparar.Location = new System.Drawing.Point(14, 15);
            this.lblSeparar.Name = "lblSeparar";
            this.lblSeparar.Size = new System.Drawing.Size(190, 15);
            this.lblSeparar.TabIndex = 21;
            this.lblSeparar.Text = "Pasta onde se encontra as páginas:";
            // 
            // cbxMoverPaginasSeparadas
            // 
            this.cbxMoverPaginasSeparadas.AutoSize = true;
            this.cbxMoverPaginasSeparadas.Checked = true;
            this.cbxMoverPaginasSeparadas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMoverPaginasSeparadas.Location = new System.Drawing.Point(14, 51);
            this.cbxMoverPaginasSeparadas.Name = "cbxMoverPaginasSeparadas";
            this.cbxMoverPaginasSeparadas.Size = new System.Drawing.Size(280, 19);
            this.cbxMoverPaginasSeparadas.TabIndex = 19;
            this.cbxMoverPaginasSeparadas.Text = "Mover páginas separadas para pasta de imagens";
            this.cbxMoverPaginasSeparadas.UseVisualStyleBackColor = true;
            // 
            // tabRenomear
            // 
            this.tabRenomear.Controls.Add(this.cbxMoverArquivos);
            this.tabRenomear.Location = new System.Drawing.Point(4, 24);
            this.tabRenomear.Name = "tabRenomear";
            this.tabRenomear.Padding = new System.Windows.Forms.Padding(3);
            this.tabRenomear.Size = new System.Drawing.Size(564, 101);
            this.tabRenomear.TabIndex = 0;
            this.tabRenomear.Text = "Renomear";
            this.tabRenomear.UseVisualStyleBackColor = true;
            // 
            // cbxMoverArquivos
            // 
            this.cbxMoverArquivos.AutoSize = true;
            this.cbxMoverArquivos.Checked = true;
            this.cbxMoverArquivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMoverArquivos.Location = new System.Drawing.Point(14, 15);
            this.cbxMoverArquivos.Name = "cbxMoverArquivos";
            this.cbxMoverArquivos.Size = new System.Drawing.Size(298, 19);
            this.cbxMoverArquivos.TabIndex = 23;
            this.cbxMoverArquivos.Text = "Mover arquivos renomeados para pasta de imagens";
            this.cbxMoverArquivos.UseVisualStyleBackColor = true;
            // 
            // tabGerarLivros
            // 
            this.tabGerarLivros.Controls.Add(this.clbTipoArquivoLivros);
            this.tabGerarLivros.Controls.Add(this.cbxUtilizarArquivoMetadata);
            this.tabGerarLivros.Controls.Add(this.cbxApagarImagesOriginais);
            this.tabGerarLivros.Location = new System.Drawing.Point(4, 24);
            this.tabGerarLivros.Name = "tabGerarLivros";
            this.tabGerarLivros.Padding = new System.Windows.Forms.Padding(3);
            this.tabGerarLivros.Size = new System.Drawing.Size(564, 101);
            this.tabGerarLivros.TabIndex = 2;
            this.tabGerarLivros.Text = "Gerar Livros";
            this.tabGerarLivros.UseVisualStyleBackColor = true;
            // 
            // clbTipoArquivoLivros
            // 
            this.clbTipoArquivoLivros.FormattingEnabled = true;
            this.clbTipoArquivoLivros.Items.AddRange(new object[] {
            "CBZ",
            "EPUB"});
            this.clbTipoArquivoLivros.Location = new System.Drawing.Point(320, 15);
            this.clbTipoArquivoLivros.Name = "clbTipoArquivoLivros";
            this.clbTipoArquivoLivros.Size = new System.Drawing.Size(229, 76);
            this.clbTipoArquivoLivros.TabIndex = 18;
            this.clbTipoArquivoLivros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTipoArquivoLivros_ItemCheck);
            // 
            // cbxUtilizarArquivoMetadata
            // 
            this.cbxUtilizarArquivoMetadata.AutoSize = true;
            this.cbxUtilizarArquivoMetadata.Location = new System.Drawing.Point(14, 15);
            this.cbxUtilizarArquivoMetadata.Name = "cbxUtilizarArquivoMetadata";
            this.cbxUtilizarArquivoMetadata.Size = new System.Drawing.Size(284, 19);
            this.cbxUtilizarArquivoMetadata.TabIndex = 17;
            this.cbxUtilizarArquivoMetadata.Text = "Utilizar metadata.opf (localizado no diretório pai)";
            this.cbxUtilizarArquivoMetadata.UseVisualStyleBackColor = true;
            // 
            // cbxApagarImagesOriginais
            // 
            this.cbxApagarImagesOriginais.AutoSize = true;
            this.cbxApagarImagesOriginais.Checked = true;
            this.cbxApagarImagesOriginais.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxApagarImagesOriginais.Location = new System.Drawing.Point(13, 51);
            this.cbxApagarImagesOriginais.Name = "cbxApagarImagesOriginais";
            this.cbxApagarImagesOriginais.Size = new System.Drawing.Size(160, 19);
            this.cbxApagarImagesOriginais.TabIndex = 16;
            this.cbxApagarImagesOriginais.Text = "Apagar arquivos originais";
            this.cbxApagarImagesOriginais.UseVisualStyleBackColor = true;
            // 
            // txtIgnoreFolderImage
            // 
            this.txtIgnoreFolderImage.Location = new System.Drawing.Point(130, 127);
            this.txtIgnoreFolderImage.Name = "txtIgnoreFolderImage";
            this.txtIgnoreFolderImage.Size = new System.Drawing.Size(406, 23);
            this.txtIgnoreFolderImage.TabIndex = 26;
            this.txtIgnoreFolderImage.Text = "folder.jpg";
            // 
            // cbxIgnoreFolderImage
            // 
            this.cbxIgnoreFolderImage.AutoSize = true;
            this.cbxIgnoreFolderImage.Checked = true;
            this.cbxIgnoreFolderImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIgnoreFolderImage.Location = new System.Drawing.Point(7, 127);
            this.cbxIgnoreFolderImage.Name = "cbxIgnoreFolderImage";
            this.cbxIgnoreFolderImage.Size = new System.Drawing.Size(63, 19);
            this.cbxIgnoreFolderImage.TabIndex = 25;
            this.cbxIgnoreFolderImage.Text = "Ignore:";
            this.cbxIgnoreFolderImage.UseVisualStyleBackColor = true;
            this.cbxIgnoreFolderImage.CheckStateChanged += new System.EventHandler(this.cbxIgnoreFolderImage_CheckStateChanged);
            // 
            // dpxDirecaoLeitura
            // 
            this.dpxDirecaoLeitura.FormattingEnabled = true;
            this.dpxDirecaoLeitura.Items.AddRange(new object[] {
            "Esquerda para Direita",
            "Direita para Esquerda"});
            this.dpxDirecaoLeitura.Location = new System.Drawing.Point(130, 25);
            this.dpxDirecaoLeitura.Name = "dpxDirecaoLeitura";
            this.dpxDirecaoLeitura.Size = new System.Drawing.Size(413, 23);
            this.dpxDirecaoLeitura.TabIndex = 5;
            // 
            // lblOrdemLeitura
            // 
            this.lblOrdemLeitura.AutoSize = true;
            this.lblOrdemLeitura.Location = new System.Drawing.Point(6, 28);
            this.lblOrdemLeitura.Name = "lblOrdemLeitura";
            this.lblOrdemLeitura.Size = new System.Drawing.Size(102, 15);
            this.lblOrdemLeitura.TabIndex = 4;
            this.lblOrdemLeitura.Text = "Ordem de Leitura:";
            // 
            // txtNomeArquivoCapa
            // 
            this.txtNomeArquivoCapa.Enabled = false;
            this.txtNomeArquivoCapa.Location = new System.Drawing.Point(130, 91);
            this.txtNomeArquivoCapa.Name = "txtNomeArquivoCapa";
            this.txtNomeArquivoCapa.Size = new System.Drawing.Size(412, 23);
            this.txtNomeArquivoCapa.TabIndex = 23;
            this.txtNomeArquivoCapa.Text = "cover.jpg";
            // 
            // txtDiretorioImagens
            // 
            this.txtDiretorioImagens.Location = new System.Drawing.Point(130, 58);
            this.txtDiretorioImagens.Name = "txtDiretorioImagens";
            this.txtDiretorioImagens.Size = new System.Drawing.Size(412, 23);
            this.txtDiretorioImagens.TabIndex = 20;
            this.txtDiretorioImagens.Text = "images";
            // 
            // lblDiretorioImagens
            // 
            this.lblDiretorioImagens.AutoSize = true;
            this.lblDiretorioImagens.Location = new System.Drawing.Point(7, 61);
            this.lblDiretorioImagens.Name = "lblDiretorioImagens";
            this.lblDiretorioImagens.Size = new System.Drawing.Size(107, 15);
            this.lblDiretorioImagens.TabIndex = 19;
            this.lblDiretorioImagens.Text = "Pasta das imagens:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSepararPaginas);
            this.groupBox1.Controls.Add(this.cbxAjusteArquivos);
            this.groupBox1.Controls.Add(this.cbxGerarLivros);
            this.groupBox1.Controls.Add(this.cbxUnificarPaginas);
            this.groupBox1.Controls.Add(this.cbxRenomear);
            this.groupBox1.Location = new System.Drawing.Point(11, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 87);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features";
            // 
            // cbxSepararPaginas
            // 
            this.cbxSepararPaginas.AutoSize = true;
            this.cbxSepararPaginas.Checked = true;
            this.cbxSepararPaginas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSepararPaginas.Location = new System.Drawing.Point(141, 55);
            this.cbxSepararPaginas.Name = "cbxSepararPaginas";
            this.cbxSepararPaginas.Size = new System.Drawing.Size(109, 19);
            this.cbxSepararPaginas.TabIndex = 15;
            this.cbxSepararPaginas.Text = "Separar Páginas";
            this.cbxSepararPaginas.UseVisualStyleBackColor = true;
            this.cbxSepararPaginas.CheckStateChanged += new System.EventHandler(this.cbxSepararPaginas_CheckStateChanged);
            // 
            // cbxAjusteArquivos
            // 
            this.cbxAjusteArquivos.AutoSize = true;
            this.cbxAjusteArquivos.Checked = true;
            this.cbxAjusteArquivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAjusteArquivos.Location = new System.Drawing.Point(7, 22);
            this.cbxAjusteArquivos.Name = "cbxAjusteArquivos";
            this.cbxAjusteArquivos.Size = new System.Drawing.Size(113, 19);
            this.cbxAjusteArquivos.TabIndex = 14;
            this.cbxAjusteArquivos.Text = "Ajustar Arquivos";
            this.cbxAjusteArquivos.UseVisualStyleBackColor = true;
            this.cbxAjusteArquivos.CheckStateChanged += new System.EventHandler(this.cbxAjusteArquivos_CheckStateChanged);
            // 
            // cbxGerarLivros
            // 
            this.cbxGerarLivros.AutoSize = true;
            this.cbxGerarLivros.Checked = true;
            this.cbxGerarLivros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGerarLivros.Location = new System.Drawing.Point(270, 22);
            this.cbxGerarLivros.Name = "cbxGerarLivros";
            this.cbxGerarLivros.Size = new System.Drawing.Size(88, 19);
            this.cbxGerarLivros.TabIndex = 13;
            this.cbxGerarLivros.Text = "Gerar Livros";
            this.cbxGerarLivros.UseVisualStyleBackColor = true;
            this.cbxGerarLivros.CheckStateChanged += new System.EventHandler(this.cbxGerarLivros_CheckStateChanged);
            // 
            // cbxUnificarPaginas
            // 
            this.cbxUnificarPaginas.AutoSize = true;
            this.cbxUnificarPaginas.Checked = true;
            this.cbxUnificarPaginas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUnificarPaginas.Location = new System.Drawing.Point(6, 55);
            this.cbxUnificarPaginas.Name = "cbxUnificarPaginas";
            this.cbxUnificarPaginas.Size = new System.Drawing.Size(111, 19);
            this.cbxUnificarPaginas.TabIndex = 12;
            this.cbxUnificarPaginas.Text = "Unificar Páginas";
            this.cbxUnificarPaginas.UseVisualStyleBackColor = true;
            this.cbxUnificarPaginas.CheckStateChanged += new System.EventHandler(this.cbxUnificarPaginas_CheckStateChanged);
            // 
            // cbxRenomear
            // 
            this.cbxRenomear.AutoSize = true;
            this.cbxRenomear.Checked = true;
            this.cbxRenomear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRenomear.Location = new System.Drawing.Point(141, 22);
            this.cbxRenomear.Name = "cbxRenomear";
            this.cbxRenomear.Size = new System.Drawing.Size(80, 19);
            this.cbxRenomear.TabIndex = 11;
            this.cbxRenomear.Text = "Renomear";
            this.cbxRenomear.UseVisualStyleBackColor = true;
            this.cbxRenomear.CheckStateChanged += new System.EventHandler(this.cbxRenomear_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDiretorio);
            this.groupBox2.Controls.Add(this.btnOpenDialog);
            this.groupBox2.Controls.Add(this.cbxSubfolders);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 71);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleção Diretórios";
            // 
            // gbxConfiguracoes
            // 
            this.gbxConfiguracoes.Controls.Add(this.txtIgnoreFolderImage);
            this.gbxConfiguracoes.Controls.Add(this.cbxUsarCapa);
            this.gbxConfiguracoes.Controls.Add(this.cbxIgnoreFolderImage);
            this.gbxConfiguracoes.Controls.Add(this.txtNomeArquivoCapa);
            this.gbxConfiguracoes.Controls.Add(this.lblOrdemLeitura);
            this.gbxConfiguracoes.Controls.Add(this.dpxDirecaoLeitura);
            this.gbxConfiguracoes.Controls.Add(this.txtDiretorioImagens);
            this.gbxConfiguracoes.Controls.Add(this.lblDiretorioImagens);
            this.gbxConfiguracoes.Location = new System.Drawing.Point(11, 182);
            this.gbxConfiguracoes.Name = "gbxConfiguracoes";
            this.gbxConfiguracoes.Size = new System.Drawing.Size(548, 168);
            this.gbxConfiguracoes.TabIndex = 16;
            this.gbxConfiguracoes.TabStop = false;
            this.gbxConfiguracoes.Text = "Configurações do Livro";
            // 
            // cbxUsarCapa
            // 
            this.cbxUsarCapa.AutoSize = true;
            this.cbxUsarCapa.Location = new System.Drawing.Point(7, 93);
            this.cbxUsarCapa.Name = "cbxUsarCapa";
            this.cbxUsarCapa.Size = new System.Drawing.Size(117, 19);
            this.cbxUsarCapa.TabIndex = 21;
            this.cbxUsarCapa.Text = "Arquivo de Capa:";
            this.cbxUsarCapa.UseVisualStyleBackColor = true;
            this.cbxUsarCapa.CheckStateChanged += new System.EventHandler(this.cbxUsarCapa_CheckStateChanged);
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.Color.Black;
            this.rtbLogs.Location = new System.Drawing.Point(0, 487);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(572, 165);
            this.rtbLogs.TabIndex = 17;
            this.rtbLogs.Text = "";
            this.rtbLogs.TextChanged += new System.EventHandler(this.rtbLogs_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 726);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.gbxConfiguracoes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.btnExecutar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabController.ResumeLayout(false);
            this.tabAjustar.ResumeLayout(false);
            this.tabAjustar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaMinima)).EndInit();
            this.tabUnificarPaginas.ResumeLayout(false);
            this.tabUnificarPaginas.PerformLayout();
            this.tabSepararPaginas.ResumeLayout(false);
            this.tabSepararPaginas.PerformLayout();
            this.tabRenomear.ResumeLayout(false);
            this.tabRenomear.PerformLayout();
            this.tabGerarLivros.ResumeLayout(false);
            this.tabGerarLivros.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxConfiguracoes.ResumeLayout(false);
            this.gbxConfiguracoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtDiretorio;
        private Button btnOpenDialog;
        private Label label1;
        private Button btnExecutar;
        private CheckBox cbxSubfolders;
        private TabControl tabController;
        private TabPage tabRenomear;
        private TabPage tabUnificarPaginas;
        private TabPage tabGerarLivros;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox cbxRenomear;
        private CheckBox cbxUnificarPaginas;
        private CheckBox cbxGerarLivros;
        private ComboBox dpxDirecaoLeitura;
        private Label lblOrdemLeitura;
        private CheckBox cbxMoverPaginasUnificadas;
        private TextBox txtFolderDuplasUnificarPagina;
        private Label lblUnificar;
        private CheckBox cbxApagarImagesOriginais;
        private CheckBox cbxUtilizarArquivoMetadata;
        private CheckBox cbxAjusteArquivos;
        private TextBox txtDiretorioImagens;
        private Label lblDiretorioImagens;
        private CheckedListBox clbTipoArquivoLivros;
        private TextBox txtNomeArquivoCapa;
        private CheckBox cbxSepararPaginas;
        private TabPage tabSepararPaginas;
        private TextBox txtFolderUnificadasSepararPagina;
        private Label lblSeparar;
        private CheckBox cbxMoverPaginasSeparadas;
        private GroupBox gbxConfiguracoes;
        private CheckBox cbxMoverArquivos;
        private CheckBox cbxUsarCapa;
        private RichTextBox rtbLogs;
        private TabPage tabAjustar;
        private CheckBox cbxAspectRatio;
        private CheckBox cbxConverterJpg;
        private CheckBox cbxUpscale;
        private Label lblPx;
        private NumericUpDown nudAlturaMinima;
        private TextBox txtIgnoreFolderImage;
        private CheckBox cbxIgnoreFolderImage;
    }
}