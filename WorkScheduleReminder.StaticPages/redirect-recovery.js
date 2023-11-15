if (window.location.hash
||  window.location.search)
{
    const currentPageURLSearchParams = new
                     URLSearchParams(window.location.hash.substring(1));
    history.replaceState({ recoveryCode: `${currentPageURLSearchParams.get("access_token")}&${currentPageURLSearchParams.get("refresh_token")}`, }, "", window.location.pathname);
}

    document
        .querySelector(".button-copy-recovery-code")
        .addEventListener("click", (event) =>
        {
            navigator.clipboard.writeText(history.state.recoveryCode);
            if                           (history.state.recoveryCode)
            {
                const notification = document.querySelector(".notification");
                notification.innerHTML = "Successfully copied the recovery code";
                setTimeout(() =>
                {
                notification.innerHTML = "";
                }, 5000);
            }
        });
