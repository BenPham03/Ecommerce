import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

function AddEditForm(props :any) {
  const navigate = useNavigate()
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
  categoryId: number
}
  const onChange = (e: any) => {
    const { name, value } = e.target;
    setValues((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };
  
useEffect(()=>{
  console.log(props.detail)
  setValues(props.detail)
},[])

const updateProd = async () => {

  const prod:prodDto ={
    name: form.name,
    price: form.price,
    quantity: form.quantity,
    status: form.status,
    imageURL: form.imageURL,
    categoryId: form.categoryId
  }
  const res = await fetch(`http://localhost:5105/api/product/update/${form.id}`,
      {method:"PUT",
      headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(prod),
      }
      
  );
  const data = await res.json();
  if (res.ok) {
      alert('Update thành công!');
      navigate('/admin')
      setValues(data)
      // props.updateState(form)
  } else {
      alert('Failed to update. Error: ' + res.status);
  }
};
  return (
    <Form onSubmit={()=>{}}>
      <FormGroup>
        <Label for="id">Mã sản phẩm</Label>
        <Input
          type="text"
          name="id"
          id="id"
          onChange={onChange}
          value={form.id}
          readOnly
          
        />
      </FormGroup>
      <FormGroup>
        <Label for="name">Tên sản phẩm</Label>
        <Input
          type="text"
          name="name"
          id="name"
          onChange={onChange}
          value={form.name}
        />
      </FormGroup>
      <FormGroup>
        <Label for="price">Giá bán</Label>
        <Input
          type="text"
          name="price"
          id="price"
          onChange={onChange}
          value={form.price}

        />
      </FormGroup>
      <FormGroup>
        <Label for="quantity">Số lượng</Label>
        <Input
          type="text"
          name="quantity"
          id="quantity"
          onChange={onChange}
          value={form.quantity}

        />
      </FormGroup>
      <FormGroup>
        <Label for="status">Trạng thái</Label>
        <Input
          type="text"
          name="status"
          id="status"
          onChange={onChange}
          value={form.status}

          placeholder="Enable or Disnable"
        />
      </FormGroup>
      <FormGroup>
        <Label for="imageURL">Ảnh</Label>
        <Input
          type="text"
          name="imageURL"
          id="imageURL"
          onChange={onChange}
          value={form.imageURL}


        />
      </FormGroup>
      <FormGroup>
        <Label for="catId">Mã danh mục</Label>
        <Input
          type="text"
          name="categoryId"
          id="catId"
          onChange={onChange}
          value={form.categoryId}
        />
      </FormGroup>
      <Button onClick={updateProd}>Submit</Button>
    </Form>
  );
}

export default AddEditForm;
