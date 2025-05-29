using Practica.Model;

namespace Practica
{
    internal static class Program
    {
        public static User CurrentUser { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = "Data Source=WIN-QHARUPHBGU0\\SQLEXPRESS;Initial Catalog=Cofetarie;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (Login loginForm = new Login(connectionString))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1()); 
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}