using System;
using System.ServiceModel.Channels;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Calculator
{
	public partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			InitializeComponent();
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Get input values
				double principal = double.Parse(txtPrincipal.Text);
				int years = int.Parse(txtYears.Text);
				int months = int.Parse(txtMonths.Text);
				double yearlyInterest = double.Parse(txtYearlyInterest.Text);

				// Calculate monthly interest rate
				double monthlyInterestRate = yearlyInterest / 12 / 100;
				txtMonthlyInterest.Text = (monthlyInterestRate * 100).ToString("0.0000") + "%";

				// Calculate total months
				int totalMonths = years * 12 + months;

				// Calculate monthly repayment using the formula
				double monthlyRepayment = principal * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths)) /
										  (Math.Pow(1 + monthlyInterestRate, totalMonths) - 1);

				txtMonthlyRepayment.Text = monthlyRepayment.ToString("0.00");
			}
			catch (Exception ex)
			{
				new MessageDialog("Please enter valid numbers for all fields.\nError: " + ex.Message);
			}
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Equals(new MainMenu());
		}
<<<<<<< HEAD

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
        }
    }
=======
	}
>>>>>>> Release
}
