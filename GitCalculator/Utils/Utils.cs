using System;
using System.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Calculator.Utils
{
	public static class Utils
	{
		// Control the expression execution
		private static double executeExpression(string text)
		{
			string number = new DataTable().Compute(text, "").ToString();
			double numberDouble = Convert.ToDouble(number);

			return numberDouble;
		}

		// check if is a number
		private static bool isNumeric(char character)
		{
			return int.TryParse(character.ToString(), out _);
		}

		// control click
		public static void handleClick(string numberdouble)
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;
			TextBlock errorDisplay = MainPage.mainPage.errorDisplay;

			// the number cannot have more than 6 digits
			if (primaryDisplay.Text.Length < 6)
			{
				if (!(primaryDisplay.Text.Length == 0 && numberdouble == "0"))
				{
					if (secondaryDisplay.Text.Length + primaryDisplay.Text.Length <= 50)
					{
						primaryDisplay.Text += numberdouble;
					}
					else
					{
						errorDisplay.Text = "The exp. can have until 50 digits";
						FlyoutBase.ShowAttachedFlyout(primaryDisplay);
					}
				}
			}
			else
			{
				errorDisplay.Text = "The number can have until 6 digits";
				FlyoutBase.ShowAttachedFlyout(primaryDisplay);
			}
		}

		// control operation click
		public static void handleOperationClick(string operation)
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;

			if (primaryDisplay.Text.Length + secondaryDisplay.Text.Length < 50)
			{
				if (secondaryDisplay.Text.Length != 0)
				{
					if (!isNumeric(secondaryDisplay.Text[secondaryDisplay.Text.Length - 1]) && primaryDisplay.Text.Length == 0)
						secondaryDisplay.Text = secondaryDisplay.Text.Substring(0, secondaryDisplay.Text.Length - 1) + operation;
					else
						secondaryDisplay.Text += primaryDisplay.Text + operation;
				}
				else if (primaryDisplay.Text.Length != 0)
				{
					secondaryDisplay.Text += primaryDisplay.Text + operation;
				}

				primaryDisplay.Text = "";
			}
		}

		// Control to clean displays
		public static void handleClearButtonClick()
		{
			MainPage.mainPage.primaryDisplay.Text = "";
			MainPage.mainPage.secondaryDisplay.Text = "";
		}

		// Control equal button
		public static void handleEqualButtonClick()
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;
			TextBlock errorDisplay = MainPage.mainPage.errorDisplay;

			try
			{
				primaryDisplay.Text = executeExpression(secondaryDisplay.Text + primaryDisplay.Text).ToString();  //

				if (primaryDisplay.Text.Length > 6)
					primaryDisplay.FontSize = 48;
				secondaryDisplay.Text = "";
			}
			catch
			{
				errorDisplay.Text = "There's an error in the exp.";
				FlyoutBase.ShowAttachedFlyout(primaryDisplay);
			}
		}

		// Control backspace
		public static void handleBackspace()
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;

			if (primaryDisplay.Text.Length > 0)
				primaryDisplay.Text = primaryDisplay.Text.Substring(0, primaryDisplay.Text.Length - 1);
		}
	}
}