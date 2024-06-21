import laptop from "../src/components/asset/css/Laptop.module.css";

let listCard = document.getElementById(`${laptop.listCard}`);
console.log(1);  
function reloadCard() {
    //@ts-ignore
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

    //@ts-ignore

      listCard.appendChild(newDiv);
    });
    //@ts-ignore

    total.innerText = totalPrice.toLocaleString();
    console.log(quantity)
    //@ts-ignore

    quantity.innerText = count;
    localStorage["cart"] = JSON.stringify(listCards);
  }