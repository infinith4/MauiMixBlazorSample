using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiMixBlazorSample.MauiPages;

public partial class CameraMauiBarcodeRendererPage : ContentPage
{
	public CameraMauiBarcodeRendererPage()
	{
		InitializeComponent();


        var code = "https://github.com/hjam40/Camera.MAUI";
        barcodeImage.Barcode = code;

    }
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = entry.Text;
    }

    private void OnEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var code = entry.Text;
        await WriteStreamToFileAsync(code);
    }

    public async Task WriteStreamToFileAsync(string code)
    {
        var barcodeRenderer = new Camera.MAUI.BarcodeRenderer();
        Microsoft.Maui.Controls.ImageSource imageSource = barcodeRenderer.EncodeBarcode(code);
        var fileName = "/Users/hiroshi/projects/github/infinith4/MauiMixBlazorSample/MauiMixBlazorSample/bin/Debug/net7.0-maccatalyst/maccatalyst-x64/aaaa.png";
        //var str = Path.GetFullPath(fileName);
        //Console.WriteLine("GetPathRoot:\n{0}\n", str);
        using (Stream inStream = await ConvertImageSourceToStreamAsync(imageSource))
        using (Stream outStream = File.OpenWrite(fileName))
        {
            inStream.CopyTo(outStream);
        }
    }

    public async Task<Stream> ConvertImageSourceToStreamAsync(ImageSource imageSource)
    {
        return await ((StreamImageSource)imageSource).Stream(CancellationToken.None);
    }
}