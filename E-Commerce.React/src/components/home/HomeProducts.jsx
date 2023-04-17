import { useEffect, useState } from "react";
import Modal from "react-bootstrap/Modal";
import productJson from "../../products.json";
import Showcase from "./Showcase";

const data = productJson;

export default function HomeProducts() {
  const [homeProducts, sethomeProducts] = useState([]);

  useEffect(() => {
    sethomeProducts(data);
  }, [homeProducts]);

  useEffect(() => {
    function shuffleProducts(array) {
      for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
      }
      return array;
    }
    shuffleProducts(data);
  }, [data]);


  return (
    <div className="products-main container mb-5">
      <div className="products-header d-flex flex-column align-items-center mb-4">
        <span className="title display-6 fw-bold mb-3">KARIŞIK ÜRÜNLER</span>
        <p className="text-muted">Premium satıcılarımızın ürünleri</p>
      </div>
      <div className="products-content">
        <div className="row">
          {homeProducts.slice(0, 12).map((item) => (
            <Showcase
              key={item.id}
              id={item.id}
              title={item.title}
              category={item.category}
              price={item.price}
              image={item.image}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
