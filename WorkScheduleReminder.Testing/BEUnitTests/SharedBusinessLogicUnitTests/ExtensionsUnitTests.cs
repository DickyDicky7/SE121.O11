using Microsoft.Maui;
using Moq;
using System;
using System.Linq;
using WorkScheduleReminder.SharedBusinessLogic.Services.Abstractions___;
using WorkScheduleReminder.SharedBusinessLogic.Services.Implementations;

namespace WorkScheduleReminder.Testing.BEUnitTests.SharedBusinessLogicUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.SingleInstance)]
	public class ExtensionsUnitTests
	{
		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustAddSupabaseClientToServiceCollection()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<BaseGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			Supabase.Client? supabaseClient = serviceProvider.GetService<Supabase.Client>();

			/* --- ASSERT --- */
			Assert.That(supabaseClient, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustAddObservableDictionaryTransferServiceToServiceCollection()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			ObservableDictionaryTransferService? observableDictionaryTransferService = serviceProvider.GetService<ObservableDictionaryTransferService>();

			/* --- ASSERT --- */
			Assert.That(observableDictionaryTransferService, Is.Not.Null);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustSetSupabaseURLEnvironmentVariable()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			string? supabaseURL = Environment.GetEnvironmentVariable("SUPABASE_URL");

			/* --- ASSERT --- */
			Assert.That("https://cklxrwkqemlsayifnnvn.supabase.co", Is.EqualTo(supabaseURL));
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustSetSupabaseKeyEnvironmentVariable()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();

			/* --- ACT --- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			string? supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

			/* --- ASSERT --- */
			Assert.That("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNrbHhyd2txZW1sc2F5aWZubnZuI" +
			"iwicm9sZSI6ImFub24iLCJpYXQiOjE2OTUyMTM2ODMsImV4cCI6MjAxMDc4OTY4M30.HuP4n3fN3TPGnkoKcJOm4fM9awVeYw0WXBY4SjKA99w", Is.EqualTo(supabaseKey));
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustSetSupabaseOptions()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<BaseGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			Supabase.Client? supabaseClient = serviceProvider.GetService<Supabase.Client>();

			/* --- ASSERT --- */
			Assert.That(supabaseClient, Is.Not.Null);
			Supabase.Gotrue.ClientOptions? supabaseGotrueClientOptions = supabaseClient?.Auth.Options;
			Assert.That(supabaseGotrueClientOptions, Is.Not.Null);
			Assert.That(supabaseGotrueClientOptions?.AutoRefreshToken, Is.True);
		}

		[Test]
		[Parallelizable]
		public void AddServicesAndExtensionsSharedBusinessLogic_MustNotAddDuplicateServices()
		{
			/* --- ARRANGE --- */
			ServiceCollection services = new();
			Mock<BaseGotrueSessionPersistenceService> mockGotrueSessionPersistenceService = new();

			/* --- ACT --- */
			services.AddSingleton(mockGotrueSessionPersistenceService.Object);
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			services.AddServicesAndExtensionsSharedBusinessLogic(); /* <-- HERE <-- */
			ServiceProvider serviceProvider = services.BuildServiceProvider();
			int supabaseClientCount = serviceProvider.GetServices<Supabase.Client>().Count();
			int observableDictionaryTransferServiceCount = serviceProvider.GetServices<ObservableDictionaryTransferService>().Count();

			/* --- ASSERT --- */
			Assert.That(1, Is.EqualTo(supabaseClientCount));
			Assert.That(1, Is.EqualTo(observableDictionaryTransferServiceCount));
		}
	}
}
