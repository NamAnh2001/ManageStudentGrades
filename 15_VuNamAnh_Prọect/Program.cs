namespace Project_PRN211_SE1729
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
        public static class ControlID
        {
            public static int? accountID { get; set; }
            public static string fullName { get; set; }
        }
    }
}