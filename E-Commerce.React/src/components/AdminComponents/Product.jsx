import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import axios from "axios";
import { useEffect, useState } from "react";

export default function Product() {
  //Form Listelemeleri
  const [productList, setProductList] = useState([]);
  const [categories, setCategories] = useState([]);
  const [brands, setBrands] = useState([]);
  const [sizeTypes, setSizeTypes] = useState([]);

  //Post Stateleri
  const [productName, setProductName] = useState("");
  const [productSpecs, setProductSpecs] = useState("");
  const [productBrand, setProductBrand] = useState("");
  const [productCategory, setproductCategory] = useState("");
  const [productSizeTypes, setProductSizeTypes] = useState("");
  const [productFile, setProductFile] = useState();

  //Modal Stateleri
  const [info, setInfo] = useState("");
  const [show, setModalShow] = useState(false);
  const [variant, setVariant] = useState("");

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Products")
      .then((response) => {
        console.log(response.data);
        setProductList(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Categories")
      .then((response) => {
        setCategories(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Brands")
      .then((response) => {
        setBrands(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/sizetypes")
      .then((response) => {
        setSizeTypes(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function handleFile(event) {
    event.preventDefault();
    setProductFile(event.target.files[0]);
  }

  function handleSubmit(event) {
    event.preventDefault();
    let createProduct = {
      Name: productName,
      Detail: productSpecs,
      BrandId: productBrand,
      CategoryId: productCategory,
      SizeTypeId: productSizeTypes,
      File: productFile,
    };
    console.log(createProduct);
    axios
      .post(
        "https://e-commercemss.azurewebsites.net/api/Products",
        createProduct,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      )
      .then((response) => {
        setInfo("Ürün Başarıyla Eklendi");
        setVariant("success");
        setModalShow(true);
        setTimeout(() => {
          window.location.reload(false);
        }, 2000);
      })
      .catch((error) => {
        setInfo(error.response.data.Error);
        setVariant("danger");
        setModalShow(true);
        console.log(error);
      });
  }
  function deleteProduct(productId) {
    console.log(productId)
    // if (window.confirm("Bu ürünü silmek istediğinize emin misiniz?")) {
    //   axios
    //     .delete(`https://e-commercemss.azurewebsites.net/api/Products/${brand}`)
    //     .then((response) => {
    //       console.log(response);
    //       setInfo("Marka başarıyla silindi");
    //       setVariant("success");
    //       setModalShow(true);
    //     })
    //     .catch((error) => {
    //       console.log(error);
    //     });
    // }
  }
  return (
    <>
      <p className="display-6 text-center mb-4 border-bottom border-bottom pb-4">
        Ürünler
      </p>

      <div className="row">
        <Alert show={show} variant={variant}>
          <Alert.Heading>{info}</Alert.Heading>
          <div className="d-flex justify-content-end">
            <Button onClick={() => setModalShow(false)} variant={variant}>
              Kapat
            </Button>
          </div>
        </Alert>
        <div className="product-left col-12 col-lg-8">
          <p className="mb-4 fs-4 fw-semibold text-muted">Ürün Listesi</p>
          <Table hover responsive>
            <thead>
              <tr>
                <th>Sıra</th>
                <th>Ürün Başlığı</th>
                <th>Teknik Detaylar</th>
                <th>Marka</th>
                <th>Kategori</th>
                <th>Beden Türü</th>
                <th>Ürün Görsel</th>
                <th>Kontrol</th>
              </tr>
            </thead>
            <tbody>
              {productList.map((item, index) => (
                <tr key={index} className="align-middle">
                  <td>{index + 1}</td>
                  <td>{item.name}</td>
                  <td>{item.detail}</td>
                  <td className="text-uppercase">{item.brand.defination}</td>
                  <td>{item.category.defination}</td>
                  <td>{item.sizeType.defination}</td>
                  <td>
                    <img
                      height="100px"
                      src={`https://e-commercemss.azurewebsites.net/api/files/${item.imageUrl}`}
                      alt={item.name}
                    />
                  </td>
                  <td className="p-0">
                    <button
                      value={item.id}
                      onClick={(e) => deleteProduct(e.target.value)}
                      className="btn btn-dark text-white px-4"
                    >
                      Ürünü Sil
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
        <div className="product-right col-12 col-lg-4  border-start">
          <p className="mb-4 fs-4 fw-semibold text-muted">Ürün Ekle</p>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3">Ürün Başlığı</label>
            <input
              className="mb-3 d-flex p-2"
              name="brand"
              type="text"
              placeholder="Ürün Başlığı"
              onChange={(e) => setProductName(e.target.value)}
            />
            <label className="mb-2">Ürün Detaylar</label>
            <textarea
              className="mb-3 d-flex p-2"
              name="brand"
              type="text"
              placeholder="Ürün Detaylar"
              onChange={(e) => setProductSpecs(e.target.value)}
            />
            <label className="mb-2">Ürün Marka</label>
            <select
              className="p-2 mb-3"
              name="brand"
              id="brand"
              onChange={(e) => setProductBrand(e.target.value)}
            >
              <option>Seçin</option>

              {brands.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.defination}
                </option>
              ))}
            </select>
            <label className="mb-2">Ürün Kategori</label>
            <select
              className="p-2 mb-3"
              name="category"
              id="category"
              onChange={(e) => setproductCategory(e.target.value)}
            >
              <option>Seçin</option>
              {categories.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.defination}
                </option>
              ))}
            </select>
            <label className="mb-2">Beden Türü</label>
            <select
              className="p-2 mb-3"
              name="sizeType"
              id="sizeType"
              onChange={(e) => setProductSizeTypes(e.target.value)}
            >
              <option>Seçin</option>
              {sizeTypes.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.defination}
                </option>
              ))}
            </select>
            <label className="mb-2">Ürün Görseli</label>
            <div className="file-input mb-3">
              <input
                className="product-image-button btn ps-0 w-100"
                type="file"
                name=""
                id=""
                onChange={handleFile}
              />
            </div>
            <button
              type="submit"
              className="btn bg-dark text-white py-2 mb-2"
              onClick={handleSubmit}
            >
              Ürün Ekle
            </button>
          </form>
        </div>
      </div>
    </>
  );
}
