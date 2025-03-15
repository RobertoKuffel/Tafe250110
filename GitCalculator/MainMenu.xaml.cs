using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace Calculator
{
	public partial class MainMenu : Page
	{
		public static MainMenu mainMenu { get; set; }

		public MainMenu()
		{
			InitializeComponent();
			mainMenu = this;
		}


		private void MathCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void MortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
		
		}

		private void CurrencyConverterButton_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}