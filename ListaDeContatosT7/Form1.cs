using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace ListaDeContatosT7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private contato[] contatos = new contato[0];

        private void Escrever(contato contato)
        {
            StreamWriter escreverEmArquivos = new StreamWriter("Contatos.txt");
            escreverEmArquivos.WriteLine(contatos.Length + 1);
            escreverEmArquivos.WriteLine(contato.Nome);
            escreverEmArquivos.WriteLine(contato.Sobrenome);
            escreverEmArquivos.WriteLine(contato.Telefone);

            for (int i = 0; i < contatos.Length; i++) 
            {
                escreverEmArquivos.WriteLine(contatos[i].Nome);
                escreverEmArquivos.WriteLine(contatos[i].Sobrenome);
                escreverEmArquivos.WriteLine(contatos[i].Telefone);
            }

            escreverEmArquivos.Close();
        }

        private void Ler()
        {
            StreamReader lerArquivo = new StreamReader("Contatos.txt");
            contatos = new contato[Convert.ToInt32(lerArquivo.ReadLine())];

            for (int i = 0; i < contatos.Length; i++)
            {
                contatos[i] = new contato();
                contatos[i].Nome = lerArquivo.ReadLine();
                contatos[i].Sobrenome = lerArquivo.ReadLine();
                contatos[i].Telefone = lerArquivo.ReadLine();
            }

            lerArquivo.Close();
        }

        private void Exibir()
        {
            listBoxContatos.Items.Clear();

            for (int i = 0; i < contatos.Length; i++)
            {
                listBoxContatos.Items.Add(contatos[i].ToString());
            }
        }

        private void LimparFormulario()
        {
            textBoxNome.Text = String.Empty;
            textBoxSobrenome.Text = String.Empty;
            textBoxTelefone.Text = String.Empty;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonIncluirContato_Click(object sender, EventArgs e)
        {
            contato contato = new contato();
            contato.Nome = textBoxNome.Text;
            contato.Sobrenome = textBoxSobrenome.Text;
            contato.Telefone = textBoxTelefone.Text;

            //listBoxContatos.Items.Add(contato.ToString());

            Escrever(contato);
            Organizar();
            Ler();
            Exibir();
            LimparFormulario();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ler();
            Exibir();  
        }

        private void Organizar()
        {
            contato temporario;
            bool troca = true;

            do
            {
                troca = false;

                for (int i = 0; i < contatos.Length - 1; i++)
                {
                    if (contatos[i].Nome.CompareTo(contatos[i + 1].Nome) > 0)
                    {
                        temporario = contatos[i];
                        contatos[i] = contatos[i + 1];
                        contatos[i + 1] = temporario;
                        troca = true;
                    }
                }

            } while (troca == true); 
        }

        private void buttonOrganizar_Click(object sender, EventArgs e)
        {
            Organizar();
            Exibir();
        }
    }
}
