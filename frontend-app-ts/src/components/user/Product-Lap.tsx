import laptop from "../asset/css/Laptop.module.css";

export default function Product_Lap(props :any){
    return(
        <>
        <div className={laptop.product1}>
          <img className={laptop.image} src={props.data.imageURL} alt="" />
          <p className={laptop.txt1}>Trả góp 0%</p>
          <p className={laptop.txt2}>Giảm 6.000.000đ</p>
          <h1>
            {props.data.name}
          </h1>
          <div className={laptop.price}>
            <p />
            <div className={laptop.num}>{props.data.price}</div>{" "}
            <div className={laptop.unit}>
              <u>đ</u>
            </div>
            <p />
          </div>
          <div className={laptop.old_price}>
            30.990.000 <span>đ</span>
          </div>
          <button onClick={props.onClick} >Thêm vào giỏ hàng</button>`;
          <img className={laptop.mini_p} src="images/mini-p1.png" alt="" />
          <img className={laptop.mini_p} src="images/mini-p2.png" alt="" />
          <img className={laptop.mini_p} src="images/mini-p3.png" alt="" />
          <p className={laptop.give}>Tặng 500K mua robot hút bụi/máy lọc nước</p>
        </div>
        </>
    )
}