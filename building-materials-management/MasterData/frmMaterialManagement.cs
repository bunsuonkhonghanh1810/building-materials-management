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

namespace building_materials_management.MasterData
{
    public partial class frmMaterialManagement : Form
    {
        public frmMaterialManagement()
        {
            InitializeComponent();
        }

        private void frmMaterialManagement_Load(object sender, EventArgs e)
        {

        }
        private void OInit()
        {
            var client = SupabaseService.Client;
            var materials = client.From<Material>().Get().Result.Models;
        }
    }
}
