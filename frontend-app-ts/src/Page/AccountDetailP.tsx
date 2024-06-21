import AccountDetail from "../components/user/AccountDetail";
import Footer from "../components/user/Footer";
import Header from "../components/user/Header";
import Menu from "../components/user/Menu";

export default function(){
    return(
        <>
        <Header />
            <Menu />
                <AccountDetail />
                <Footer/>
        </>
        
    )
}