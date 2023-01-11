using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Syncfusion.Blazor.PdfViewer;
using Syncfusion.Blazor.PdfViewerServer;

using ToolbarItem = Syncfusion.Blazor.PdfViewer.ToolbarItem;

namespace MauiBlazorApp1.Pages.PdfViewer
{
    public partial class PdfViewer
    {
        protected override void OnInitialized()
        {
            MainPage.hideWebBrowserFunction();
        }
        public string DocumentPath { get; set; } = "C:/GitReposMobileApp/MobilePrototypes/MauiBlazorApp1/MauiBlazorApp1/wwwroot/data/TestPDF1.pdf";
        SfPdfViewerServer pdfViewer = new SfPdfViewerServer();

        private void DocumentLoaded(LoadEventArgs args)

        {
            pdfViewer.UpdateViewerContainerAsync();

        }

        public PdfViewerToolbarSettings ToolbarSettings = new PdfViewerToolbarSettings()
        {
            ToolbarItems = new List<ToolbarItem>()
           {
                ToolbarItem.PageNavigationTool,
                ToolbarItem.MagnificationTool,
                ToolbarItem.CommentTool,
                ToolbarItem.SelectionTool,
                ToolbarItem.UndoRedoTool,
                ToolbarItem.CommentTool,
                ToolbarItem.AnnotationEditTool,
                ToolbarItem.PrintOption,
                ToolbarItem.DownloadOption
            }
        };

        public static string getRootpath()
        {
            string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
            string rootpath2 = System.IO.Path.Combine(rootpath, "data/TestPDF1.pdf");
            return rootpath2;
        }
    }
}
