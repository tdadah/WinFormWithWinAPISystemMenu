using System.ComponentModel;
using System.Windows.Forms;

using WinFormWithWinAPISystemMenu.Models;

namespace WinFormWithWinAPISystemMenu
{
	public partial class FormCodingAssessment: Form
	{
		#region Constructor

		public FormCodingAssessment()
		{
			InitializeComponent();

			SystemMenuItem = new SystemMenuItem();
			SystemMenuItem.AddSystemMenuItem( Handle, ApplicationType.LocalApplication );

			InitializeAndRunFindCalculatorBackgroundWorker();
		}

		#endregion Constructor

		#region Private methods

		private void FindCalculatorBackgroundWorker_DoWork( object sender, DoWorkEventArgs args )
		{
			// Continuously check to see if the calculator is open.
			while( true )
			{
				SystemMenuItem.CheckForCalculatorAndAddMenuItem();

				System.Threading.Thread.Sleep( 500 );
			}
		}

		private void InitializeAndRunFindCalculatorBackgroundWorker()
		{
			FindCalculatorBackgroundWorker.WorkerSupportsCancellation = true;
			FindCalculatorBackgroundWorker.DoWork += new DoWorkEventHandler( FindCalculatorBackgroundWorker_DoWork );

			FindCalculatorBackgroundWorker.RunWorkerAsync();
		}

		private SystemMenuItem SystemMenuItem;

		#endregion Private methods

		#region Protected methods

		protected override void OnClosing( CancelEventArgs e )
		{
			FindCalculatorBackgroundWorker.CancelAsync();

			SystemMenuItem.RemoveCalculatorMenuItem();

			base.OnClosing( e );
		}

		protected override void WndProc( ref Message message )
		{
			// Check if a System Command has been executed and if parameter is our menu item
			if( message.Msg == WindowsApi.WM_SYSCOMMAND && message.WParam.ToInt32() == WindowsApi.LOCAL_MENU_ITEM_ID )
			{
				// Execute the appropriate code for the System Menu item that was clicked
				MessageBox.Show( "Hello world!" );
			}

			base.WndProc( ref message );
		}

		#endregion Protected methods
	}
}
