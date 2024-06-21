import Header from "../components/user/Header";
import Menu from "../components/user/Menu";
import SlideLaptop from "../components/user/SlideLaptop";
import "../components/asset/css/Laptop.module.css"
import CategoryLaptop from "../components/user/CategoryLaptop";
import ListProductLap from "../components/user/ListProduct-lap";
import Footer from "../components/user/Footer";
// import "../components/user/Laptop"
import laptop from "../components/asset/css/Laptop.module.css"


export default function LaptopPage(){
    return(
        <>

            <Header />
            <Menu />

            <div id={laptop.container}>
            <div id={laptop.roughting}>
            <a href="/index.html">Trang chủ</a> <p>/</p> <p>Laptop</p>
        </div>
                <SlideLaptop/>
                <div id={laptop.product}>
                    <CategoryLaptop />
                    <ListProductLap />
                </div>
                <Footer/>
            </div>
      

        </>
    )

}