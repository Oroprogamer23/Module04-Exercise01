namespace Module0Exercise0.View;

public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
	}

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var photo = await MediaPicker.CapturePhotoAsync();
        if (photo != null)
        {
            var stream = await photo.OpenReadAsync();
            EmployeePhoto.Source = ImageSource.FromStream(() => stream);
        }
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();

            if (location != null)
            {
                CoordinatesLabel.Text = $"{location.Latitude}, {location.Longitude}";
                MunicipalityEntry.Text = "Your Municipality"; // Set this accordingly
                ProvinceEntry.Text = "Your Province"; // Set this accordingly
            }
            else
            {
                await DisplayAlert("Error", "Location not found.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
        }
    }
}