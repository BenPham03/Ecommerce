import React, { useEffect, useState } from "react";
import Product from "./Product";


export default function Listproduct(){
  useEffect(() => {
    ( async () => {
    const res = await fetch('http://localhost:5105/api/product?PageNumber=1&PageSize=4');
    const data = await res.json();
    setProducts(data);
    })()
    }, [])

    const [products, setProducts] = useState<any[]>([])
    console.log(products)
    return (
      
        <>
        {products.map(prod => <Product key={prod.id} data={prod}/>)}
            {/* <div className="product1">
        <img className="image" src="images/caymt.webp" alt="" />
        <p className="txt1">Trả góp 0%</p>
        <p className="txt2">Giảm 6.000.000đ</p>
        <h1>
          PC E-Power Office 12 Core i3 10105 3.7 GHz - 4.4 GHz / 8GB / 240GB /
          250W
        </h1>
        <div className="price">
          <p />
          <div className="num">6.390.000</div>{" "}
          <div className="unit">
            <u>đ</u>
          </div>
          <p />
        </div>
        <div className="old-price">
          30.990.000 <span>đ</span>
        </div>
        <img className="mini-p" src="images/mini-p1.png" alt="" />
        <img className="mini-p" src="images/mini-p2.png" alt="" />
        <img className="mini-p" src="images/mini-p3.png" alt="" />
        <p className="give">Tặng 500K mua robot hút bụi/máy lọc nước</p>
      </div>
      <div className="product1">
        <img className="image" src="images/vivobook.webp" alt="" />
        <p className="txt1">Trả góp 0%</p>
        <p className="txt2">Giảm 9.000.000đ</p>
        <h1>Asus Vivobook E1404FA-NK186W R5 7520U</h1>
        <div className="price">
          <p />
          <div className="num">31.990.000</div>{" "}
          <div className="unit">
            <u>đ</u>
          </div>
          <p />
        </div>
        <div className="old-price">
          40.990.000 <span>đ</span>
        </div>
        <img className="mini-p" src="images/mini-p1.png" alt="" />
        <img className="mini-p" src="images/mini-p2.png" alt="" />
        <img className="mini-p" src="images/mini-p3.png" alt="" />
        <p className="give">Giảm ngay 600.000đ khi mở thẻ TPBANK EVO</p>
      </div>
      <div className="product1">
        <img className="image" src="images/HP.webp" alt="" />
        <p className="txt1">Trả góp 0%/0đ</p>
        <p className="txt2">Giảm 1.700.000đ</p>
        <h1>Máy tính xách tay HP 245 G9 R5</h1>
        <div className="price">
          <p />
          <div className="num">8.990.000</div>{" "}
          <div className="unit">
            <u>đ</u>
          </div>
          <p />
        </div>
        <div className="old-price">
          10.690.000 <span>đ</span>
        </div>
        <img className="mini-p" src="images/mini-p1.png" alt="" />
        <img className="mini-p" src="images/mini-p2.png" alt="" />
        <img className="mini-p" src="images/mini-p3.png" alt="" />
        <p className="give">Tặng Samsung Care +</p>
      </div>
      <div className="product1">
        <img className="image" src="images/asus.png" alt="" />
        <p className="txt1">Trả góp 0%</p>
        <p className="txt2">Giảm 3.500.000đ</p>
        <h1>Asus TUF Gaming FX506LHB-HN188W i5 10300Hb</h1>
        <div className="price">
          <p />
          <div className="num">17.490.000</div>{" "}
          <div className="unit">
            <u>đ</u>
          </div>
          <p />
        </div>
        <div className="old-price">
          20.990.000 <span>đ</span>
        </div>
        <img className="mini-p" src="images/mini-p1.png" alt="" />
        <img className="mini-p" src="images/mini-p2.png" alt="" />
        <img className="mini-p" src="images/mini-p3.png" alt="" />
        <p className="give">Tặng 500K mua robot hút bụi/máy lọc nước</p>
      </div> */}
        </>
    )
}