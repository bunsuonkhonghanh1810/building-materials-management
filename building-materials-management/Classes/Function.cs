using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace building_materials_management.Classes
{
    internal class Function
    {
        public void FillCombox(ComboBox cb, object dt, string display, string value)
        {
            cb.DataSource = dt;
            cb.DisplayMember = display;
            cb.ValueMember = value;
            cb.SelectedIndex = -1;
        }
    }
}
