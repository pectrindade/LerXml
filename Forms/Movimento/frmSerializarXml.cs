using LerXML.Classes.MySQL;
using LerXML.ModelSerialization;
using LerXML.Relatorio.RelCompra;
using LerXML.Serializable;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LerXML.Forms.Movimento
{


    public partial class frmSerializarXml : Form
    {
        string vChave = "";

        public frmSerializarXml()
        {
            InitializeComponent();
        }

        private void frmSerializarXml_Load(object sender, EventArgs e)
        {

        }

        private void btnLerXml_Click(object sender, EventArgs e)
        {
            LerXml();
        }

        private void LerXml()
        {
            try
            {
                if (openFileXml.ShowDialog() == DialogResult.OK)
                {
                    txtpathXml.Text = openFileXml.FileName;

                    NFeSerialization serializable = new NFeSerialization();
                    var nfe = serializable.GetObjectFromFile<NFeProc>(txtpathXml.Text);

                    if (nfe == null)
                    {
                        MessageBox.Show("Falha ao ler o arquivo xml. Verifique se o arquivo é de uma NF-e/NFC-e autorizada!", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        popularForm(nfe);
                        MessageBox.Show("Arquivo xml da Nota Fiscal lido com Sucesso!", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Falha no processo de leitura do arquivo xml da Nota Fiscal.", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void popularForm(NFeProc nfe)
        {
            /* Populando tab Identificação */
            txtNaturezaOperacao.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.natOp;
            txtNumero.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.nNF;
            txtModelo.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.mod;
            txtSerie.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.serie.ToString();
            txtDataEmissao.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.dhEmi.ToShortDateString();

            /* Populando tab Emitente */
            txtRazaoSocial.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.xNome;
            txtNomeFantasia.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.xFant;
            txtCpfCnpjEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.CNPJ;
            txtInscricaoEstadual.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.IE;
            txtLogradouroEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.xLgr;
            txtNroEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.nro;
            txtMunicipioEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.xMun;
            txtUFEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.UF;

            /* Populando tab Destinatário */
            txtDestNomeFantasia.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.xNome;
            txtDestCpfCnpj.Text = string.IsNullOrEmpty(nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ) ? nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CPF : nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ;
            txtDestEmail.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.email;
            txtDestLogradouro.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xLgr;
            txtDestNumero.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.nro;
            txtDestMunicipio.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xMun;
            txtDestUF.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.UF;
            txtDestCEP.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.CEP;
            txtDestBairro.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xBairro;


            int num = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe.Count();
            string teste = "";

            for (int i = 0; i < num; i++)
            {

                //define um array de strings com nCOlunas
                string[] linhaDados = new string[9];

                linhaDados[0] = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.nNF;
                linhaDados[1] = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.dhEmi.ToShortDateString();
                linhaDados[2] = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.CNPJ;

                linhaDados[3] = vChave.Substring(0, 44);

                linhaDados[4] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.xProd.ToString();
                linhaDados[5] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.qCom.ToString();
                linhaDados[6] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.vUnCom.ToString();
                linhaDados[7] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.NCM.ToString();
                linhaDados[8] = txtRazaoSocial.Text.Trim();

                Grid.Rows.Add(linhaDados);


            }

        }

        private void popularFormVenda(NFeProc nfe)
        {
            /* Populando tab Identificação */
            txtNaturezaOperacao.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.natOp;
            txtNumero.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.nNF;
            txtModelo.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.mod;
            txtSerie.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.serie.ToString();
            txtDataEmissao.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.dhEmi.ToShortDateString();

            /* Populando tab Emitente */
            txtRazaoSocial.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.xNome;
            txtNomeFantasia.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.xFant;
            txtCpfCnpjEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.CNPJ;
            txtInscricaoEstadual.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.IE;
            txtLogradouroEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.xLgr;
            txtNroEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.nro;
            txtMunicipioEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.xMun;
            txtUFEmitente.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.Endereco.UF;


            /* Populando tab Destinatário */
            try
            {
                txtDestNomeFantasia.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.xNome;
                txtDestCpfCnpj.Text = string.IsNullOrEmpty(nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ) ? nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CPF : nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ;
                txtDestEmail.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.email;
                txtDestLogradouro.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xLgr;
                txtDestNumero.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.nro;
                txtDestMunicipio.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xMun;
                txtDestUF.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.UF;
                txtDestCEP.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.CEP;
                txtDestBairro.Text = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.Endereco.xBairro;
            }
            catch
            {

            }

            int num = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe.Count();
            string teste = "";

            for (int i = 0; i < num; i++)
            {

                //define um array de strings com nCOlunas
                string[] linhaDados = new string[11];

                linhaDados[0] = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.nNF;
                linhaDados[1] = nfe.NotaFiscalEletronica.InformacoesNFe.Identificacao.dhEmi.ToShortDateString();
                linhaDados[2] = nfe.NotaFiscalEletronica.InformacoesNFe.Emitente.CNPJ;

                linhaDados[3] = vChave.Substring(0, 44);

                linhaDados[4] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.xProd.ToString();
                linhaDados[5] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.qCom.ToString();
                linhaDados[6] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.vUnCom.ToString();
                linhaDados[7] = nfe.NotaFiscalEletronica.InformacoesNFe.Detalhe[i].Produto.NCM.ToString();
                linhaDados[8] = txtRazaoSocial.Text.Trim();
                linhaDados[9] = string.IsNullOrEmpty(nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ) ? nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CPF : nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.CNPJ;
                linhaDados[10] = nfe.NotaFiscalEletronica.InformacoesNFe.Destinatario.xNome;

                Grid.Rows.Add(linhaDados);


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var cria = new CriaArquivo();
            //cria.Cria_RelNcm();
        }

        private void btnbusca_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            txtpathXml.Text = folderBrowserDialog1.SelectedPath;

            BuscaArquivos();

        }

        public void BuscaArquivos()
        {
            //Marca o diretório a ser listado
            DirectoryInfo diretorio = new DirectoryInfo(@" " + txtpathXml.Text + "");
            //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
            FileInfo[] Arquivos = diretorio.GetFiles("*.*");

            //Começamos a listar os arquivos
            foreach (FileInfo fileinfo in Arquivos)
            {
                var arquivo = txtpathXml.Text + "\\" + fileinfo.Name.ToString();
                vChave = fileinfo.Name.ToString();

                NFeSerialization serializable = new NFeSerialization();
                var nfe = serializable.GetObjectFromFile<NFeProc>(arquivo);

                if (nfe == null)
                {
                    MessageBox.Show("Falha ao ler o arquivo xml. Verifique se o arquivo é de uma NF-e/NFC-e autorizada!", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    popularFormVenda(nfe);
                    //MessageBox.Show("Arquivo xml da Nota Fiscal lido com Sucesso!", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Base();
                }

            }
            Base();
            CarregaCmbEmitente();
            CarregaCmbDestinatario();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //System.Threading.Thread tFormAguarde = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaFormAguarde));
                //tFormAguarde.Start();

                Relatorio();


                //tFormAguarde.Abort();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void CarregaFormAguarde()
        {
            Form f = new Espera();
            f.ShowDialog();
        }

        private void Base()
        {
            DateTime data;

            var numeronf = "";
            var ano = "";
            var dataemissao = "";
            var cnpj = "";
            var nomeempresa = "";
            var chave = "";
            var nomeproduto = "";
            var quantidade = "";
            var valorunitario = "";
            var ncm = "";
            var destcnpj = "";
            var destnome = "";


            var cria = new Classes.CriaArquivo();
            cria.Cria_RelBase();

            // BUSCA E GRAVA NO REPOSITORIO

            var Linhas = Grid.Rows.Count;

            foreach (DataGridViewRow linha1 in Grid.Rows)
            {
                try
                {
                    data = Convert.ToDateTime(linha1.Cells[1].Value.ToString());

                    ano = data.ToString("yyyy");
                    numeronf = linha1.Cells[0].Value.ToString();
                    dataemissao = linha1.Cells[1].Value.ToString();
                    cnpj = linha1.Cells[2].Value.ToString();
                    chave = linha1.Cells[3].Value.ToString();
                    nomeproduto = linha1.Cells[4].Value.ToString();
                    quantidade = linha1.Cells[5].Value.ToString();
                    valorunitario = linha1.Cells[6].Value.ToString();
                    ncm = linha1.Cells[7].Value.ToString();
                    nomeempresa = linha1.Cells[8].Value.ToString();
                    destcnpj = linha1.Cells[9].Value.ToString();
                    destnome = linha1.Cells[10].Value.ToString();

                    var item = new RelBase();
                    item.InsertAccess_RelBase(ano, numeronf, dataemissao, cnpj, nomeempresa, destcnpj, destnome, chave, nomeproduto, quantidade, valorunitario, ncm);

                }
                catch
                {

                }

            }
            MessageBox.Show("Arquivo xml da Nota Fiscal lido com Sucesso!", "Aviso - Leitura do Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CarregaCmbEmitente()
        {
            string codigo;
            string nome;


            cmbEmitente.Items.Clear();

            cmbEmitente.Items.Insert(0, "--SELECIONE--");

            var dr = RelCompra.BuscaEmitente();

            if (dr.HasRows)
            {
                var cont = 1;

                while (dr.Read())
                {

                    codigo = dr.GetString(dr.GetOrdinal("CODEMITENTE"));
                    nome = dr.GetString(dr.GetOrdinal("NOMEEMITENTE")) + " - " + codigo;

                    cmbEmitente.Items.Insert(cont, nome);
                    cont++;
                }

            }

            dr.Close();
            dr.Dispose();

        }

        private void CarregaCmbDestinatario()
        {
            string codigo = "";
            string CodigoAnterior = "";
            string nome;

            cmbDestinatario.Items.Clear();

            cmbDestinatario.Items.Insert(0, "--SELECIONE--");

            var dr = RelCompra.BuscaDestinatario();

            if (dr.HasRows)
            {
                var cont = 1;

                while (dr.Read())
                {
                    codigo = dr.GetString(dr.GetOrdinal("CODDESTINATARIO"));

                    if (CodigoAnterior != codigo)
                    {
                        nome = dr.GetString(dr.GetOrdinal("NOMEDESTINATARIO")) + " - " + codigo;
                        cmbDestinatario.Items.Insert(cont, nome);
                        cont++;
                    }
                    CodigoAnterior = dr.GetString(dr.GetOrdinal("CODDESTINATARIO"));
                }

            }

            dr.Close();
            dr.Dispose();

        }

        private void Relatorio()
        {

            var numeronf = "";
            var dataemissao = "";
            var cnpj = "";
            var nomeempresa = "";
            var chave = "";
            var nomeproduto = "";
            var quantidade = "";
            var valorunitario = "";
            var ncm = "";


            var cria = new Classes.CriaArquivo();
            cria.Cria_RelCompras();

            var dr = RelCompra.BuscaBaseCompras();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //if (!dr.IsDBNull(dr.GetOrdinal("CODPRODUTO"))) { Ucodproduto = dr.GetInt32(dr.GetOrdinal("CODPRODUTO")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("NUMERONF"))) { numeronf = dr.GetString(dr.GetOrdinal("NUMERONF")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("DATAEMISSAO"))) { dataemissao = dr.GetDateTime(dr.GetOrdinal("DATAEMISSAO")).ToString(); }
                    if (!dr.IsDBNull(dr.GetOrdinal("EMICNPJ"))) { cnpj = dr.GetString(dr.GetOrdinal("EMICNPJ")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("CHAVE"))) { chave = dr.GetString(dr.GetOrdinal("CHAVE")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NOMEPRODUTO"))) { nomeproduto = dr.GetString(dr.GetOrdinal("NOMEPRODUTO")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("QUANTIDADE"))) { quantidade = dr.GetString(dr.GetOrdinal("QUANTIDADE")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("VALORUNITARIO"))) { valorunitario = dr.GetString(dr.GetOrdinal("VALORUNITARIO")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NCM"))) { ncm = dr.GetString(dr.GetOrdinal("NCM")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("EMINOME"))) { nomeempresa = dr.GetString(dr.GetOrdinal("EMINOME")); }

                    var item = new RelCompra();
                    item.InsertAccess_RelCompra(numeronf, dataemissao, cnpj, nomeempresa, chave, nomeproduto, quantidade, valorunitario, ncm);

                }
            }

            dr.Close();
            dr.Dispose();

            //CHAMA A TELA DE RELATORIO
            bool open = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form is FRelcompra)
                {
                    form.BringToFront();
                    open = true;
                }
            }
            if (!open)
            {
                Form tela = new FRelcompra();
                tela.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Relatorio1();
           
        }

        private void Relatorio1()
        {
            DateTime data;

            var ano = "";
            var numeronf = "";
            var dataemissao = "";
            var cnpj = "";
            var nomeempresa = "";
           
            var nomeproduto = "";
            var quantidade = "";
            var valorunitario = "";

            var dtinicial = txtDataInicial.Text.Trim();
            var dtfinal = txtDataFinal.Text.Trim();
            var emicnpj = txtEmicnpj.Text.Trim();
            var destcnpj = txtDestcnpj.Text.Trim();
            var ncm = txtNcm.Text.Trim();
            var chave = txtChave.Text.Trim();

            if (txtDataInicial.Text.Trim() != "")
            {
                data = Convert.ToDateTime(txtDataInicial.Text.Trim());
            }
            else
            {
                data = DateTime.Now;
            }


            ano = data.ToString("yyyy");


            var cria = new Classes.CriaArquivo();
            cria.Cria_RelCompras();

            var dr = RelCompra.BuscaCompras(ano, dtinicial, dtfinal, emicnpj, destcnpj, chave, ncm);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //if (!dr.IsDBNull(dr.GetOrdinal("CODPRODUTO"))) { Ucodproduto = dr.GetInt32(dr.GetOrdinal("CODPRODUTO")); }

                    if (!dr.IsDBNull(dr.GetOrdinal("NUMERONF"))) { numeronf = dr.GetString(dr.GetOrdinal("NUMERONF")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("DATAEMISSAO"))) { dataemissao = dr.GetDateTime(dr.GetOrdinal("DATAEMISSAO")).ToString(); }
                    if (!dr.IsDBNull(dr.GetOrdinal("EMICNPJ"))) { cnpj = dr.GetString(dr.GetOrdinal("EMICNPJ")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("CHAVE"))) { chave = dr.GetString(dr.GetOrdinal("CHAVE")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NOMEPRODUTO"))) { nomeproduto = dr.GetString(dr.GetOrdinal("NOMEPRODUTO")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("QUANTIDADE"))) { quantidade = dr.GetString(dr.GetOrdinal("QUANTIDADE")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("VALORUNITARIO"))) { valorunitario = dr.GetString(dr.GetOrdinal("VALORUNITARIO")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("NCM"))) { ncm = dr.GetString(dr.GetOrdinal("NCM")); }
                    if (!dr.IsDBNull(dr.GetOrdinal("EMINOME"))) { nomeempresa = dr.GetString(dr.GetOrdinal("EMINOME")); }

                    var item = new RelCompra();
                    item.InsertAccess_RelCompra(numeronf, dataemissao, cnpj, nomeempresa, chave, nomeproduto, quantidade, valorunitario, ncm);

                }
            }

            dr.Close();
            dr.Dispose();

            //CHAMA A TELA DE RELATORIO
            bool open = false;
            foreach (Form form in this.MdiChildren)
            {
                if (form is FRelcompra)
                {
                    form.BringToFront();
                    open = true;
                }
            }
            if (!open)
            {
                Form tela = new FRelcompra();
                tela.ShowDialog();
            }

        }

        private void cmbEmitente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbEmitente.Text != "--SELECIONE--")
            {
                var cnpjemitente = cmbEmitente.Text;
                txtEmicnpj.Text = cnpjemitente.Substring(cnpjemitente.Length - 14, 14);
            }
            else
            {
                txtEmicnpj.Text = "";
            }
        }

        private void cmbDestinatario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDestinatario.Text != "--SELECIONE--")
            {
                var cnpjdestinatario = cmbDestinatario.Text;
                txtDestcnpj.Text = cnpjdestinatario.Substring(cnpjdestinatario.Length - 14, 14);
            }
            else
            {
                txtDestcnpj.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregaCmbEmitente();
            CarregaCmbDestinatario();
        }
    }
}
