namespace PerfectPay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		bill = decimal.Parse(txtbill.ToString());
		CalculateTotal();
	}

	private void CalculateTotal()
	{
		var totalTip = (bill * tip) / 100;

		var tipByPerson = (totalTip/ noPersons);
		lbltip.Text = $"{tipByPerson:C}";

		var subtotal = (bill / noPersons);
		lblsub.Text = $"{subtotal:C}";

		var totalByperson = (bill + totalTip) / noPersons;
		lblTotal.Text = $"{totalByperson:C}";
	}

	private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if(sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			sldTip.Value = percentage;
		}
	}

	private void btnMinus_Clicked(object sender, EventArgs e)
	{
		if(noPersons > 1)
		{
			noPersons--;
		}
		lblNoPersons.Text = noPersons.ToString();
		CalculateTotal();
	}

	private void btnPlus_Clicked(object sender, EventArgs e)
	{
		noPersons++;
		lblNoPersons.Text = noPersons.ToString();
		CalculateTotal();
	}

	private  void txtbill_TextChanged(object sender, TextChangedEventArgs e)
	{
		try
		{
			bill = decimal.Parse(txtbill.Text);
			CalculateTotal();
		}
		catch(Exception ex)
		{
			
		}
    }
}

