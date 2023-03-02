const userJson = sessionStorage.getItem('userInfo');
const user = JSON.parse(userJson);

const init = () => { 
    document.getElementById('helloToUser').innerHTML = `Hello ${user.firstName}, nice to see you here!`;
}

init();

const update = async () => {

    console.log('in update')
    let userName = document.getElementById('userName').value;
    let password = document.getElementById('password').value;
    let firstName = document.getElementById('firstName').value;
    let lastName = document.getElementById('lastName').value;

    let userToSend = {
        UserName: userName, Password: password, FirstName: firstName, LastName: lastName
    }
    let res = await fetch(`api/users/${user.id}`, {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: "PUT",
        body: JSON.stringify(userToSend)
    })
    console.log(res)
}
