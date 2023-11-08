using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Moq;
using MudBlazor;
using MudBlazor.Services;
using MudExtensions.Services;
using MudExtensions.Utilities;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.Testing.MockDependencies;

namespace WorkScheduleReminder.Testing.FEUnitTests.SharedBlazorComponentsUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class ExtensionsUnitTests
	{
		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_MustAddMudServices()
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
			Assert.That(dialogService, Is.Not.Null);
			Assert.That(snackBarService, Is.Not.Null);
			Assert.That(resizeListenerService, Is.Not.Null);
			Assert.That(browserViewportService, Is.Not.Null);
			Assert.That(browserWindowSizeProvider, Is.Not.Null);
			Assert.That(resizeService, Is.Not.Null);
			Assert.That(breakpointService, Is.Not.Null);
			Assert.That(resizeObserver, Is.Not.Null);
			Assert.That(resizeObserverFactory, Is.Not.Null);
			Assert.That(keyInterceptor, Is.Not.Null);
			Assert.That(keyInterceptorFactory, Is.Not.Null);
			Assert.That(jsEvent, Is.Not.Null);
			Assert.That(jsEventFactory, Is.Not.Null);
			Assert.That(scrollManager, Is.Not.Null);
			Assert.That(mudPopoverService, Is.Not.Null);
			Assert.That(popoverService, Is.Not.Null);
			Assert.That(scrollListener, Is.Not.Null);
			Assert.That(scrollListenerFactory, Is.Not.Null);
			Assert.That(scrollSpy, Is.Not.Null);
			Assert.That(scrollSpyFactory, Is.Not.Null);
			Assert.That(jsApiService, Is.Not.Null);
			Assert.That(eventListener, Is.Not.Null);
			Assert.That(eventListenerFactory, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_MustAddSupabaseAuthenticationStateProviderService()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<BaseGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			SupabaseAuthenticationStateProviderService? supabaseAuthenticationStateProviderService = serviceProvider.GetService<SupabaseAuthenticationStateProviderService>();

			/* --- ASSERT --- */
			Assert.That(supabaseAuthenticationStateProviderService, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_MustAddAuthenticationStateProvider()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<BaseGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBlazorComponents(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			AuthenticationStateProvider? authenticationStateProvider = serviceProvider.GetService<AuthenticationStateProvider>();

			/* --- ASSERT --- */
			Assert.That(authenticationStateProvider, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_MustAddAuthorizationCore()
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
			Assert.That(authorizationService, Is.Not.Null);
			Assert.That(authorizationHandler, Is.Not.Null);
			Assert.That(authorizationHandlerProvider, Is.Not.Null);
			Assert.That(authorizationHandlerContextFactory, Is.Not.Null);
			Assert.That(authorizationEvaluator, Is.Not.Null);
			Assert.That(authorizationPolicyProvider, Is.Not.Null);
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
		public void AddServicesAndExtensionsSharedBlazorComponents_MustAddMudExtensions()
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
			Assert.That(mudTeleportManager, Is.Not.Null);
			Assert.That(mudCssManager, Is.Not.Null);
			Assert.That(scrollManagerExtended, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBlazorComponents_MustUseSupabaseAuthenticationStateProviderService()
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
			Assert.That(mockSupabaseAuthenticationStateProviderService, Is.SameAs(authenticationStateProvider));
		}
	}
}
