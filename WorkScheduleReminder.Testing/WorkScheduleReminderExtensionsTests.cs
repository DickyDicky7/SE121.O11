using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;
using MudExtensions.Utilities;
using System;
using System.Linq;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace WorkScheduleReminder.Testing.ExtensionsTests
{
	public class MockNavigationManager : NavigationManager
	{
		public MockNavigationManager() : base()
		{
			Initialize(
			"http://localhost:2112/",
			"http://localhost:2112/test");
		}

		public bool WasNavigateInvoked { get; private set; }

		protected override void NavigateToCore(string uri, bool forceLoad)
		{
			WasNavigateInvoked = true;
		}
	}

	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class SharedBusinessLogicTests
	{
		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_AddsSupabaseClientToServiceCollection()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			Supabase.Client? supabaseClient = serviceProvider.GetService<Supabase.Client>();

			/* --- ASSERT --- */
			Assert.IsNotNull(supabaseClient);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_AddsObservableDictionaryTransferServiceToServiceCollection()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			ObservableDictionaryTransferService? observableDictionaryTransferService = serviceProvider.GetService<ObservableDictionaryTransferService>();

			/* --- ASSERT --- */
			Assert.IsNotNull(observableDictionaryTransferService);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_SetsSupabaseUrlEnvironmentVariable()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			string? supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");

			/* --- ASSERT --- */
			Assert.AreEqual("https://cklxrwkqemlsayifnnvn.supabase.co", supabaseUrl);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_SetsSupabaseKeyEnvironmentVariable()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			string? supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

			/* --- ASSERT --- */
			Assert.AreEqual("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNrbHhyd2txZW1sc2F5aWZubnZ" +
			"uIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTUyMTM2ODMsImV4cCI6MjAxMDc4OTY4M30.HuP4n3fN3TPGnkoKcJOm4fM9awVeYw0WXBY4SjKA99w", supabaseKey);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_SetsSupabaseOptions()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			Supabase.Client? supabaseClient = serviceProvider.GetService<Supabase.Client>();

			/* --- ASSERT --- */
			Assert.IsNotNull(supabaseClient);
			Supabase.Gotrue.ClientOptions? supabaseGotrueClientOptions = supabaseClient?.Auth.Options;
			Assert.IsNotNull(supabaseGotrueClientOptions);
			Assert.IsTrue(supabaseGotrueClientOptions?.AutoRefreshToken);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_DoesNotAddDuplicateServices()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			int supabaseClientCount = serviceProvider.GetServices<Supabase.Client>().Count();
			int observableDictionaryTransferServiceCount = serviceProvider.GetServices<ObservableDictionaryTransferService>().Count();

			/* --- ASSERT --- */
			Assert.AreEqual(1, supabaseClientCount);
			Assert.AreEqual(1, observableDictionaryTransferServiceCount);
		}
	}

	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class SharedBlazorComponentsTests
	{
		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_AddsMudServices()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IJSRuntime> mockIJSRuntime = new();
			MockNavigationManager mockNavigationManager = new();

			/* --- ACT --- */
			services.AddLogging();
			services.AddSingleton(mockIJSRuntime.Object);
			services.AddSingleton<NavigationManager>(mockNavigationManager);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			IDialogService? dialogService = serviceProvider.GetService<IDialogService>();
			ISnackbar? snackBarService = serviceProvider.GetService<ISnackbar>();
#pragma warning disable CS0618
			IResizeService? resizeService = serviceProvider.GetService<IResizeService>();
			IResizeListenerService? resizeListenerService = serviceProvider.GetService<IResizeListenerService>();
			IBreakpointService? breakpointService = serviceProvider.GetService<IBreakpointService>();
			IBrowserWindowSizeProvider? browserWindowSizeProvider = serviceProvider.GetService<IBrowserWindowSizeProvider>();
#pragma warning restore CS0618
			IBrowserViewportService? browserViewportService = serviceProvider.GetService<IBrowserViewportService>();
			IResizeObserver? resizeObserver = serviceProvider.GetService<IResizeObserver>();
			IResizeObserverFactory? resizeObserverFactory = serviceProvider.GetService<IResizeObserverFactory>();
			IKeyInterceptor? keyInterceptor = serviceProvider.GetService<IKeyInterceptor>();
			IKeyInterceptorFactory? keyInterceptorFactory = serviceProvider.GetService<IKeyInterceptorFactory>();
			IJsEvent? jsEvent = serviceProvider.GetService<IJsEvent>();
			IScrollManager? scrollManager = serviceProvider.GetService<IScrollManager>();
			IJsEventFactory? jsEventFactory = serviceProvider.GetService<IJsEventFactory>();
#pragma warning disable CS0618
			IMudPopoverService? mudPopoverService = serviceProvider.GetService<IMudPopoverService>();
#pragma warning restore CS0618
			IPopoverService? popoverService = serviceProvider.GetService<IPopoverService>();
			IScrollListener? scrollListener = serviceProvider.GetService<IScrollListener>();
			IScrollListenerFactory? scrollListenerFactory = serviceProvider.GetService<IScrollListenerFactory>();
			IScrollSpy? scrollSpy = serviceProvider.GetService<IScrollSpy>();
			IScrollSpyFactory? scrollSpyFactory = serviceProvider.GetService<IScrollSpyFactory>();
			IJsApiService? jsApiService = serviceProvider.GetService<IJsApiService>();
			IEventListener? eventListener = serviceProvider.GetService<IEventListener>();
			IEventListenerFactory? eventListenerFactory = serviceProvider.GetService<IEventListenerFactory>();

			/* --- ASSERT --- */
			Assert.IsNotNull(dialogService);
			Assert.IsNotNull(snackBarService);
			Assert.IsNotNull(resizeListenerService);
			Assert.IsNotNull(browserViewportService);
			Assert.IsNotNull(browserWindowSizeProvider);
			Assert.IsNotNull(resizeService);
			Assert.IsNotNull(breakpointService);
			Assert.IsNotNull(resizeObserver);
			Assert.IsNotNull(resizeObserverFactory);
			Assert.IsNotNull(keyInterceptor);
			Assert.IsNotNull(keyInterceptorFactory);
			Assert.IsNotNull(jsEvent);
			Assert.IsNotNull(jsEventFactory);
			Assert.IsNotNull(scrollManager);
			Assert.IsNotNull(mudPopoverService);
			Assert.IsNotNull(popoverService);
			Assert.IsNotNull(scrollListener);
			Assert.IsNotNull(scrollListenerFactory);
			Assert.IsNotNull(scrollSpy);
			Assert.IsNotNull(scrollSpyFactory);
			Assert.IsNotNull(jsApiService);
			Assert.IsNotNull(eventListener);
			Assert.IsNotNull(eventListenerFactory);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_AddsSupabaseAuthenticationStateProviderService()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			SupabaseAuthenticationStateProviderService? supabaseAuthenticationStateProviderService = serviceProvider.GetService<SupabaseAuthenticationStateProviderService>();

			/* --- ASSERT --- */
			Assert.IsNotNull(supabaseAuthenticationStateProviderService);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_AddsAuthenticationStateProvider()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			AuthenticationStateProvider? authenticationStateProvider = serviceProvider.GetService<AuthenticationStateProvider>();

			/* --- ASSERT --- */
			Assert.IsNotNull(authenticationStateProvider);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_AddsAuthorizationCore()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddLogging();
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			IAuthorizationService? authorizationService = serviceProvider.GetService<IAuthorizationService>();
			IAuthorizationHandler? authorizationHandler = serviceProvider.GetService<IAuthorizationHandler>();
			IAuthorizationHandlerProvider? authorizationHandlerProvider = serviceProvider.GetService<IAuthorizationHandlerProvider>();
			IAuthorizationHandlerContextFactory? authorizationHandlerContextFactory = serviceProvider.GetService<IAuthorizationHandlerContextFactory>();
			IAuthorizationEvaluator? authorizationEvaluator = serviceProvider.GetService<IAuthorizationEvaluator>();
			IAuthorizationPolicyProvider? authorizationPolicyProvider = serviceProvider.GetService<IAuthorizationPolicyProvider>();

			/* --- ASSERT --- */
			Assert.IsNotNull(authorizationService);
			Assert.IsNotNull(authorizationHandler);
			Assert.IsNotNull(authorizationHandlerProvider);
			Assert.IsNotNull(authorizationHandlerContextFactory);
			Assert.IsNotNull(authorizationEvaluator);
			Assert.IsNotNull(authorizationPolicyProvider);
		}

		//[Test]
		//public void AddServicesAndExtensionsSharedBlazorComponents_ConfiguresSnackbar()
		//{
		//	/* --- ARRANGE --- */
		//	var services = new ServiceCollection();
		//	var mudServiceMock = new Mock<IMudService>();

		//	/* --- ACT --- */
		//	services.AddSingleton(mudServiceMock.Object);
		//	services.AddServicesAndExtensionsSharedBlazorComponents();

		//	/* --- ASSERT --- */
		//	mudServiceMock.Verify(m => m.ConfigureSnackbar(It.IsAny<Action<SnackbarConfiguration>>()), Times.Once);
		//}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_AddsMudExtensions()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<IJSRuntime> mockJSRuntime = new();

			/* --- ACT --- */
			services.AddSingleton(mockJSRuntime.Object);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			MudTeleportManager? mudTeleportManager = serviceProvider.GetService<MudTeleportManager>();
			MudCssManager? mudCssManager = serviceProvider.GetService<MudCssManager>();
			IScrollManagerExtended? scrollManagerExtended = serviceProvider.GetService<IScrollManagerExtended>();

			/* --- ASSERT --- */
			Assert.IsNotNull(mudTeleportManager);
			Assert.IsNotNull(mudCssManager);
			Assert.IsNotNull(scrollManagerExtended);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_UsesSupabaseAuthenticationStateProviderService()
		{
			/* --- ARRANGE --- */
			string SUPABASE_URL = string.Empty;
			string SUPABASE_KEY = string.Empty;
			ServiceCollection services = new();
			Supabase.Client mockSupabaseClient = new(SUPABASE_URL, SUPABASE_KEY);
			SupabaseAuthenticationStateProviderService mockSupabaseAuthenticationStateProviderService = new(mockSupabaseClient);

			/* --- ACT --- */
			services.AddSingleton(mockSupabaseClient);
			services.AddSingleton(mockSupabaseAuthenticationStateProviderService);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			AuthenticationStateProvider authenticationStateProvider = serviceProvider.GetRequiredService<AuthenticationStateProvider>();

			/* --- ASSERT --- */
			Assert.AreSame(mockSupabaseAuthenticationStateProviderService, authenticationStateProvider);
		}
	}
}
