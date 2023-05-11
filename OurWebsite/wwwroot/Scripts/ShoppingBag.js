document.addEventListener('load', onload())


function onload() {
    const cart = JSON.parse(localStorage.getItem('cart'))
    drawProducts(cart)
}



function changeAmount(productId, itemNumber, operation) {
    let products = JSON.parse(localStorage.getItem('cart'))
    let amount;
    products.forEach(p => { if (p.productId == productId) { operation == '-' ? p.amount -= 1 : p.amount+=1; amount = p.amount } })
    if (amount == 0) {
        deleteItem(productId)
        return
    }
    itemNumber.textContent = amount
   
    localStorage.setItem('cart', JSON.stringify(products))
}

function deleteItem(productId) {
    let products = JSON.parse(localStorage.getItem('cart'))
    products = products.filter(p => p.productId != productId)
    localStorage.setItem('cart', JSON.stringify(products))
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
    console.log(template)
    let clone = template.content.cloneNode(true);

    let img = clone.querySelector('.imageColumn .image')
    img.src = `../Images/Products/${product.imageLink}`;
    img.alt = product.imageLink;

    let itemName = clone.querySelector('.descriptionColumn .itemName')
    itemName.textContent = product.productName

    let itemNumber = clone.querySelector('.amountColumn h3')
    itemNumber.textContent = product.amount

    let more = clone.querySelector('.amountColumn #more')
    more.addEventListener('click', () => { changeAmount(product.productId, itemNumber,'+') })

    let less = clone.querySelector('.amountColumn #less')
    less.addEventListener('click', () => { changeAmount(product.productId, itemNumber,'-') })

    let deleteButton = clone.querySelector('#deleteButton')
    console.log(deleteButton)
    deleteButton.addEventListener('click', () => { deleteItem(product.productId) })


    let items = document.querySelector('#items tbody')
    items.appendChild(clone);
}




