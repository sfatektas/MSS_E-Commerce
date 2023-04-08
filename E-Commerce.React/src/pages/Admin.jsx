import { useState } from "react";
import Brands from "../components/AdminComponents/Brands";
import Product from "../components/AdminComponents/Product";
import AdminHome from "../components/AdminComponents/AdminHome";

export default function Admin() {
  const [adminPanel, setAdminPanel] = useState("adminHome");
  return (
    <>
      <div className="">
        <div className="admin row">
          <div className="admin-header col-2 d-flex flex-column p-0">
            <div className="d-flex flex-column p-4 ">
              <button
                className={`btn fs-5 py-3 ${
                  adminPanel === "adminHome" && "active"
                }`}
                onClick={() => setAdminPanel("adminHome")}
              >
                Yönetim Paneli
              </button>
            </div>
            <div className="buttons d-flex flex-column">
              <button
                className={`btn fs-5 mx-4 mb-3 ${
                  adminPanel === "brands" && "active"
                }`}
                onClick={() => setAdminPanel("brands")}
              >
                Markalar
              </button>
              <button
                className={`btn fs-5 mx-4 mb-3 ${
                  adminPanel === "product" && "active"
                }`}
                onClick={() => setAdminPanel("product")}
              >
                Ürünler
              </button>
            </div>
          </div>
          <div className="admin-content col-10 px-5 py-4">
            <div className="content-right">
              <div>
                {adminPanel === "adminHome" && <AdminHome />}
                {adminPanel === "brands" && <Brands />}
                {adminPanel === "product" && <Product />}
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
