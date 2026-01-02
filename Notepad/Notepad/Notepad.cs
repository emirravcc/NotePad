using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        private string mevcutDosyaYolu = string.Empty;

        public Notepad()
        {
            InitializeComponent();
            this.Text = "Notepad";
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txticerik.Clear();
            mevcutDosyaYolu = string.Empty;
            this.Text = "Notepad";
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            ofd.Title = "Dosya Aç";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txticerik.Text = DosyaIsleyici.DosyaOku(ofd.FileName);
                    mevcutDosyaYolu = ofd.FileName;
                    this.Text = Path.GetFileName(mevcutDosyaYolu) + " - Notepad";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool DosyayiKaydet(bool farkliKaydet)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Metin Dosyaları (*.txt)|*.txt";
            sfd.Title = "Dosya Kaydet";

            if (farkliKaydet || string.IsNullOrEmpty(mevcutDosyaYolu))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    mevcutDosyaYolu = sfd.FileName;
                }
                else
                {
                    return false;
                }
            }

            try
            {
                DosyaIsleyici.DosyaYaz(mevcutDosyaYolu, txticerik.Text);
                this.Text = Path.GetFileName(mevcutDosyaYolu) + " - Notepad";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyayiKaydet(false);
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyayiKaydet(true);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}