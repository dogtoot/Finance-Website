function btn(){
    const currUrl = window.location.href;
    var token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    fetch(`?handler=Button&message=${currUrl}`, {
        method: 'POST',
        headers: {
            "RequestVerificationToken": token,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(currUrl)
    });
}

