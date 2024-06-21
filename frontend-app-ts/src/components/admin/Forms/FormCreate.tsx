import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

function AddEditForm(props :any) {
  const navigate = useNavigate()
  const [name, setName] = useState("");
  const [price, setPrice] = useState(0)
  const [quantity, setQuantity] = useState(0)
  const [status, setStatus] = useState("")
  const [imageURL, setImg] = useState("")
  const [catId, setCategoryId] = useState(0)
  const [form, setValues] = useState({
    id:0,
    name: "",
    price: 0,
    quantity: 0,
    status: "",
    imageURL: "",
    categoryId: 0
  });
  interface prodDto{
    name: string,
  price: number,
  quantity: number,
  status: string,
  imageURL: string,
}

  
useEffect(()=>{

},[])

const updateProd = async () => {

  const prod:prodDto ={
    name: name,
    price: price,
    quantity: quantity,
    status: status,
    imageURL: imageURL,
  }
  const res = await fetch(`http://localhost:5105/api/product/${catId}`,
      {method:"POST",
      headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(prod),
      }
      
  );
  const data = await res.json();
  if (res.ok) {
      alert('Thêm sản phẩm thành công!');
      navigate('/admin')
      // props.updateState(form)
  } else {
      alert('Failed to update. Error: ' + res.status);
  }
};
  return (
    <Form onSubmit={()=>{}}>
      
      <FormGroup>
        <Label for="name">Tên sản phẩm</Label>
        <Input
          type="text"
          name="name"
          id="name"
          onChange={(e)=>{setName(e.target.value)}}
        />
      </FormGroup>
      <FormGroup>
        <Label for="price">Giá bán</Label>
        <Input
          type="text"
          name="price"
          id="price"
          onChange={(e)=>{setPrice(parseInt(e.target.value))}}

        />
      </FormGroup>
      <FormGroup>
        <Label for="quantity">Số lượng</Label>
        <Input
          type="text"
          name="quantity"
          id="quantity"
          onChange={(e)=>{setQuantity(parseInt(e.target.value))}}

        />
      </FormGroup>
      <FormGroup>
        <Label for="status">Trạng thái</Label>
        <Input
          type="text"
          name="status"
          id="status"
          onChange={(e)=>{setStatus(e.target.value)}}


          placeholder="Enable or Disnable"
        />
      </FormGroup>
      <FormGroup>
        <Label for="imageURL">Ảnh</Label>
        <Input
          type="text"
          name="imageURL"
          id="imageURL"
          onChange={(e)=>{setImg(e.target.value)}}



        />
      </FormGroup>
      <FormGroup>
        <Label for="catId">Mã danh mục</Label>
        <Input
          type="text"
          name="categoryId"
          id="catId"
          onChange={(e)=>{setCategoryId(parseInt(e.target.value))}}

        />
      </FormGroup>
      <Button onClick={updateProd}>Submit</Button>
    </Form>
  );
}

export default AddEditForm;
