import React from "react";
import contain from '../asset/css/Container.module.css';
import Listproduct from "./Listproduct";

export default function LaptopDisplay(){
    return(
        <>
  <div id={contain.promotion}>
    <p>Khuyến mãi hot</p>
    <div id={contain.list_product}>
      <Listproduct/>
    </div>
  </div>
  <div id={contain.discout_weekend}>
    <div className={contain.image}>
      <img src="images/apple-discount.png" alt="" />
      <img src="images/phone-discount.png" alt="" />
      <img src="images/laptop-discount.png" alt="" />
      <img src="images/houseware-discount.png" alt="" />
    </div>
    <div className={contain.buy_now}>MUA NGAY</div>
  </div>
  <img src="images/slode-laptop.webp" alt="" id={contain.banner}/>
  <div id={contain.ads}>
    <img src="images/card.png" alt="" />
    <img src="images/ads.png" alt="" />
    <img src="images/ads2.png" alt="" />
  </div>
</>

    )
}