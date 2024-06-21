import React from "react";
import admin from "../asset/css/Admin.module.css"
import icon from "../asset/font/themify-icons-font/themify-icons/themify-icons.module.css"
import { Link } from "react-router-dom";


export default function AdminHeader() {
  return (
    <>
      <div id={admin.header}>
        <p className={`${admin.text} ${admin.ad}`}>ADMIN</p>
        <div className={admin.sign_out}
        onClick={()=>{localStorage.setItem("login", "0")}}>
          <i className={`${admin.text} ${admin.sign_out_icon} ti-power-off`}
           />
          <Link to="/" className={admin.text}>
            Đăng xuất
            </Link>
        </div>
        <b>Hệ thông quản trị nội dung</b>
        <hr id={admin.blue} />
        <hr id={admin.red} />
      </div>
      <hr id={admin.blue}/>
        <hr id ={admin.red}/>
        </>
  );
}
