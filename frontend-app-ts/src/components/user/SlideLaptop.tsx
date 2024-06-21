// import "../asset/css/Laptop.css"

import { useState } from "react";
import laptop from "../asset/css/Laptop.module.css";
var img = [
  "images/slidelap1.webp",
  "images/slidelap2.webp",
  "images/slidelap3.webp",
  "images/slidelap4.webp",
  "images/slidelap5.webp",
  "images/slidelap6.webp",
  "images/slidelap7.webp",
  "images/slidelap8.webp",
  "images/slidelap9.webp",
  "images/slidelap10.webp",
];
export default function SlideLaptop() {
  // console.log(1);
  const [src, setSrc] = useState(0);

  return (
    <>
      <div id={laptop.slide_show}>
        <div className={laptop.main}>
          {/* <img className{"img-feature" src="images/slidelap1.webp" /> */}
          {img.map((i, index) => (index === src ? <img key={index} src={i} height={300}/> : null))}
          <i
            className ={`${laptop.icon1} ti-angle-left`}
            onClick={() => {
              setSrc(index => index < img.length-1 ? ++index: 0)
              }}
          />
          <i className= {`${laptop.icon2} ti-angle-right`} onClick={() => {
              setSrc((index) => (index < img.length-1 ? index + 1 : 0));
            }}/>
        </div>
        <div className={laptop.list_img}>
          {/* <div className="active">
            <img src="images/slidelap1.webp" alt="" />
          </div> */}
          {/* <img src="images/slidelap2.webp" />
          <img src="images/slidelap3.webp" />
          <img src="images/slidelap4.webp" />
          <img src="images/slidelap5.webp" />
          <img src="images/slidelap6.webp" />
          <img src="images/slidelap7.webp" />
          <img src="images/slidelap8.webp" />
          <img src="images/slidelap9.webp" />
          <img src="images/slidelap10.webp" />  */}
        </div>
      </div>
    </>
  );
}
