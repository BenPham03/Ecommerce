import { useEffect, useState } from "react";
import admin from "../asset/css/Admin.module.css";
import ProductModal from "./ProductModal";
import ProductCreateModal from "./ProductCreateModal";

export default function () {
  const [products, setProducts] = useState<any[]>([]);
  useEffect(() => {
    (async () => {
      const res = await fetch("http://localhost:5105/api/product");
      const data = await res.json();
      setProducts(data);
    })();
  }, []);
  const deleteProduct = async (e:number) =>{
    const Delete = await fetch(`http://localhost:5105/api/product/delete/${e}`,{
      method: 'DELETE'
    })
    // const b = await Delete.json()
    console.log(Delete.status)
    const res = await fetch("http://localhost:5105/api/product");
      const data = await res.json();
      setProducts(data);
  }
  // useEffect(()=>{
  //     var listProduct="";
  //         let count =0

  //         for(let i =0 ;i<products.length; i++){

  //             count+=1;
  //             var newDiv = "";
  //             // let newDiv = document.createElement("tr");
  //             newDiv = `
  //                         <tr>
  //                             <td>`+products[i]["id"]+`</td>
  //                             <td>`+products[i]["name"]+`</td>
  //                             <td>`+products[i]["price"]+`</td>
  //                             <td>`+products[i]["quantity"]+`</td>
  //                             <td>`+products[i]["status"]+`</td>
  //                             <td>`+products[i]["imageURL"]+`</td>
  //                             <td>`+products[i]["categoryId"]+`</td>
  //                         </tr>
  //                     `;
  //                     // console.log(newDiv)
  //         listProduct+=newDiv
  //         // console.log(listProduct)

  //         }
  //         // console.log(listProduct)
  //         //@ts-ignore
  //         document.querySelector(`.${admin.tt}`).innerHTML = listProduct;
  //         console.log(document.querySelector(`.${admin.tt}`))

  // })

  const updateState = (item:any) => {
    console.log(item)
    const { name, value } = item;
    setProducts((prevState) => ({
      ...prevState,
      [name]: value,
  }
));
};
  return (
    <>
      <div id={admin.right}>
        <p>
          <i className={`${admin.icon} ti-arrow-circle-right`} /> Quản lý sản
          phẩm
        </p>
        {/* <input type="button" value="thêm mới">
      <input type="button" value="xóa nhiều"> */}
        <table id={admin.tb}>
          <thead>
            <tr>
              <th>Mã sản phẩm</th>
              {/* <th><input type="checkbox" name="" id{admin.="></}h> */}
              <th>Tên sản phẩm</th>
              <th>Giá bán</th>
              <th>Số lượng</th>
              <th>Trạng thái</th>
              <th>Ảnh</th>
              <th>Mã danh mục</th>
              {/* <th>Thêm</th> */}
              <th>Thêm </th>
              <th>Sửa </th>
              <th>Xóa</th>
            </tr>
          </thead>
          <tbody className={admin.tt}>
            {products.map((prod) => (
              // <div >
                <tr>
                <td>{prod.id}</td>
                <td style={{width : "250px"}}>{prod.name}</td>
                <td>{prod.price}</td>
                <td>{prod.quantity}</td>
                <td>{prod.status}</td>
                <td>{prod.imageURL}</td>
                <td>{prod.categoryId}</td>
                {/* <td><button className="ti-plus"></button></td> */}
                <td>
                <ProductCreateModal buttonLabel="Thêm" detail ={prod} updateState = {updateState}/></td>
                <td>
                <ProductModal buttonLabel="Sửa" detail ={prod} updateState = {updateState}/></td>

                <td><button className="ti-minus"onClick={()=>{deleteProduct(prod.id)}}></button></td>
              </tr>
              // </div>
              
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
}
