import { useEffect, useState } from "react";
import Modal from "react-bootstrap/Modal";
import productJson from "../../products.json";
import Showcase from "../common/Showcase";
import axios from "axios";

export default function HomeProducts() {
  const [homeProducts, setHomeProducts] = useState([]);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/SalesProducts/home")
      .then((response) => {
        setHomeProducts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [homeProducts]);

  return (
    <div className="products-main container mb-5">
      <div className="products-header d-flex flex-column align-items-center mb-4">
        <span className="title display-6 fw-bold mb-3">KARIŞIK ÜRÜNLER</span>
        <p className="text-muted">Premium satıcılarımızın ürünleri</p>
      </div>
      <div className="products-content">
        <div className="row">
          {homeProducts.slice(0, 8).map((item) => {
            return (
              <Showcase
                key={item.supplierProductId}
                id={item.supplierProductId}
                title={item.productTitle}
                brand={item.brand.defination}
                price={item.unitPrice}
                image={item.imageUrls[0]}
                category={item.category.defination}
              />
            );
          })}
        </div>
      </div>
    </div>
  );
}
