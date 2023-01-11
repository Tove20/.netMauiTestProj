namespace MauiBlazorApp1.NativePages;

public partial class QrCodeReader : ContentPage
{
	public QrCodeReader()
	{
		InitializeComponent();
		btnClose.Clicked += BtnClose_Clicked;
	}

	private void BtnClose_Clicked(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}
}