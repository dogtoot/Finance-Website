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

function signIn(data){
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
    fetch(`api/verify`, {
        method: 'POST',
        headers: {
            "RequestVerificationToken": token,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(r => );
}
