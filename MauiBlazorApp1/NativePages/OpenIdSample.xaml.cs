using IdentityModel.Client;
using IdentityModel.OidcClient;
using MauiBlazorApp1.OpenId;
using System.Text;
using System.Text.Json;

namespace MauiBlazorApp1.NativePages;

public partial class OpenIdSample : ContentPage
{

    private readonly OidcClient _client;
    private string _currentAccessToken;

    public OpenIdSample(OidcClient client)
    {
        InitializeComponent();
        _client = client;
        btnBack.Clicked += BtnBack_Clicked;
    }


    public OpenIdSample()
    {
        InitializeComponent();
        _client = OpenIdInitialization.GetOidcClient();
        btnBack.Clicked += BtnBack_Clicked;
    }


    private async void BtnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }


    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var result = await _client.LoginAsync();

        if (result.IsError)
        {
            editor.Text = result.Error;
            return;
        }

        _currentAccessToken = result.AccessToken;

        var sb = new StringBuilder(128);

        sb.AppendLine("claims:");
        foreach (var claim in result.User.Claims)
        {
            sb.AppendLine($"{claim.Type}: {claim.Value}");
        }

        sb.AppendLine();
        sb.AppendLine("access token:");
        sb.AppendLine(result.AccessToken);

        if (!string.IsNullOrWhiteSpace(result.RefreshToken))
        {
            sb.AppendLine();
            sb.AppendLine("access token:");
            sb.AppendLine(result.AccessToken);
        }

        editor.Text = sb.ToString();
    }

    private async void OnApiClicked(object sender, EventArgs e)
    {
        if (_currentAccessToken != null)
        {
            var client = new HttpClient();
            client.SetBearerToken(_currentAccessToken);

            var response = await client.GetAsync("https://demo.duendesoftware.com/api/test");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(content).RootElement;
                editor.Text = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            }
            else
            {
                editor.Text = response.ReasonPhrase;
            }
        }
    }
}