function btn(){
    const currUrl = window.location.href;
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
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

//575px
window.addEventListener('resize', move_login);

function move_login(){
    if(window.innerWidth < 575){
        const login_btn_large = document.getElementById("login-btn-bg");
        const login_btn_small = document.getElementById("login-btn-sm");
        login_btn_large.hidden = true;
        login_btn_small.hidden = false;

    }
    else{
        const login_btn_large = document.getElementById("login-btn-bg");
        const login_btn_small = document.getElementById("login-btn-sm");
        login_btn_large.hidden = false;
        login_btn_small.hidden = true;
    }
}

function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

function decodeJwtResponse(data){
    signIn(parseJwt(data));
}

function signIn(data){
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    fetch(`?handler=Verify`, {
        method: 'POST',
        headers: {
            "RequestVerificationToken": token,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    });
}
