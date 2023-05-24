import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import axios from "axios";
import { useEffect, useState } from "react";

export default function AdminProducts() {
  //Form Listelemeleri
  const [productList, setProductList] = useState([]);
  const [categories, setCategories] = useState([]);
  const [brands, setBrands] = useState([]);
  const [sizeTypes, setSizeTypes] = useState([]);
  //Modal Stateleri
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const [productAddModal, setProductAddModal] = useState();

  useEffect(() => {
    axios
      .get("https://msse-commerce.azurewebsites.net/api/Products", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setProductList(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://msse-commerce.azurewebsites.net/api/Categories", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setCategories(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://msse-commerce.azurewebsites.net/api/Brands", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then(({ data }) => setBrands(data))
      .catch((error) => {
        console.log(error.response.data);
      });
  }, []);

  useEffect(() => {
    axios
      .get("https://msse-commerce.azurewebsites.net/api/sizetypes", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setSizeTypes(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  }, []);

  function deleteProduct(productId) {
    if (window.confirm("Bu ürünü silmek istediğinize emin misiniz?")) {
      axios
        .delete(
          `https://msse-commerce.azurewebsites.net/api/Products/${productId}`,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
            },
          }
        )
        .then((response) => {
          setInfo("Ürün başarıyla silindi");
          setVariant("success");
          setInfoModal(true);
        })
        .catch((error) => {
          console.log(error.response.data);
        });
    }
  }

  function AddProductModal(props) {
    //Post Stateleri
    const [productName, setProductName] = useState("");
    const [productSpecs, setProductSpecs] = useState("");
    const [productBrand, setProductBrand] = useState("");
    const [productCategory, setproductCategory] = useState("");
    const [productSizeTypes, setProductSizeTypes] = useState("");
    const [productFile, setProductFile] = useState();

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
      axios
        .post(
          "https://msse-commerce.azurewebsites.net/api/Products",
          createProduct,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              "Content-Type": "multipart/form-data",
            },
          }
        )
        .then((response) => {
          setInfo("Ürün Başarıyla Eklendi");
          setVariant("success");
          setInfoModal(true);
          setTimeout(() => {
            window.location.reload(false);
          }, 2000);
        })
        .catch((error) => {
          setInfo(error.response.data.Error);
          setVariant("danger");
          setInfoModal(true);
          setProductAddModal(false);
          console.log(error.response.data);
        });
    }
    return (
      <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Ürün Ekle
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3 fw-semibold ">Ürün Başlığı</label>
            <input
              className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Ürün Başlığı"
              onChange={(e) => setProductName(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Ürün Detaylar</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Ürün Detaylar"
              onChange={(e) => setProductSpecs(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Ürün Marka</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
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
            <label className="mb-3 fw-semibold ">Ürün Kategori</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
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
            <label className="mb-3 fw-semibold ">Beden Türü</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
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
            <label className="mb-3 fw-semibold ">Ürün Görseli</label>
            <div className="file-input mb-3">
              <input
                className="product-image-button btn ps-0 w-100 border rounded-3"
                type="file"
                name=""
                id=""
                onChange={handleFile}
              />
            </div>
            <button
              type="submit"
              className="btn btn-light border py-2 mb-2 rounded-3"
              onClick={handleSubmit}
            >
              Ürün Ekle
            </button>
          </form>
        </Modal.Body>
        <Modal.Footer>
          <button
            className="btn btn-light border rounded-3 px-5"
            onClick={props.onHide}
          >
            Kapat
          </button>
        </Modal.Footer>
      </Modal>
    );
  }

  return (
    <>
      <div className="row">
        <Alert show={infoModal} variant={variant}>
          <Alert.Heading>{info}</Alert.Heading>
          <div className="d-flex justify-content-end">
            <Button onClick={() => setInfoModal(false)} variant={variant}>
              Kapat
            </Button>
          </div>
        </Alert>
        <div className="admin-product col-12">
          <div className="d-flex justify-content-between">
            <p className="mb-4 fs-4 fw-semibold text-muted">Ürünler</p>
            <button
              className="btn btn-light rounded-3 border px-5 fw-semibold"
              onClick={() => setProductAddModal(true)}
            >
              Ürün Ekle
            </button>
          </div>
          <Table responsive hover borderless>
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Ürün Başlığı</th>
                <th>Teknik Detaylar</th>
                <th>Marka</th>
                <th>Kategori</th>
                <th>Beden Türü</th>
                <th>Ürün Görseli</th>
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
                      height="50px"
                      src={`https://msse-commerce.azurewebsites.net/api/files/${item.imageUrl}`}
                      alt={item.name}
                    />
                  </td>
                  <td className="p-0">
                    <button
                      value={item.id}
                      onClick={(e) => deleteProduct(e.target.value)}
                      className="btn btn-light border px-4 rounded-3"
                    >
                      Ürünü Sil
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
        <AddProductModal
          show={productAddModal}
          onHide={() => setProductAddModal(false)}
        />
      </div>
    </>
  );
}
