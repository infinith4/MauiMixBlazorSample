namespace MauiMixBlazorSample.MauiPages;

public partial class MauiQRCodePage : ContentPage
{
	public MauiQRCodePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}