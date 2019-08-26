using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iniciacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //EVENTOS PRINCIPAIS
        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty || cbbFilhos.Text == String.Empty || cbbEstadoCivil.Text == String.Empty ||
               txtIdade.Text == String.Empty || cbbSexo.Text == String.Empty ||
               txtCelular.Text == String.Empty || txtTelefone.Text == String.Empty ||
               txtNacionalidade.Text == String.Empty || txtEmail.Text == String.Empty || cbbEscolaridade.Text == String.Empty ||
               txtInstituicaoEscola.Text == String.Empty || txtAnoEscola.Text == String.Empty ||
               cbbHorarioEscola.Text == String.Empty || txtCursos.Text == String.Empty || txtObjetivo.Text == String.Empty ||
               txtExperiencia.Text == String.Empty || txtRua.Text == String.Empty || txtNumeroRua.Text == String.Empty ||
               txtBairro.Text == String.Empty || txtCidade.Text == String.Empty || cbbEstado.Text == String.Empty ||
               txtCep.Text == String.Empty)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Atenção!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else {geradorPDF();}   
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }

        //MÉTODOS
        private void geradorPDF()
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textformatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);

                var font = new PdfSharp.Drawing.XFont("Arial", 14);
                var font2 = new PdfSharp.Drawing.XFont("Arial", 22);
                //NEGRITO FONTE
                var font3 = new PdfSharp.Drawing.XFont("Arial", 14, PdfSharp.Drawing.XFontStyle.Bold);
                var font4 = new PdfSharp.Drawing.XFont("Arial", 22, PdfSharp.Drawing.XFontStyle.Bold);

                //NOME
                textformatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                textformatter.DrawString(txtNome.Text, font4, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 40, page.Width, page.Height));
                //ENDEREÇO    
                textformatter.DrawString("Rua " + txtRua.Text + ", " + txtNumeroRua.Text + " - " +
                    txtBairro.Text + " - " +
                    txtCidade.Text + " - " + cbbEstado.Text + " - CEP: " + txtCep.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 80, page.Width, page.Height));
                //CONTATOS               
                textformatter.DrawString("Telefone: " + txtTelefone.Text + " Celular: " + txtCelular.Text,
                     font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 110, page.Width, page.Height));

                textformatter.DrawString("E-mail: " + txtEmail.Text, font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 140, page.Width, page.Height));
                //ESTADO CIVIL E IDADE               
                textformatter.DrawString("Idade: " + txtIdade.Text + " - Estado Civil: " + cbbEstadoCivil.Text
                    + " - Sexo: " + cbbSexo.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 170, page.Width, page.Height));
                //GENERO, FILHOS E NACIONALIDADE                
                textformatter.DrawString("Filhos: " +
                    cbbFilhos.Text + " - Nacionalidade: " + txtNacionalidade.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 200, page.Width, page.Height));
                //OBJETIVO                
                textformatter.DrawString("Objetivo: " + txtObjetivo.Text, font3, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 225, page.Width, page.Height));
                //FORMAÇÃO ACADÊMICA                
                textformatter.DrawString("Formação Acadêmica", font4, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 330, page.Width, page.Height));
                //ESCOLARIDADE               
                textformatter.DrawString("Escolaridade: " + cbbEscolaridade.Text + " - " + txtInstituicaoEscola.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 365, page.Width, page.Height));

                textformatter.DrawString("Horário: " + cbbHorarioEscola.Text +
                    " - Ano de Término (Previsão de Término): " + txtAnoEscola.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 380, page.Width, page.Height));

                textformatter.DrawString(txtCursos.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 405, page.Width, page.Height));
                //EXPERIÊNCIA profissional                
                textformatter.DrawString("Experiência Profissional", font4, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 500, page.Width, page.Height));

                textformatter.DrawString(txtExperiencia.Text,
                    font, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(0, 525, page.Width, page.Height));
                try
                {
                    doc.Save("arquivo.pdf");
                    System.Diagnostics.Process.Start("arquivo.pdf");
                    
                    
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Erro: " + Erro,
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void LimpaTela()
        {
            txtNome.Text = "";
            cbbFilhos.SelectedIndex = -1;
            cbbEstadoCivil.SelectedIndex = -1;
            txtIdade.Text = "";
            cbbSexo.SelectedIndex = -1;
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtNacionalidade.Text = "";
            txtEmail.Text = "";
            cbbEscolaridade.SelectedIndex = -1;
            txtInstituicaoEscola.Text = "";
            txtAnoEscola.Text = "";
            cbbHorarioEscola.SelectedIndex = -1;
            txtCursos.Text = "";
            txtObjetivo.Text = "";
            txtExperiencia.Text = "";
            txtRua.Text = "";
            txtNumeroRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbbEstado.SelectedIndex = -1;
            txtCep.Text = "";
        }

        //EVENTOS SECUNDÁRIOS
        private void txtAnoEscola_Click_1(object sender, EventArgs e)
        {
            txtAnoEscola.SelectionStart = 0;
        }

        private void txtIdade_Click(object sender, EventArgs e)
        {
            txtIdade.SelectionStart = 0;
        }

        private void txtCelular_Click(object sender, EventArgs e)
        {
            txtCelular.SelectionStart = 0;
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            txtTelefone.SelectionStart = 0;
        }

        private void txtNumeroRua_Click(object sender, EventArgs e)
        {
            txtNumeroRua.SelectionStart = 0;
        }

        private void txtCep_Click(object sender, EventArgs e)
        {
            txtCep.SelectionStart = 0;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtNacionalidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtInstituicaoEscola_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
               !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    return;
                default:
                    break;
            }
        }

        private void txtTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    return;
                default:
                    break;
            }
        }

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    return;
                default:
                    break;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtNumeroRua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    return;
                default:
                    break;
            }
        }
    }
}
