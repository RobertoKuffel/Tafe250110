using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using System.Windows;
using System;

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
			MainFrame.Navigate(typeof(MainPage));
		}

		private void MortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(typeof(MortgageCalculator));
		}

		private void CurrencyConverterButton_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(typeof(BlankPage1));
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}