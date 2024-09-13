using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDatabaseOOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KitapVT vtsinif = new KitapVT();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vtsinif.Liste();
        }

        private void buttonKAYDET_Click(object sender, EventArgs e)
        {
            Kitap ktpsinif = new Kitap
            {
                KITAPAD = textBoxKITAPAD.Text,
                YAZAR = textBoxYAZAR.Text
            };

            try
            {
                vtsinif.KitapEkle(ktpsinif);
                MessageBox.Show("Kitap başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
