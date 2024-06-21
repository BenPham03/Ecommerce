import admin from "../asset/css/Admin.module.css"
export default function BillManagement() {
  return (
    <>
      <div id={admin.right}>
        <p>
          <i className={`${admin.icon} ti-arrow-circle-right`} /> Quản lý hóa đơn bán
        </p>
        {/* <input type="button" value="thêm mới">
      <input type="button" value="xóa nhiều"> */}
        <table id={admin.tb}>
          <thead>
            <tr>
              <th>STT</th>
              {/* <th><input type="checkbox" name="" id{admin.="></}h> */}
              <th>Mã khách hàng</th>
              <th>Tên Khách Hàng</th>
              <th>Mã sản phẩm</th>
              <th>Tên sản phẩm</th>
              <th>Ngày thanh toán</th>
              {/* <th>Xem</th>
                  <th>Sửa </th>
                  <th>Xóa</th> */}
            </tr>
          </thead>
          <tbody id={admin.tt}></tbody>
        </table>
      </div>
    </>
  );
}
