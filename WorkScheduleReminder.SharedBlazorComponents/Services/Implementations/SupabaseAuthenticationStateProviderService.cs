using System.Security
     .Claims;
using Microsoft.AspNetCore
               .Components;
using Microsoft.AspNetCore
               .Components.Authorization;
using MudBlazor;
using Newtonsoft.Json.Linq;

namespace WorkScheduleReminder.SharedBlazorComponents.Services.Implementations
{
	public class SupabaseAuthenticationStateProviderService : AuthenticationStateProvider
	{
	public       SupabaseAuthenticationStateProviderService
			    (Supabase
		.Client  supabaseClient,
		                 SharedBusinessLogic.Services.Implementations
		.ObservableDictionaryTransferService observableDictionaryTransferService) : base()
		{
			this.supabaseClient =
			     supabaseClient ;
			this.observableDictionaryTransferService =
			     observableDictionaryTransferService ;
		}

		private readonly Supabase.Client supabaseClient;
        private readonly SharedBusinessLogic.Services.Implementations
		.ObservableDictionaryTransferService observableDictionaryTransferService;

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

        private async Task<(bool ok, string reason)> SignUp_(string email, string password)
		{
			try
			{
				Supabase.Gotrue.Session? gotrueSession =
				await supabaseClient.Auth.SignUp(email, password, new()
				{
					RedirectTo = "https://work-schedule-reminder.vercel.app/redirect-sign-up.html/",
					Data = new()
					{
						{ "full_name", email }, { "avatar_url", string.Empty }
					},
				});
				if (gotrueSession?.User?.Identities.Count == 0)
				{
				return (ok: false, reason: Message.Error  .USER_ALREADY_EXISTS    (email));
				}
				return (ok: true , reason: Message.Success.SUCCESSFULLY_SIGNING_UP(email));
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
		}

        private async Task<(bool ok, string reason)> SignIn_(string email, string password)
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
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
		}

        private async Task<(bool ok, string reason)> SignOut()
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
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
		}

		public async Task<bool> LogIn(
		string email                 ,
		string    password           ,
		ISnackbar snackbar           )
		{
			(bool ok1, string reason1) = Helper.CheckEmailFormat(email);
			if  (!ok1)
			{
				snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason1),
				Severity.Error);
				return
				  ok1;
			}
			(bool ok2, string reason2) = Helper.CheckPasswordFormat(password);
			if  (!ok2)
			{
				snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason2),
				Severity.Error);
				return
				  ok2;
			}
			(bool ok3, string reason3) = await SignIn_(email, password);
			if  (!ok3)
			{
				snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason3),
				Severity.Error);
				return
				  ok3;
			}
			else
			{
				snackbar.Add(reason3,
				Severity.Success);
				return
				  ok3;
			}
		}

		public async Task<bool> SignUp(
		string email                  ,
		string    password            ,
		string    passwordConfirmed   ,
		ISnackbar snackbar            )
		{
			(bool ok1, string reason1) = Helper.CheckEmailFormat(email);
			if  (!ok1)
			{
				snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason1),
				Severity.Error);
				return
				  ok1;
			}
			(bool ok2, string reason2) = Helper.CheckPasswordFormat(password);
			if  (!ok2)
			{
				snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason2),
				Severity.Error);
				return
				  ok2;
			}
			if  (password != passwordConfirmed)
			{
				snackbar.Add(Message.Error.CANNOT_SIGN_UP(Message.Error.PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH),
				Severity.Error);
				return   false ;
			}
			(bool ok4, string reason4) = await SignUp_(email, password);
			if  (!ok4)
			{
				snackbar.Add(Message.Error.CANNOT_SIGN_UP(reason4),
				Severity.Error);
				return
				  ok4;
			}
			else
			{
				snackbar.Add(reason4,
				Severity.Success);
				return
				  ok4;
			}
		}

		public async Task LogInWithGoogle__(NavigationManager navigationManager)
		{
			Supabase.Gotrue.
			ProviderAuthState
			providerAuthState = await  supabaseClient.Auth.SignIn(
			Supabase.Gotrue.Constants.Provider.Google, new Supabase.Gotrue.SignInOptions()
			{
				FlowType   =
			Supabase.Gotrue.Constants.
			  OAuthFlowType.PKCE,
				RedirectTo = navigationManager.BaseUri
			,
			});
			navigationManager.NavigateTo(providerAuthState.Uri.ToString());
			observableDictionaryTransferService.Remove("authenticationCode", SuccessfullyLogInWithOAuthVer2(
			providerAuthState.PKCEVerifier));
			observableDictionaryTransferService.Insert("authenticationCode", SuccessfullyLogInWithOAuthVer2(
			providerAuthState.PKCEVerifier));
		}

		public async Task LogInWithFacebook(NavigationManager navigationManager)
		{
			Supabase.Gotrue.
			ProviderAuthState
			providerAuthState = await    supabaseClient.Auth.SignIn(
			Supabase.Gotrue.Constants.Provider.Facebook, new Supabase.Gotrue.SignInOptions()
			{
				FlowType   =
			Supabase.Gotrue.Constants.
			  OAuthFlowType.PKCE,
				RedirectTo = navigationManager.BaseUri
			,
			});
			navigationManager.NavigateTo(providerAuthState.Uri.ToString());
			observableDictionaryTransferService.Remove("authenticationCode", SuccessfullyLogInWithOAuthVer2(
			providerAuthState.PKCEVerifier));
			observableDictionaryTransferService.Insert("authenticationCode", SuccessfullyLogInWithOAuthVer2(
			providerAuthState.PKCEVerifier));
		}

		public Action<object?> SuccessfullyLogInWithOAuthVer2(string? maybeNullPKCEVerifier)
		=>  async (maybeNullAuthenticationCode) =>
		{
			string pkceVerifier       = maybeNullPKCEVerifier                 ?? string.Empty;
			string authenticationCode = maybeNullAuthenticationCode as string ?? string.Empty;
			await  supabaseClient.Auth.ExchangeCodeForSession(pkceVerifier, authenticationCode);
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
			observableDictionaryTransferService.Remove(nameof(authenticationCode));
		};

		private async Task<(bool ok, string reason)> SendPasswordRecoveryCodeToEmail(string email)
		{
			try
			{
				Supabase.Gotrue.
				ResetPasswordForEmailState
				resetPasswordForEmailState = await supabaseClient.Auth.
				ResetPasswordForEmail(new Supabase.Gotrue.ResetPasswordForEmailOptions(email)
				{
					FlowType   = Supabase.Gotrue.Constants.OAuthFlowType.Implicit,
					RedirectTo = "https://work-schedule-reminder.vercel.app/redirect-recovery.html/",
				});
				return (ok: true , reason: Message.Success.SUCCESSFULLY_SEND_PASSWORD_RECOVERY_CODE_TO(email));
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
		}

		private async Task<(bool ok, string reason)> CheckPasswordRecoveryCode(string passwordRecoveryCode)
		{
			try
			{
				string[] partsOfPasswordRecoveryCode =    passwordRecoveryCode.Split('&');
				await supabaseClient.Auth.SetSession(
				partsOfPasswordRecoveryCode[0],
				partsOfPasswordRecoveryCode[1],
				forceAccessTokenRefresh: true);
				return (ok: true , reason: Message.Success.SUCCESSFULLY_LOGGING_IN_BY_PASSWORD_RECOVERY_CODE);
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
			catch (Exception exception)
			{
				return (ok: false, reason: Message.Error.INVALID_PASSWORD_RECOVERY_CODE);
			}
		}

		private async Task<(bool ok, string reason)> ResetPassword(string newPassword)
		{
			try
			{
				await supabaseClient.Auth.Update(new Supabase.Gotrue.UserAttributes() { Password = newPassword, });
				NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
				return (ok: true, reason: Message.Success.SUCCESSFULLY_RESET_PASSWORD
				(supabaseClient.Auth.CurrentUser?.Email ?? string.Empty));
			}
			catch (Supabase.Gotrue.Exceptions.GotrueException gotrueException)
			{
				JObject message = JObject.Parse(gotrueException.Message);
				return (ok: false, reason: message.ExtractSupabaseGotrueException());
			}
		}

		public async Task<bool> SendPasswordRecoveryCodeToEmail(string email, ISnackbar snackbar)
		{
			(bool ok1, string reason1) = await SendPasswordRecoveryCodeToEmail(email);
			if  (!ok1)
			{
				snackbar.Add(Message.Error.CANNOT_SEND_PASSWORD_RECOVERY_CODE(reason1),
				Severity.Error);
				return
				  ok1;
			}
			else
			{
				snackbar.Add(reason1,
				Severity.Success);
				return
				  ok1;
			}
		}

		public async Task<bool> CheckPasswordRecoveryCode(string passwordRecoveryCode, ISnackbar snackbar)
		{
			(bool ok1, string reason1) = await CheckPasswordRecoveryCode(passwordRecoveryCode);
			if  (!ok1)
			{
				snackbar.Add(Message.Error.CANNOT_LOG_IN_(reason1),
				Severity.Error);
				return
				  ok1;
			}
			else
			{
				snackbar.Add(reason1,
				Severity.Success);
				return
				  ok1;
			}
		}

		public async Task<bool> ResetPassword(
		string newPassword                   ,
		string newPasswordConfirmed          ,
		ISnackbar snackbar                   )
		{
			(bool ok1, string reason1) = Helper.CheckPasswordFormat(newPassword);
			if  (!ok1)
			{
				snackbar.Add(Message.Error.CANNOT_RESET_PASSWORD(reason1),
				Severity.Error);
				return
				  ok1;
			}
			if (newPassword != newPasswordConfirmed)
			{
				snackbar.Add(Message.Error.CANNOT_RESET_PASSWORD(Message.Error.PASSWORD_AND_PASSWORD_CONFIRMED_NOT_MATCH),
				Severity.Error);
				return   false ;
			}
			(bool ok2, string reason2) = await ResetPassword(newPassword);
			if  (!ok2)
			{
				snackbar.Add(Message.Error.CANNOT_RESET_PASSWORD(reason2),
				Severity.Error);
				return
				  ok2;
			}
			else
			{
				snackbar.Add(reason2,
				Severity.Success);
				return
				  ok2;
			}
		}
	}
}
