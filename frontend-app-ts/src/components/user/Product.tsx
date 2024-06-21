import { Link } from "react-router-dom"
import contain from "../asset/css/Container.module.css"
export default function Product(props: any) {
    return(
        <>
        
        <div className={contain.productItem}>
        <img className={contain.image} src={props.data.imageURL} alt="" />
        <p className={contain.txt1}>Trả góp 0%</p>
        <p className={contain.txt2}>Giảm 6.000.000đ</p>
        <Link className={contain.lin} to='/productDetail' state={{id:props.data.detailProductId}}>
        <h1>
          {props.data.name}
        </h1>
        </Link>
        
        
        <div className={contain.price}>

          <div className={contain.num}>{props.data.price}</div>{" "}
          <div className={contain.unit}>
            <u>đ</u>
          </div>
          
        </div>
        <div className={contain.old_price}>30.990.000 <span>đ</span></div>
                <img className={contain.mini_p} src="images/mini-p1.png" alt=""/>
                <img className={contain.mini_p} src="images/mini-p2.png" alt=""/>
                <img className={contain.mini_p} src="images/mini-p3.png" alt=""/>
                <p className={contain.give}>Tặng 500K mua robot hút bụi/máy lọc nước</p>
        </div>
        </>
    )
}