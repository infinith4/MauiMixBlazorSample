#if __ANDROID__ || __IOS__
using ZXing.Net.Maui;
#endif

namespace MauiMixBlazorSample.MauiPages;

public partial class MauiQRCodePage : ContentPage
{
	public MauiQRCodePage()
	{
		InitializeComponent();
        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = true
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });
        //MainThread.BeginInvokeOnMainThread(() => {
        //    lbl.Text = $"{e.Results[0].Format}->{e.Results[0].Format}";
        //    barcodeView.IsDetecting = false;
        //});
    }
}