import axios from "axios";
import { useEffect, useState } from "react";
import { tokenStore } from "../store/generalStore";

export default function Favorites() {
  const [userName, setUserName] = useState(null);
  const [userId, setUserId] = useState(null);
  const { tokenId, tokenUsername } = tokenStore();
  const [favoriteProducts, setFavoriteProducts] = useState([]);
  let totalPrice = 0;
  favoriteProducts &&
    favoriteProducts.map((item) => {
      totalPrice += item.unitPrice;
      return null;
    });
  useEffect(() => {
    setUserName(tokenUsername);
  }, [tokenUsername]);
  useEffect(() => {
    if (tokenId != null) {
      axios
        .get(`http://api.mssdev.online/api/Users/${tokenId}/favoriteproducts`)
        .then((response) => {
          console.log(response.data);
          setFavoriteProducts(response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, [tokenId]);
  function favoriteProductDelete(productInStockId) {
    axios
      .delete(
        `http://api.mssdev.online/api/Baskets/${userName}/${productInStockId}`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
          },
        }
      )
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  }
  return (
    <>
      <div className="d-flex flex-column my-4 text-center">
        <p className="fs-1 text-secondary fw-bold">Favorilerim</p>
      </div>
      <div className="container mb-5">
        <div className="row">
          <div className="col-9 cart-products">
            {favoriteProducts &&
              favoriteProducts.map((item, index) => {
                return (
                  <div className="cart-product p-3 mb-4" key={index}>
                    <div className="d-flex justify-content-between border-bottom mb-3 pb-2">
                      <div className="product-seller d-flex">
                        <p>Satıcı Adı :</p>
                        <span className="ms-1 fw-semibold text-primary">
                          Satıcı Adı
                        </span>
                      </div>
                      <div className="product-campaign">
                        <div className="cart-seller">
                          <p className="fw-semibold text-danger">
                            Yeni
                          </p>
                        </div>
                      </div>
                    </div>
                    <p className="mb-3 my-2">
                      Tahmini <span className="fw-semibold">20 Haziran'da</span>{" "}
                      kapında!
                    </p>
                    <div className="d-flex align-items-center">
                      <div className="cart-product-image d-flex">
                        <img
                          src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                          alt=""
                          className="border rounded-3"
                        />
                      </div>
                      <div className="w-100 ms-4 align-items-between">
                        <div className="cart-product-content h-100">
                          <a
                            href={`/${item.category}/${item.supplierProductId}`}
                            className="mb-2 fw-semibold text-black text-decoration-none"
                          >
                            {item.title?item.title:"Ürün Başlığı"}
                          </a>
                          <p className="mb-2">{item.defination}</p>
                          <div className="d-flex align-items-end">
                            <p className="text-uppercase">{item.brand}</p>
                            <div className="d-flex w-100 justify-content-end align-items-end">
                              <p className="fw-semibold fs-5">
                                {item.unitPrice} TL
                              </p>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                );
              })}
          </div>
          <div className="col-3">
            <div className="cart-end d-flex flex-column align-items-center py-3">
              <p className="text-uppercase text-primary fw-semibold mb-3">
                Favori ürünler ({favoriteProducts && favoriteProducts.length})
              </p>
              <p className="fw-semibold display-5 mb-3">
                {totalPrice} <span className="fs-4">TL</span>
              </p>
              <button className="btn btn-primary text-white py-3 rounded-3 w-75 mb-3">
                Alışverişi tamamla
              </button>
              <div className="cart-end-sub d-flex justify-content-between w-75 mb-1">
                <p className="text-muted fw-semibold">Kargo :</p>
                <span className="text-success">Bedava</span>
              </div>
              <div className="cart-end-sub d-flex justify-content-between w-75">
                <p className="text-muted fw-semibold">Ürünler :</p>
                <span>{totalPrice} TL</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
