import { Link, useNavigate } from "react-router-dom";
// import "../components/asset/css/signIn.css";
import styles from "../components/asset/css/signUp.module.css";
import { useEffect, useState } from "react";
import { Alert } from "react-bootstrap";

export default function SignUp() {
  const navigate = useNavigate()
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
  const [userName, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [passWord, setPassword] = useState("");
  interface userDTO {
    email: string;
    passWord: string;
    fund: 0;
    type: 0;
    userName: string;
  }

  const registration = async () => {
    const userDTO: userDTO = {
      email,
      passWord,
      fund: 0,
      type: 0,
      userName,
    };
    const createUser = await fetch("http://localhost:5105/api/user", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userDTO),
      });

      alert("Đăng ký thành công")
      navigate("/signIn")

  };
  return (
      <>
        <Link id={styles.toHome} to="/">
          <img src="/images/logo.png" alt="" />
        </Link>
        <div id={styles.container}>
          <p>Sign Up</p>
          <form onSubmit={registration}>
          <div id={styles.input}>
            <input type="text" id={styles.UserName} placeholder="User Name" 
              onChange={(e)=>setUsername(e.target.value)}
              />
            <small id={styles.Usererror}>Username không được bỏ trống</small>
          </div>
          <div id={styles.input}>
            <input type="text" id={styles.Email} placeholder="Email"
              onChange={(e)=>setEmail(e.target.value)}
              />
            <small id={styles.Emailerror}>Email không được bỏ trống</small>
          </div>
          <div id={styles.input}>
            <input type="text" id={styles.Password} placeholder="Password" 
              onChange={(e)=>setPassword(e.target.value)}
              />
            <small id={styles.Passwordrerror}>
              Password không được bỏ trống
            </small>
          </div>
          <div id={styles.input}>
            <input
              type="text"
              id={styles.confirmPassword}
              placeholder="Confirm Password"
            />
            <small id={styles.unmatch}>
              Không trùng khớp với mật khẩu trên
            </small>
          </div>
          <Link to="/signIn">Sign In</Link>
          
          <button id={styles.btnSignup}> Sign Up</button>
          </form>
        </div>

    </>
  );
}
