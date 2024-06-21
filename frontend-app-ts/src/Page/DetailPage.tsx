import React, { useEffect, useState } from "react";
import Header from "../components/user/Header";
import Menu from "../components/user/Menu";
import Slider from "../components/user/Slider";
import Category from "../components/user/Category";
import LaptopDisplay from "../components/user/LaptopDisplay";
import Footer from "../components/user/Footer";
import { Container } from "react-bootstrap";
import contain  from "../components/asset/css/Container.module.css";
import ProductDetail from "../components/user/ProductDetail";
import Detail from "../asset/css/Detail.module.css"
import { useLocation } from "react-router-dom";

export default function DetailPage(){
  
  const location = useLocation();
  const id = location.state.id
  console.log(id)
  useEffect(() => {
    (async () => {
      const res = await fetch(`http://localhost:5105/api/DetailProduct/${id}`);
      const data = await res.json();
      setProducts(data);
      console.log(data)
    })();
  }, []);
  
  const [products, setProducts] = useState<any[]>([]);

    return(
<>
      <Header/>
        <Menu/>
        {/* <div id={contain.container}> */}
        <ProductDetail data={products}/>  
          <Footer/>
        {/* </div> */}
</>
        
    )
}