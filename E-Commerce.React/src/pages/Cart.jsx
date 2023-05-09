import { useEffect, useState } from "react";
import { basketStore } from "../store/basketStore";

export default function Cart() {
  const { basketItems } = basketStore();
  console.log(basketItems);
  let totalPrice = 0;
  basketItems &&
    basketItems.map((item) => {
      totalPrice += item.unitPrice * item.amount;
      return null;
    });
  console.log(basketItems);
  return (
    <>
      <div className="d-flex flex-column my-4 text-center">
        <p className="fs-1 text-secondary fw-bold">Sepetim</p>
      </div>
      <div className="container mb-5">
        <div className="row">
          <div className="col-9 cart-products">
            {basketItems &&
              basketItems.map((item, index) => {
                return (
                  <div className="cart-product p-3 mb-4" key={index}>
                    <div className="d-flex justify-content-between border-bottom mb-3 pb-2">
                      <div className="product-seller d-flex">
                        <p>Satıcı Adı :</p>
                        <span className="ms-1 fw-semibold text-primary">
                          {item.supplier.name}
                        </span>
                      </div>
                      <div className="product-campaign">
                        <div className="cart-seller">
                          <p className="fw-semibold text-success">
                            Kargo bedava
                          </p>
                        </div>
                      </div>
                    </div>
                    <p className="mb-3 my-2">
                      Tahmini <span className="fw-semibold">20 Mayıs'ta</span>{" "}
                      kapında!
                    </p>
                    <div className="d-flex align-items-center">
                      <div className="cart-product-image d-flex">
                        <img
                          src={`https://e-commercemss.azurewebsites.net/api/files/${item.imageUrl}`}
                          alt=""
                          className="border rounded-3"
                        />
                      </div>
                      <div className="w-100 ms-4">
                        <div className="cart-product-content">
                          <a
                            href={`/${item.category}/${item.supplierProductId}`}
                            className="mb-2 fw-semibold text-black text-decoration-none"
                          >
                            {item.customProductTitle}
                          </a>
                          <p className="mb-2">{item.brand}</p>
                          <div className="d-flex w-100 justify-content-between align-items-end">
                            {item.amount == 1 ? (
                              <div className="product-piece d-flex justify-content-center">
                                <div className="piece-box border d-flex align-items-center bg-white rounded-3">
                                  <a
                                    className="btn btn-white fs-5 h-100 rounded-3 d-flex align-items-center"
                                    // onClick={() => calcPiece(-1)}
                                  >
                                    <svg
                                      xmlns="http://www.w3.org/2000/svg"
                                      width="25"
                                      height="25"
                                      viewBox="0 0 24 24"
                                      fill="none"
                                    >
                                      <path
                                        d="M4.99997 8H6.5M6.5 8V18C6.5 19.1046 7.39543 20 8.5 20H15.5C16.6046 20 17.5 19.1046 17.5 18V8M6.5 8H17.5M17.5 8H19M9 5H15M9.99997 11.5V16.5M14 11.5V16.5"
                                        stroke="#000"
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                      />
                                    </svg>
                                  </a>
                                  <p className="px-3">{item.amount}</p>
                                  <a
                                    className="btn btn-white fs-5 h-100 rounded-3"
                                    // onClick={() => calcPiece(+1)}
                                  >
                                    +
                                  </a>
                                </div>
                              </div>
                            ) : (
                              <div className="product-piece d-flex justify-content-center">
                                <div className="piece-box border d-flex align-items-center bg-white rounded-3">
                                  <a
                                    className="btn btn-white fs-5 h-100 rounded-3"
                                    // onClick={() => calcPiece(-1)}
                                  >
                                    -
                                  </a>
                                  <p className="px-3">{item.amount}</p>
                                  <a
                                    className="btn btn-white fs-5 h-100 rounded-3"
                                    // onClick={() => calcPiece(+1)}
                                  >
                                    +
                                  </a>
                                </div>
                                <a
                                  className="btn btn-white fs-5 h-100 rounded-3 d-flex align-items-center"
                                  // onClick={() => calcPiece(-1)}
                                >
                                  <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    width="30"
                                    height="30"
                                    viewBox="0 0 24 24"
                                    fill="none"
                                  >
                                    <path
                                      d="M4.99997 8H6.5M6.5 8V18C6.5 19.1046 7.39543 20 8.5 20H15.5C16.6046 20 17.5 19.1046 17.5 18V8M6.5 8H17.5M17.5 8H19M9 5H15M9.99997 11.5V16.5M14 11.5V16.5"
                                      stroke="#000"
                                      strokeLinecap="round"
                                      strokeLinejoin="round"
                                    />
                                  </svg>
                                </a>
                              </div>
                            )}
                            <p className="fw-semibold fs-5">
                              {item.unitPrice} TL
                            </p>
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
                Seçilen ürünler ({basketItems && basketItems.length})
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
