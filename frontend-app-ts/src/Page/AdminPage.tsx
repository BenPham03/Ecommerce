import AdminCategory from "../components/admin/AdminCategory";
import AdminHeader from "../components/admin/AdminHeader";
import BillManagement from "../components/admin/BillManagement";
import ProductManager from "../components/admin/ProductManager";
import admin from "../components/asset/css/Admin.module.css"

export default function AdminPage(){
    return(
        <>
            <AdminHeader/>
        <div id={admin.container}>
            <AdminCategory/>
            <ProductManager/>
        </div>
        </>
        
    )
}