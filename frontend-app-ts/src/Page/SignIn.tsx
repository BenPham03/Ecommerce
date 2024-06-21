import { Link, useNavigate } from "react-router-dom";
import styles from "../components/asset/css/signIn.module.css";
import React, { useEffect, useState } from "react";
import Homepage from "./Homepage";

// Đăng nhập
interface LoginDTO {
  username: string;
  password: string;
  email: string;
}
interface Cus {
  name: string;
  age: number;
  phoneNumber: number;
  address: string;
  sex: string;
}
interface userDTO {
  email: string;
  passWord: string;
  fund: 0;
  type: 0;
  userName: string;
  customerId: number
}
const Login: React.FC = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({})
  useEffect(() => {
    // Store the original body style
    const originalOverflow = document.body.style.overflow;
    const originalBackgroundColor = document.body.style.backgroundColor;

    // Apply custom styles to the body
    document.body.style.backgroundColor = "#DA2627";
    document.body.style.textAlign = "center";

    // Cleanup function to revert styles
    return () => {
      document.body.style.overflow = originalOverflow;
      document.body.style.backgroundColor = originalBackgroundColor;
    };
  }, []);

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const loginData: LoginDTO = {
      username,
      password,
      email,
    };
    try {
      const response = await fetch("http://localhost:5105/api/user/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(loginData),
      });
      
      // console.log(response)
      if (!response.ok) {
        throw new Error("Login failed");
      }
      const userData = await response.json();
      setUser( userData)
      console.log("User logged in:", user);
      setIsLoggedIn(true);
      console.log(user)
      if (userData.customerId == null) {
        const customerDto: Cus = {
          name: "unknown",
          age: 18,
          phoneNumber: 1222222222,
          address: "Viet Nam",
          sex: "Nam",
        };
        const createCustomer = await fetch("http://localhost:5105/api/customer", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(customerDto),
        });
        const newCus = await createCustomer.json();
        console.log(newCus.id)
        localStorage.setItem("CustomerId", newCus.id);

        const account: userDTO = {
          email: email,
          passWord: password,
          fund: 0,
          type: 0,
          userName: username,
          customerId: newCus.id
        };
        console.log(account)

        const updateAcc = await fetch(`http://localhost:5105/api/user/update/${userData.id}`, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(account),
        });
        const ac = await updateAcc.json();
        console.log(ac)
        setUser(ac)

      }

      userData.type == 1 ? navigate("/admin") : navigate("/");
      localStorage.setItem("CustomerId", userData.customerId);
      localStorage.setItem("login", "1");
      //@ts-ignore
      localStorage.setItem("AccountId", userData.id);
      alert("Đăng nhập thành công");

    } catch (err) {
      setError("Invalid username or password");
    }
  };

  return (
    <>
      <Link id={styles.toHome} to="/">
        <img src="images/logo.png" alt="" />
      </Link>
      <div id={styles.container}>
        <p>Sign In</p>

        <form onSubmit={handleSubmit}>
          <div id={styles.input}>
            <input
              type="text"
              id={styles.UserName}
              placeholder="User name"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
            <small id={styles.Usererror}>Username không được bỏ trống</small>
          </div>
          <div id={styles.input}>
            <input
              type="text"
              id={styles.Email}
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <small id={styles.Emailerror}>Email không được bỏ trống</small>
          </div>
          <div id={styles.input}>
            <input
              type="password"
              id={styles.Password}
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <small id={styles.Passwordrerror}>
              Password không được bỏ trống
            </small>
          </div>
          {/* <input type="checkbox" name="" id={styles.hide} style="height: 20px;width: 20px;"><label for="hide"  style="height: 20px;">Hiện password</label> */}
          {/* <br> */}
          <Link to="/signUp">Sign Up</Link>
          <button id={styles.btnSignin}>Login</button>
          {error && <div>{error}</div>}
        </form>
      </div>
    </>
  );
};

export default Login;
