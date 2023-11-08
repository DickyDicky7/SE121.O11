using System.Security
	 .Claims;
using Microsoft.AspNetCore
			   .Components.Authorization;
using Newtonsoft.Json.Linq;

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
				string? userId  = supabaseClient.Auth.CurrentUser?.Id;
				if     (userId != null)
				{
					claimsPrincipal = new(new ClaimsIdentity(claims: new Claim[]
					{ new(nameof(userId), userId)
					}
					, authenticationType: "SUPABASE_GOTRUE"));
				}
			}
			return new
				   (claimsPrincipal);
		}

		public async Task<(bool ok, string reason)> SignUp_(string email, string password)
		{
			try
			{
				await supabaseClient.Auth.SignUp(email, password, new()
				{
					RedirectTo = "https://google.com",
					Data = new()
					{
						{ "full_name", email }, { "avatar_url", string.Empty }
					},
				});
				return (ok: true , reason: Message.Success.SUCCESSFULLY_SIGNING_UP(email));
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message?["msg"]?.Value<string>() ?? string.Empty);
			}
		}

		public async Task<(bool ok, string reason)> SignIn_(string email, string password)
		{
			try
			{
				await supabaseClient.Auth.SignIn(email, password);
				NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
				return (ok: true , reason:
				Message.Success.SUCCESSFULLY_LOGGING_IN_);
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message?["error_description"]?.Value<string>() ?? string.Empty);
			}
		}

		public async Task<(bool ok, string reason)> SignOut()
		{
			try
			{
				await supabaseClient.Auth.SignOut();
				NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
				return (ok: true , reason:
				Message.Success.SUCCESSFULLY_LOGGING_OUT);
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message?["error_description"]?.Value<string>() ?? string.Empty);
			}
		}
	}
}
