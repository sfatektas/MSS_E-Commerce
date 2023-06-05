import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import Modal from "react-bootstrap/Modal";
import { generalStore, tokenStore } from "../store/generalStore";
import { cartSidebarStore } from "../store/basketStore";
import Showcase from "../components/common/Showcase";
import axios from "axios";
import { Navigate } from "react-router-dom";
import * as signalR from "@microsoft/signalr";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import { favoriteStore } from "../store/favoriteStore";

// Ürünler API'den çekildiği zaman title sorgulanıp true dönerse sayfa görüntülenecek.
export default function Product() {
  const { name } = useParams();
  const { defination } = useParams();
  const [product, setProduct] = useState();
  const { options } = generalStore();
  const { setSidebarActive } = cartSidebarStore();
  const [productPiece, setProductPiece] = useState(1);
  const [colorVariant, setColorVariant] = useState();
  const [sizeVariant, setSizeVariant] = useState();
  const [productDetails, setDroductDetails] = useState("details");
  const [basketModal, setBasketModal] = useState(false);
  const [favoritesModal, setFavoritesModal] = useState(false);
  const [carouselPosition, setCarouselPosition] = useState(0);
  const [bigImage, setBigImage] = useState("");
  const [hubConnection, setHubConnection] = useState();
  const [liveVisiters, setLiveVisiters] = useState();
  const [userName, setUserName] = useState(null);
  const [comments, setComments] = useState();
  const [commentContent, setcommentContent] = useState();
  const [commentStar, setCommentStar] = useState();
  const [featuredProducts, setFeaturedProducts] = useState();
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const { tokenUsername, tokenId, tokenRole } = tokenStore();
  const { getFavoriteItems } = favoriteStore();
  let productRate = 0;

  useEffect(() => {
    setUserName(tokenUsername);
  }, [tokenUsername]);

  const createHubConnection = async () => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl(`http://api.mssdev.online/visit?productId=${name}`, {
        transport: signalR.HttpTransportType.WebSockets,
        skipNegotiation: true,
      })
      .build();
    try {
      await connection.start();
      setHubConnection(connection);
      connection.onclose(async () => {
        await start();
      });
      connection.on("ReceiveMessage", (visiters) => {
        setLiveVisiters(visiters);
      });
    } catch (e) {
      console.log("Error : ", e);
    }
  };

  useEffect(() => {
    createHubConnection();
  }, []);

  useEffect(() => {
    axios
      .get(`http://api.mssdev.online/api/suppliers/products/${name}`)
      .then((response) => {
        setProduct(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
        setProduct("Hata");
      });
  }, []);

  useEffect(() => {
    axios
      .get(
        `http://api.mssdev.online/api/salesproducts?category=${defination}&pagesize=24&pagenumber=1&color=${""}&size=${""}&brand=${""}&minprice=${""}&maxprice=${""}&search=${""}`
      )
      .then((response) => {
        setFeaturedProducts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get(`http://api.mssdev.online/api/productınstocks/${name}/Comments`)
      .then((response) => {
        setComments(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function addComment(event) {
    event.preventDefault;
    if (localStorage.getItem("user_token") != null) {
      const comment = {
        productsInStockId: name,
        customerId: tokenId,
        content: commentContent,
        point: commentStar,
        // createdDate: null,
      };
      console.log(comment);

      if (tokenRole == "customer") {
        if (commentContent == null || commentStar == null) {
          setInfo("Yorum ve puan bilgisi eksik olamaz!");
          setVariant("danger");
          setInfoModal(true);
        } else {
          axios
            .post(
              `http://api.mssdev.online/api/productınstocks/${name}/Comments`,
              comment
            )
            .then((response) => {
              setInfo("Yorum başarıyla eklendi");
              setVariant("success");
              setInfoModal(true);
              setTimeout(() => {
                window.location.reload(true);
              }, 1500);
            })
            .catch((error) => {
              setInfo(error.response.data);
              setVariant("danger");
              setInfoModal(true);
            });
        }
      } else {
        setInfo("Yorum yapma yetkiniz bulunmuyor!");
        setVariant("danger");
        setInfoModal(true);
      }
    } else {
      setSidebarActive(true);
    }
  }

  function addBasket() {
    const basketItem = {
      username: userName,
      productInStockId: name,
      amount: productPiece,
    };
    console.log(basketItem);
    if (userName != null) {
      axios
        .post(`http://api.mssdev.online/api/baskets/${userName}`, basketItem)
        .then((response) => {
          console.log(response);
          setBasketModal(true);
        })
        .catch((error) => {
          console.log(error);
        });
    } else {
      setSidebarActive(true);
    }
  }
  function addFavorites(id) {
    if (userName != null) {
      axios
        .post(
          `http://api.mssdev.online/api/Users/${tokenId}/favoriteproducts/${id}`
        )
        .then((response) => {
          console.log(response);
          setFavoritesModal(true);
          getFavoriteItems(tokenId, tokenRole);
        })
        .catch((error) => {
          console.log(error);
        });
    } else {
      setSidebarActive(true);
    }
  }
  useEffect(() => {
    setTimeout(() => {
      setBasketModal(false);
      setFavoritesModal(false);
    }, 1500);
  }, [basketModal, favoritesModal]);

  function calcPiece(piece) {
    if (piece !== -1 || productPiece !== 0) {
      setProductPiece(productPiece + piece);
    }
  }

  function calcCarousel(position) {
    let carouselWidth = 330; // Showcase genişliğini gir.
    let carouselItems = featuredProducts.length; // Carousel'e kaç tane showcase item basılacaksa onun değerini gir.
    let carouselLimit = carouselWidth * (carouselItems - 4); // Carousel limit hesaplaması

    if (position == "next") {
      if (carouselPosition > -carouselLimit) {
        setCarouselPosition(carouselPosition - 1320);
      }
    } else {
      if (carouselPosition < 0) {
        setCarouselPosition(carouselPosition + 1320);
      }
    }
  }

  function AddedCartModal(props) {
    return (
      <Modal
        {...props}
        size="md"
        aria-labelledby="contained-modal-title-vcenter"
      >
        <Modal.Body className="overflow-hidden position-relative rounded-3">
          <div className="basket-left-color bg-success"></div>
          <div className=" text-center d-flex align-items-center justify-content-center">
            <div className="basket-modal-icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="#000000"
                width="30"
                height="30"
                viewBox="0 0 14 14"
                role="img"
                focusable="false"
                aria-hidden="true"
              >
                <path
                  fill="green"
                  d="M13 4.1974q0 .3097-.21677.5265L7.17806 10.329l-1.0529 1.0529q-.21677.2168-.52645.2168-.30968 0-.52645-.2168L4.01935 10.329 1.21677 7.5264Q1 7.3097 1 7t.21677-.5265l1.05291-1.0529q.21677-.2167.52645-.2167.30968 0 .52645.2167l2.27613 2.2839 5.07871-5.0864q.21677-.2168.52645-.2168.30968 0 .52645.2168l1.05291 1.0529Q13 3.8877 13 4.1974z"
                />
              </svg>
            </div>
            <div className="basket-modal-text ps-2">
              <p>Ürün sepete eklendi</p>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    );
  }
  function AddedFavoritesModal(props) {
    return (
      <Modal
        {...props}
        size="sm"
        aria-labelledby="contained-modal-title-vcenter"
      >
        <Modal.Body className="overflow-hidden position-relative rounded-3">
          <div className="favorites-left-color bg-primary"></div>
          <div className=" text-center d-flex align-items-center justify-content-center">
            <div className="favorites-modal-icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M19.3 5.71002C18.841 5.24601 18.2943 4.87797 17.6917 4.62731C17.0891 4.37666 16.4426 4.2484 15.79 4.25002C15.1373 4.2484 14.4909 4.37666 13.8883 4.62731C13.2857 4.87797 12.739 5.24601 12.28 5.71002L12 6.00002L11.72 5.72001C10.7917 4.79182 9.53273 4.27037 8.22 4.27037C6.90726 4.27037 5.64829 4.79182 4.72 5.72001C3.80386 6.65466 3.29071 7.91125 3.29071 9.22002C3.29071 10.5288 3.80386 11.7854 4.72 12.72L11.49 19.51C11.6306 19.6505 11.8212 19.7294 12.02 19.7294C12.2187 19.7294 12.4094 19.6505 12.55 19.51L19.32 12.72C20.2365 11.7823 20.7479 10.5221 20.7442 9.21092C20.7405 7.89973 20.2218 6.64248 19.3 5.71002Z"
                  fill="#EF3636"
                ></path>
              </svg>
            </div>
            <div className="favorites-modal-text ps-2">
              <p>Ürün favorilere eklendi</p>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    );
  }
  if (product != undefined && product != "Hata") {
    return (
      <>
        <div className="visiters">
          <p>Bu ürünü şu anda {liveVisiters} kişi görüntülüyor</p>
        </div>
        <div className="container">
          <div className="row my-5">
            <div className="col-12 col-lg-6">
              <div className="product-left">
                <div className="row mb-4 d-flex flex-column">
                  <div className="big-image mb-4">
                    <img
                      src={
                        bigImage
                          ? bigImage
                          : `http://api.mssdev.online/api/files/${product.productInStock.supplierProduct.productImages[0].imageUrl}`
                      }
                      alt=""
                    />
                  </div>
                  <div className="mini-images d-flex justify-content-around">
                    {product.productInStock.supplierProduct.productImages.map(
                      (item) => {
                        return (
                          <a
                            key={item.id}
                            onClick={() =>
                              setBigImage(
                                `http://api.mssdev.online/api/files/${item.imageUrl}`
                              )
                            }
                            href="#!"
                            className="mb-2 d-flex justify-content-center"
                          >
                            <img
                              src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                              alt=""
                            />
                          </a>
                        );
                      }
                    )}
                  </div>
                </div>
              </div>
            </div>
            <div className="col-12 col-lg-6">
              <div className="product-right bg-light px-4 rounded-3">
                <div className="product-title mb-2">
                  <p className="fw-semibold fs-2 pt-3">
                    {product.productInStock.supplierProduct.customProductTitle}
                  </p>
                  <div className="product-supplier d-flex">
                    <div className="d-flex">
                      <p className="fw-semibold text-muted">Satıcı{": "}</p>
                      <a
                        href="#!"
                        className="fw-semibold ms-2 text-decoration-none"
                      >
                        {
                          product.productInStock.supplierProduct.supplier
                            .companyName
                        }
                      </a>
                    </div>
                    <div className="d-flex ms-3">
                      <p className="fw-semibold text-muted">Puan:</p>
                      <span className="seller-rating fw-semibold rounded-3 ms-2">
                        {
                          product.productInStock.supplierProduct.supplier
                            .companyPoint
                        }
                      </span>
                    </div>
                  </div>
                </div>
                <div className="product-price d-flex justify-content-between mb-2">
                  <p className="fs-3 fw-semibold">
                    {product.productInStock.supplierProduct.unitPrice} TL
                  </p>
                  <div className="product-rating d-flex flex-column align-items-end">
                    <p style={{ fontSize: "14px" }}>Değerlendirme</p>
                    <div className="d-flex align-items-center">
                      <span className="pt-1">
                        {comments &&
                          comments.forEach((item, index) => {
                            productRate += item.point;
                          })}
                        {comments
                          ? (comments && productRate / comments.length) + ",0"
                          : ""}
                      </span>

                      {comments ? (
                        <div className="stars d-flex ms-2">
                          {" "}
                          {comments &&
                            Array.from(
                              { length: productRate / comments.length },
                              (_, index) => (
                                <div key={index}>
                                  {" "}
                                  <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 47.94 47.94"
                                    width="15px"
                                    height="15px"
                                    fill="#ffc107"
                                  >
                                    <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757 c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042 c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685 c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528 c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956 C22.602,0.567,25.338,0.567,26.285,2.486z"></path>
                                  </svg>
                                </div>
                              )
                            )}
                          {comments &&
                            Array.from(
                              { length: 5 - productRate / comments.length },
                              (_, index) => (
                                <div key={index}>
                                  {" "}
                                  <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 47.94 47.94"
                                    width="15px"
                                    height="15px"
                                    fill="#dddddd"
                                  >
                                    <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757 c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042 c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685 c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528 c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956 C22.602,0.567,25.338,0.567,26.285,2.486z"></path>
                                  </svg>
                                </div>
                              )
                            )}
                        </div>
                      ) : (
                        <div className="stars d-flex ms-2">
                          {" "}
                          {Array.from({ length: 5 }, (_, index) => (
                            <div key={index}>
                              {" "}
                              <svg
                                xmlns="http://www.w3.org/2000/svg"
                                viewBox="0 0 47.94 47.94"
                                width="15px"
                                height="15px"
                                fill="#dddddd"
                              >
                                <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757 c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042 c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685 c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528 c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956 C22.602,0.567,25.338,0.567,26.285,2.486z"></path>
                              </svg>
                            </div>
                          ))}
                        </div>
                      )}
                    </div>
                  </div>
                </div>
                <div className="product-buttons d-flex flex-column mb-4">
                  <div className="variants mb-4 d-flex justify-content-between">
                    <div className="colors">
                      <p className="mb-2 fw-semibold text-muted">
                        Renk:{" "}
                        <span className="text-black">
                          {
                            product.productInStock.supplierProduct.color
                              .defination
                          }
                        </span>
                      </p>
                      {product.avaiableColors.map((item) => {
                        return (
                          <a
                            href={`/${product.productInStock.supplierProduct.product.category.defination}/${item.id}`}
                            key={item.color.id}
                          >
                            <button
                              className={`black border rounded-3 px-3 py-1 btn btn-outline-dark me-2 mb-2 ${
                                colorVariant == item.color.defination
                                  ? "active"
                                  : ""
                              }`}
                              value={item.color.defination}
                              onClick={() =>
                                setColorVariant(item.color.defination)
                              }
                            >
                              {item.color.defination}
                            </button>
                          </a>
                        );
                      })}
                    </div>
                    <div className="size-type">
                      <p className="mb-2 fw-semibold text-muted">
                        Beden:{" "}
                        <span className="text-black">
                          {product.productInStock.supplierProduct.size.value}
                        </span>
                      </p>
                      {product.avaiableSizes.map((item) => {
                        return (
                          <a
                            href={`/${product.productInStock.supplierProduct.product.category.defination}/${item.id}`}
                            key={item.size.id}
                          >
                            <button
                              className={`size btn btn-outline-dark border rounded-3 p-2 py-1 me-2 mb-2 ${
                                sizeVariant == item.size.value ? "active" : ""
                              }`}
                              value={item.size.value}
                              onClick={() => setSizeVariant(item.size.value)}
                            >
                              {item.size.value}
                            </button>
                          </a>
                        );
                      })}
                    </div>
                  </div>
                  <div className="d-flex">
                    <div className="product-piece d-flex justify-content-center">
                      <div className="piece-box border d-flex align-items-center bg-white rounded-3">
                        <button
                          className="btn btn-white fs-5 h-100 rounded-3"
                          onClick={() => calcPiece(-1)}
                        >
                          -
                        </button>
                        <p className="px-3">{productPiece}</p>
                        <button
                          className="btn btn-white fs-5 h-100 rounded-3"
                          onClick={() => calcPiece(+1)}
                        >
                          +
                        </button>
                      </div>
                    </div>
                    <button
                      onClick={addBasket}
                      className="btn btn-dark text-white fs-5 py-3 w-100 ms-4 rounded-3"
                    >
                      Sepete Ekle
                    </button>
                  </div>
                </div>
                <div className="product-share d-flex justify-content-between mb-4">
                  <div className="product-social d-flex align-items-center">
                    <p>Paylaş :</p>
                    <a
                      href={options && options.facebookLink}
                      className="facebook mx-2"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        width="24"
                        height="24"
                        viewBox="0 0 24 24"
                        fill="none"
                      >
                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M2 6C2 3.79086 3.79086 2 6 2H18C20.2091 2 22 3.79086 22 6V18C22 20.2091 20.2091 22 18 22H6C3.79086 22 2 20.2091 2 18V6ZM6 4C4.89543 4 4 4.89543 4 6V18C4 19.1046 4.89543 20 6 20H12V13H11C10.4477 13 10 12.5523 10 12C10 11.4477 10.4477 11 11 11H12V9.5C12 7.567 13.567 6 15.5 6H16.1C16.6523 6 17.1 6.44772 17.1 7C17.1 7.55228 16.6523 8 16.1 8H15.5C14.6716 8 14 8.67157 14 9.5V11H16.1C16.6523 11 17.1 11.4477 17.1 12C17.1 12.5523 16.6523 13 16.1 13H14V20H18C19.1046 20 20 19.1046 20 18V6C20 4.89543 19.1046 4 18 4H6Z"
                          fill="#212529"
                        />
                      </svg>
                    </a>
                    <a
                      href={options && options.twitterLink}
                      className="twitter mx-2"
                    >
                      <svg
                        width="22"
                        height="22"
                        viewBox="0 -2 20 20"
                        version="1.1"
                      >
                        <g
                          id="Page-1"
                          stroke="none"
                          strokeWidth="1"
                          fill="none"
                          fillRule="evenodd"
                        >
                          <g
                            id="Dribbble-Light-Preview"
                            transform="translate(-60.000000, -7521.000000)"
                            fill="#212529"
                          >
                            <g
                              id="icons"
                              transform="translate(56.000000, 160.000000)"
                            >
                              <path
                                d="M10.29,7377 C17.837,7377 21.965,7370.84365 21.965,7365.50546 C21.965,7365.33021 21.965,7365.15595 21.953,7364.98267 C22.756,7364.41163 23.449,7363.70276 24,7362.8915 C23.252,7363.21837 22.457,7363.433 21.644,7363.52751 C22.5,7363.02244 23.141,7362.2289 23.448,7361.2926 C22.642,7361.76321 21.761,7362.095 20.842,7362.27321 C19.288,7360.64674 16.689,7360.56798 15.036,7362.09796 C13.971,7363.08447 13.518,7364.55538 13.849,7365.95835 C10.55,7365.79492 7.476,7364.261 5.392,7361.73762 C4.303,7363.58363 4.86,7365.94457 6.663,7367.12996 C6.01,7367.11125 5.371,7366.93797 4.8,7366.62489 L4.8,7366.67608 C4.801,7368.5989 6.178,7370.2549 8.092,7370.63591 C7.488,7370.79836 6.854,7370.82199 6.24,7370.70483 C6.777,7372.35099 8.318,7373.47829 10.073,7373.51078 C8.62,7374.63513 6.825,7375.24554 4.977,7375.24358 C4.651,7375.24259 4.325,7375.22388 4,7375.18549 C5.877,7376.37088 8.06,7377 10.29,7376.99705"
                                id="twitter-[#154]"
                              ></path>
                            </g>
                          </g>
                        </g>
                      </svg>
                    </a>
                    <a
                      href={options && options.linkedInLink}
                      className="linkedin mx-2"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="#212529"
                        width="22"
                        height="22"
                        viewBox="0 0 32 32"
                        version="1.1"
                      >
                        <title>linkedin</title>
                        <path d="M28.778 1.004h-25.56c-0.008-0-0.017-0-0.027-0-1.199 0-2.172 0.964-2.186 2.159v25.672c0.014 1.196 0.987 2.161 2.186 2.161 0.010 0 0.019-0 0.029-0h25.555c0.008 0 0.018 0 0.028 0 1.2 0 2.175-0.963 2.194-2.159l0-0.002v-25.67c-0.019-1.197-0.994-2.161-2.195-2.161-0.010 0-0.019 0-0.029 0h0.001zM9.9 26.562h-4.454v-14.311h4.454zM7.674 10.293c-1.425 0-2.579-1.155-2.579-2.579s1.155-2.579 2.579-2.579c1.424 0 2.579 1.154 2.579 2.578v0c0 0.001 0 0.002 0 0.004 0 1.423-1.154 2.577-2.577 2.577-0.001 0-0.002 0-0.003 0h0zM26.556 26.562h-4.441v-6.959c0-1.66-0.034-3.795-2.314-3.795-2.316 0-2.669 1.806-2.669 3.673v7.082h-4.441v-14.311h4.266v1.951h0.058c0.828-1.395 2.326-2.315 4.039-2.315 0.061 0 0.121 0.001 0.181 0.003l-0.009-0c4.5 0 5.332 2.962 5.332 6.817v7.855z" />
                      </svg>
                    </a>
                    <a
                      href={options && options.instagramLink}
                      className="instagram mx-2"
                    >
                      <svg
                        width="22"
                        height="22"
                        viewBox="0 0 20 20"
                        version="1.1"
                      >
                        <g
                          id="Page-1"
                          stroke="none"
                          strokeWidth="1"
                          fill="none"
                          fillRule="evenodd"
                        >
                          <g
                            id="Dribbble-Light-Preview"
                            transform="translate(-340.000000, -7439.000000)"
                            fill="#212529"
                          >
                            <g
                              id="icons"
                              transform="translate(56.000000, 160.000000)"
                            >
                              <path
                                d="M289.869652,7279.12273 C288.241769,7279.19618 286.830805,7279.5942 285.691486,7280.72871 C284.548187,7281.86918 284.155147,7283.28558 284.081514,7284.89653 C284.035742,7285.90201 283.768077,7293.49818 284.544207,7295.49028 C285.067597,7296.83422 286.098457,7297.86749 287.454694,7298.39256 C288.087538,7298.63872 288.809936,7298.80547 289.869652,7298.85411 C298.730467,7299.25511 302.015089,7299.03674 303.400182,7295.49028 C303.645956,7294.859 303.815113,7294.1374 303.86188,7293.08031 C304.26686,7284.19677 303.796207,7282.27117 302.251908,7280.72871 C301.027016,7279.50685 299.5862,7278.67508 289.869652,7279.12273 M289.951245,7297.06748 C288.981083,7297.0238 288.454707,7296.86201 288.103459,7296.72603 C287.219865,7296.3826 286.556174,7295.72155 286.214876,7294.84312 C285.623823,7293.32944 285.819846,7286.14023 285.872583,7284.97693 C285.924325,7283.83745 286.155174,7282.79624 286.959165,7281.99226 C287.954203,7280.99968 289.239792,7280.51332 297.993144,7280.90837 C299.135448,7280.95998 300.179243,7281.19026 300.985224,7281.99226 C301.980262,7282.98483 302.473801,7284.28014 302.071806,7292.99991 C302.028024,7293.96767 301.865833,7294.49274 301.729513,7294.84312 C300.829003,7297.15085 298.757333,7297.47145 289.951245,7297.06748 M298.089663,7283.68956 C298.089663,7284.34665 298.623998,7284.88065 299.283709,7284.88065 C299.943419,7284.88065 300.47875,7284.34665 300.47875,7283.68956 C300.47875,7283.03248 299.943419,7282.49847 299.283709,7282.49847 C298.623998,7282.49847 298.089663,7283.03248 298.089663,7283.68956 M288.862673,7288.98792 C288.862673,7291.80286 291.150266,7294.08479 293.972194,7294.08479 C296.794123,7294.08479 299.081716,7291.80286 299.081716,7288.98792 C299.081716,7286.17298 296.794123,7283.89205 293.972194,7283.89205 C291.150266,7283.89205 288.862673,7286.17298 288.862673,7288.98792 M290.655732,7288.98792 C290.655732,7287.16159 292.140329,7285.67967 293.972194,7285.67967 C295.80406,7285.67967 297.288657,7287.16159 297.288657,7288.98792 C297.288657,7290.81525 295.80406,7292.29716 293.972194,7292.29716 C292.140329,7292.29716 290.655732,7290.81525 290.655732,7288.98792"
                                id="instagram-[#167]"
                              ></path>
                            </g>
                          </g>
                        </g>
                      </svg>
                    </a>
                  </div>
                  <div className="product-compare d-flex">
                    <a
                      href="#!"
                      className="text-decoration-none text-black d-flex"
                    >
                      <svg
                        width="20"
                        height="20"
                        viewBox="0 0 20 20"
                        fill="none"
                      >
                        <path
                          d="M17.5 3.75H11.25V2.5C11.25 2.16848 11.1183 1.85054 10.8839 1.61612C10.6495 1.3817 10.3315 1.25 10 1.25H2.5C2.16848 1.25 1.85054 1.3817 1.61612 1.61612C1.3817 1.85054 1.25 2.16848 1.25 2.5V15C1.25 15.3315 1.3817 15.6495 1.61612 15.8839C1.85054 16.1183 2.16848 16.25 2.5 16.25H8.75V17.5C8.75 17.8315 8.8817 18.1495 9.11612 18.3839C9.35054 18.6183 9.66848 18.75 10 18.75H17.5C17.8315 18.75 18.1495 18.6183 18.3839 18.3839C18.6183 18.1495 18.75 17.8315 18.75 17.5V5C18.75 4.66848 18.6183 4.35054 18.3839 4.11612C18.1495 3.8817 17.8315 3.75 17.5 3.75V3.75ZM2.5 9.375H6.35625L4.74375 10.9938L5.625 11.875L8.75 8.75L5.625 5.625L4.74375 6.50625L6.35625 8.125H2.5V2.5H10V15H2.5V9.375ZM10 17.5V16.25C10.3315 16.25 10.6495 16.1183 10.8839 15.8839C11.1183 15.6495 11.25 15.3315 11.25 15V5H17.5V10.625H13.6437L15.2562 9.00625L14.375 8.125L11.25 11.25L14.375 14.375L15.2562 13.4938L13.6437 11.875H17.5V17.5H10Z"
                          fill="#515256"
                        ></path>
                      </svg>
                      <p className="ms-2 ">Karşılaştır</p>
                    </a>
                  </div>
                </div>
                {product.supplierProductsFromOtherSupplier.length != 0 ? (
                  <div className="product-sellers d-flex flex-column mb-4">
                    <p className="fs-5 fw-semibold mb-2">Diğer Satıcılar</p>
                    <div className="sellers-container">
                      <div className="sellers d-flex flex-column rounded-3 border overflow-hidden">
                        {product.supplierProductsFromOtherSupplier.map(
                          (item, index) => {
                            return (
                              <a
                                key={index}
                                href={`/${item.supplierProduct.product.category.defination}/${item.supplierProduct.id}`}
                                className="supplier d-flex justify-content-between p-4 text-decoration-none text-black"
                              >
                                <div className="d-flex align-items-center">
                                  <span className="seller-rating border px-3 rounded-3">
                                    {item.supplierProduct.supplier.companyPoint}
                                  </span>
                                  <p className="ms-3 fw-semibold text-muted">
                                    {item.supplierProduct.supplier.companyName}
                                  </p>
                                </div>
                                <div className="d-flex align-items-center">
                                  <p className="fw-semibold">
                                    {item.supplierProduct.unitPrice} TL
                                  </p>
                                  <button className="btn btn-primary text-white rounded-3 px-4 ms-3">
                                    Satın Al
                                  </button>
                                </div>
                              </a>
                            );
                          }
                        )}
                      </div>
                      <div className="sellers"></div>
                    </div>
                  </div>
                ) : null}
                <div className="product-sub-buttons d-flex justify-content-around pb-4">
                  <a
                    href="#!"
                    className="d-flex align-items-center text-decoration-none"
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="24"
                      height="24"
                      viewBox="0 0 24 24"
                      fill="none"
                    >
                      <path
                        d="M11.8456 6.42726L12 6.59097L12.1544 6.42726C14.132 4.33053 17.4026 4.57697 19.0807 6.94915C20.57 9.05459 20.2133 12.0335 18.275 13.6776L12 19L5.725 13.6776C3.78668 12.0335 3.42999 9.05459 4.91934 6.94915C6.59738 4.57698 9.86801 4.33053 11.8456 6.42726Z"
                        stroke="#000000"
                        strokeLinecap="round"
                        strokeLinejoin="round"
                      ></path>
                    </svg>
                    <p
                      className="ms-2 text-black"
                      onClick={() =>
                        addFavorites(product && product.productInStock.id)
                      }
                    >
                      Favori Ürün
                    </p>
                  </a>
                  <a
                    href="#!"
                    className="d-flex align-items-center text-decoration-none"
                  >
                    <svg width="24" height="24" viewBox="0 0 20 20" fill="none">
                      <path
                        d="M4.67789 13.9442C4.88828 14.1562 4.99363 14.4513 4.96523 14.7493C4.90159 15.4171 4.75502 16.112 4.56677 16.7576C5.96166 16.4338 6.81358 16.0581 7.20082 15.8609C7.42062 15.749 7.67381 15.7226 7.91182 15.7867C8.56966 15.9639 9.27076 16.06 10 16.06C13.9956 16.06 17 13.2395 17 10.0323C17 6.8251 13.9956 4.00461 10 4.00461C6.0044 4.00461 3 6.8251 3 10.0323C3 11.5071 3.6173 12.8757 4.67789 13.9442ZM4.18489 17.8672C4.17816 17.8685 4.17142 17.8699 4.16466 17.8712C4.07283 17.8894 3.97922 17.9073 3.88382 17.9248C3.75 17.9495 3.61264 17.9734 3.47172 17.9966C3.27271 18.0293 3.12037 17.8202 3.19898 17.6336C3.25034 17.5117 3.30097 17.384 3.3503 17.2515C3.38164 17.1673 3.41245 17.0813 3.44259 16.9936C3.44389 16.9899 3.44518 16.9861 3.44648 16.9823C3.69422 16.2593 3.89596 15.4282 3.96979 14.6536C2.74306 13.4177 2 11.8013 2 10.0323C2 6.14846 5.58172 3 10 3C14.4183 3 18 6.14846 18 10.0323C18 13.9161 14.4183 17.0646 10 17.0646C9.18324 17.0646 8.39508 16.957 7.65284 16.757C7.13337 17.0215 6.01434 17.5029 4.18489 17.8672Z"
                        fill="#4B4B4B"
                      ></path>
                      <path
                        d="M6 7.52075C6 7.24334 6.22386 7.01845 6.5 7.01845H13.5C13.7761 7.01845 14 7.24334 14 7.52075C14 7.79817 13.7761 8.02306 13.5 8.02306H6.5C6.22386 8.02306 6 7.79817 6 7.52075ZM6 10.0323C6 9.75487 6.22386 9.52998 6.5 9.52998H13.5C13.7761 9.52998 14 9.75487 14 10.0323C14 10.3097 13.7761 10.5346 13.5 10.5346H6.5C6.22386 10.5346 6 10.3097 6 10.0323ZM6 12.5438C6 12.2664 6.22386 12.0415 6.5 12.0415H10.5C10.7761 12.0415 11 12.2664 11 12.5438C11 12.8212 10.7761 13.0461 10.5 13.0461H6.5C6.22386 13.0461 6 12.8212 6 12.5438Z"
                        fill="#4B4B4B"
                      ></path>
                    </svg>
                    <p className="ms-2 text-black">Yorum Yaz</p>
                  </a>
                  <a
                    href="#!"
                    className="d-flex align-items-center text-decoration-none"
                  >
                    <svg width="20" height="20" viewBox="0 0 20 20" fill="none">
                      <path
                        d="M18.75 17.5C18.75 17.5 20 17.5 20 16.25C20 15 18.75 11.25 13.75 11.25C8.75 11.25 7.5 15 7.5 16.25C7.5 17.5 8.75 17.5 8.75 17.5H18.75ZM8.77793 16.25C8.7736 16.2495 8.76754 16.2487 8.76019 16.2475C8.75672 16.2469 8.75333 16.2463 8.75001 16.2456C8.75182 15.9156 8.95859 14.9586 9.69907 14.0947C10.3917 13.2867 11.6034 12.5 13.75 12.5C15.8966 12.5 17.1083 13.2867 17.8009 14.0947C18.5414 14.9586 18.7482 15.9156 18.75 16.2456C18.7467 16.2463 18.7433 16.2469 18.7398 16.2475C18.7325 16.2487 18.7264 16.2495 18.7221 16.25H8.77793Z"
                        fill="#4B4B4B"
                      ></path>
                      <path
                        d="M13.75 8.75C15.1307 8.75 16.25 7.63071 16.25 6.25C16.25 4.86929 15.1307 3.75 13.75 3.75C12.3693 3.75 11.25 4.86929 11.25 6.25C11.25 7.63071 12.3693 8.75 13.75 8.75ZM17.5 6.25C17.5 8.32107 15.8211 10 13.75 10C11.6789 10 10 8.32107 10 6.25C10 4.17893 11.6789 2.5 13.75 2.5C15.8211 2.5 17.5 4.17893 17.5 6.25Z"
                        fill="#4B4B4B"
                      ></path>
                      <path
                        d="M8.66991 11.6C8.21017 11.4529 7.69942 11.346 7.13285 11.2913C6.85244 11.2643 6.55835 11.25 6.25 11.25C1.25 11.25 0 15 0 16.25C0 17.0833 0.416667 17.5 1.25 17.5H6.52045C6.34445 17.1449 6.25 16.7239 6.25 16.25C6.25 14.9871 6.72156 13.6975 7.61227 12.6202C7.91659 12.2522 8.26983 11.9089 8.66991 11.6ZM6.15005 12.5006C5.40319 13.642 5 14.9434 5 16.25H1.25C1.25 15.9241 1.45531 14.9625 2.19907 14.0947C2.88086 13.2993 4.06562 12.5246 6.15005 12.5006Z"
                        fill="#4B4B4B"
                      ></path>
                      <path
                        d="M1.875 6.875C1.875 4.80393 3.55393 3.125 5.625 3.125C7.69607 3.125 9.375 4.80393 9.375 6.875C9.375 8.94607 7.69607 10.625 5.625 10.625C3.55393 10.625 1.875 8.94607 1.875 6.875ZM5.625 4.375C4.24429 4.375 3.125 5.49429 3.125 6.875C3.125 8.25571 4.24429 9.375 5.625 9.375C7.00571 9.375 8.125 8.25571 8.125 6.875C8.125 5.49429 7.00571 4.375 5.625 4.375Z"
                        fill="#4B4B4B"
                      ></path>
                    </svg>
                    <p className="ms-2 text-black">Tavsiye et</p>
                  </a>
                </div>
              </div>
            </div>
            <div className="product-bottom">
              <AddedCartModal
                show={basketModal}
                onHide={() => setBasketModal(false)}
              />
              <AddedFavoritesModal
                show={favoritesModal}
                onHide={() => setFavoritesModal(false)}
              />
              <div className="specs-header d-flex flex-column flex-lg-row justify-content-center mb-4">
                <a
                  href="#!"
                  className={`text-decoration-none btn p-3 mx-3 mb-2 mb-lg-0 ${
                    productDetails == "details" ? "active" : ""
                  }`}
                  onClick={() => setDroductDetails("details")}
                >
                  Ürün Özellikleri
                </a>
                <a
                  href="#!"
                  className={`text-decoration-none btn p-3 mx-3 mb-2 mb-lg-0  ${
                    productDetails == "campaigns" ? "active" : ""
                  }`}
                  onClick={() => setDroductDetails("campaigns")}
                >
                  Kampanyalar
                </a>
                <a
                  href="#!"
                  className={`text-decoration-none btn p-3 mx-3 mb-2 mb-lg-0  ${
                    productDetails == "comments" ? "active" : ""
                  }`}
                  onClick={() => setDroductDetails("comments")}
                >
                  Yorumlar
                </a>
                <a
                  href="#!"
                  className={`text-decoration-none btn p-3 mx-3 ${
                    productDetails == "credit-card" ? "active" : ""
                  }`}
                  onClick={() => setDroductDetails("credit-card")}
                >
                  Taksit Seçenekleri
                </a>
              </div>
              <div className="specs-content mb-4 p-4">
                {productDetails == "details" && (
                  <div className="details active">
                    <div className="detail-item d-flex">
                      <p className="fw-semibold">Özellik :</p>
                      <span className="ms-2">
                        {product.productInStock.supplierProduct.product.detail}
                      </span>
                    </div>
                  </div>
                )}
                {productDetails == "campaigns" && (
                  <div className="campaigns active">
                    <div className="campaign-item d-flex">
                      <p className="fw-semibold">Kampanya :</p>
                      <span className="ms-2">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      </span>
                    </div>
                  </div>
                )}
                {productDetails == "comments" && (
                  <div className="comments active">
                    <div className="mb-5">
                      <p className="fs-2 mb-2">Yeni yorum</p>
                      <Alert show={infoModal} variant={variant}>
                        <Alert.Heading>{info}</Alert.Heading>
                        <div className="d-flex justify-content-end">
                          <Button
                            onClick={() => setInfoModal(false)}
                            variant={variant}
                          >
                            Kapat
                          </Button>
                        </div>
                      </Alert>
                      <div className="d-flex flex-column">
                        <p className="fs-4 mb-2">Ürün ile ilgili :</p>
                        <textarea
                          name="new-comment"
                          id="new-comment"
                          rows="5"
                          className="w-100 p-2 mb-2 rounded-3"
                          onChange={(e) => setcommentContent(e.target.value)}
                        ></textarea>
                        <div className="d-flex flex-column mb-2">
                          <p className="fs-4">
                            Bu üründen ne kadar memnun kaldınız?
                          </p>
                          <div className="rate">
                            <button
                              className={`btn me-2 ${
                                commentStar == 1
                                  ? "btn-dark"
                                  : "btn-outline-dark"
                              }`}
                              value="1"
                              onClick={(e) => setCommentStar(e.target.value)}
                            >
                              1
                            </button>
                            <button
                              className={`btn me-2 ${
                                commentStar == 2
                                  ? "btn-dark"
                                  : "btn-outline-dark"
                              }`}
                              value="2"
                              onClick={(e) => setCommentStar(e.target.value)}
                            >
                              2
                            </button>
                            <button
                              className={`btn me-2 ${
                                commentStar == 3
                                  ? "btn-dark"
                                  : "btn-outline-dark"
                              }`}
                              value="3"
                              onClick={(e) => setCommentStar(e.target.value)}
                            >
                              3
                            </button>
                            <button
                              className={`btn me-2 ${
                                commentStar == 4
                                  ? "btn-dark"
                                  : "btn-outline-dark"
                              }`}
                              value="4"
                              onClick={(e) => setCommentStar(e.target.value)}
                            >
                              4
                            </button>
                            <button
                              className={`btn me-2 ${
                                commentStar == 5
                                  ? "btn-dark"
                                  : "btn-outline-dark"
                              }`}
                              value="5"
                              onClick={(e) => setCommentStar(e.target.value)}
                            >
                              5
                            </button>
                          </div>
                        </div>
                        <a
                          className="btn btn-dark px-5 py-2 rounded-3"
                          onClick={(e) => addComment(e)}
                        >
                          Gönder
                        </a>
                      </div>
                    </div>
                    <div className="comment-item d-flex">
                      <div className="w-100">
                        {comments &&
                          comments.map((item, index) => {
                            return (
                              <div
                                key={index}
                                className="d-flex flex-column flex-lg-row mb-5"
                              >
                                <div
                                  id="left-side"
                                  className="d-flex justify-content-center mb-2 mb-lg-0"
                                >
                                  <div
                                    style={{ width: "100px", height: "100px" }}
                                    className="bg-light p-4 rounded-circle d-flex justify-content-center align-items-center"
                                  >
                                    <p className="fs-4">
                                      {item.customer.firstName.charAt(0)}
                                      {item.customer.lastName.charAt(0)}
                                    </p>
                                  </div>
                                </div>
                                <div
                                  id="right-side"
                                  className="ms-lg-4 mt-3 mt-lg-0 w-100"
                                >
                                  <div className="d-flex mb-3">
                                    <p className="d-flex align-items-center ms-2 text-muted">
                                      {item.customer.firstName.charAt(0)}****
                                    </p>
                                    <p className="d-flex align-items-center ms-1 text-muted border-end pe-2">
                                      {item.customer.lastName.charAt(0)}****
                                    </p>
                                    {/* <span className="ms-2">|</span> */}
                                    <p className="d-flex align-items-center ms-2 text-muted border-end pe-2">
                                      {item.createdDate.substring(0,10)}
                                    </p>
                                    <div className="d-flex ms-2">
                                      {Array.from(
                                        { length: item.point },
                                        (_, index) => (
                                          <div
                                            className="d-flex align-items-center"
                                            key={index}
                                          >
                                            {" "}
                                            <svg
                                              xmlns="http://www.w3.org/2000/svg"
                                              viewBox="0 0 47.94 47.94"
                                              width="15px"
                                              height="15px"
                                              fill="#ffc107"
                                            >
                                              <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757 c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042 c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685 c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528 c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956 C22.602,0.567,25.338,0.567,26.285,2.486z"></path>
                                            </svg>
                                          </div>
                                        )
                                      )}
                                      {Array.from(
                                        { length: 5 - item.point },
                                        (_, index) => (
                                          <div
                                            className="d-flex align-items-center"
                                            key={index}
                                          >
                                            {" "}
                                            <svg
                                              xmlns="http://www.w3.org/2000/svg"
                                              viewBox="0 0 47.94 47.94"
                                              width="15px"
                                              height="15px"
                                              fill="#dddddd"
                                            >
                                              <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757 c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042 c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685 c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528 c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956 C22.602,0.567,25.338,0.567,26.285,2.486z"></path>
                                            </svg>
                                          </div>
                                        )
                                      )}
                                    </div>
                                  </div>
                                  <div className="bg-light px-2 py-3 rounded-5">
                                    <p className="ms-3">{item.content}</p>
                                  </div>
                                </div>
                              </div>
                            );
                          })}
                      </div>
                    </div>
                  </div>
                )}
                {productDetails == "credit-card" && (
                  <div className="credit-card active">
                    <div className="credit-card-item d-flex">
                      <p className="fw-semibold">Taksit Seçenekleri :</p>
                      <span className="ms-2">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      </span>
                    </div>
                  </div>
                )}
              </div>
            </div>
          </div>

          <div className="product-showcase">
            <p className="text-center fw-semibold fs-3 mb-4">
              Beğenebileceğiniz Ürünler
            </p>
            <div className="carousel-buttons d-flex justify-content-between">
              <a className="btn prev" onClick={() => calcCarousel("prev")}>
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="-4.5 0 20 20"
                  version="1.1"
                >
                  <g
                    id="Page-1"
                    stroke="none"
                    strokeWidth="1"
                    fill="none"
                    fillRule="evenodd"
                  >
                    <g
                      id="Dribbble-Light-Preview"
                      transform="translate(-345.000000, -6679.000000)"
                      fill="#000000"
                    >
                      <g
                        id="icons"
                        transform="translate(56.000000, 160.000000)"
                      >
                        <path
                          d="M299.633777,6519.29231 L299.633777,6519.29231 C299.228878,6518.90256 298.573377,6518.90256 298.169513,6519.29231 L289.606572,6527.55587 C288.797809,6528.33636 288.797809,6529.60253 289.606572,6530.38301 L298.231646,6538.70754 C298.632403,6539.09329 299.27962,6539.09828 299.685554,6538.71753 L299.685554,6538.71753 C300.100809,6538.32879 300.104951,6537.68821 299.696945,6537.29347 L291.802968,6529.67648 C291.398069,6529.28574 291.398069,6528.65315 291.802968,6528.26241 L299.633777,6520.70538 C300.038676,6520.31563 300.038676,6519.68305 299.633777,6519.29231"
                          id="arrow_left-[#335]"
                        ></path>
                      </g>
                    </g>
                  </g>
                </svg>
              </a>
              <a className="btn next" onClick={() => calcCarousel("next")}>
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="-4.5 0 20 20"
                  version="1.1"
                >
                  <g
                    id="Page-1"
                    stroke="none"
                    strokeWidth="1"
                    fill="none"
                    fillRule="evenodd"
                  >
                    <g
                      id="Dribbble-Light-Preview"
                      transform="translate(-305.000000, -6679.000000)"
                      fill="#000000"
                    >
                      <g
                        id="icons"
                        transform="translate(56.000000, 160.000000)"
                      >
                        <path
                          d="M249.365851,6538.70769 L249.365851,6538.70769 C249.770764,6539.09744 250.426289,6539.09744 250.830166,6538.70769 L259.393407,6530.44413 C260.202198,6529.66364 260.202198,6528.39747 259.393407,6527.61699 L250.768031,6519.29246 C250.367261,6518.90671 249.720021,6518.90172 249.314072,6519.28247 L249.314072,6519.28247 C248.899839,6519.67121 248.894661,6520.31179 249.302681,6520.70653 L257.196934,6528.32352 C257.601847,6528.71426 257.601847,6529.34685 257.196934,6529.73759 L249.365851,6537.29462 C248.960938,6537.68437 248.960938,6538.31795 249.365851,6538.70769"
                          id="arrow_right-[#336]"
                        ></path>
                      </g>
                    </g>
                  </g>
                </svg>
              </a>
            </div>
            <div className="overflow-hidden">
              <div
                className="row product-showcase-page d-flex position-relative"
                style={{ left: carouselPosition }}
              >
                {featuredProducts &&
                  featuredProducts.slice(0, 12).map((item) => {
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
                  })}
              </div>
            </div>
          </div>
        </div>
      </>
    );
  } else if (product == "Hata") {
    return <Navigate to="/NotFound" />;
  }
}
