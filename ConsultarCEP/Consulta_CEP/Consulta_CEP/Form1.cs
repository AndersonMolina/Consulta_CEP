using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consulta_CEP
{
    public partial class ConsultaCEP : Form
    {
        public ConsultaCEP()
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                Correios.AtendeClienteClient consulta = new
                    Correios.AtendeClienteClient("AtendeClientePort");

                var resultado = consulta.consultaCEP(txtCEP.Text);

                if(resultado!= null)
                {
                    txtEndereco.Text = resultado.end;
                    txtComplemento.Text = resultado.complemento;
                    txtBairro.Text = resultado.bairro;
                    txtCidade.Text = resultado.cidade;
                    txtCEPOK.Text = txtCEP.Text;
                    txtUF.Text = resultado.uf;
                    lblInformacoes.Text = "Consulta realizada com sucesso!";
                }
                txtCEP.Clear();
            }
            catch (FaultException)
            {
                MessageBox.Show("CEP não encontrado ou inválido.","Aviso", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtCEP.Clear();
                txtCEP.Focus();
            }
            catch(EndpointNotFoundException)
            {
                MessageBox.Show("Não foi possível completar a operação.\nVerifique a sua conexão!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCEP.Clear();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEndereco.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtCEPOK.Clear();
            txtUF.Clear();
            lblInformacoes.Text = "Digite o CEP";
        }
    }
}
