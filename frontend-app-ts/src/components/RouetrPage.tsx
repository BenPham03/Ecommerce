import React from "react";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import Homepage from "../Page/Homepage";
import LaptopPage from "../Page/LaptopPage";
import SignIn from "../Page/SignIn";
import SignUp from "../Page/SignUp";
import AdminPage from "../Page/AdminPage";
import ProductManager from "./admin/ProductManager";
import AccountDetail from "../Page/AccountDetailP";
import DetailPage from "../Page/DetailPage";

export default function RouterPage(){
    return(
        // <Router>
            <Routes>
                <Route path='/' element= {<Homepage />}/> 
                <Route path='/latoppage' element = {<LaptopPage/>}/>
                <Route path='/admin' element = {<AdminPage/>}/>
                <Route path='/signIn' element = {<SignIn/>}/>
                <Route path='/signUp' element = {<SignUp/>}/>
                <Route path='/productmanage' element = {<ProductManager/>}/>
                <Route path='/accountDetail' element = {<AccountDetail/>}/>
                <Route path='/productDetail' element = {<DetailPage/>}/>
            </Routes>
        // </Router>
    )
}