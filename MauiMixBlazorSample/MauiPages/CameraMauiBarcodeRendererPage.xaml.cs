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

        var barcodeRenderer = new Camera.MAUI.BarcodeRenderer();
        Microsoft.Maui.Controls.ImageSource imgSource = barcodeRenderer.EncodeBarcode(code);
        var streamImgSource = ((Microsoft.Maui.Controls.StreamImageSource)imgSource);
        var fileName = "aaaa.png";
        using (Stream inStream = ConvertImageSourceToStreamAsync(imgSource).GetAwaiter().GetResult())
        using (Stream outStream = File.OpenWrite(fileName))
        {
            inStream.CopyTo(outStream);
        }
    }
    public async Task<Stream> ConvertImageSourceToStreamAsync(ImageSource imageSource)
    {
        using var stream = await ((StreamImageSource)imageSource).Stream(CancellationToken.None);
        return stream;
    }
}