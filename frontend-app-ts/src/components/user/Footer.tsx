import React from "react";
import contain from '../asset/css/Container.module.css'

export default function Footer(){
    return(
    <>
  <div id={contain.footer}>
    <div className={contain.content}>
      <ul>
        <li>
          <a href="">Giới thiệu về công ty</a>
        </li>
        <li>
          <a href="">Chính sách bảo mật</a>
        </li>
        <li>
          <a href="">Quy chế hoạt động</a>
        </li>
        <li>
          <a href="">Kiểm tra hóa đơn điện tử</a>
        </li>
        <li>
          <a href="">Tra cứu thông tin bảo hành</a>
        </li>
        <li>
          <a href="">Câu hỏi thường gặp mua hàng</a>
        </li>
      </ul>
      <img src="images/ft-img1.png" alt="" />
      <img src="images/ft-img2.png" alt="" />
    </div>
    <div className={contain.content}>
      <ul>
        <li>
          <a href="">Tin tuyển dụng</a>
        </li>
        <li>
          <a href="">Tin khuyến mãi</a>
        </li>
        <li>
          <a href="">Hướng dẫn mua online</a>
        </li>
        <li>
          <a href="">Hướng dẫn mua trả góp</a>
        </li>
        <li>
          <a href="">Chính sách trả góp</a>
        </li>
      </ul>
      <p>Chứng nhận:</p>
      <img src="/images/ft-img3.png" alt="" />
      <img src="/images/ft-img4.png" alt="" />
      <img src="/images/ft-img5.png" alt="" />
    </div>
    <div className={contain.content}>
      <ul>
        <li>
          <a href="">Hệ thống cửa hàng</a>
        </li>
        <li>
          <a href="">Chính sách đổi trả</a>
        </li>
        <li>
          <a href="">Hệ thống bảo hành</a>
        </li>
        <li>
          <a href="">Giới thiệu máy đổi trả</a>
        </li>
      </ul>
    </div>
    <div className={contain.content}>
      <ul>
        <li className={contain.hotline}>
          <h1>Tư vấn mua hàng (Miễn phí)</h1>
          <a href="" className="hl">
            1800 6601 <span>(Nhánh 1)</span>
          </a>
        </li>
        <li className={contain.hotline}>
          <h1>Hỗ trợ kỹ thuật</h1>
          <a href="">
            1800 6601 <span>(Nhánh 2)</span>
          </a>
        </li>
        <li className={contain.hotline}>
          <h1>Góp ý, khiếu nại (8h00 - 22h00)</h1>
          <a href="">1800 6616 </a>
        </li>
      </ul>
      <p>Hỗ trợ thanh toán:</p>
      <img className={contain.ft} src="/images/ft-img6.png" alt="" />
      <img className={contain.ft} src="/images/ft-img7.png" alt="" />
      <img className={contain.ft} src="/images/ft-img8.png" alt="" />
      <img className={contain.ft} src="/images/ft-img9.png" alt="" />
      <img className={contain.ft} src="/images/ft-img8.png" alt="" />
      <img className={contain.ft} src="/images/ft-img11.png" alt="" />
    </div>
    <div className={contain.content}>
      <h2>Website cùng FPT Retail:</h2>
      <p style={{ marginTop: 20 }}>Cửa hàng uỷ quyền bởi Apple:</p>
      <img
        style={{ height: "24.5px", marginTop: 10 }}
        src="/images/ft-img16.png"
        alt=""
      />
      <p style={{ marginTop: 15 }}>Trung tâm bảo hành uỷ quyền Apple:</p>
      <img
        style={{ height: "24.5px", marginTop: 10 }}
        src="/images/ft-img17.png"
        alt=""
      />
      <p style={{ marginTop: 15 }}>Chuỗi nhà thuốc:</p>
      <img
        style={{ height: "24.5px", marginTop: 10 }}
        src="/images/ft-img18.png"
        alt=""
      />
    </div>
  </div>
  <div id={contain.last}>
    <p>
      © 2007 - 2023 Công Ty Cổ Phần Bán Lẻ Kỹ Thuật Số FPT / Địa chỉ: 261 - 263
      Khánh Hội, P5, Q4, TP. Hồ Chí Minh / GPĐKKD số 0311609355 do Sở KHĐT
      TP.HCM cấp ngày 08/03/2012.
    </p>
    <p style={{ marginTop: 5 }}>
      GP số 47/GP-TTĐT do sở TTTT TP HCM cấp ngày 02/07/2018. Điện thoại:{" "}
      <span>(028) 7302 3456</span>. Email: <span>fptshop@fpt.com.vn</span>. Chịu
      trách nhiệm nội dung: Nguyễn Trịnh Nhật Linh.
    </p>
  </div>
</>
    )

}