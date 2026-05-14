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
            dgw_BookList.DataSource = _bookService.GetAll();
        }
    }
}
