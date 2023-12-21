#nullable enable

using CommunityToolkit.Mvvm.Input;
using H.NotifyIcon;
using System.Web;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Components.WebView;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
#endif

namespace WorkScheduleReminder.MAUIBlazor
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		protected override async void OnHandlerChanged()
		{
		                         base.OnHandlerChanged();
			blazorWebView.UrlLoading -= BlazorWebViewOnUrlLoading;
			await ConfigureWebViewAndClearWebViewCache();
			blazorWebView.UrlLoading += BlazorWebViewOnUrlLoading;
		}

		protected async void BlazorWebViewOnUrlLoading(object? sender,
			UrlLoadingEventArgs
			urlLoadingEventArgs)
		{
			urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
			if (
			urlLoadingEventArgs.Url.Host   == "0.0.0.0" &&
			urlLoadingEventArgs.Url.Scheme ==  "https"   )
			{
				NameValueCollection queryStrings
				=  HttpUtility.ParseQueryString(urlLoadingEventArgs.Url.Query);
				string? authenticationCode   = queryStrings["code"];
				if (    authenticationCode  != null               )
				{
					if (Handler             != null
					&&  Handler.MauiContext != null)
					{
						ObservableDictionaryTransferService?
						observableDictionaryTransferService =
						Handler.MauiContext.Services.GetRequiredService<
						ObservableDictionaryTransferService>();
						observableDictionaryTransferService.
						InsertOrUpdate(nameof(authenticationCode), authenticationCode);
						await ConfigureWebViewAndClearWebViewCache();
					}
				}
			}
		}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		protected async Task ConfigureWebViewAndClearWebViewCache()
		{
#if WINDOWS
			WebView2? webView2  = blazorWebView.Handler?.PlatformView as WebView2;
			if       (webView2 != null)
			{
				await webView2.EnsureCoreWebView2Async();
				      webView2.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
					  webView2.CoreWebView2.Settings.
					  IsGeneralAutofillEnabled = false;
				      webView2.CoreWebView2.
					  CookieManager.DeleteAllCookies();
			}
#endif
		}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

		private bool IsWindowVisible { get; set; } = true;

		[RelayCommand]
		public void ShowOHideWindow()
		{
			var window = Microsoft.Maui.Controls.Application.Current?.MainPage?.Window;
			if (window == null)
			{
				return;
			}

			if (IsWindowVisible)
			{
				window.Hide();
			}
			else
			{
				window.Show();
			}
			IsWindowVisible = !IsWindowVisible;
		}

		[RelayCommand]
		public void ExitApplication()
		{
			Microsoft.Maui.Controls.Application.Current?.Quit();
		}
	}
}
