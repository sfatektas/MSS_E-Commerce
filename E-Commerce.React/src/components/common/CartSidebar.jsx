import { useEffect } from "react";
import { basketStore, cartSidebarStore } from "../../store/basketStore";
import { generalStore } from "../../store/generalStore";

function CartProduct(props) {
  return (
    <div className="product d-flex border-top position-relative">
      <div className="product-image d-flex align-items-center p-2">
        <img
          height="100px"
          width="100px"
          src={`https://e-commercemss.azurewebsites.net/api/files/${props.image}`}
          alt=""
        />
      </div>
      <div className="product-content p-2">
        <a href="#!" className="mb-2 fw-semibold text-decoration-none text-black">{props.brand}</a>
        <p className="mb-3">{props.title}</p>
        <p className="mb-3 position-absolute end-0">{props.amount} Adet</p>
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
          <p className="fw-semibold">{props.price} TL</p>
        </div>
      </div>
    </div>
  );
}

export default function CartSidebar() {
  const { basketItems } = basketStore();
  const { options } = generalStore();
  const { sidebarActive, setSidebarActive } = cartSidebarStore();
  console.log(basketItems)

  let totalPrice = 0;
  basketItems &&
    basketItems.map((item) => {
      totalPrice += item.unitPrice * item.amount;
      return null;
    });

  if (localStorage.getItem("user_token") != null) {
    if (basketItems != null) {
      return (
        <>
          <div
            onClick={() => {
              setSidebarActive(false);
            }}
            className={`sidebar ${sidebarActive ? "active" : ""}`}
          ></div>
          <div
            className={`cart-sidebar bg-light ${sidebarActive ? "active" : ""}`}
          >
            <div className="">
              <div className="d-flex flex-column p-5">
                <div className="cart-title mb-5">
                  <p className="fs-2 fw-semibold mb-2">Alışveriş Sepeti</p>
                  <span className="fs-5">
                    Sepetinizde{" "}
                    <u className="underline">{basketItems.length} ürün</u>{" "}
                    bulunmaktadır.
                  </span>
                </div>
                <div className="cart-items">
                  {basketItems.map((item, index) => (
                    <CartProduct
                      key={item.id}
                      image={item.imageUrl}
                      brand={item.productName}
                      title={item.customProductTitle}
                      price={item.unitPrice}
                      amount={item.amount}
                    />
                  ))}
                  <div className="cart-total border-top mb-4 pt-4">
                    <p className="fs-4">Sepet Toplamı</p>
                    <span className="fs-5 fw-bold">{totalPrice} TL</span>
                  </div>
                </div>
                <div className="cart-buttons d-flex flex-column">
                  <a href="/cart" className="btn btn-dark mb-3 p-3">
                    Sepete Git
                  </a>
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
    } else {
      return (
        <>
          <div
            onClick={() => {
              setSidebarActive(false);
            }}
            className={`sidebar ${sidebarActive ? "active" : ""}`}
          ></div>
          <div
            className={`cart-sidebar bg-light ${sidebarActive ? "active" : ""}`}
          >
            <div className="">
              <div className="d-flex flex-column p-5">
                <div className="cart-title mb-5">
                  <p className="fs-2 fw-semibold mb-2">Alışveriş Sepeti</p>
                  <span className="fs-5">
                    Sepetinizde ürün bulunmamaktadır.
                  </span>
                </div>
                <div className="cart-buttons d-flex flex-column">
                  <a href="/" className="btn btn-dark mb-3 p-3">
                    Alışverişe Başla
                  </a>
                </div>
              </div>
            </div>
          </div>
        </>
      );
    }
  } else {
    return (
      <>
        <div
          onClick={() => {
            setSidebarActive(false);
          }}
          className={`sidebar ${sidebarActive ? "active" : ""}`}
        ></div>
        <div
          className={`cart-sidebar bg-light ${sidebarActive ? "active" : ""}`}
        >
          <div className="">
            <div className="d-flex flex-column p-5">
              <div className="logo d-flex justify-content-center mb-4">
                <a
                  href="/"
                  className="logo-text text-decoration-none text-black display-5 fw-bold"
                >
                  {options && options.logo}
                </a>
              </div>
              <div className="cart-title mb-5">
                <p className="fs-2 fw-semibold mb-2">Lütfen Giriş Yapın</p>
              </div>
              <div className="cart-buttons d-flex flex-column">
                <a href="/login" className="btn btn-dark mb-3 p-3">
                  Giriş Yap
                </a>
                <a href="/register" className="btn btn-outline-dark mb-3 p-3">
                  Kayıt Ol
                </a>
              </div>
            </div>
          </div>
        </div>
      </>
    );
  }
}
