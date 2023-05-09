
async function getProducts() {
    try {
        const res = await fetch("api/products", {
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
    description.textContent = product.despriction;
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
    span.textContent = category
    let categoryList = document.getElementById('categoryList')
    categoryList.appendChild(clone);
}

async function onload() {
    const products = await getProducts(); 
    if (products != null)
        products.forEach(product => drawProduct(product))
    const categories = ['Home', 'Garden', 'Toys'];
//        await getCategories();
    if (categories != null)
        categories.forEach(category => drawCategory(category))
}


document.addEventListener('load', onload())