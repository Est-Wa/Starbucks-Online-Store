
async function getProducts() {
    let res = await fetch("api/products", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const data = await res.json();
    return data
}
function drawProduct(product) {
    let template = document.getElementById("temp-card");
    let clone = template.content.cloneNode(true);
    let img = clone.querySelector(".img-w img");
    img.src = `../Images/Products/${product.ImageLink}`;
    img.alt = product.ImageLink;
    let name = clone.querySelector("h1");
    name.textContent = product.productName;
    let price = clone.querySelector(".price");
    price.textContent = `${product.Price}$`
    let description = clone.querySelector(".description");
    description.textContent = product.Despriction
    document.body.appendChild(clone);
}
async function getCategories() {
    
}

async function onload() {
    const products = [{
        ProductId: 1, productName: 'Iced Chai Tea Latte', Price: 15,
        Despriction: 'Black tea infused with cinnamon, clove, and other warming spices are combined with milk and ice for the perfect balance of sweet and spicy.',
        CatergoryId: 1, ImageLink: 'IcedChai.jpg'
    }, {
        ProductId: 2, productName: 'Green Soft Touch Stainless-Steel Cold Cup', Price: 10,
        Despriction: 'Our 24 fl oz stainless-steel cold cup in a classic green with a soft touch finish adds a special feel.',
        CatergoryId: 1, ImageLink: 'GreenCup.jpg'
        }, {
            ProductId: 2, productName: 'Green Soft Touch Stainless-Steel Cold Cup', Price: 10,
            Despriction: 'Our 24 fl oz stainless-steel cold cup in a classic green with a soft touch finish adds a special feel.',
            CatergoryId: 1, ImageLink: 'DoubleChoc.jpg'
        }, {
            ProductId: 2, productName: 'Green Soft Touch Stainless-Steel Cold Cup', Price: 10,
            Despriction: 'Our 24 fl oz stainless-steel cold cup in a classic green with a soft touch finish adds a special feel.',
            CatergoryId: 1, ImageLink: 'Espresso.jpg'
        }, {
            ProductId: 2, productName: 'Green Soft Touch Stainless-Steel Cold Cup', Price: 10,
            Despriction: 'Our 24 fl oz stainless-steel cold cup in a classic green with a soft touch finish adds a special feel.',
            CatergoryId: 1, ImageLink: 'StrawberryCreme.jpg'
        }]
    // await getProducts()
    products.forEach(product => (drawProduct(product)))


}


document.addEventListener('load', onload())