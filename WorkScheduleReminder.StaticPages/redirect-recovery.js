if (window.location.hash
||  window.location.search)
{
    const currentPageURLSearchParams = new
                     URLSearchParams(window.location.search);
    history.replaceState({ recoveryCode: currentPageURLSearchParams.get("code"), }, "", window.location.pathname);
}
else
{
    document
        .querySelector(".\\.container")
        .innerHTML = `Your recovery code: ${history.state.recoveryCode}`;
}