using MauiBlazorApp1.Platforms.PartialMethods;
using Microsoft.JSInterop;
using System.Diagnostics;


namespace MauiBlazorApp1.Pages.PhotoPage
{
    public partial class PhotoPage
    {
        protected override void OnInitialized()
        {
            MainPage.hideWebBrowserFunction();
        }

        Stopwatch sw = new Stopwatch();

        Dictionary<string, string> imageSource = new Dictionary<string, string>();

        FileAccessIntegration fileAccesIntegration = new FileAccessIntegration();

        public async void TakePhoto()
        {
            sw.Start();
            if (MediaPicker.Default.IsCaptureSupported)
            {
#if WINDOWS
                CustomMediaPicker mediapicker = new CustomMediaPicker();
                var photo = await mediapicker.CaptureFileAsync();
                var fotoPath = photo.Path;
                var imageBytes = File.ReadAllBytes(fotoPath);
                SaveImageToFolderAndCreateThumbnail(imageBytes, Path.GetFileName(fotoPath));
                loadAllImages();
#else
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    using Stream sourceStream = await photo.OpenReadAsync();

                    var localImageFolderPath = CreateDirectory("Images");

                    string imagePath = Path.Combine(localImageFolderPath, photo.FileName);

                    using FileStream localFileStreamImage = File.OpenWrite(imagePath);

                    await sourceStream.CopyToAsync(localFileStreamImage);


                    localFileStreamImage.Close();
                    sourceStream.Close();
                    var imageBytes = File.ReadAllBytes(imagePath);
                    SaveImageToFolderAndCreateThumbnail(imageBytes, Path.GetFileName(imagePath));
                    loadAllImages();
                }
#endif

            }
            sw.Stop();

            await JSRuntime.InvokeVoidAsync("console.log", "TakePhoto " + sw.Elapsed.Seconds);
        }


        public async Task<FileResult> PickAndShow()
        {
            sw.Start();
            ImageSource image = "";

            try
            {

#if IOS
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pick a photo"
                });
#else
                var result = await FilePicker.Default.PickAsync(null);

                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        image = ImageSource.FromStream(() => stream);
                    }
                }
#endif



                var imageBytes = File.ReadAllBytes(result.FullPath);

                SaveImageToFolderAndCreateThumbnail(imageBytes, Path.GetFileName(result.FullPath));

                loadAllImages();
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
            sw.Stop();
            await JSRuntime.InvokeVoidAsync("console.log", "PickAndShow " + sw.Elapsed.Seconds);
            return null;
        }


        //Save Images to subfolders
        public async void SaveImageToFolderAndCreateThumbnail(byte[] imageBytes, string filename)
        {
            sw.Start();
            var filepath = CreateDirectory("Images");
            if (string.IsNullOrEmpty(filepath))
                return;

            string imageFilePath = Path.Combine(filepath, filename);



            if (!File.Exists(imageFilePath))
            {
                await File.WriteAllBytesAsync(imageFilePath, imageBytes);
            }

            filepath = CreateDirectory("Thumbnails");
            if (string.IsNullOrEmpty(filepath))
                return;

            var thumbnailFilePath = Path.Combine(filepath, filename);

            if (!File.Exists(thumbnailFilePath))
            {
                Stream thumbnailStream = new MemoryStream(imageBytes);
                fileAccesIntegration.CreateThumbnaiFromStream(thumbnailStream, thumbnailFilePath);

            }
            sw.Stop();
            await JSRuntime.InvokeVoidAsync("console.log", "SaveImageToFolderAndCreateThumbnail " + sw.Elapsed.Seconds);
        }

        //create a subfolder in the Cachedirectory
        public string CreateDirectory(string type)
        {

            string photoFilePath = Path.Combine(fileAccesIntegration.GetAppRootPath(), type);

            bool exists = Directory.Exists(photoFilePath);

            if (!exists)
                Directory.CreateDirectory(photoFilePath);

            return photoFilePath;

        }

        public void loadAllImages()
        {
            sw.Start();
            Dictionary<string, string> allFiles = new Dictionary<string, string>();
            string photoFilePath = Path.Combine(fileAccesIntegration.GetAppRootPath(), "Thumbnails");
            if (!Directory.Exists(photoFilePath))
                return;
            string[] filePaths = Directory.GetFiles(photoFilePath);

            foreach (var file in filePaths)
            {
                var imageBytes = File.ReadAllBytes(file);
                var tempimageSource = Convert.ToBase64String(imageBytes);
                tempimageSource = string.Format("data:image/png;base64,{0}", tempimageSource);
                allFiles.Add(tempimageSource, file);
            }

            imageSource = allFiles;
            sw.Stop();
            JSRuntime.InvokeVoidAsync("console.log", "loadAllImages " + sw.Elapsed.Seconds);
        }

        public async void navigateToImagePage(string path)
        {
            var filename = Path.GetFileName(path);
            string photoFilePath = Path.Combine(fileAccesIntegration.GetAppRootPath(), "Images");
            string imagePath = Path.Combine(photoFilePath, filename);


            var page = App.GetCurrentPage();
            var objPage = new NativePages.ImagePage(imagePath);

            try
            {
                await page.Navigation.PushModalAsync(objPage);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }
    }
}
