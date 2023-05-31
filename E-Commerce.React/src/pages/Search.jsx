import { useParams } from "react-router-dom";
import { generalStore } from "../store/generalStore";
import Showcase from "../components/common/Showcase";
import { useEffect, useState } from "react";
import axios from "axios";
import BrandsShowcase from "../components/common/BrandsShowcase";
import HomeProducts from "../components/home/HomeProducts";

export default function Search() {
  const { search } = useParams();
  const [products, setProducts] = useState([]);
  const [filterMin, setFilterMin] = useState("");
  const [filterMax, setFilterMax] = useState("");
  const [filterColor, setFilterColor] = useState("");
  const [filterSize, setFilterSize] = useState("");
  const [filterBrand, setFilterBrand] = useState("");
  const [filterCategory, setFilterCategory] = useState("");

  useEffect(() => {
    axios
      .get(
        `http://api.mssdev.online/api/salesproducts?category=${filterCategory}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${search}`
      )
      .then((response) => {
        setProducts(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  }, []);
  return (
    <>
      <div className="container mb-5">
        <div className="d-flex align-items-center">
          <p className="my-4">Aranan kritere ait sonuçlar</p>
        </div>
        <div className="row">
          <div className="products col-12 col-lg-12">
            <div className="row">
              {products.length >= 1 ? (
                <>
                  {products.map((item) => {
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
                </>
              ) : (
                <div>
                  <p className="fw-semibold mb-5 text-center fs-4">Aranılan kritere ait sonuç bulunamadı</p>
                  <HomeProducts title="Bu ürünler ilginizi çekebilir"/>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
      <BrandsShowcase />
    </>
  );
}
