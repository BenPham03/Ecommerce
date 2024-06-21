import admin from "../asset/css/Admin.module.css"
import icon from "../asset/font/themify-icons-font/themify-icons/themify-icons.module.css"
export default function AdminCategory(){
    return(
        <>
            <div id={admin.left}>
  <ul id={admin.nav}>
    <li>
      <a>Trang chủ </a>
    </li>
    <li className="nav-down">
      <a>
        Bán hàng <i className="nav-down-arrow ti-angle-down" />
      </a>
      {/* <i class="fa-solid fa-chevron-down"></i> */}
      <ul className={admin.subnav}>
        <li>
          <a>Hoá đơn bán</a>
        </li>
        <li>
          <a>Khách hàng</a>
        </li>
      </ul>
    </li>
    <li className="nav-down">
      <a>
        Nhập hàng <i className="nav-down-arrow ti-angle-down" />
      </a>
      <ul className={admin.subnav}>
        <li>
          <a>Hóa đơn nhập</a>
        </li>
        <li>
          <a>Hãng sản xuất</a>
        </li>
        <li>
          <a>Nhà cung cấp</a>
        </li>
      </ul>
    </li>
    <li className="nav-down">
      <a>
        Danh mục <i className="nav-down-arrow ti-angle-down" />
      </a>
      <ul className={admin.subnav}>
        <li>
          <a>Sản phẩm</a>
        </li>
        <li>
          <a>Chuyên mục</a>
        </li>
        <li>
          <a>Slide show</a>
        </li>
        <li>
          <a>Quảng cáo</a>
        </li>
        <li>
          <a>Người dùng</a>
        </li>
        <li>
          <a>Tài khoản</a>
        </li>
      </ul>
    </li>
  </ul>
</div>

        </>
    )
}