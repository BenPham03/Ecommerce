let openShopping = document.querySelector(".shopping");
let closeShopping = document.querySelector(".closeShopping");
let list = document.querySelector(".list");
let listCard = document.querySelector(".listCard");
let body = document.querySelector("body");
let total = document.querySelector(".total");
let quantity = document.querySelector(".quantity");
// console.log(document.querySelector(".listCard"))


openShopping.addEventListener("click", () => {


    body.classList.add("actives");
  });

  
  closeShopping.addEventListener("click", () => {


    body.classList.remove("actives");
  });
let products = [
    {
      id: 1,
      name: "PC E-Power Office ",
      image: "caymt.webp",
      price: 6390000,
    },
    {
      id: 2,
      name: "vivobook.webp",
      image: "ss-zfold.png",
      price: 31990000,
    },
    {
      id: 3,
      name: "Xiaomi 13 Lite",
      image: "xiaomi13.png",
      price: 8990000,
    },
    {
      id: 4,
      name: "Asus TUF Gaming",
      image: "asus.png",
      price: 17490000,
    },
    {
      id: 5,
      name: "iPhone 11",
      image: "ip11.png",
      price: 10299000,
    },
    {
      id: 6,
      name: "Realme C55",
      image: "realme.png",
      price: 17490000,
    },
  ];
  let listCards = JSON.parse(localStorage["cart"] || "[]");
  
  function initApp() {
    products.forEach((value, key) => {
    });
    reloadCard();
  }
  initApp();
  // let key =  0;
  
  function addToCard(key) {
    // console.log(key)
    if (listCards[key] == null) {
      // copy product form list to list card
      listCards[key] = products[key];
      listCards[key].quantity = 1;
      key += 1;
    }
    reloadCard();
  }
  function reloadCard() {
    listCard.innerHTML = "";
    let count = 0;
    // console.log(listCards.filter(Boolean))
    let totalPrice = 0;
    listCards.filter(Boolean).forEach((value) => {
      // console.log(value.quantity)
      totalPrice = totalPrice + value.price;
      count = count + value.quantity;
      let newDiv = document.createElement("li");
      newDiv.innerHTML = `
                  <div><img src="img/${value.image}"/></div>
                  <div>${value.name}</div>
                  <div>${value.price.toLocaleString()}</div>
                  <div>
                      <button onclick="changeQuantity(${value.id}, ${
        value.quantity - 1
      })">-</button>
                      <div class="count">${value.quantity}</div>
                      <button onclick="changeQuantity(${value.id}, ${
        value.quantity + 1
      })">+</button>
                  </div>`;


      listCard.appendChild(newDiv);
    });


    total.innerText = totalPrice.toLocaleString();
    console.log(quantity)
    // quantity.innerText = count;

    localStorage["cart"] = JSON.stringify(listCards);
  }
  
  function changeQuantity(id, quantity) {
    const key = products.findIndex((item) => item.id === id);
    if (quantity == 0) {
      delete listCards[key];
    } else {
      listCards[key].quantity = quantity;
      listCards[key].price = quantity * products[key].price;
    }
    reloadCard();
  }