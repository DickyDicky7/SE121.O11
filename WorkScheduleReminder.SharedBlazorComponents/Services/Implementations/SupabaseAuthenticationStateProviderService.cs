using System.Security
	 .Claims;
using Microsoft.AspNetCore
			   .Components.Authorization;

namespace WorkScheduleReminder.SharedBlazorComponents.Services.Implementations
{
	public class SupabaseAuthenticationStateProviderService : AuthenticationStateProvider
	{
	public       SupabaseAuthenticationStateProviderService
			    (Supabase
		.Client  supabaseClient) : base()
		{
			this.supabaseClient  = supabaseClient;
		}

		private readonly Supabase.Client supabaseClient;

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			ClaimsPrincipal claimsPrincipal = new();
			if (supabaseClient.Auth.CurrentSession != null)
			{
				string? UserId  = supabaseClient.Auth.CurrentUser?.Id;
				if     (UserId != null)
				{
					claimsPrincipal = new(new ClaimsIdentity(new Claim[]
					{ new(nameof(UserId), UserId)
					}
					, authenticationType: "SUPABASE_GOTRUE"));
				}
			}
			return new
				   (claimsPrincipal);
		}
	}
}
