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
        if (res.data !=null) {
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
    document.body.appendChild(clone);
}

async function getCategories() {
    try {
        const res = await fetch("api/categories", {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: "GET",
        });
        if (res.data != null) {
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
    span.textContent = category.name
    let chekBox = clone.querySelector("#categoryChekBox")
    console.log(chekBox)
    chekBox.addEventListener('change', (e)=>categoryFilter(category.id,e))
    let categoryList = document.getElementById('categoryList')
    categoryList.appendChild(clone);
}

async function onload() {
    const products = await getProducts(); 
    if (products != null)
        products.forEach(product => drawProduct(product))
    const categories = [{ name: 'Home', id: 1 }, { name: 'Garden', id: 2 }, { name: 'Toys', id: 3 }];
    //await getCategories();
    if (categories != null)
        categories.forEach(category => drawCategory(category))
}


document.addEventListener('load', onload())


async function filter() {

}

function categoryFilter(categoryId,e) {
    if(e.target.checked){
        categoryIds.push(categoryId)
    }
    else {
        categoryIds = categoryIds.filter(c => c != categoryId)
    }
    console.log(categoryIds)
    getProducts()
}

function nameFilter() {
    const input = document.getElementById('nameSearch')
    productName = input.value
    getProducts()
}

function priceFilter() {
    minPrice = document.getElementById('minPrice').value
    maxPrice = document.getElementById('maxPrice').value
    getProducts()
}