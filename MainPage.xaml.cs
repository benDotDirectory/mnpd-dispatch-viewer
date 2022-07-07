using mnpd_dispatch_viewer.Services;

namespace mnpd_dispatch_viewer;

public partial class MainPage : ContentPage
{
	RestService restService;

	public MainPage()
	{
		InitializeComponent();

		restService = new RestService();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		var items = await restService.RefreshDataAsync();
		var output = $"Address: {items[0].Address}\nCall Received: {items[0].Call_Received}\nCity: {items[0].City}\nIncident Type: {items[0].Incident_Type}\nType Code: {items[0].Incident_Type_Code}" +
            $"\nLast Updated: {items[0].Last_Updated}";

		ResultsArea.Text = output;
	}
}

