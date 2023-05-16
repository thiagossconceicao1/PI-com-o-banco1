using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoPI
{
    public partial class frmPesquisaFunc : Form
    {
        public frmPesquisaFunc()
        {
            InitializeComponent();
            txtDescricao.Enabled = false;
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
        }
        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }
        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                ltbItensPesquisados.Items.Clear();
                ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaCodFunc(txtDescricao.Text);
                MessageBox.Show("por favor selecione o codigo para pesquisar o funcionario", "Aviso do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                //Limpando a text
                txtDescricao.Text = "";
                

            }
            else if (rdbNome.Checked)
            {
                ltbItensPesquisados.Items.Clear();
                ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaNome(txtDescricao.Text);
                MessageBox.Show("por favor selecione o nome para pesquisar o funcionario", "Aviso do sistema",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                //Limpando a text
                txtDescricao.Text = "";
            }
            MessageBox.Show("Por favor selecione codigo ou nome para pesquisar o funcionario no sistema");   
            }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Enabled = false;
            rdbNome.Checked = false;
            rdbCodigo.Checked = false;
            txtDescricao.Clear();
            ltbItensPesquisados.Items.Clear();
        }
        public void pesquisaCodFunc(string codigo)
        {
            bool validaCodigo = acessaBancoCod(codigo);
            if (validaCodigo)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbFuncionarios where codFunc = " + codigo + ";";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados.Items.Clear();

                while (DR.Read())
                {
                    ltbItensPesquisados.Items.Add(DR.GetString(1));
                }
            }
            else
            {
                acessaBancoCod(txtDescricao.Text);
                MessageBox.Show("O funcionario não existe no Banco!!!",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

                Conexao.fecharConexao();

        }
        public bool acessaBanco(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbfuncionarios where nome like '%" + nome + "%';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            bool resposta = DR.HasRows;

            Conexao.fecharConexao();

            return resposta;
        }
        public bool acessaBancoCod(string codfunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbfuncionarios where codfunc = '" + codfunc + "';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            bool resposta = DR.HasRows;

            Conexao.fecharConexao();

            return resposta;
        }
        public void pesquisaNome(string nome)
        {
            bool validaNome = acessaBanco(nome);
            if (validaNome)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select * from tbFuncionarios where nome like '%" + nome + "%';";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.obterConexao();

                MySqlDataReader DR;

                DR = comm.ExecuteReader();

                ltbItensPesquisados.Items.Clear();

                while (DR.Read())
                {
                    ltbItensPesquisados.Items.Add(DR.GetString(1));
                }
            }
            else
            {
                acessaBanco(txtDescricao.Text);
                MessageBox.Show("O funcionario não existe no Banco!!!",
                    "Aviso do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            Conexao.fecharConexao();
        }
        private void ltbItensPesquisados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ltbItensPesquisados.SelectedItem.ToString();
            //MessageBox.Show("Resultado: " + valor);
            frmfuncionarios abrir = new frmfuncionarios (valor);
            abrir.Show();
            this.Hide();
        }
        private void btnPesquisaFunc_Click(object sender, EventArgs e)
        {

            frmCarregaDataGridDB abrir = new frmCarregaDataGridDB();
            abrir.Show();
            this.Hide();
        }
        private void frmPesquisaFunc_Load(object sender, EventArgs e)
        {

        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmfuncionarios abrir = new frmfuncionarios();
            abrir.Show();
            this.Hide();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

            acessaBancoCod(txtDescricao.Text);
            MessageBox.Show("O codigo não existe no Banco!!!",
                "Aviso do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
        }
    }
}
