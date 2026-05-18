using MyPersonalLib.Business.Abstract;
using MyPersonalLib.Business.Concrete;
using MyPersonalLib.DataAccess.Concrete.AdoNet;
using MyPersonalLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPersonalLib.UI
{
    public partial class Form1 : Form
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
       
        public Form1(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List();
            LoadCombobox();
            Header();
        }

        private void List()
        {
            dgw_BookList.DataSource = _bookService.GetAll().Select(b => new
            {
                b.ID,
                b.BookName,
                b.Author,
                Tür = _genreService.GetAll().FirstOrDefault(g => b.GenreID == g.ID).BookGenre,
                b.StartDate,
                b.FinishDate,
                Durum = b.Status == true ? "Okundu" : "Okunmadı",
                b.Rate
            }).ToList();
        }
        private void Header()
        {
            dgw_BookList.Columns[0].HeaderText = "ID";
            dgw_BookList.Columns[1].HeaderText = "Kitap";
            dgw_BookList.Columns[2].HeaderText = "Yazar";
            dgw_BookList.Columns[3].HeaderText = "Tür";
            dgw_BookList.Columns[4].HeaderText = "Başlama Tarihi";
            dgw_BookList.Columns[5].HeaderText = "Bitirme Tarihi";
            dgw_BookList.Columns[6].HeaderText = "Durum";
            dgw_BookList.Columns[7].HeaderText = "Puan";
        }
        private void LoadCombobox()
        {
            cmb_Genre.DataSource = _genreService.GetAll();
            cmb_Genre.DisplayMember = "BookGenre";
            cmb_Genre.ValueMember = "ID";
        }
        private void Clear()
        {
            txt_ID.Clear();
            txt_BookName.Clear();
            txt_Author.Clear();
            cmb_Genre.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            chk_IsRead.Checked = false;
            num_Rate.Value = 0;

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.BookName = txt_BookName.Text;
            book.Author = txt_Author.Text;

            if (cmb_Genre.SelectedValue != null)
                book.GenreID = Convert.ToInt32(cmb_Genre.SelectedValue);

            book.Status = chk_IsRead.Checked;

            if (chk_IsRead.Checked == true)
            {
                if (dateTimePicker1.Checked)
                {
                    book.StartDate = dateTimePicker1.Value;
                }
                else
                {
                    book.StartDate = (DateTime?)null;
                }

                if (dateTimePicker2.Checked)
                {
                    book.FinishDate = dateTimePicker2.Value;
                }
                else
                {
                    book.FinishDate = (DateTime?)null;
                }
            }

            book.Rate = Convert.ToByte(num_Rate.Value);

            _bookService.Add(book);

            MessageBox.Show("Kitap başarıyla eklendi");
            List();
            Clear();
        }
        private void dgw_BookList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_ID.Text = dgw_BookList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_BookName.Text = dgw_BookList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_Author.Text = dgw_BookList.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmb_Genre.SelectedIndex = cmb_Genre.FindStringExact(dgw_BookList.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (dgw_BookList.Rows[e.RowIndex].Cells[4].Value == DBNull.Value || dgw_BookList.Rows[e.RowIndex].Cells[4].Value == null)
                    dateTimePicker1.Value = DateTime.Now;
                else
                    dateTimePicker1.Value = Convert.ToDateTime(dgw_BookList.Rows[e.RowIndex].Cells[4].Value);
                if (dgw_BookList.Rows[e.RowIndex].Cells[5].Value == DBNull.Value || dgw_BookList.Rows[e.RowIndex].Cells[5].Value == null)
                    dateTimePicker2.Value = DateTime.Now;
                else
                    dateTimePicker2.Value = Convert.ToDateTime(dgw_BookList.Rows[e.RowIndex].Cells[5].Value);
            }
            else
            {
                return;
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.ID = Convert.ToInt32(txt_ID.Text);
            book.BookName = txt_BookName.Text;
            book.Author = txt_Author.Text;
            book.GenreID = Convert.ToInt32(cmb_Genre.SelectedValue);
            book.StartDate = dateTimePicker1.Value;
            book.FinishDate = dateTimePicker2.Value;
            book.Status = chk_IsRead.Checked;
            book.Rate = Convert.ToByte(num_Rate.Value);

            _bookService.Update(book);
            MessageBox.Show("Güncelleme başarıyla tamamlandı");
            List();
            Clear();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string text = txt_BookName.Text + " adlı kitabı silmek istediğinize emin misiniz?";
            DialogResult dr = MessageBox.Show(text, "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                _bookService.Delete(Convert.ToInt32(txt_ID.Text));
            }
            else
            {
                return;
            }
            List();
            Clear();
        }

        private void chk_IsRead_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsRead.Checked)
            {
                lbl_StartDate.Visible = true;
                dateTimePicker1.Visible = true;

                lbl_FinishDate.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                lbl_StartDate.Visible = false;
                dateTimePicker1.Visible = false;

                lbl_FinishDate.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }
    }
}
