import { useEffect, useState } from "react";
import Alert from "react-bootstrap/Alert";
import Table from "react-bootstrap/Table";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import axios from "axios";
import { tokenStore } from "../../store/generalStore";

export default function SupplierProducts() {
  const [products, setProducts] = useState();
  const [productList, setProductList] = useState([]);
  const [productAddModal, setProductAddModal] = useState();
  const [productChangeModal, setProductChangeModal] = useState();
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const [colors, setColors] = useState([]);
  const [sizes, setSizes] = useState([]);
  const [changeProductId, setChangeProductId] = useState(0);
  const { tokenId } = tokenStore();

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/Products", {
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
      .get(`http://api.mssdev.online/api/suppliers/${tokenId}/products/`)
      .then((response) => {
        setProducts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [tokenId]);
  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/Colors", {
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
      .get("http://api.mssdev.online/api/Sizes", {
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

  function deleteProduct(id) {
    if (window.confirm("Bu markayı silmek istediğinize emin misiniz?")) {
      axios
        .delete(`http://api.mssdev.online/api/Suppliers/products/${id}`)
        .then((response) => {
          setInfo("Ürün Başarıyla Silindi");
          setVariant("success");
          setInfoModal(true);
        })
        .catch((error) => {
          setInfo(error.response.data);
          setVariant("danger");
          setInfoModal(true);
          console.log(error);
        });
    }
  }

  function AddProductModal(props) {
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
      formData.append("SupplierId", tokenId);
      formData.append("UnitPrice", productPrice);
      formData.append("Amount", productAmount);
      formData.append("CustomProductTitle", productTitle);
      formData.append("CustomProductDefination", productInfo);
      axios
        .post(
          `http://api.mssdev.online/api/suppliers/${tokenId}/products/`,
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
  function ChangeProductModal(props) {
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

      if (productFile == null) {
        formData.append("files", []);
      } else {
        for (let i = 0; i < productFile.length; i++) {
          formData.append("files", productFile[i]);
        }
      }
      formData.append(
        "Id",
        products && products[changeProductId].supplierProduct.id
      );
      formData.append(
        "SizeId",
        productSize
          ? productSize
          : products[changeProductId].supplierProduct.sizeId
      );
      formData.append(
        "ColorId",
        productColor
          ? productColor
          : products[changeProductId].supplierProduct.colorId
      );
      formData.append(
        "SupplierId",
        tokenId ? tokenId : products[changeProductId].supplierProduct.supplierId
      );
      formData.append(
        "UnitPrice",
        productPrice ? productPrice : products[changeProductId].unitPrice
      );
      formData.append(
        "Amount",
        productAmount ? productAmount : products[changeProductId].amount
      );
      formData.append(
        "CustomProductTitle",
        productTitle
          ? productTitle
          : products[changeProductId].supplierProduct.customProductTitle
      );
      formData.append(
        "CustomProductDefination",
        productInfo
          ? productInfo
          : products[changeProductId].supplierProduct.customProductDefination
      );
      console.log(formData);
      var object = {};
      formData.forEach((value, key) => (object[key] = value));
      var json = JSON.stringify(object);
      console.log(json);
      axios
        .put(
          `http://api.mssdev.online/api/Suppliers/products/${
            products && products[changeProductId].supplierProductId
          }`,
          formData,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              "Content-Type": "multipart/form-data",
            },
          }
        )
        .then((response) => {
          setInfo("Ürün Başarıyla Düzenlendi");
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

    function deleteProductImage(imageUrl) {
      axios
        .delete(
          `http://api.mssdev.online/api/Suppliers/products/${
            products && products[changeProductId].supplierProductId
          }/images/${imageUrl}`
        )
        .then((response) => {
          console.log(response);
          setInfo("Görsel Başarıyla Silindi");
          setVariant("success");
          setInfoModal(true);
        })
        .catch((error) => {
          setInfo(error.response.data);
          setVariant("danger");
          setInfoModal(true);
          console.log(error);
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
            Ürün Düzenle
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3 fw-semibold ">Ürün</label>
            <select className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0">
              <option
                value={
                  products &&
                  products[changeProductId].supplierProduct.product.id
                }
              >
                {products &&
                  products[changeProductId].supplierProduct.product.name}
              </option>
              {/* {productList.map((item, index) => (
                <option
                  selected={
                    products &&
                    item.name ==
                      products[changeProductId].supplierProduct.product.name
                      ? `selected`
                      : `asdasd`
                  }
                  value={item.id}
                  key={index}
                >
                  {item.name}
                </option>
              ))} */}
            </select>
            <label className="mb-3 fw-semibold ">Ürün Başlığı</label>
            <input
              className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder={
                products &&
                products[changeProductId].supplierProduct.customProductTitle
              }
              onChange={(e) => setProductTitle(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Ürün Detaylar</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder={
                products &&
                products[changeProductId].supplierProduct.product.detail
              }
              onChange={(e) => setProductInfo(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Beden</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="sizeType"
              id="sizeType"
              onChange={(e) => setProductSize(e.target.value)}
            >
              <option
                value={
                  products && products[changeProductId].supplierProduct.size.id
                }
              >
                {products &&
                  products[changeProductId].supplierProduct.size.value}
              </option>
              {sizes.map((item, index) => (
                <option value={item.id} key={index}>
                  {item.value}
                </option>
              ))}
            </select>
            <label className="mb-3 fw-semibold ">Renk</label>
            <select
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="color"
              id="color"
              onChange={(e) => setProductColor(e.target.value)}
            >
              <option
                value={
                  products && products[changeProductId].supplierProduct.color.id
                }
              >
                {products &&
                  products[changeProductId].supplierProduct.color.defination}
              </option>
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
                  placeholder={
                    products &&
                    products[changeProductId].supplierProduct.unitPrice
                  }
                  onChange={(e) => setProductPrice(e.target.value)}
                />
              </div>
              <div className="d-flex flex-column">
                <label className="mb-3 fw-semibold ">Ürün Stok Miktarı</label>
                <input
                  className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                  name="amount"
                  type="number"
                  placeholder={products && products[changeProductId].amount}
                  onChange={(e) => setProductAmount(e.target.value)}
                />
              </div>
            </div>
            <label className="mb-3 fw-semibold ">Ürün Görselleri</label>
            <div className="row">
              {products &&
                products[changeProductId].supplierProduct.productImages.map(
                  (item, index) => {
                    return (
                      <div
                        key={index}
                        className="image-edit col-2 d-flex align-items-center justify-content-center my-2"
                      >
                        <img
                          className="mini-img"
                          src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                          alt=""
                        />
                        <button
                          value={item.imageUrl}
                          className="image-delete-button btn"
                          onClick={(event) => {
                            event.preventDefault();
                            deleteProductImage(event.target.value);
                          }}
                        ></button>
                      </div>
                    );
                  }
                )}
            </div>
            <label className="mb-3 fw-semibold ">Yeni Görsel Ekle</label>
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
              Düzenlemeleri Kaydet
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
          <Table responsive hover borderless variant="light">
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Ürün Başlığı</th>
                <th>Marka</th>
                <th>Kategori</th>
                <th>Ürün Görseli</th>
                <th>Fiyat</th>
                <th>Kontrol</th>
                <th>Kontrol</th>
              </tr>
            </thead>
            <tbody>
              {products &&
                products.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>{item.supplierProduct.customProductTitle}</td>
                    <td className="text-uppercase">
                      {item.supplierProduct.product.brand.defination}
                    </td>
                    <td>{item.supplierProduct.product.category.defination}</td>
                    <td>
                      <img
                        height="50px"
                        src={`http://api.mssdev.online/api/files/${item.supplierProduct.productImages[0].imageUrl}`}
                        alt={item.supplierProduct.customProductTitle}
                      />
                    </td>
                    <td>{item.unitPrice} TL</td>
                    <td className="p-0">
                      <button
                        value={index}
                        onClick={(e) => {
                          setProductChangeModal(true),
                            setChangeProductId(e.target.value);
                        }}
                        className="btn btn-light border px-4 rounded-3"
                      >
                        Ürünü Düzenle
                      </button>
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
        <ChangeProductModal
          show={productChangeModal}
          onHide={() => setProductChangeModal(false)}
        />
      </div>
    </>
  );
}
