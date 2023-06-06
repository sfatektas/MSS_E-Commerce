import { useParams } from "react-router-dom";
import { generalStore } from "../store/generalStore";
import { Navigate } from "react-router-dom";
import Showcase from "../components/common/Showcase";
import { useEffect, useState } from "react";
import axios from "axios";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";

export default function Category(props) {
  const { defination } = useParams();
  const { categories } = generalStore();
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const [filtersShow, setFiltersShow] = useState("d-none");
  const [products, setProducts] = useState([]);
  const [categoryTypeId, setCategoryTypeId] = useState();
  const [categoryDefination, setCategoryDefination] = useState();
  const [filterListableBrands, setFilterListableBrands] = useState([]);
  const [filterListableColors, setFilterListableColors] = useState([]);
  const [listBrands, setListBrands] = useState();
  const [filterBrand, setFilterBrand] = useState("");
  const [listSizes, setListSizes] = useState();
  const [filterSize, setFilterSize] = useState("");
  const [listColors, setListColors] = useState();
  const [filterColor, setFilterColor] = useState("");
  const [filterSearch, setFilterSearch] = useState("");
  const [filterMin, setFilterMin] = useState("");
  const [filterMax, setFilterMax] = useState("");
  const [productsLink, setProductsLink] = useState(
    `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
  );

  function colorFilter(color) {
    setFilterColor(color);
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${color}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
    );
  }

  function brandFilter(brand) {
    setFilterBrand(brand);
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${brand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
    );
  }

  function sizeFilter(size) {
    setFilterSize(size);
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${size}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
    );
  }

  function searchFilter(e) {
    e.preventDefault();
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
    );
  }

  function priceFilter(e) {
    e.preventDefault();
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${filterSearch}`
    );
  }

  function cleanPrice() {
    setFilterMax("");
    setFilterMin("");
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${""}&maxprice=${""}&search=${filterSearch}`
    );
  }

  function cleanSearch() {
    setFilterSearch("");
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${filterColor}&size=${filterSize}&brand=${filterBrand}&minprice=${filterMin}&maxprice=${filterMax}&search=${""}`
    );
  }

  function cleanAllFilters() {
    setFilterBrand("");
    setFilterColor("");
    setFilterMax("");
    setFilterMin("");
    setFilterSearch("");
    setFilterSize("");
    setProductsLink(
      `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${""}&size=${""}&brand=${""}&minprice=${""}&maxprice=${""}&search=${""}`
    );
  }

  useEffect(() => {
    cleanAllFilters();
    axios
      .get(productsLink)
      .then((response) => {
        setProducts(response.data);
        setCategoryTypeId(response.data[0].category.id);
      })
      .catch((error) => {
        setInfo("İstenilen kritere ait ürün bulunamadı");
        setVariant("light");
        setInfoModal(true);
      });
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  }, [productsLink, filterColor, defination]);

  useEffect(() => {
    if (categoryDefination != defination) {
      setFilterListableBrands([]);
    }
    products.forEach((item) => {
      setCategoryDefination(item.category.defination);
      // setFilterListableBrands(...filterListableBrands+item.brand.defination)
      setFilterListableBrands((filterListableBrands) => [
        ...filterListableBrands,
        item.brand.defination,
      ]);
    });
  }, [products]);

  // useEffect(() => {
  //   products.forEach((item) => {
  //     // console.log(item.brand.defination)
  //     // setFilterListableBrands(...filterListableBrands+item.brand.defination)
  //     setFilterListableColors((filterListableColors) => [
  //       ...filterListableColors,
  //       item.brand.defination,
  //     ]);
  //   });
  // }, [products]);
  // console.log(filterListableColors);

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/brands")
      .then((response) => {
        setListBrands(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, []);

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/colors")
      .then((response) => {
        setListColors(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, []);

  useEffect(() => {
    axios
      .get(
        `http://api.mssdev.online/api/sizes/${
          categoryTypeId ? categoryTypeId : ""
        }`
      )
      .then((response) => {
        setListSizes(response.data);
      })
      .catch((error) => [console.log(error)]);
  }, [categoryTypeId]);
  function handleFilterShow() {
    filtersShow == "d-none"
      ? setFiltersShow("d-block")
      : setFiltersShow("d-none");
  }

  function handleKeyDown(event) {
    //Input alanı enter keypress disable işlemi
    if (event.key === "Enter") {
      event.preventDefault();
    }
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
            <div className="d-flex align-items-center">
              <p className="my-4">
                HOME | Category | <span className="fw-bold">{defination}</span>
              </p>
              {filterBrand ? (
                <a
                  className="ms-4 filter-modal"
                  onClick={(e) => brandFilter("")}
                  href="#"
                >
                  Marka: <span className="fw-semibold">{filterBrand}</span>
                </a>
              ) : null}
              {filterColor ? (
                <a
                  className="ms-4 filter-modal"
                  onClick={(e) => colorFilter("")}
                  href="#"
                >
                  Renk: <span className="fw-semibold">{filterColor}</span>
                </a>
              ) : null}
              {filterSize ? (
                <a
                  className="ms-4 filter-modal"
                  onClick={(e) => sizeFilter("")}
                  href="#"
                >
                  Beden: <span className="fw-semibold">{filterSize}</span>
                </a>
              ) : null}
              {filterMax || filterMax ? (
                <a className="ms-4 filter-modal" onClick={cleanPrice} href="#">
                  Fiyat Aralığı:{" "}
                  <span className="fw-semibold">
                    {filterMin}-{filterMax} TL
                  </span>
                </a>
              ) : null}
              {filterSearch ? (
                <a className="ms-4 filter-modal" onClick={cleanSearch} href="#">
                  Filtre kelimesi:{" "}
                  <span className="fw-semibold">{filterSearch}</span>
                </a>
              ) : null}
            </div>
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
                    <p className="my-2 text-center">
                      <span className="fw-semibold">
                        {products.length} Ürün
                      </span>{" "}
                      listeleniyor
                    </p>
                    {productsLink !=
                    `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${""}&size=${""}&brand=${""}&minprice=${""}&maxprice=${""}&search=${""}` ? (
                      <button
                        className="btn btn-outline-dark rounded-3"
                        onClick={cleanAllFilters}
                      >
                        Filtreleri Temizle
                      </button>
                    ) : null}
                  </div>
                  <div className="category-brand px-3 mb-3 pb-3 border-bottom">
                    <p className="fw-semibold mb-3">Marka</p>
                    {listBrands.map((item) => {
                      if (filterListableBrands.includes(item.defination)) {
                        return (
                          <div key={item.id} className="d-flex mb-1">
                            <input
                              type="radio"
                              name="brand"
                              value={item.defination}
                              onClick={(e) => brandFilter(e.target.value)}
                            />
                            <p
                              style={{ textTransform: "uppercase" }}
                              className="ms-2"
                            >
                              {item.defination}
                            </p>
                          </div>
                        );
                      }
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
                          <input
                            type="radio"
                            name="color"
                            value={item.defination}
                            onClick={(e) => colorFilter(e.target.value)}
                          />
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
                        name="minPrice"
                        id=""
                        className="price-min col-4 rounded-3 px-1"
                        placeholder="En az"
                        onChange={(e) => setFilterMin(e.target.value)}
                      />
                      <input
                        type="number"
                        name="maxPrice"
                        id=""
                        className="price-max col-4 ms-2 rounded-3 px-1"
                        placeholder="En çok"
                        onChange={(e) => setFilterMax(e.target.value)}
                      />
                      <a
                        className="btn btn-outline-dark rounded-3 ms-2 py-0 px-1"
                        onClick={priceFilter}
                      >
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
                          <input
                            type="radio"
                            name="size"
                            value={item.value}
                            onClick={(e) => sizeFilter(e.target.value)}
                          />
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
                        onChange={(e) => setFilterSearch(e.target.value)}
                        onKeyDown={handleKeyDown}
                      />
                      <a
                        className="btn btn-outline-dark col-43 ms-2 py-0 px-1 rounded-3"
                        onClick={searchFilter}
                      >
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
                  <Alert show={infoModal} variant={variant}>
                    <Alert.Heading className="d-flex justify-content-center text-center">
                      {info}
                    </Alert.Heading>
                    <div className="d-flex justify-content-center">
                      <Button
                        className="btn-outline-dark rounded-3"
                        onClick={() => {
                          setInfoModal(false);
                          cleanAllFilters();
                        }}
                        variant={variant}
                      >
                        Filteleri Temizle
                      </Button>
                    </div>
                  </Alert>
                  {products.map((item) => {
                    if (item.category.defination == defination) {
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
