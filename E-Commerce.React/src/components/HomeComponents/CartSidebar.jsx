import React, { useState } from "react";
import { CartSidebarStore } from "../../store/CartSidebarStore";

const data = [
  {
    id: 1,
    brand: "Nike",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Jordan-PNG-Pic.png",
  },
  {
    id: 2,
    brand: "Adidas",
    title: "Adidas React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-Clipart.png",
  },
];

function CartProduct(props) {
  return (
    <div className="product d-flex border-top position-relative">
      <div className="product-image d-flex align-items-center p-2">
        <img width="100px" src={props.image} alt="" />
      </div>
      <div className="product-content p-2">
        <p className="mb-2">{props.brand}</p>
        <p className="mb-3">{props.title}</p>
        <div className="d-flex align-items-center">
          <a href="#!" className="cart-delete-button">
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
          <p className="fw-semibold">${props.price}</p>
        </div>
      </div>
    </div>
  );
}

export default function CartSidebar() {
  let totalPrice = 0;
  data.map((item) => {
    totalPrice += item.price;
    return null; // Boş bir değer döndür, çünkü map fonksiyonu bir dizi döndürmelidir
  });
  const { sidebarActive, setSidebarActive } = CartSidebarStore();
  return (
    <>
      <div
        onClick={() => {
          setSidebarActive(false);
        }}
        className={`sidebar ${sidebarActive ? "active" : ""}`}
      ></div>
      <div className={`cart-sidebar bg-light ${sidebarActive ? "active" : ""}`}>
        <div className="">
          <div className="d-flex flex-column p-5">
            <div className="cart-title mb-5">
              <p className="fs-2 fw-semibold mb-2">Alışveriş Sepeti</p>
              <span className="fs-5">
                Sepetinizde <u className="underline">{data.length} ürün</u>{" "}
                bulunmaktadır.
              </span>
            </div>
            <div className="cart-items">
              {data.map((item,index) => (
                <CartProduct
                  key={item.id}
                  image={item.image}
                  brand={item.brand}
                  title={item.title}
                  price={item.price}
                />
              ))}
              <div className="cart-total border-top mb-4 pt-4">
                <p className="fs-4">Sepet Toplamı</p>
                <span className="fs-5 fw-bold">${totalPrice}</span>
              </div>
            </div>
            <div className="cart-buttons d-flex flex-column">
              <a href="/cart" className="btn btn-dark mb-3 p-3">Sepete Git</a>
              <button
                className="btn btn-outline-dark p-3"
                onClick={() => {
                  setSidebarActive(false);
                }}
              >
                Alışverişe Devam Et
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
