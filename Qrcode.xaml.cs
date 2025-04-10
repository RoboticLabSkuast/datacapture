namespace datacapture;
using Camera.MAUI.ZXing;
using Camera.MAUI;
using datacapture.services;

public partial class Qrcode : ContentPage
{
    public Qrcode()
    {
        InitializeComponent();
        SetupCamera();

        // Setup decoder and options
        cameraView.BarCodeDecoder = new ZXingBarcodeDecoder();
        cameraView.BarCodeOptions = new BarcodeDecodeOptions
        {
            AutoRotate = true,
            TryHarder = true,
            TryInverted = true,
            ReadMultipleCodes = false,
            PossibleFormats = { Camera.MAUI.BarcodeFormat.QR_CODE }
        };

        cameraView.BarCodeDetectionEnabled = true;
        cameraView.BarCodeDetectionFrameRate = 10;
        cameraView.BarCodeDetectionMaxThreads = 2;

        // Handle the QR code result
        cameraView.BarcodeDetected += CameraView_BarcodeDetected;
    }

    private void SetupCamera()
    {
        cameraView.CamerasLoaded += async (s, e) =>
        {
            if (cameraView.Cameras.Count > 0)
            {
                cameraView.Camera = cameraView.Cameras.First();
                var result = await cameraView.StartCameraAsync();

                if (result != CameraResult.Success)
                {
                    await DisplayAlert("Camera Error", "Could not start camera", "OK");
                }
            }
            else
            {
                await DisplayAlert("No Camera", "No camera found", "OK");
            }
        };
    }

    private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs e)
    {
        var scannedText = e.Result?.FirstOrDefault()?.Text;
       // Encrption encrption= new Encrption();

        if (!string.IsNullOrEmpty(scannedText))
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                /* String orginal;
                 try { 
                 orginal = encrption.Decrypt(scannedText, "haris");
                 }
                 catch
                 {

                     orginal = "";
                     return;
                 }
               if (orginal.ToLower().Contains("haris"))
                {
                    
                    App.treeidqr = orginal;
                 */

                if (scannedText.ToLower().Contains("haris"))
                {
                    
                    App.treeidqr = scannedText;

                    cameraView.BarCodeDetectionEnabled = false; // Stop scanning
                    await Navigation.PopAsync();

                }
            });

        }

    }
}
