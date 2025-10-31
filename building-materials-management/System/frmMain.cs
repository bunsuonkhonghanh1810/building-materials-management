using building_materials_management.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace building_materials_management.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.CenterToScreen();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào, {GlobalState.CurrentUserName}";

            menuMasterData.Visible = false;
            menuOperation.Visible = false;
            menuReport.Visible = false;

            if (GlobalState.CurrentUserRole == "admin")
            {
                menuMasterData.Visible = true;
                menuOperation.Visible = true;
                menuReport.Visible = true;
            }
            else if (GlobalState.CurrentUserRole == "quan_ly")
            {
                menuMasterData.Visible = true;
                menuUserManagement.Visible = false;
                menuOperation.Visible = true;
                menuReport.Visible = true;
            }
            else if (GlobalState.CurrentUserRole == "nhan_vien")
            {
                menuMasterData.Visible = true;
                menuUserManagement.Visible = false;
                menuCategoryManagement.Visible = false;
                menuOperation.Visible = true;
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuMaterialManagement_Click(object sender, EventArgs e)
        {
            Form frmMater = new MasterData.frmMaterialManagement();
            frmMater.ShowDialog();
        }
    }
}
