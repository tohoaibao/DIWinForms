using DIWinForms.Config;
using DIWinForms.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIWinForms
{
    public partial class Form1 : Form
    {
        private static readonly ILogger _logger = Log.ForContext<Form1>();
        private IUserService _userService;

        public Form1(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var lst = _userService.GetAll();
            _logger.Information("Form1 => button click");
            //var frm2 = IoC.GetForm<Form2>();
            //frm2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var users = _userService.GetAll();

            bindingSourceUserDto.DataSource = users;
            bindingSourceUserDto.ResetBindings(false);
        }
    }
}
