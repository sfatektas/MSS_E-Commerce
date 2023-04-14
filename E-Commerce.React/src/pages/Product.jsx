import { useParams } from "react-router-dom";
import productJson from "../products.json";
import { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";

const data = productJson;
// Ürünler API'den çekildiği zaman title sorgulanıp true dönerse sayfa görüntülenecek.
export default function Product() {
  const { name } = useParams();
  const [product, setProduct] = useState([]);
  useEffect(() => {
    data.map((item) => {
      if (item.title == name) {
        return setProduct(item);
      }
    });
  }, []);

  return (
    <>
      <div className="container">
        <div className="row my-5">
          <div className="col-6">
            <img width="200px" src={product.image} />
          </div>
          <div className="col-6">
            <p className="fw-semibold">{product.title}</p>
          </div>
        </div>
      </div>
    </>
  );
}
