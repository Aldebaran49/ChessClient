namespace ChessClient
{
    static class FForms
    {
        public static Form1 F1 = new Form1();
        public static Form2 F2 = new Form2();
        public static Form3 F3 = new Form3();
    }
    static class globalVar
    {
        static public serverConnector conn = new serverConnector();
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(FForms.F1);
        }
    }
    
}