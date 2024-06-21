import React, { useEffect, useState } from "react";
import "../asset/css/Header.module.css";
import header from "../asset/css/Header.module.css";
import laptop from "../asset/css/Laptop.module.css";
import "../asset/font/themify-icons-font/themify-icons/themify-icons.css";
import { Link, useNavigate } from "react-router-dom";

const getItemsLocalStorage = () => {
  return JSON.parse(localStorage["cart"] || "[]").filter(Boolean);
};

export default function Header() {
  const [products, setProducts] = useState<any[]>([]);
  const [cart, setCart] = useState<any[]>([]);
  let login = localStorage.getItem('login')
  let navigate = useNavigate()
  function changeQuantity(id: any, count: any) {
    const key = cart.findIndex((item) => item.id === id);
    if (count == 0) {
      const newCart = cart.filter((item) => item.id !== id);
      setCart(newCart);

      localStorage.setItem("cart", JSON.stringify(newCart));
      // if(newCart.length==0){
      // console.log(cart)
      //   localStorage.clear();
      // }
    } else {
      cart[key].count = count;
      cart[key].totalP = count * products[key].price;
      localStorage.setItem("cart", JSON.stringify(cart.filter(Boolean)));
    }
    loadTotal();
    const cartItems = getItemsLocalStorage();
    setCart(cartItems);
    console.log(cart)

  }

  useEffect(() => {
    (async () => {
      const res = await fetch("http://localhost:5105/api/product");
      const data = await res.json();
      const cartItems = getItemsLocalStorage();
      setCart(cartItems);
      setProducts(data);
      // console.log(cartItems)
    })();
  }, []);
  useEffect(() => {
    const interval = setInterval(() => {
      const items = getItemsLocalStorage();
      setCart(items);
    }, 500); // 0.5s

    return () => clearInterval(interval);
  }, [localStorage]);

  const loadTotal = () => {
    let total = document.querySelector(`.${laptop.total}`);
    let totalPrice = 0;
    cart.filter(Boolean).forEach((value: any) => {
      totalPrice = totalPrice + value.price * value.count;
    });
    if (total) {
      //@ts-ignore
      total.innerText = totalPrice.toLocaleString();
    }
  };
  loadTotal();
  interface BillDTO {
    totalPrice: number;
    discount: number;
  }
  interface BillInfoDTO {
    count: number;
  }

  const payment = async (e: any) => {
    if(cart.length != 0){
    let ttp = 0;
    cart.forEach((e) => {
      ttp += e.totalP;
    });
    if (e != null) {
      const cus = localStorage.getItem("CustomerId");
      const billDTO: BillDTO = {
        totalPrice: ttp,
        discount: 1
      };
      const createBillDTO = await fetch(`http://localhost:5105/api/bill/${cus}/4`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(billDTO),
      });
      const bill = await createBillDTO.json();
      console.log(bill);
      cart.forEach(async (e) => {
        if (e != null) {
          const billInfoDTO: BillInfoDTO = {
            count: e.count,
          };
          const createBillInfoDTO = await fetch(`http://localhost:5105/api/billInfo/${bill.id}/${e.id}`, {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(billInfoDTO),
          });
          const billInfo = await createBillInfoDTO.json();
      console.log(billInfo);
        }
      });
    }
    alert("Thanh toán thành công")
    localStorage.setItem("cart","")
  }
  };

  return (
    <div id={header.nav1}>
      <Link to="/">
        <img className={header.im} src="/images/logo.png" alt="" />
      </Link>
      <input type="text" placeholder="Nhập tên phụ kiện cần tìm" />
      <button className={header.search_btn}>
        <i className={`${header.icon} ti-search`} />
      </button>
      <ul id={header.convinient}>
        <li>
          <a href="">
            <i className={`${header.icon1} ti-save`} />
            Thông tin hay
          </a>
          <ul className={header.sub_conv}>
            <li>
              <a href="">Tin mới</a>{" "}
            </li>
            <li>
              <a href="">Khuyến mãi</a>{" "}
            </li>
            <li>
              <a href="">Điện máy-Gia dụng</a>{" "}
            </li>
            <li>
              <a href="">Thủ thuật</a>
            </li>
            <li>
              <a href="">For Gamers</a>
            </li>
            <li>
              <a href="">Video hot</a>
            </li>
            <li>
              <a href="">Đánh giá-tư vấn</a>
            </li>
            <li>
              <a href="">App & Game</a>
            </li>
            <li>
              <a href="">Sự Kiện</a>
            </li>
          </ul>
        </li>
        <li>
          <a href="">
            <i className={`${header.icon1} ti-bookmark-alt`} />
            Thanh toán &amp; tiện ích
          </a>
        </li>
        <li
        onClick={()=>{
          if(login == '0' || !login){
            navigate('/SignIn')
          }
          else{navigate('/accountDetail')}
          
        }}>
            <i className={`${header.icon1} ti-user`} />
            Tài khoản của tôi
        </li>
        <li
          className={laptop.shopping}
          onClick={() => {
            document.body.classList.add(`${laptop.actives}`);
          }}
        >
          <i className={`${header.icon1} ti-shopping-cart`} />
          Giỏ hàng
        </li>
      </ul>
      <div className={laptop.card}>
        <h1>Card</h1>
        <ul className={laptop.listCard}>
          {cart.map((product) => (
            <li key={product.id}>
              <div>
                <img className={laptop.im} src={product.imageURL} />
              </div>
              <div>{product.name}</div>
              <div>{product.totalP.toLocaleString()}</div>
              <div>
                <button
                  onClick={() => changeQuantity(product.id, product.count - 1)}
                >
                  -
                </button>
                <div className={laptop.count}>{product.count}</div>
                <button
                  onClick={() => changeQuantity(product.id, product.count + 1)}
                >
                  +
                </button>
              </div>
            </li>
          ))}
        </ul>
        <div className={laptop.checkout}>
          <div className={laptop.total}>0</div>
          <div
            className={laptop.closeShopping}
            onClick={() => {
              document.body.classList.remove(`${laptop.actives}`);
            }}
          >
            Close
          </div>
          <div id={laptop.pa} onClick={payment} >
            <p style={{marginLeft:"160px"}}>Thanh</p>
             
          </div>
          <div id={laptop.pa} onClick={payment}>
          <p style={{marginLeft:"5px"}}>toán</p>
            
          </div>
        </div>
      </div>
    </div>
  );
}
