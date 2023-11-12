if (window.location.hash
||  window.location.search)
{
    const currentPageURLSearchParams = new
                     URLSearchParams(window.location.hash.substring(1));
    history.replaceState({ recoveryCode: `${currentPageURLSearchParams.get("access_token")}&${currentPageURLSearchParams.get("refresh_token")}`, }, "", window.location.pathname);
}
//else
//{
    document
        .querySelector(".\\.container")
        .innerHTML = `Your recovery code: ${history.state.recoveryCode}`;
//}