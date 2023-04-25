import { useParams } from "react-router-dom";
import { generalStore } from "../store/generalStore";
import { Navigate } from "react-router-dom";
import Showcase from "../components/common/Showcase";
import { useEffect, useState } from "react";
import axios from "axios";

export default function Category(props) {
  const { defination } = useParams();
  const { categories } = generalStore();
  const [filtersShow, setFiltersShow] = useState("d-none");
  const [products, setProducts] = useState([]);
  const [listBrands, setListBrands] = useState();
  const [filterBrand, setFilterBrand] = useState("")
  const [listSizes, setListSizes] = useState();
  const [filterSize, setSilterSize] = useState("")
  const [listColors, setListColors] = useState();
  const [filterColor, setFilterColor] = useState("")
  const [productsLink, setProductsLink] = useState(
    `https://e-commercemss.azurewebsites.net/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}`
  );

  function colorFilter(color){
    setFilterColor(color)
    setProductsLink(`https://e-commercemss.azurewebsites.net/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${color}&size=${filterSize}&brand=${filterBrand}`)
  }

  function brandFilter(brand){
    setFilterBrand(brand)
    setProductsLink(`https://e-commercemss.azurewebsites.net/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${brand}`)
  }

  useEffect(() => {
    axios
      .get(productsLink)
      .then((response) => {
        setProducts(response.data);
        console.log(productsLink)
      })
      .catch((error) => {
        console.log(error.response.data.Error);
        alert(error.response.data.Error)
      });
  }, [productsLink,filterColor]);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/brands")
      .then((response) => {
        setListBrands(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, []);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/colors")
      .then((response) => {
        setListColors(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, []);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/sizes")
      .then((response) => {
        setListSizes(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, []);

  function handleFilterShow() {
    filtersShow == "d-none"
      ? setFiltersShow("d-block")
      : setFiltersShow("d-none");
  }

  try {
    let definationList = categories.map((item) => {
      return item.defination;
    });
    let isValid = definationList.includes(defination);
    if (isValid) {
      return (
        <>
          <div className="container mb-5">
            <p className="my-4 ">
              HOME | Category | <span className="fw-bold">{defination}</span>
            </p>

            <div className="row">
              <button
                onClick={handleFilterShow}
                className="btn btn-dark py-3 mb-4 d-lg-none"
                href="#!"
              >
                Filteler
              </button>
              <div
                className={`filters col-12 col-lg-2 d-lg-block ${filtersShow}`}
              >
                <div className="d-flex flex-column border rounded-3">
                  <div className="border-bottom p-3 mb-3">
                    <p>
                      <span className="fw-semibold">+50 Ürün</span> listeleniyor
                    </p>
                  </div>
                  <div className="category-brand px-3 mb-3 pb-3 border-bottom">
                    <p className="fw-semibold mb-3">Marka</p>
                    {listBrands.map((item) => {
                      return (
                        <div key={item.id} className="d-flex mb-1">
                          <input type="radio" name="brand" value={item.defination} onClick={(e)=>brandFilter(e.target.value)}/>
                          <p className="ms-2">{item.defination}</p>
                        </div>
                      );
                    })}
                  </div>
                  <div className="category-color px-3 mb-3 pb-3 border-bottom">
                    <p className="fw-semibold mb-3">Renk</p>
                    {listColors.map((item) => {
                      return (
                        <div
                          className="d-flex align-items-center mb-1"
                          key={item.id}
                        >
                          <input type="radio" name="color" value={item.defination}  onClick={(e)=>colorFilter(e.target.value)}/>
                          <div className="black ms-2"></div>{" "}
                          {/*Renk kodu gelecek*/}
                          <p className="ms-2">{item.defination}</p>
                        </div>
                      );
                    })}
                  </div>
                  <div className="category-price d-flex flex-column px-3 mb-3 pb-3 border-bottom">
                    <p className="fw-semibold mb-3">Fiyat Aralığı</p>
                    <form action="" className="d-flex">
                      <input
                        type="number"
                        name=""
                        id=""
                        className="price-min col-4 rounded-3 px-1"
                        placeholder="En az"
                      />
                      <input
                        type="number"
                        name=""
                        id=""
                        className="price-max col-4 ms-2 rounded-3 px-1"
                        placeholder="En çok"
                      />
                      <a className="btn btn-outline-dark rounded-3 ms-2 py-0 px-1">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="18"
                          height="18"
                          viewBox="0 0 20 20"
                          fill="none"
                        >
                          <path
                            fill="#000000"
                            fillRule="evenodd"
                            d="M4 9a5 5 0 1110 0A5 5 0 014 9zm5-7a7 7 0 104.2 12.6.999.999 0 00.093.107l3 3a1 1 0 001.414-1.414l-3-3a.999.999 0 00-.107-.093A7 7 0 009 2z"
                          ></path>
                        </svg>
                      </a>
                    </form>
                  </div>
                  <div className="category-size px-3 mb-3 pb-3 border-bottom">
                    <p className="fw-semibold mb-3">Beden</p>
                    {listSizes.map((item) => {
                      return (
                        <div className="d-flex mb-1" key={item.id}>
                          <input type="radio" name="size" />
                          <p className="ms-2">{item.value}</p>
                        </div>
                      );
                    })}
                  </div>
                  <div className="category-search row px-3 mb-4 ">
                    <p className="fw-semibold mb-3">Arama</p>
                    <form action="" className="d-flex">
                      <input
                        type="text"
                        name="product-search"
                        id=""
                        placeholder="Ara"
                        className="category-search-box col-9 rounded-3 px-2"
                      />
                      <a className="btn btn-outline-dark col-43 ms-2 py-0 px-1 rounded-3">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="18"
                          height="18"
                          viewBox="0 0 20 20"
                          fill="none"
                        >
                          <path
                            fill="#000000"
                            fillRule="evenodd"
                            d="M4 9a5 5 0 1110 0A5 5 0 014 9zm5-7a7 7 0 104.2 12.6.999.999 0 00.093.107l3 3a1 1 0 001.414-1.414l-3-3a.999.999 0 00-.107-.093A7 7 0 009 2z"
                          ></path>
                        </svg>
                      </a>
                    </form>
                  </div>
                  <button
                    onClick={() => setFiltersShow("d-none")}
                    className="btn btn-dark py-3 mb-4 d-lg-none"
                    href="#!"
                  >
                    Kapat
                  </button>
                </div>
              </div>
              <div className="products col-12 col-lg-10">
                <div className="row">
                  {products.map((item) => {
                    if (item.category.defination == defination) {
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
                    }
                  })}
                </div>
              </div>
            </div>
          </div>
        </>
      );
    } else {
      return <Navigate to="/NotFound" />;
    }
  } catch {}
}
