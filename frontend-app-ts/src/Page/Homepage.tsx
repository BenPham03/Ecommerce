import React from "react";
import Header from "../components/user/Header";
import Menu from "../components/user/Menu";
import Slider from "../components/user/Slider";
import Category from "../components/user/Category";
import LaptopDisplay from "../components/user/LaptopDisplay";
import Footer from "../components/user/Footer";
import { Container } from "react-bootstrap";
import contain  from "../components/asset/css/Container.module.css";

export default function Homepage(){
    return(
<>
      <Header/>
        <Menu/>
        <div id={contain.container}>
          <Slider/>
          <Category/>
          <LaptopDisplay/>
          <Footer/>
        </div>
</>
        
    )
}