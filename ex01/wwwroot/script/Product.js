
async function filterProducts() {
    let checkedArr = [];
    var allCategoriesOptions = document.querySelectorAll(".opt");
    for (i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) {
            checkedArr.push(allCategoriesOptions[i].id);
        }
    }
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const name = document.getElementById("nameSearch").value;


    let url = 'api/Product';
    if (name || minPrice || maxPrice || checkedArr) url += `?`;

    if (name) url += `&desc=${name}`;

    if (minPrice) url += `&minPrice=${minPrice}`;

    if (maxPrice) url += `&maxPrice=${maxPrice}`;
    if (checkedArr) {
        for (let i = 0; i < checkedArr.length; i++) {
            url += `&categoryIds=${checkedArr[i]}`;
        }
    }


        var res = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (!res.ok) {
            throw new Error("Error in product fetch")
            alert("Error in product fetch")
        }

        const products = await res.json()

    document.getElementById("PoductList").replaceChildren(clonProducts);
    for (let i = 0; i < products.length; i++) {
        var tmp = document.getElementById("temp-card");
        var clonProducts = tmp.content.cloneNode(true);
        clonProducts.querySelector("img").src = "./images/" + products[i].img;
        clonProducts.querySelector(".description").innerText = products[i].description;
        clonProducts.querySelector(".price").innerText = products[i].price + "$";
        clonProducts.querySelector("h1").innerText = products[i].name;
        clonProducts.querySelector("button").addEventListener('click', () => { addtoshop(products[i]) });
        document.getElementById("PoductList").appendChild(clonProducts);



    }
    return products;
}





async function getAllCategory() {
    const res = await fetch(`api/Category`);
    const catetegoryData = await res.json();
    return catetegoryData;
}
async function drawCategory() {
    const categories = await getAllCategory();

    for (let i = 0; i < categories.length; i++) {
        var tmp = document.getElementById("temp-category");
        var clonCategories = tmp.content.cloneNode(true);
        clonCategories.querySelector("span.OptionName").innerText = categories[i].name;
        document.getElementById("categoryList").appendChild(clonCategories);


    }
}
var cart = [];
var count = 0;

function addtoshop(product) {
    if (cart.find(p => p.productId == product.productId)) {
        console.log("xclk")

    }
    else {
        cart.push(product);

        sessionStorage.setItem("count", count += 1)
        document.getElementById("ItemsCountText").innerText = count;
        sessionStorage.setItem('shopingBag', JSON.stringify(cart));
        console.log(cart);
    }
}

