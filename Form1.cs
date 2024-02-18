using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaCEP
{
    public partial class LocalizarCEP : Form
    {
        public LocalizarCEP()
        {
            InitializeComponent();
            lblRua.Text = string.Empty;
            lblBairro.Text = string.Empty;
            lblCidade.Text = string.Empty;
            lblEstado.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            var CepCorreto = ValidarCEP.Validar(txtCEP.Text);
            if (CepCorreto)
            {
                var CEP = txtCEP.Text;
                var strURL = "https://brasilapi.com.br/api/cep/v1/" + CEP;
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var response = client.GetAsync(strURL).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            CEP cep = JsonConvert.DeserializeObject<CEP>(result);
                            lblRua.Text = string.Format(cep.Street);
                            lblBairro.Text = string.Format(cep.Neighborhood);
                            lblCidade.Text = string.Format(cep.City);
                            lblEstado.Text = string.Format(cep.State);
                        }
                        else
                        {
                            lblRua.Text = string.Empty;
                            lblBairro.Text = string.Empty;
                            lblCidade.Text = string.Empty;
                            lblEstado.Text = string.Empty;
                        }
                    }
                    catch(Exception ex)
                    {
                        lblRua.Text = string.Empty;
                        lblBairro.Text = string.Empty;
                        lblCidade.Text = string.Empty;
                        lblEstado.Text = string.Empty;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("CEP inválido, digite novamente");
                txtCEP.Text = string.Empty;
            }
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
