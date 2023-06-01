import { useParams } from "react-router-dom";
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
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    axios
      .get(
        `http://api.mssdev.online/api/salesproducts?category=${filterCategory}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${search}`
      )
      .then((response) => {
        setProducts(response.data);
        console.log(response.data);
        setLoading(false)
      })
      .catch((error) => {
        console.log(error.response.data);
        setLoading(false)
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
              {loading ? (
                <div
                  className="loader loader--style2 d-flex justify-content-center"
                  title="1"
                >
                  <svg
                    version="1.1"
                    id="loader-1"
                    x="0px"
                    y="0px"
                    width="80"
                    height="80"
                    viewBox="0 0 50 50"
                  >
                    <path
                      fill="#000"
                      d="M25.251,6.461c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615V6.461z"
                    >
                      <animateTransform
                        attributeType="xml"
                        attributeName="transform"
                        type="rotate"
                        from="0 25 25"
                        to="360 25 25"
                        dur="0.6s"
                        repeatCount="indefinite"
                      />
                    </path>
                  </svg>
                </div>
              ) : (
                <>
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
                      <p className="fw-semibold mb-5 text-center fs-4">
                        Aranılan kritere ait sonuç bulunamadı
                      </p>
                      <HomeProducts title="Bu ürünler ilginizi çekebilir" />
                    </div>
                  )}
                </>
              )}
            </div>
          </div>
        </div>
      </div>
      <BrandsShowcase />
    </>
  );
}
