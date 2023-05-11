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

function drawProduct(product) {
    let template = document.getElementById("temp-card");
    let clone = template.content.cloneNode(true);
    let img = clone.querySelector(".img-w img");
    img.src = `../Images/Products/${product.imageLink}`;
    img.alt = product.imageLink;
    let name = clone.querySelector("h1");
    name.textContent = product.productName;
    let price = clone.querySelector(".price");
    price.textContent = `${product.price}$`
    let description = clone.querySelector(".description");
    description.textContent = product.description;
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

function drawCategory(category) {
    let template = document.getElementById("temp-category");
    let clone = template.content.cloneNode(true);
    let span = clone.querySelector(".OptionName");
    span.textContent = category.categoryName
    let chekBox = clone.querySelector("#categoryChekBox")
    console.log(chekBox)
    chekBox.addEventListener('change', (e) => categoryFilter(category.categoryId, e))
    let categoryList = document.getElementById('categoryList')
    categoryList.appendChild(clone);
}

async function onload() {
    const products = await getProducts();
    if (products != null) { 
        const productList = document.getElementById('ProductList')
        productList.innerHTML = '';
        products.forEach(product => drawProduct(product))}
    const categories = await getCategories();
    if (categories != null)
        categories.forEach(category => drawCategory(category))
}


document.addEventListener('load', onload())


async function filter() {

}

async function categoryFilter(categoryId,e) {
    if(e.target.checked){
        categoryIds.push(categoryId)
    }
    else {
        categoryIds = categoryIds.filter(c => c != categoryId)
    }
    console.log(categoryIds)
    const products = await getProducts();
    if (products != null) {
        const productList = document.getElementById('ProductList')
        productList.innerHTML = '';
        products.forEach(product => drawProduct(product))
    }
}

async function nameFilter() {
    const input = document.getElementById('nameSearch')
    productName = input.value
    const products = await getProducts();
    if (products != null) {
        const productList = document.getElementById('ProductList')
        productList.innerHTML = '';
        products.forEach(product => drawProduct(product))
    }
}

async function priceFilter() {
    minPrice = document.getElementById('minPrice').value
    maxPrice = document.getElementById('maxPrice').value
    const products = await getProducts();
    if (products != null) {
        const productList = document.getElementById('ProductList')
        productList.innerHTML = '';
        products.forEach(product => drawProduct(product))
    }
}