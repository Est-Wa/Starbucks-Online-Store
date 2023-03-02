function switchVisible() {
    if (document.getElementById('login')) {

        if (document.getElementById('login').style.display == 'none') {
            document.getElementById('login').style.display = 'block';
            document.getElementById('register').style.display = 'none';
        }
        else {
            document.getElementById('login').style.display = 'none';
            document.getElementById('register').style.display = 'block';
        }
    }
}