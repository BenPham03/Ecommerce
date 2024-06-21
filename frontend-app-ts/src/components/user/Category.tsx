import React from "react";
import contain from '../asset/css/Container.module.css'

export default function Category(){
    return(
        <>
  <div id={contain.category}>
    <div className={contain.product}>
      <img src="/images/phone.png" alt="" />
      <p>Điện thoại</p>
    </div>
    <div className={contain.product}>
      <img src="/images/laptop.png" alt="" />
      <p>Laptop</p>
    </div>
    <div className={contain.product}>
      <img src="/images/pc.png" alt="" />
      <p>PC-Lắp ráp</p>
    </div>
    <div className={contain.product}>
      <img src="/images/tablet.png" alt="" />
      <p>Máy tính bảng</p>
    </div>
    <div className={contain.product}>
      <img src="/images/smart-device.png" alt="" />
      <p>Thiết bị thông minh</p>
    </div>
    <div className={contain.product}>
      <img src="/images/houseware.png" alt="" />
      <p>Gia dụng</p>
    </div>
  </div>
  <div id={contain.category}>
    <div className={contain.product}>
      <img src="/images/apple.png" alt="" />
      <p>Apple</p>
    </div>
    <div className={contain.product}>
      <img src="/images/samsung1.png" alt="" />
      <p>Samsung</p>
    </div>
    <div className={contain.product}>
      <img src="/images/smartwatch.png" alt="" />
      <p>Đồng hood thông minh</p>
    </div>
    <div className={contain.product}>
      <img src="/images/accessories.png" alt="" />
      <p>Phụ kiện</p>
    </div>
    <div className={contain.product}>
      <img src="/images/screen.png" alt="" />
      <p>Màn hình</p>
    </div>
    <div className={contain.product}>
      <img src="/images/old-device.png" alt="" />
      <p>Máy cũ</p>
    </div>
  </div>
  <img id={contain.banner} src="/images/banner.png" alt=""></img>

</>

    )
}