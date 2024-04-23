namespace EmployeeApp
{
	public static class Program
	{
		public static string connectionString = "Data Source=DESKTOP-VOPPTIR;Initial Catalog=TestCompanies;User ID=userNick;Password=sa;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{


			ApplicationConfiguration.Initialize();
			Application.Run(new StartForm());
		}
	}
}