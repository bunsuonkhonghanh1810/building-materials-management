using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using building_materials_management.Login;
using building_materials_management.Classes;

namespace building_materials_management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                await SupabaseService.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối Supabase: {ex.Message}", "Lỗi kết nối");
                return;
            }

            Application.Run(new frmLogin());
        }
    }
}
