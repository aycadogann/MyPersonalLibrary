using MyPersonalLib.Business.Abstract;
using MyPersonalLib.Business.Concrete;
using MyPersonalLib.DataAccess.Concrete.AdoNet;
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
        IBookService _bookService = new BookManager(new AdoNetBookDal());
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgw_BookList.DataSource = _bookService.GetAll().Select(b=> new {
                b.ID,
                b.BookName,
                b.Author,
                b.Genre,
                b.StartDate,
                b.FinishDate,
                Durum=b.Status==true ? "Okundu" : "Okunmadı",
                b.Rate
            }).ToList();
            Header();
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
    }
}
