const checkPWbefore = async () => {
    console.log("in checking pw before sending");
    let currentPw = document.getElementById("password").value;
    try {
        let res = await fetch("api/passwords", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "POST",
            body: JSON.stringify(currentPw)
        });
        if (res) {
            const strength = await res.json();
            document.getElementById("progress").value = strength;
        }
    }
    catch (err) {
        console.log(err);
    }
}


const register = async () => {

    let userName = document.getElementById('userName').value;
    let password = document.getElementById('password').value;
    let firstName = document.getElementById('firstName').value;
    let lastName = document.getElementById('lastName').value;
    let email = document.getElementById('email').value;

    let user = {
        userName,  password, firstName, lastName, email
    }
    try {
        let res = await fetch("api/users/register", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "POST",
            body: JSON.stringify(user)
        })
        if (!res.ok) {
            console.log(res);
        }
        else { 
        const data = await res.json();
        if (data) {
            sessionStorage.setItem("userInfo", JSON.stringify({ firstName: data.firstName, lastName: data.lastName, id: data.userId }));
            window.location.href = "products.html";
            }
        }
    }
    catch (err) {
        console.log(err)
    }
}


const login = async () => {

    let userName = document.getElementById('userNameLogin').value;
    let password = document.getElementById('passwordLogin').value;

    let user = {
        UserName: userName, Password: password
    }
    try {
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
    catch (err) {
        console.log(err)
    }
}