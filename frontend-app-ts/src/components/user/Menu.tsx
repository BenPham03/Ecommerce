import React from "react";
import menu from '../asset/css/Menu.module.css'
import { Link } from "react-router-dom";

export default function Menu(){
    return(
        <div id={menu.menu}>
  <ul className={menu.nav}>
    <li>
      <i className={`${menu.icon} ti-mobile`} />
      <Link to="/latoppage">Laptop</Link>
    </li>
    <li>
      <i className={`${menu.icon} icon ti-tablet`} />
      <a href="">Máy tính bảng</a>
    </li>
    <li>
      <i className={`${menu.icon}  ti-apple`} />
      <a href="">Apple</a>
    </li>
    <li>
      <i className={`${menu.icon}  ti-blackboard`} />
      <a href="">Pc-Linh kiện</a>
    </li>
    <li>
      <i className={`${menu.icon}  ti-headphone`} />
      <a href="">Phụ kiện</a>
    </li>
    <li>
      <i className={`${menu.icon}  ti-reload`} />
      <a href="">Máy cũ giá rẻ</a>
    </li>
    {/* <li><i class="icon ti-home"></i><a href="">Hàng gia dụng</a></li> */}
    {/* <li><i class="icon ti-save-alt"></i><a href="">Sim thẻ</a></li> */}
    <li>
      <i className={`${menu.icon} ti-settings`} />
      <a href="">Khuyến mãi</a>
      <ul className={menu.subnav}>
        <li>
          <a href="">Thông tin trao thưởng</a>
        </li>
        <li>
          <a href="">Tất cả khuyến mãi</a>
        </li>
      </ul>
    </li>
  </ul>
</div>

    )
}