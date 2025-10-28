using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_materials_management.Classes
{
    public static class SupabaseService
    {
        private static readonly string SupabaseUrl = "https://tsgmsztliyadcjzvopay.supabase.co";
        private static readonly string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRzZ21zenRsaXlhZGNqenZvcGF5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjE2NDExNjAsImV4cCI6MjA3NzIxNzE2MH0.pBY3SZ5FV-APitGMYsp35rP5w91VoFIL_JXXC_upick";

        public static Supabase.Client Client { get; private set; }

        public static async Task InitializeAsync()
        {
            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true
            };

            Client = new Supabase.Client(SupabaseUrl, SupabaseKey, options);
            await Client.InitializeAsync();
        }
    }
}
