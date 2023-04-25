import { useEffect, useState } from "react";
import Alert from "react-bootstrap/Alert";
import Table from "react-bootstrap/Table";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import { Base64 } from "js-base64";
import axios from "axios";

export default function SupplierProducts() {
  const [products, setProducts] = useState();
  const [productList, setProductList] = useState([]);
  const [productAddModal, setProductAddModal] = useState();
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const [colors, setColors] = useState([]);
  const [sizes, setSizes] = useState([]);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Products", {
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
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const filteredToken = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = filteredToken.substring(1, filteredToken.length - 1);
    const decodedPayload = Base64.decode(trimmedPayload);
    let supplierId = JSON.parse(decodedPayload).Id;
    axios
      .get(
        `https://e-commercemss.azurewebsites.net/api/suppliers/${supplierId}/products/`
      )
      .then((response) => {
        setProducts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Colors", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setColors(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Sizes", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setSizes(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  }, []);
  function AddProductModal(props) {
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const filteredToken = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = filteredToken.substring(1, filteredToken.length - 1);
    const decodedPayload = Base64.decode(trimmedPayload);
    let supplierId = JSON.parse(decodedPayload).Id;
    //Post Stateleri
    const [productId, setProductId] = useState();
    const [productTitle, setProductTitle] = useState();
    const [productSize, setProductSize] = useState();
    const [productColor, setProductColor] = useState();
    const [productInfo, setProductInfo] = useState();
    const [productFile, setProductFile] = useState(null);
    const [productPrice, setProductPrice] = useState();
    const [productAmount, setProductAmount] = useState();

    function handleFile(event) {
      event.preventDefault();
      setProductFile(event.target.files);
    }

    function handleSubmit(event) {
      event.preventDefault();

      const formData = new FormData();

      for (let i = 0; i < productFile.length; i++) {
        formData.append("files", productFile[i]);
      }

      formData.append("ProductId", productId);
      formData.append("SizeId", productSize);
      formData.append("ColorId", productColor);
      formData.append("SupplierId", supplierId);
      formData.append("UnitPrice", productPrice);
      formData.append("Amount", productAmount);
      formData.append("CustomProductTitle", productTitle);
      formData.append("CustomProductDefination", productInfo);
      axios
        .post(
          `https://e-commercemss.azurewebsites.net/api/suppliers/${supplierId}/products/`,
          formData,
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
          console.log(response);
          // setTimeout(() => {
          //   window.location.reload(false);
          // }, 2000);
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
            <label className="mb-3 fw-semibold ">Ürün</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="sizeType"
              id="sizeType"
              onChange={(e) => setProductId(e.target.value)}
            >
              <option>Seçin</option>
              {productList.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.name}
                </option>
              ))}
            </select>
            <label className="mb-3 fw-semibold ">Ürün Başlığı</label>
            <input
              className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Ürün Başlığı"
              onChange={(e) => setProductTitle(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Ürün Detaylar</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Ürün Detaylar"
              onChange={(e) => setProductInfo(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Beden</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="sizeType"
              id="sizeType"
              onChange={(e) => setProductSize(e.target.value)}
            >
              <option>Seçin</option>
              {sizes.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.value}
                </option>
              ))}
            </select>
            <label className="mb-3 fw-semibold ">Renk</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="sizeType"
              id="sizeType"
              onChange={(e) => setProductColor(e.target.value)}
            >
              <option>Seçin</option>
              {colors.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.defination}
                </option>
              ))}
            </select>
            <div className="d-flex">
              <div className="d-flex flex-column">
                <label className="mb-3 fw-semibold ">Ürün Fiyatı</label>
                <input
                  className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                  name="price"
                  type="number"
                  placeholder="Ürün Fiyatı"
                  onChange={(e) => setProductPrice(e.target.value)}
                />
              </div>
              <div className="d-flex flex-column">
                <label className="mb-3 fw-semibold ">Ürün Stok Miktarı</label>
                <input
                  className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                  name="amount"
                  type="number"
                  placeholder="Ürün Stok Miktarı"
                  onChange={(e) => setProductAmount(e.target.value)}
                />
              </div>
            </div>
            <label className="mb-3 fw-semibold ">Ürün Görseli</label>
            <div className="file-input mb-3">
              <input
                className="product-image-button btn ps-0 w-100 border rounded-3"
                type="file"
                name="files"
                id="files"
                onChange={handleFile}
                multiple
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
                <th>Ürün Bilgisi</th>
                <th>Marka</th>
                <th>Kategori</th>
                <th>Beden Türü</th>
                <th>Ürün Görseli</th>
                <th>Fiyat</th>
                <th>Kontrol</th>
              </tr>
            </thead>
            <tbody>
              {products &&
                products.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>{item.supplierProduct.customProductTitle}</td>
                    <td>{item.supplierProduct.customProductDefination}</td>
                    <td className="text-uppercase">
                      {item.supplierProduct.product.brand.defination}
                    </td>
                    <td>{item.supplierProduct.product.category.defination}</td>
                    <td>{item.supplierProduct.product.sizeType.defination}</td>
                    <td>
                      <img
                        height="50px"
                        src={`https://e-commercemss.azurewebsites.net/api/files/${item.supplierProduct.productImages[0].imageUrl}`}
                        alt={item.supplierProduct.customProductTitle}
                      />
                    </td>
                    <td>{item.unitPrice} TL</td>
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
