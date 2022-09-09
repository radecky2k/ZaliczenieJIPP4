using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZaliczenieJIPP4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                if(textBox1.Text.Length > 0)
                {
                    if (listBox1.Items.Contains(textBox1.Text))
                    {
                       DialogResult result = MessageBox.Show("Element już istnieje. Czy NA PEWNO chcesz go dodać?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(result == DialogResult.No)
                        {
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text);
                    AktualizujProgres();
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Wartość jest pusta!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista jest już pełna! Aby rozszerzyć listę do 10 pozycji zakup pełną wersję :)","Błąd!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AktualizujProgres()
        {
            int i = listBox1.Items.Count;
            progressBar1.Value = i * 20;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AktualizujProgres();
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if(i != -1)
            {
                listBox1.Items.RemoveAt(i);
                AktualizujProgres();
            }
            else
            {
                MessageBox.Show("Nie mam co usunąć :(", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
