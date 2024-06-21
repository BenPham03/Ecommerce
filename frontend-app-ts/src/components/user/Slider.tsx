import React from "react";
import container from '../asset/css/Container.module.css'
// import '../asset/img/bg-banner.png'

export default function Slider(){
    return(
        <div id={container.slider}>
  <div id={container.left_site}>
    <img className={container.img} src="images/AssusSlide.webp" alt="" />

    <i className={`${container.icon1} ti-angle-left`} />
    <i className={`${container.icon2} ti-angle-right`}/>
    <p className={container.title}>Mở bán Galaxy A34| A54 5G tặng quà xịn</p>
    <p className={container.title}>iPhone 14 Pro Max giảm đến 8,5 triệu</p>
    <p className={container.title}>Đặt trước Redmi Note 12 ưu đãi 2.89 triệu</p>
    <p className={container.title}>Đặt trước Find N2 Flip ưu đãi 5 triệu</p>
    <p className={container.title}>Sắm Robot Ecovacs N10 ngay</p>
  </div>
  <div id={container.right_site}>
    <img src="/images/airpods2.png" alt="" />
    <img src="/imgages/applewatch2.webp" alt="" />
    <p className={container.label}>Tin khuyến mãi</p>
    <p className={container.view_all}>Xem tất cả</p>
    <div className={container.discount_product}>
      <img src="/images/laptop_msi.png" alt="" />
      <p className={container.content}>Laptop MSI đồng loạt giảm từ 10% - 20%</p>
    </div>  
    <div className={container.discount_product}>
      <img src="/images/samsung.png" alt="" />
      <p className={container.content}>Samsung ưu đãi 500k qua VNPAY – QR</p>
    </div>
  </div>
</div>

    )
}