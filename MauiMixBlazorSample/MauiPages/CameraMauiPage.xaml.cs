using System;

namespace MauiMixBlazorSample.MauiPages;

public partial class CameraMauiPage : ContentPage
{
	public CameraMauiPage()
	{
		InitializeComponent();
        //cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        //{
        //    Formats = BarcodeFormats.OneDimensional,
        //    AutoRotate = true,
        //    Multiple = true
        //};
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            barcodeResult.Text = $"Text: {args.Result[0].Text}; {args.Result[0].BarcodeFormat}";
        });
    }
}