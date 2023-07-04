import { useEffect, useState } from "react";
import Modal from "react-bootstrap/Modal";
import productJson from "../../products.json";
import Showcase from "../common/Showcase";
import axios from "axios";

export default function HomeProducts(props) {
  const [homeProducts, setHomeProducts] = useState([]);

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/SalesProducts/home")
      .then((response) => {
        setHomeProducts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <div className="products-main container mb-5">
      <div className="products-header d-flex flex-column align-items-center mb-4">
        <span className="title display-6 fw-bold mb-3 text-center">{props.title}</span>
        <p className="text-muted text-center">Premium satıcılarımızdan sizlere özel seçtiklerimiz</p>
      </div>
      <div className="products-content">
        <div className="row">
          {homeProducts.slice(0, 8).map((item) => {
            return (
              <Showcase
              key={item.supplierProductId}
              id={item.id}
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
