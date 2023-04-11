import { useState } from "react";
import Brands from "../components/admin/Brands";
import Product from "../components/admin/Product";
import AdminHome from "../components/admin/AdminHome";
import Options from "../components/admin/Options";
import Contents from "../components/admin/Contents";
import UserManagement from "../components/admin/UserManagement";

export default function Admin() {
  const [adminPanel, setAdminPanel] = useState("adminHome");
  return (
    <>
      <div className="">
        <div className="admin row flex-column flex-lg-row">
          <div className="admin-header col-12 col-lg-2 d-flex flex-row flex-lg-column p-0">
            <div className="d-flex flex-column p-4 w-100">
              <button
                className={`btn fs-5 py-3 mb-3 rounded-3 ${
                  adminPanel === "adminHome" && "active"
                }`}
                onClick={() => setAdminPanel("adminHome")}
              >
                Yönetim Paneli
              </button>
              <button
                className={`btn fs-5 mb-3 rounded-3 ${
                  adminPanel === "contents" && "active"
                }`}
                onClick={() => setAdminPanel("contents")}
              >
                İçerik Ayarları
              </button>
              <button
                className={`btn fs-5 mb-3 rounded-3 ${
                  adminPanel === "product" && "active"
                }`}
                onClick={() => setAdminPanel("product")}
              >
                Ürünler
              </button>
              <button
                className={`btn fs-5 mb-3 rounded-3 ${
                  adminPanel === "brands" && "active"
                }`}
                onClick={() => setAdminPanel("brands")}
              >
                Markalar
              </button>
              <button
                className={`btn fs-5 mb-3 rounded-3 ${
                  adminPanel === "options" && "active"
                }`}
                onClick={() => setAdminPanel("options")}
              >
                Site Ayarları
              </button>
              <button
                className={`btn fs-5 mb-3 rounded-3 ${
                  adminPanel === "userManagement" && "active"
                }`}
                onClick={() => setAdminPanel("userManagement")}
              >
                Kullanıcı Yönetimi
              </button>
            </div>
          </div>
          <div className="admin-content col-12 col-lg-10 px-5 py-4">
            <div className="content-right">
              <div>
                {adminPanel === "adminHome" && <AdminHome />}
                {adminPanel === "brands" && <Brands />}
                {adminPanel === "product" && <Product />}
                {adminPanel === "options" && <Options />}
                {adminPanel === "contents" && <Contents />}
                {adminPanel === "userManagement" && <UserManagement />}
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
