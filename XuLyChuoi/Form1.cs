using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuLyChuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSoKyTu_Click(object sender, EventArgs e)
        {
            txtKQ.Text= txtGoc.Text.Length.ToString();
        }

        private void btnInHoa_Click(object sender, EventArgs e)
        {
            txtKQ.Text = txtGoc.Text.ToUpper();
        }

        private void btnInThuong_Click(object sender, EventArgs e)
        {
            txtKQ.Text = txtGoc.Text.ToLower();
        }

        private void btnDemHoa_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text;
            int count = 0;
            foreach(char c in s)
            {
                if(char.IsUpper(c)) count++;
            }
            txtKQ.Text = count.ToString();
        }

        private void btnDemThuong_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text;
            int count = 0;
            foreach (char c in s)
            {
                if (char.IsLower(c)) count++;
            }
            txtKQ.Text = count.ToString();

        }

        private void btnDemSo_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text;
            int count = 0;
            foreach (char c in s)
            {
                if (char.IsDigit(c)) count++;
            }
            txtKQ.Text = count.ToString();
        }

        private void btnDaoChuoi_Click(object sender, EventArgs e)
        {
            string str = txtGoc.Text;
            
            txtKQ.Text = new string(str.Reverse().ToArray());
        }

        private void btnToiUu_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text.Trim();
            string normalizedSpaces = Regex.Replace(s, @"\s+", " ");
            string capitalized = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(normalizedSpaces);
            txtKQ.Text = capitalized;



        }

        private void btnTimDau_Click(object sender, EventArgs e)
        {
            int vt = txtGoc.Text.IndexOf(txtDau.Text);
            if(vt != -1)
            {
                txtKQ.Text = vt.ToString();
            }
            else
            {
                txtKQ.Text = "Không tìm thấy";
            }
            
        }

        private void btnTimCuoi_Click(object sender, EventArgs e)
        {
            int last = txtGoc.Text.LastIndexOf(txtCuoi.Text);
            if (last != -1)
            {
                txtKQ.Text = last.ToString();
            }
            else
            {
                txtKQ.Text = "Không tìm thấy";
            }

        }

        private void btnDemLanXuatHien_Click(object sender, EventArgs e)
        {

            int count = 0;
            string s = txtGoc.Text;
            int vt = s.IndexOf(txtLan.Text);
            if(vt == -1)
            {
                txtKQ.Text = "Không có";
            }
            else
            {
                while(vt != -1)
                {
                    count++;
                    s = s.Substring(vt + txtLan.Text.Length);
                    vt = s.IndexOf(txtLan.Text);
                }
                txtKQ.Text = count.ToString();
            }



            
        }

        private void btnTach_Click(object sender, EventArgs e)
        {
            if(txtTach.Text == " ")
            {
                string[] arr = txtGoc.Text.Split(' ');
                txtKQ.Text = "";
                foreach(string s in arr)
                {
                    txtKQ.Text += s + "\r\n";
                }
            }
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            txtKQ.Text = txtGoc.Text.Replace(txtChangeOld.Text, txtChangNew.Text);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            int vt = txtGoc.Text.IndexOf(txtXoa.Text);
            if( vt != -1) {
                string s = txtGoc.Text;
                s = s.Remove(vt,txtXoa.Text.Length);
                


                string s1 = s.Trim();
                string normalizedSpaces = Regex.Replace(s1, @"\s+", " ");
                string capitalized = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(normalizedSpaces);
                txtKQ.Text = capitalized;
            }
            else
            {
                txtKQ.Text = "Không tìm thấy";
            }

            
        }

        private void btnChen_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text;
            string s2 = s.Insert(int.Parse(txtViTriChen.Text),txtChen.Text);
           

            txtKQ.Text = s2;

        }

        private void btnTrichLoc_Click(object sender, EventArgs e)
        {
            string s = txtGoc.Text;
            if (!int.TryParse(txtVT1.Text, out int startIndex) || !int.TryParse(txtVT2.Text, out int length))
            {
                MessageBox.Show("Vị trí bắt đầu và độ dài phải là số nguyên.");
                return;
            }

            // Kiểm tra vị trí bắt đầu và độ dài có hợp lệ không
            if (startIndex < 0 || startIndex >= s.Length || length <= 0 || startIndex + length > s.Length)
            {
                MessageBox.Show("Vị trí bắt đầu hoặc độ dài không hợp lệ.");
                return;
            }

            string substring = s.Substring(startIndex, length);
            txtKQ.Text = substring;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn thoát à","Hỏi thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            e.Cancel = (ret == DialogResult.No);
        }
    }
}
