const checkPWbefore = async () => {
    //    let progress = document.getElementById('progress');
    console.log("in checking pw before sending");
    let currentPw = document.getElementById("password").value;
    let res = await fetch("api/passwords", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: "POST",
        body: JSON.stringify(currentPw)
    });
    const strength = await res.json();
    console.log(strength)
    if (strength < 2) {
        alert("Password not strong enough, please enter a new one.");
        document.getElementById("progress").value = strength;
    }
    else { 
        document.getElementById("progress").value = strength;
     alert("great choice")
}
    }



const register = async () => {

    console.log('in register')
    let userName = document.getElementById('userName').value;
    let password = document.getElementById('password').value;
    let firstName = document.getElementById('firstName').value;
    let lastName = document.getElementById('lastName').value;
    let email = document.getElementById('email').value;
    let progress = document.getElementById('progress')

    let user = {
        userName,  password, firstName, lastName, email
    }
    let res = await fetch("api/users/register", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: "POST",
        body: JSON.stringify(user)
    })
    const data = await res.json();
    if (data) {
        sessionStorage.setItem("userInfo", JSON.stringify({ firstName: data.firstName, lastName: data.lastName, id: data.userId }));
        /*window.location.href = "update.html";*/
    }
}



const login = async () =>{

    console.log('in login')
    let userName = document.getElementById('userNameLogin').value;
    let password = document.getElementById('passwordLogin').value;

    let user = {
        UserName: userName, Password: password
    }

    let res = await fetch("api/users/login", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: "POST",
        body: JSON.stringify(user)
    })

    console.log(res)

    if (!res.ok) {
        console.log(res);
    }
    else {
        if (res.status == '204') {
            alert("no user found");
        }
        else {
            const data = await res.json();
            if (data) {
                sessionStorage.setItem("userInfo", JSON.stringify({ firstName: data.firstName, lastName: data.lastName, id: data.userId }));
                window.location.href = "products.html";
            }
        }
    }
}
