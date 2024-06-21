import { useEffect, useState } from "react";
import Acc from "../asset/css/AccountDetaill.module.css";
import { useNavigate } from "react-router-dom";
export default function AccountDetail() {
  const id = localStorage["CustomerId"];
  const acid = localStorage["AccountId"];
  const navigate = useNavigate()
  interface Customer {
    name: string;
    phoneNumber: string;
    address: string;
    age: string;
    sex: string;
  }
  interface customerDto{
    name: string,
    age: number,
    phoneNumber: number,
    address: string,
    sex: string,
  }
  interface account{
    email: string,
    passWord : string,
    fund: number,
    type: number,
    userName: string,
  }
  interface accountDto{
    email: string,
    passWord : string,
    fund: number,
    type: number,
    userName: string,
    customerId: number
  }
  const [customer, setCustomer] = useState<Customer>({
    name: "",
    phoneNumber: "",
    address: "",
    age: "",
    sex: "",
  });const [acc, setAcc] = useState<account>({
    email: "",
    passWord : "",
    fund: 0,
    type: 0,
    userName: "",
  });

  useEffect(() => {
    (async () => {
      const res = await fetch(`http://localhost:5105/api/customer/${id}`);
      const data = await res.json();
      setCustomer(data);
    })();
  }, []);
  useEffect(() => {
    (async () => {
      const res = await fetch(`http://localhost:5105/api/user/ById/${acid}`);
      const data = await res.json();
      setAcc(data);
      console.log(data)
    })();
  }, []);

    const updateCustomer = async () => {
        console.log(customer)

        const customerDto: customerDto = {
            name: customer.name,
            age: Number(customer.age),
            phoneNumber: Number(customer.phoneNumber),
            address: customer.address,
            sex: customer.sex
        }
        const res = await fetch(`http://localhost:5105/api/customer/update/${id}`,
            {method:"PUT",
            headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify(customerDto),
            }
            
        );
        if (res.ok) {
            alert('Update thành công!');
        } else {
            alert('Thông tin khách hàng chưa đúng định dạng');
        }
      };
      const updateAcount = async () => {

        const account: accountDto = {
            email: acc.email,
            passWord : acc.passWord,
            fund: 0,
            type: acc.type,
            userName: acc.userName,
            customerId: id
        }
        const res = await fetch(`http://localhost:5105/api/user/update/${acid}`,
            {method:"PUT",
            headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify(account),
            }
            
        );
        if (res.ok) {
            alert('Update thành công!');
        } else {
            alert('Failed to update. Error: ' + res.status);
        }
      };
  const handleChange = (e: any) => {
    const { name, value } = e.target;
    setCustomer((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };
  const handleAccChange = (e: any) => {
    const { name, value } = e.target;
    setAcc((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };
  return (
    <>
      <main>
        <h1 id={Acc.h}>Thông tin cá nhân</h1>
        <form id={Acc.frm}>
          <div>
            <label htmlFor="name">Tên người nhận</label>
            <input
              id={Acc.name}
              type="text"
              name="name"
              value={customer.name}
              onChange={handleChange}
            />
          </div>
          <div>
            <label htmlFor="name">Số điện thoại</label>
            <input
              id={Acc.phoneNumber}
              type="text"
              name="phoneNumber"
              value={customer.phoneNumber}
              onChange={handleChange}
            />
          </div>
          <div>
            <label htmlFor="address">Địa chỉ</label>
            <input
              id={Acc.address}
              type="text"
              name="address"
              value={customer.address}
              onChange={handleChange}
            />
          </div>
          <div>
            <label htmlFor="age">Tuổi</label>
            <input id={Acc.age} type="text" name="age" value={customer.age} 
              onChange={handleChange}
              />
          </div>
          <div>
            <label htmlFor="sex">Giới tính</label>
            <input id={Acc.sex} type="text" name="sex" value={customer.sex} 
              onChange={handleChange}
              />
          </div>
          <button id={Acc.btn} type="button" onClick={updateCustomer}>
            Cập nhật thông tin cá nhân
          </button>
        </form>

        <h1 id={Acc.h}>Thông tin tài khoản</h1>
        <form id={Acc.frm}>
          <div>
            <label htmlFor="userName">Tên người dùng</label>
            <input id={Acc.userName} type="text" name="userName" value={acc.userName} onChange={handleAccChange}/>
          </div>
          <div>
            <label htmlFor="email">Email</label>
            <input id={Acc.email} type="text" name="email" value={acc.email} onChange={handleAccChange}/>
          </div>
          <div>
            <label htmlFor="password">Password</label>
            <input id={Acc.password} type="text" name="pasword" value={acc.passWord} onChange={handleAccChange}/>
          </div>
          {/* <br /> */}
          <button id={Acc.btn} type="button" onClick={updateAcount}>
            Cập nhật thông tin tài khoản
          </button>
        </form>

        <button style={{border: "0px solid #000" , height: "50px", width: "150px",
         fontSize:"20px", color:"#fff", backgroundColor:"#DA2627",
         marginTop:"100px", borderRadius:"20px"}}
         onClick={()=>{
          localStorage.setItem("login", "0")
          navigate("/")
         }}
         > Đăng xuất </button>
      </main>
    </>
  );
}
