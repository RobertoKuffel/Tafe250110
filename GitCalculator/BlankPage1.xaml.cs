using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	public sealed partial class BlankPage1 : Page
	{
		public BlankPage1()
		{
			this.InitializeComponent();
		}

		private void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			bool isValid = double.TryParse(AmountTextBox.Text, out amount);
			if (!isValid || amount < 0)
			{
				ResultLabel.Text = "Please enter a valid positive amount.";
				return;
			}

			string fromCurrency = ((ComboBoxItem)FromCurrencyComboBox.SelectedItem).Content.ToString().Split('-')[0].Trim();
			string toCurrency = ((ComboBoxItem)ToCurrencyComboBox.SelectedItem).Content.ToString().Split('-')[0].Trim();

			double conversionRate = GetConversionRate(fromCurrency, toCurrency);

			double convertedAmount = amount * conversionRate;

			// Update result labels
			DollarResultLabel.Text = $"{amount} {fromCurrency} =";
			ResultLabel.Text = $"{convertedAmount:F8} {toCurrency}";
			DollarToPoundsLabel.Text = $"1 {fromCurrency} = {conversionRate:F8} {toCurrency}";
			PoundsToDollarLabel.Text = $"1 {toCurrency} = {(1 / conversionRate):F5} {fromCurrency}";
		}

		private double GetConversionRate(string fromCurrency, string toCurrency)
		{
			if (fromCurrency == toCurrency)
				return 1.0;

			// USD conversions
			if (fromCurrency == "USD")
			{
				if (toCurrency == "EUR") return 0.85189982;
				if (toCurrency == "GBP") return 0.72872436;
				if (toCurrency == "INR") return 74.257327;
			}

			// EUR conversions
			if (fromCurrency == "EUR")
			{
				if (toCurrency == "USD") return 1.1739732;
				if (toCurrency == "GBP") return 0.8556672;
				if (toCurrency == "INR") return 87.00755;
			}

			// GBP conversions
			if (fromCurrency == "GBP")
			{
				if (toCurrency == "USD") return 1.371907;
				if (toCurrency == "EUR") return 1.1686692;
				if (toCurrency == "INR") return 101.68635;
			}

			// INR conversions
			if (fromCurrency == "INR")
			{
				if (toCurrency == "USD") return 0.0114962628;
				if (toCurrency == "EUR") return 0.013492774;
				if (toCurrency == "GBP") return 0.0098339397;
			}

			// Default fallback
			return 1.0;
		}

		private void ExitButton_Click_1(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}
	}
}
