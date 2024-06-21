import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import { Container } from 'react-bootstrap';
import { BrowserRouter } from 'react-router-dom';
import Header from './components/user/Header';
import Menu from './components/user/Menu';
import Slider from './components/user/Slider';
import Category from './components/user/Category';
import LaptopDisplay from './components/user/LaptopDisplay';
import Footer from './components/user/Footer';
import Homepage from './Page/Homepage';
import RouterPage from './components/RouetrPage';

function App() {
  useEffect(() => {
    const hasLogin = localStorage['login'];
    if(!hasLogin) localStorage['login'] = '0'
    // else if(hasLogin != '0') localStorage['login'] = '1'
}, [])

  return (
      <>
      <BrowserRouter>
        <RouterPage/>
      </BrowserRouter>
      </>
      

  );
}

export default App;
