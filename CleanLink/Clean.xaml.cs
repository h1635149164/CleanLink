using CleanLink.Lib;

namespace CleanLink;

public partial class Clean : ContentPage
{
	public Clean()
	{
		InitializeComponent();
	}

    private void LinkEntered(object sender, TextChangedEventArgs e)
    {
		string preferences = Preferences.Default.Get<string>("innactiveFilters","");
		Cleaner cleaner = new Cleaner(preferences);
		Output.Text = cleaner.Clean(((Editor)sender).Text);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		ShareTextRequest request = new ShareTextRequest();
		request.Title = "Share a link";
		request.Text = Output.Text;

		Share.RequestAsync(request);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(Output.Text);
    }
}