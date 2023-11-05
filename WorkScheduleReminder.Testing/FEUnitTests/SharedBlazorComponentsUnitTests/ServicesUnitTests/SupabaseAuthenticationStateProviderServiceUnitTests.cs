using System.Linq;
using System.Security
	 .Claims;
using System.Threading.Tasks;
using WorkScheduleReminder.SharedBlazorComponents.Services.Implementations;

namespace WorkScheduleReminder.Testing.FEUnitTests.SharedBlazorComponentsUnitTests.ServicesUnitTests
{
	[TestFixture]
	[Parallelizable]
	[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
	public class SupabaseAuthenticationStateProviderServiceUnitTests
	{
		public SupabaseAuthenticationStateProviderServiceUnitTests()
		{
			string SUPABASE_URL = "https://cklxrwkqemlsayifnnvn.supabase.co";
			string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.ey" +
			"Jpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNrbHhyd2txZW1sc2F5aWZubnZuIiw" +
			"icm9sZSI6ImFub24iLCJpYXQiOjE2OTUyMTM2ODMsImV4cCI6MjAxMDc4OTY4" +
			"M30.HuP4n3fN3TPGnkoKcJOm4fM9awVeYw0WXBY4SjKA99w";
			mockSupabaseClient = new(SUPABASE_URL, SUPABASE_KEY);
		}

		private readonly Supabase.Client mockSupabaseClient = default!;

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithNoClaimIfCurrentSessionNotExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Claims, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithNoIdentityIfCurrentSessionNotExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Identities, Is.Empty);
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithOneClaimIfCurrentSessionExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			await mockSupabaseClient.Auth.SignIn("default@default.com", "default@default.com");
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Claims.Count(), Is.EqualTo(1));
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithOneIdentityIfCurrentSessionExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			await mockSupabaseClient.Auth.SignIn("default@default.com", "default@default.com");
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Identities.Count(), Is.EqualTo(1));
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithOneClaimHavingValidUserIdIfCurrentSessionExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			await mockSupabaseClient.Auth.SignIn("default@default.com", "default@default.com");
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */
			var userId = mockSupabaseClient.Auth.CurrentUser?.Id ?? string.Empty;
			var claimHavingValidUserId = new Claim(nameof(userId), userId);

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Claims.Count(), Is.EqualTo(1));
			Assert.That(authenticationState.User.Claims.ElementAt(0).ToString(), Is.EqualTo(claimHavingValidUserId.ToString()));
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithOneIdentityHavingValidClaimsAndValidAuthenticationTypeIfCurrentSessionExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			await mockSupabaseClient.Auth.SignIn("default@default.com", "default@default.com");
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */
			var userId = mockSupabaseClient.Auth.CurrentUser?.Id ?? string.Empty;
			var claimHavingValidUserId = new Claim(nameof(userId), userId);
			var identityHavingValidClaimsAndValidAuthenticationType = new ClaimsIdentity(claims: new Claim[] { claimHavingValidUserId }, authenticationType: "SUPABASE_GOTRUE");

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Identities.Count(), Is.EqualTo(1));
			Assert.That(authenticationState.User.Identities.ElementAt(0).Claims.Count(), Is.EqualTo(1));
			Assert.That(authenticationState.User.Identities.ElementAt(0).Claims.Count(), Is.EqualTo(identityHavingValidClaimsAndValidAuthenticationType.Claims.Count()));
			Assert.That(authenticationState.User.Identities.ElementAt(0).Claims.ElementAt(0).ToString(), Is.EqualTo(identityHavingValidClaimsAndValidAuthenticationType.Claims.ElementAt(0).ToString()));
			Assert.That(authenticationState.User.Identities.ElementAt(0).AuthenticationType, Is.EqualTo(identityHavingValidClaimsAndValidAuthenticationType.AuthenticationType));
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithPrimaryIdentityHavingIsAuthenticatedTrueIfCurrentSessionExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			await mockSupabaseClient.Auth.SignIn("default@default.com", "default@default.com");
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Identity, Is.Not.Null);
			Assert.That(authenticationState.User.Identity?.IsAuthenticated, Is.True);
		}

		[Test]
		[Parallelizable]
		public async Task GetAuthenticationStateAsync_MustReturnAuthenticationStateWithNoPrimaryIdentityIfCurrentSessionNotExisted()
		{
			/* --- ARRANGE --- */
			var supabaseAuthenticationStateProviderService = new SupabaseAuthenticationStateProviderService(mockSupabaseClient);

			/* --- ACT --- */
			var authenticationState = await supabaseAuthenticationStateProviderService.GetAuthenticationStateAsync(); /* <-- HERE <-- */

			/* --- ASSERT --- */
			Assert.That(authenticationState.User.Identity, Is.Null);
		}

		//[Test]
		//[Parallelizable]
		//[TestCase()]
		//public async Task SignUp__MustReturnTrueAndSuccessMessageIfSignUpActivityOnServerSucceed(string email, string password)
		//{

		//}

		//[Test]
		//[Parallelizable]
		//public async Task Test2()
		//{
		//	var s = await supabaseClient_.Auth.SignIn("tuan.pham.21.01.2003@gmail.com", "Anh21012003");

		//	Assert.That(s, Is.Not.Null);
		//}
	}
}
