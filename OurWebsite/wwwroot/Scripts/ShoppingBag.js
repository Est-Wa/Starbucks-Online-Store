document.addEventListener('load', onload())

function onload() {
    const cart = JSON.parse(localStorage.getItem('cart'))
    drawProducts(cart)
    setHead(cart);
}

function setHead(products) {
    let count = 0, sum = 0;
    products.forEach(p => { count += p.amount; sum += (p.amount * p.price) })
    document.getElementById('itemCount').textContent = count;
    document.getElementById('totalAmount').textContent = sum;
}

function changeAmount(productId, operation) {
    let products = JSON.parse(localStorage.getItem('cart'))
    let amount;
    products.forEach(p => { if (p.productId == productId) { operation == '-' ? p.amount -= 1 : p.amount += 1; amount = p.amount } })
    if (amount == 0) {
        deleteItem(productId)
        return
    }
    setHead(products);
    drawProducts(products)
    localStorage.setItem('cart', JSON.stringify(products))
}

function deleteItem(productId) {
    let products = JSON.parse(localStorage.getItem('cart'))
    products = products.filter(p => p.productId != productId)
    localStorage.setItem('cart', JSON.stringify(products))
    setHead(products);
    drawProducts(products)
}

function drawProducts(products) {
    let items = document.querySelector('#items tbody')
    items.innerHTML = ''
    if (products.length > 0)
        products.forEach((p) => drawProduct(p))
}

function drawProduct(product) {
    let template = document.getElementById("temp-row");
    let clone = template.content.cloneNode(true);

    let img = clone.querySelector('img')
    img.src = `../Images/Products/${product.imageLink}`;
    img.alt = product.imageLink;

    let itemName = clone.querySelector('.descriptionColumn .itemName')
    itemName.textContent = product.productName

    let itemNumber = clone.querySelector('.amountColumn h3')
    itemNumber.textContent = product.amount

    let price = clone.querySelector('.price')
    price.textContent = `$${product.price * product.amount}`

    let more = clone.querySelector('.amountColumn #more')
    more.addEventListener('click', () => { changeAmount(product.productId, '+') })

    let less = clone.querySelector('.amountColumn #less')
    less.addEventListener('click', () => { changeAmount(product.productId, '-') })

    let deleteButton = clone.querySelector('#deleteButton')
    deleteButton.addEventListener('click', () => { deleteItem(product.productId) })


    let items = document.querySelector('#items tbody')
    items.appendChild(clone);
}

async function placeOrder() {

    const user = JSON.parse(sessionStorage.getItem("userInfo"));
    if (!user) {
        alert('You must login or register for making an order')
        return;
    }
    const id = user.id;
    const cart = JSON.parse(localStorage.getItem('cart'));
    let items = [];
    for (let c in cart) {
        let i = {
            "productId": cart[c].productId,
            "quantity": cart[c].amount
        };
        items.push(i);
    }

    let sum = 0;
    cart.forEach(p => sum += (p.amount * p.price));
    const order = {
        orderDate: (new Date()).toISOString().slice(0, 10),
        "orderSum": sum,
        "userId": id,
        "orderItems": items
    };

    try {
        const res = await fetch("api/Orders", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "POST",
            body: JSON.stringify(order)
        })
        if (!res.ok) {
            alert('couldnt place order')
        }
        else {
            const order = await res.json()
            alert(`oreder ${order.orderId} placed successfully`);
            localStorage.removeItem('cart');
            window.location.href = "products.html";
        }
    }
    catch (err) {
        console.log(err)
    }
}