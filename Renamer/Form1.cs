using System.Linq;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Renamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dpxDirecaoLeitura.SelectedIndex = 1;

            ConfigurarListaGerarLivros();

            btnExecutar.Enabled = !string.IsNullOrWhiteSpace(txtDiretorio.Text);

            cbxGerarLivros.Checked = false;
            cbxUnificarPaginas.Checked = false;
            cbxSepararPaginas.Checked = false;
        }

        #region ON_KEYPRESS

        private void txtDiretorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnRename_Click(sender, null);
            }
        }

        private void nudInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnRename_Click(sender, null);
            }
        }

        private void nudQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnRename_Click(sender, null);
            }
        }

        #endregion ON_KEYPRESS

        #region ON_TEXTCHANGED

        private void txtDiretorio_TextChanged(object sender, EventArgs e)
        {
            btnExecutar.Enabled = !string.IsNullOrWhiteSpace(txtDiretorio.Text);
        }

        #endregion

        #region ON_CHECKSTATECHANGED

        private void cbxRenomear_CheckStateChanged(object sender, EventArgs e)
        {
            cbxMoverArquivos.Enabled = cbxRenomear.CheckState == CheckState.Checked;

            FocarTabAtiva();
            ValidaBtnExecutarEnable();
        }

        private void cbxGerarLivros_CheckStateChanged(object sender, EventArgs e)
        {
            var status = cbxGerarLivros.CheckState == CheckState.Checked;

            cbxApagarImagesOriginais.Enabled = status;
            cbxUtilizarArquivoMetadata.Enabled = status;
            clbTipoArquivoLivros.Enabled = status;

            if (status)
            {
                ConfigurarListaGerarLivros();
            }

            FocarTabAtiva();
            ValidaBtnExecutarEnable();
        }

        private void cbxConverterJpg_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxUpscale.CheckState == CheckState.Checked && cbxConverterJpg.CheckState != CheckState.Checked)
            {
                cbxConverterJpg.CheckState = CheckState.Checked;
            }
        }

        private void cbxAspectRatio_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxUpscale.CheckState == CheckState.Checked && cbxAspectRatio.CheckState != CheckState.Checked)
            {
                cbxAspectRatio.CheckState = CheckState.Checked;
            }
        }

        private void cbxAjusteArquivos_CheckStateChanged(object sender, EventArgs e)
        {
            cbxConverterJpg.Enabled = cbxAjusteArquivos.CheckState == CheckState.Checked;
            cbxAspectRatio.Enabled = cbxAjusteArquivos.CheckState == CheckState.Checked;
            cbxUpscale.Enabled = cbxAjusteArquivos.CheckState == CheckState.Checked;
            nudAlturaMinima.Enabled = cbxAjusteArquivos.CheckState == CheckState.Checked && cbxUpscale.CheckState == CheckState.Checked; ;
            lblPx.Enabled = cbxAjusteArquivos.CheckState == CheckState.Checked;

            FocarTabAtiva();
            ValidaBtnExecutarEnable();
        }

        private void cbxUnificarPaginas_CheckStateChanged(object sender, EventArgs e)
        {
            lblUnificar.Enabled = cbxUnificarPaginas.CheckState == CheckState.Checked;
            lblOrdemLeitura.Enabled = cbxUnificarPaginas.CheckState == CheckState.Checked;
            txtFolderDuplasUnificarPagina.Enabled = cbxUnificarPaginas.CheckState == CheckState.Checked;
            cbxMoverPaginasUnificadas.Enabled = cbxUnificarPaginas.CheckState == CheckState.Checked;

            FocarTabAtiva();
            ValidaBtnExecutarEnable();
        }

        private void cbxUpscale_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxUpscale.CheckState == CheckState.Checked)
            {
                cbxConverterJpg.CheckState = CheckState.Checked;
                cbxAspectRatio.CheckState = CheckState.Checked;
            }

            nudAlturaMinima.Enabled = cbxUpscale.CheckState == CheckState.Checked;
        }

        private void cbxSepararPaginas_CheckStateChanged(object sender, EventArgs e)
        {
            lblSeparar.Enabled = cbxSepararPaginas.CheckState == CheckState.Checked;
            txtFolderUnificadasSepararPagina.Enabled = cbxSepararPaginas.CheckState == CheckState.Checked;
            cbxMoverPaginasSeparadas.Enabled = cbxSepararPaginas.CheckState == CheckState.Checked;

            FocarTabAtiva();
            ValidaBtnExecutarEnable();
        }

        private void cbxUsarCapa_CheckStateChanged(object sender, EventArgs e)
        {
            txtNomeArquivoCapa.Enabled = cbxUsarCapa.Checked;
        }

        private void cbxIgnoreFolderImage_CheckStateChanged(object sender, EventArgs e)
        {
            txtIgnoreFolderImage.Enabled = cbxIgnoreFolderImage.CheckState == CheckState.Checked;
        }

        #endregion

        #region ON_ITEMCHECK

        private void clbTipoArquivoLivros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var status = false;

            if (e.NewValue == CheckState.Checked || (e.NewValue != CheckState.Checked && clbTipoArquivoLivros.CheckedItems.Count > 1))
            {
                status = true;
            }

            cbxGerarLivros.Checked = status;
        }

        #endregion

        #region ON_CLICK

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtDiretorio.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            rtbLogs.Clear();

            var directories = cbxSubfolders.Checked
                ? Directory.GetDirectories(txtDiretorio.Text)
                : new string[1] { txtDiretorio.Text};

            var searchSubDirectories = cbxSubfolders.Checked;

            GravarLog("INÍCIO DA EXECUÇÃO...", Color.Magenta);

            GravarLog($@"{new DirectoryInfo(txtDiretorio.Text.Trim()).Name.ToUpper()} >>>>>", Color.WhiteSmoke);

            foreach (var directory in directories)
            {
                var directoryName = new DirectoryInfo(directory).Name;
                GravarLog($@"<{directoryName}>", Color.MediumVioletRed);

                ExecuteFileAdjustments(
                        directoryPath: directory,
                        searchSubDirectories: searchSubDirectories
                    );

                ExecutePageUnification(
                        directoryPath: directory,
                        searchSubDirectories: searchSubDirectories
                    );

                ExecutePageSplit(
                        directoryPath: directory,
                        searchSubDirectories: searchSubDirectories
                    );

                ExecutePageRename(
                        directoryPath: directory,
                        searchSubDirectories: searchSubDirectories
                    );

                ExecuteBookGenerator(
                        directoryPath: directory,
                        searchSubDirectories: searchSubDirectories
                    );

                GravarLog($@"</{directoryName}>", Color.MediumVioletRed);
                Thread.Sleep(500);
            }

            GravarLog("FINAL DA EXECUÇÃO.", Color.Magenta);

            MessageBox.Show("Execução finalizada!");
        }

        #endregion

        #region ON_TEXTCHANGED

        private void rtbLogs_TextChanged(object sender, EventArgs e)
        {
            rtbLogs.SelectionStart = rtbLogs.Text.Length;
            rtbLogs.ScrollToCaret();
        }

        #endregion

        #region EXECUTION

        private void GravarLog(string value, Color color)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var lastIndex = rtbLogs.Text.Length > 0 ? rtbLogs.Text.Length - 1 : 0;
            rtbLogs.AppendText(value);
            rtbLogs.AppendText(Environment.NewLine);
            rtbLogs.Select(lastIndex, value.Length + 1);
            rtbLogs.SelectionColor = color;
            rtbLogs.Select(0, 0);
        }

        private void ExecuteFileAdjustments(
                string directoryPath,
                bool searchSubDirectories
            )
        {
            if (cbxAjusteArquivos.CheckState == CheckState.Checked)
            {
                var ajustar = new AjustarAqruivos();
                ajustar.Executar(
                        diretorioInicial: directoryPath,
                        pesquisarSubDiretorios: searchSubDirectories,
                        converterJPG: cbxConverterJpg.Checked,
                        ajustarAspectRatio: cbxAspectRatio.Checked,
                        alturaMinima: cbxUpscale.Checked ? (int?)nudAlturaMinima.Value : null,
                        destinyDirectory: txtDiretorioImagens.Text,
                        ignoreImageName: cbxIgnoreFolderImage.CheckState == CheckState.Checked ? txtIgnoreFolderImage.Text : null,
                        gravarLog: GravarLog
                    );
            }
        }

        private void ExecutePageUnification(
                string directoryPath,
                bool searchSubDirectories
            )
        {
            if (cbxUnificarPaginas.CheckState == CheckState.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtFolderDuplasUnificarPagina.Text))
                {
                    MessageBox.Show($@"O valor do campo '{lblUnificar.Text}' da tab '{tabController.TabPages[0].Text}' tem que estar preenchido!");
                    return;
                }

                if (cbxMoverPaginasUnificadas.CheckState == CheckState.Checked && string.IsNullOrWhiteSpace(txtDiretorioImagens.Text))
                {
                    MessageBox.Show($@"O valor campo '{lblDiretorioImagens.Text}' da '{gbxConfiguracoes.Text}' tem que estar preenchido!");
                    return;
                }

                var unificar = new UnificarPaginas();
                unificar.Executar(
                        diretorioInicial: directoryPath,
                        pesquisarSubDiretorios: searchSubDirectories,
                        subDiretorio: txtFolderDuplasUnificarPagina.Text,
                        leituraPadraoOcidental: dpxDirecaoLeitura.SelectedIndex == 0,
                        diretorioDestino: cbxMoverPaginasUnificadas.CheckState == CheckState.Checked ? txtDiretorioImagens.Text : string.Empty
                    );
            }
        }

        private void ExecutePageSplit(
                string directoryPath,
                bool searchSubDirectories
            )
        {
            if (cbxSepararPaginas.CheckState == CheckState.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtFolderUnificadasSepararPagina.Text))
                {
                    MessageBox.Show($@"O valor do campo '{lblSeparar.Text}' da tab '{tabController.TabPages[1].Text}' tem que estar preenchido!");
                    return;
                }

                if (cbxMoverPaginasSeparadas.CheckState == CheckState.Checked && string.IsNullOrWhiteSpace(txtDiretorioImagens.Text))
                {
                    MessageBox.Show($@"O valor campo '{lblDiretorioImagens.Text}' da '{gbxConfiguracoes.Text}' tem que estar preenchido!");
                    return;
                }

                var separar = new SepararPaginas();
                separar.Executar(
                        diretorioInicial: directoryPath,
                        pesquisarSubDiretorios: searchSubDirectories,
                        subDiretorio: txtFolderUnificadasSepararPagina.Text,
                        leituraPadraoOcidental: dpxDirecaoLeitura.SelectedIndex == 0,
                        diretorioDestino: cbxMoverPaginasSeparadas.CheckState == CheckState.Checked ? txtDiretorioImagens.Text : string.Empty,
                        gravarLog: GravarLog
                    );
            }
        }

        private void ExecutePageRename(
                string directoryPath,
                bool searchSubDirectories
            )
        {
            if (cbxRenomear.CheckState == CheckState.Checked)
            {
                var renomear = new Renomear();
                renomear.Executar(
                        diretorioInicial: directoryPath,
                        pesquisarSubDiretorios: searchSubDirectories,
                        diretorioDestino: cbxMoverArquivos.CheckState == CheckState.Checked ? txtDiretorioImagens.Text : null,
                        ignoreImageName: cbxIgnoreFolderImage.CheckState == CheckState.Checked ? txtIgnoreFolderImage.Text : null,
                        gravarLog: GravarLog
                    );
            }
        }

        private void ExecuteBookGenerator(
                string directoryPath,
                bool searchSubDirectories
            )
        {
            if (cbxGerarLivros.CheckState == CheckState.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtDiretorioImagens.Text))
                {
                    MessageBox.Show($@"O valor do campo '{lblDiretorioImagens.Text}' da tab '{tabController.TabPages[2].Text}' tem que estar preenchido!");
                    return;
                }

                if (cbxUsarCapa.CheckState == CheckState.Checked && string.IsNullOrWhiteSpace(txtNomeArquivoCapa.Text))
                {
                    MessageBox.Show($@"O valor campo '{cbxUsarCapa.Text}' da '{gbxConfiguracoes.Text}' tem que estar preenchido!");
                    return;
                }

                var gerarLivros = new GerarLivros();
                gerarLivros.Executar(
                        diretorioInicial: directoryPath,
                        pesquisarSubDiretorios: searchSubDirectories,
                        subDiretorio: txtDiretorioImagens.Text,
                        nomeArquivoCapa: cbxUsarCapa.CheckState == CheckState.Checked ? txtNomeArquivoCapa.Text : string.Empty,
                        utilizarMetadados: cbxUtilizarArquivoMetadata.CheckState == CheckState.Checked,
                        apagarArquivosOriginais: cbxApagarImagesOriginais.CheckState == CheckState.Checked,
                        gerarCbz: clbTipoArquivoLivros.GetItemChecked(0),
                        gerarEpub: clbTipoArquivoLivros.GetItemChecked(1),
                        diretorioDestino: cbxMoverArquivos.CheckState == CheckState.Checked ? txtDiretorioImagens.Text : null, 
                        ignoreImageName: cbxIgnoreFolderImage.CheckState == CheckState.Checked ? txtIgnoreFolderImage.Text : null,
                        gravarLog: GravarLog
                    );
            }
        }

        #endregion EXECUTION

        private void ConfigurarListaGerarLivros()
        {
            if (clbTipoArquivoLivros.CheckedItems.Count == 0)
            {
                for (var i = 0; i < clbTipoArquivoLivros.Items.Count; i++)
                {
                    if (clbTipoArquivoLivros.Items[i].ToString() == "CBZ")
                    {
                        clbTipoArquivoLivros.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void ValidaBtnExecutarEnable()
        {
            if (
                    (
                        cbxAjusteArquivos.CheckState != CheckState.Checked &&
                        cbxUnificarPaginas.CheckState != CheckState.Checked &&
                        cbxSepararPaginas.CheckState != CheckState.Checked &&
                        cbxRenomear.CheckState != CheckState.Checked &&
                        cbxGerarLivros.CheckState != CheckState.Checked
                    )
                    || string.IsNullOrWhiteSpace(txtDiretorio.Text)
                    || !Directory.Exists(txtDiretorio.Text)
                )
            {
                btnExecutar.Enabled = false;
                return;
            }

            btnExecutar.Enabled = true;
        }

        private void FocarTabAtiva()
        {
            if (cbxAjusteArquivos.CheckState == CheckState.Checked)
            {
                tabController.SelectedIndex = 0;
            }
            else if (cbxUnificarPaginas.CheckState == CheckState.Checked)
            {
                tabController.SelectedIndex = 1;
            }
            else if (cbxSepararPaginas.CheckState == CheckState.Checked)
            {
                tabController.SelectedIndex = 2;
            }
            else if (cbxRenomear.CheckState == CheckState.Checked)
            {
                tabController.SelectedIndex = 3;
            }
            else if (cbxGerarLivros.CheckState == CheckState.Checked)
            {
                tabController.SelectedIndex = 4;
            }
            else
            {
                tabController.SelectedIndex = 0;
            }
        }
    }
}