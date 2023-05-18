var categoryIds = [];
var minPrice = null;
var maxPrice = null;
var productName = null;
var description = null;

async function getProducts() {
    try {
        const res = await fetch(`api/products?${categoryIds.length != 0 ? `categoryIds=${categoryIds.join('&categoryIds=')}` : ``}${minPrice ? `&minPrice=${minPrice}` : ``}${maxPrice ? `&maxPrice=${maxPrice}` : ``}${productName ? `&productName=${productName}` : ``}${description ? `&description=${description}` : ``}`, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "GET",
        });
        if (res.ok == true) {
            const data = await res.json();
            return data
        }
        else {
            return null;
        }
    }
    catch (err) {
        console.log(err)
    }
}

function drawProducts(products) {
        document.getElementById('counter').textContent = products.length;
        const productList = document.getElementById('ProductList')
        productList.innerHTML = '';
        products.forEach(product => drawProduct(product))
}

function drawProduct(product) {
    let template = document.getElementById("temp-card");
    let clone = template.content.cloneNode(true);
    let img = clone.querySelector(".img-w img");
    img.src = `../Images/Products/${product.imageLink}`;
    img.alt = product.imageLink;
    let name = clone.querySelector("h1");
    name.textContent = product.productName;
    let price = clone.querySelector(".price");
    price.textContent = `$${product.price}`
    let description = clone.querySelector(".description");
    description.textContent = product.description;
    const addButton = clone.querySelector("button")
    addButton.addEventListener('click', () => addToCart(product))
    const productList = document.getElementById('ProductList')
    productList.appendChild(clone);
}

async function getCategories() {
    try {
        const res = await fetch("api/categories", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "GET",
        });
        if (res.ok == true) {
            const data = await res.json();
            return data
        }
        else {
            return null;
        }
    }
    catch (err) {
        console.log(err)
    }
}

function drawCategory(category, products) {
    let template = document.getElementById("temp-category");
    let clone = template.content.cloneNode(true);
    if (products != null) {
            let count = 0;
            products.forEach((product) => {
                if (product.categoryId == category.categoryId)
                    count++
            clone.querySelector('.Count').textContent = count;
        })
        let span = clone.querySelector(".OptionName");
        span.textContent = category.categoryName
        let chekBox = clone.querySelector("#categoryChekBox")
        console.log(chekBox)
        chekBox.addEventListener('change', (e) => categoryFilter(category.categoryId, e))
        let categoryList = document.getElementById('categoryList')
        categoryList.appendChild(clone);
    }
}

    function setLoginOrOut() {
        const user = sessionStorage.getItem('userInfo')
        if (!user) {
            document.getElementById('loginOrRegister').textContent = 'Login';
        }
        else {
            document.getElementById('loginOrRegister').addEventListener('click', () => sessionStorage.removeItem('userInfo'))
        }
    }

    async function onload() {
        setLoginOrOut();
        const categories = await getCategories();
        const products = await getProducts();
        drawProducts(products)
        if (categories != null)
            categories.forEach(category => drawCategory(category, products))
        setAmountOfItems()
    }

    function setAmountOfItems() {
        const cart = JSON.parse(localStorage.getItem('cart'))
        let sum = 0;
        if (cart) {
            cart.forEach(p => sum += p.amount)
        }
        const itemsCount = document.getElementById('ItemsCountText')
        itemsCount.textContent = sum
    }


    document.addEventListener('load', onload())


    async function categoryFilter(categoryId, e) {
        if (e.target.checked) {
            categoryIds.push(categoryId)
        }
        else {
            categoryIds = categoryIds.filter(c => c != categoryId)
        }
        console.log(categoryIds)
        const products = await getProducts();
        drawProducts(products)
    }

    async function nameFilter() {
        const input = document.getElementById('nameSearch')
        productName = input.value
        const products = await getProducts();
        drawProducts(products)
    }

    async function priceFilter() {
        minPrice = document.getElementById('minPrice').value
        maxPrice = document.getElementById('maxPrice').value
        const products = await getProducts();
        drawProducts(products)
    }

    function addToCart(product) {
        let cart = localStorage.getItem('cart')
        cart = JSON.parse(cart)
        let inCart = false;
        if (cart != null) {
            cart.forEach((p) => { if (p.productId == product.productId) { p.amount += 1; inCart = true } })
            if (!inCart) {
                cart.push({ ...product, amount: 1 })
            }
            localStorage.setItem('cart', JSON.stringify(cart))
        }
        else {
            localStorage.setItem('cart', JSON.stringify([{ ...product, amount: 1 }]))
        }
        setAmountOfItems()
    }
