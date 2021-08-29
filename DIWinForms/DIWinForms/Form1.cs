using DIWinForms.Config;
using DIWinForms.Dto;
using DIWinForms.Helpers;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var users = _userService.GetAll();

            bindingSourceUserDto.DataSource = users;
            bindingSourceUserDto.ResetBindings(false);
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            bindingSourceUserDto.DataSource = _userService.GetAll();
            textBoxId.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int.TryParse(textBoxId.Text, out int UserId);
            var userDto = new UserDto
            {
                Id = UserId,
                Name = textBoxName.Text,
                Phone = textBoxPhone.Text
            };
            _userService.CreateOrUpdate(userDto);
            RefreshList();
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var userSelected = dataGridViewUser.GetSelectedItem<UserDto>();
            if (userSelected != null)
            {
                textBoxId.Text = userSelected.Id.ToString();
                textBoxName.Text = userSelected.Name;
                textBoxPhone.Text = userSelected.Phone;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var userSelected = dataGridViewUser.GetSelectedItem<UserDto>();
            if (userSelected != null)
            {
                _userService.Delete(userSelected.Id);
                RefreshList();
            }
        }
    }
}
