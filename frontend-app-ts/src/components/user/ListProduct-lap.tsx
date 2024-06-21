import laptop from '../asset/css/Laptop.module.css';
import { useEffect, useState } from 'react';
import Product_Lap from './Product-Lap';
import { useNavigate } from 'react-router-dom';

const getItemsLocalStorage = () =>
  JSON.parse(localStorage['cart'] || '[]').filter(Boolean);

export default function () {
  const navigate = useNavigate()
  const [products, setProducts] = useState<any[]>([]);
  const [cart, setCart] = useState<any[]>([]);

  useEffect(() => {
    (async () => {
      const res = await fetch('http://localhost:5105/api/product');
      const data = await res.json();
      const cartItems = getItemsLocalStorage();
      setCart(cartItems);
      setProducts(data);
    })();
  }, []);

  //add to cart
   //[]
   const login = localStorage.getItem("login")

  function addToCard(key: any, id: any) {
    if(login == "0"  || !login){
      navigate("/signIn")
    }
    else{
    let listCards = getItemsLocalStorage();
    console.log(cart)

    setCart(listCards);
    console.log(cart)
    let count =0;
    for(var i=1; i>=-1;i++){
      if(listCards[i] == null){
        count = i;
        console.log(i)
        break
      }
    }
    if (listCards[count] == null && listCards.findIndex((item:any) => item.id === id) ==-1) {
      // copy product form list to list card

      listCards[count] = products[key];
      listCards[count]['count'] = 1;
      listCards[count]['totalP'] = products[key]['price'];
      console.log(listCards[key])
      // listCards[key].quantity = 1;
      // key += 1;
    }
    localStorage.setItem("cart", JSON.stringify(listCards.filter(Boolean)));
    // console.log(listCards[key])
    setCart(listCards);
  }
}
  useEffect(() => {
    const interval = setInterval(() => {
      const items = getItemsLocalStorage();
      setCart(items);
    }, 500); // 0.5s

    return () => clearInterval(interval);
  }, [localStorage]);
  return (
    <>
      <div className={laptop.rightsite}>
        {/* <div class="brand">
              <h1>Laptop</h1><h3>(235 sản phẩm)</h3>

          </div> */}
        <div className={laptop.Laptop_Follow_Demand}>
          <b>Laptop theo nhu cầu</b>
          <div className={laptop.listdemand}>
            <div className={laptop.gaming}>
              <a href="">
                <img src="images/gaming.webp" alt="" />
                <h2>Gaming</h2>
              </a>
            </div>
            <div className={laptop.gaming}>
              <a href="">
                <img src="images/sv-vp.webp" alt="" />
                <h2>Sinh viên - Văn phòng</h2>
              </a>
            </div>
            <div className={laptop.gaming}>
              <a href="">
                <img src="images/design.webp" alt="" />
                <h2>Thiết kế đồ họa</h2>
              </a>
            </div>
            <div className={laptop.gaming}>
              <a href="">
                <img src="images/mong.webp" alt="" />
                <h2>Mỏng nhẹ</h2>
              </a>
            </div>
            <div className={laptop.gaming}>
              <a href="">
                <img src="images/bss.webp" alt="" />
                <h2>Doanh nhân</h2>
              </a>
            </div>
          </div>
        </div>
        <div className={laptop.list}>
          <div id={laptop.promotionLap}>
            <p>Danh sách sản phẩm</p>
            <div id={laptop.list_product}>
              {products.map((prod, index) => (
                <Product_Lap
                  key={prod.id}
                  data={prod}
                  onClick={() => addToCard(index, prod.id)}
                />
              ))}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
