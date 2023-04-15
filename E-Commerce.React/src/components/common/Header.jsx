import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import Offcanvas from "react-bootstrap/Offcanvas";
import { authStore } from "../../store/authStore";
import { generalStore, cartSidebarStore } from "../../store/generalStore";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import CartSidebar from "../home/CartSidebar";
import { Base64 } from "js-base64";

function Header() {
  let navigate = useNavigate();
  const { logout, logoutStatus } = authStore();
  const { setSidebarActive } = cartSidebarStore();
  const { options, getOptions, categories, getCategories } = generalStore();

  useEffect(() => {
    getOptions();
    getCategories();
  }, []);

  useEffect(() => {
    try {
      const token = localStorage.getItem("user_token");
      const startIndex = token.indexOf(".");
      const endIndex = token.lastIndexOf(".");
      const filteredToken = token.slice(startIndex, endIndex + 1);
      const trimmedPayload = filteredToken.substring(
        1,
        filteredToken.length - 1
      );
      const decodedPayload = Base64.decode(trimmedPayload);

      let tokenExpire = JSON.parse(decodedPayload).exp;
      let tokenString = tokenExpire.toString();
      tokenString += "000";
      let finalExpireToken = parseInt(tokenString) - 10800000;
      const nowDate = new Date().getTime();
      let difference = finalExpireToken - nowDate;
      if (difference < 0) {
        localStorage.removeItem("user_token");
      }
    } catch {}
  }, []);

  useEffect(() => {
    if (logoutStatus === 204) {
      setTimeout(() => {
        alert("Başarıyla çıkış yapıldı, yönlendiriliyorsunuz.");
        navigate("/");
      }, 1000);
    } else if (logoutStatus === "ERR_NETWORK") {
      alert("Hatalı çıkış yapıldı, lütfen destek birimimize ulaşın.");
      setTimeout(() => {
        navigate("/");
      }, 1000);
    }
  }, [logoutStatus]);

  function handleLogout() {
    logout();
  }

  return (
    <>
      <CartSidebar />
      <div className="bg-black">
        <div className="container">
          <div className="header-top row d-flex align-items-center py-2">
            <div className="slogan col-12 col-lg-8 text-center text-lg-start mb-2 mb-lg-0">
              <p className="text-white fs-5 fw-semibold">
                <span className="text-primary">Kampanya! </span>
                {options && options.slogan}
              </p>
            </div>
            <div className="social-links col-12 col-lg-4 d-flex justify-content-center justify-content-lg-end mb-2 mb-lg-0">
              <a
                href={options && options.facebookLink}
                className="facebook mx-3"
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
                    fill="#fff"
                  />
                </svg>
              </a>
              <a href={options && options.twitterLink} className="twitter mx-3">
                <svg width="24" height="24" viewBox="0 -2 20 20" version="1.1">
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
                      fill="#fff"
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
                className="linkedin mx-3"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="#fff"
                  width="24"
                  height="24"
                  viewBox="0 0 32 32"
                  version="1.1"
                >
                  <title>linkedin</title>
                  <path d="M28.778 1.004h-25.56c-0.008-0-0.017-0-0.027-0-1.199 0-2.172 0.964-2.186 2.159v25.672c0.014 1.196 0.987 2.161 2.186 2.161 0.010 0 0.019-0 0.029-0h25.555c0.008 0 0.018 0 0.028 0 1.2 0 2.175-0.963 2.194-2.159l0-0.002v-25.67c-0.019-1.197-0.994-2.161-2.195-2.161-0.010 0-0.019 0-0.029 0h0.001zM9.9 26.562h-4.454v-14.311h4.454zM7.674 10.293c-1.425 0-2.579-1.155-2.579-2.579s1.155-2.579 2.579-2.579c1.424 0 2.579 1.154 2.579 2.578v0c0 0.001 0 0.002 0 0.004 0 1.423-1.154 2.577-2.577 2.577-0.001 0-0.002 0-0.003 0h0zM26.556 26.562h-4.441v-6.959c0-1.66-0.034-3.795-2.314-3.795-2.316 0-2.669 1.806-2.669 3.673v7.082h-4.441v-14.311h4.266v1.951h0.058c0.828-1.395 2.326-2.315 4.039-2.315 0.061 0 0.121 0.001 0.181 0.003l-0.009-0c4.5 0 5.332 2.962 5.332 6.817v7.855z" />
                </svg>
              </a>
              <a
                href={options && options.instagramLink}
                className="instagram mx-3"
              >
                <svg width="24" height="24" viewBox="0 0 20 20" version="1.1">
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
                      fill="#fff"
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
          </div>
        </div>
      </div>
      <Navbar
        className="navbar sticky-top shadow-sm"
        key="lg"
        bg="light"
        expand="lg"
      >
        <Container>
          <div className="logo order-1 order-lg-0 col-lg-3 d-flex align-items-center justify-content-center justify-content-lg-start ">
            <a
              href="/"
              className="logo-text text-decoration-none text-black display-5 fw-bold"
            >
              {options && options.logo}
            </a>
          </div>

          <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-lg`} />
          <Navbar.Offcanvas
            id={`offcanvasNavbar-expand-lg`}
            aria-labelledby={`offcanvasNavbarLabel-expand-lg`}
            placement="start"
            className="col-lg-6 order-2"
          >
            <Offcanvas.Header closeButton>
              <Offcanvas.Title id={`offcanvasNavbarLabel-expand-lg`}>
                Menü
              </Offcanvas.Title>
            </Offcanvas.Header>
            <Offcanvas.Body className="d-flex flex-column">
              <Form className="d-flex mt-2">
                <div className="p-1 bg-light rounded-pill shadow-sm mb-2 w-100">
                  <div className="input-group">
                    <input
                      type="search"
                      placeholder="Nasıl bir ürün arıyorsunuz?"
                      aria-describedby="button-addon1"
                      className="form-control border-0 bg-light rounded-pill"
                    />
                    <div className="input-group-append">
                      <a href="#!" className="btn btn-link text-primary">
                        <svg
                          xmlns="http://www.w3.org/2000/svg"
                          width="24"
                          height="24"
                          viewBox="0 0 20 20"
                          fill="none"
                        >
                          <path
                            fill="#000000"
                            fillRule="evenodd"
                            d="M4 9a5 5 0 1110 0A5 5 0 014 9zm5-7a7 7 0 104.2 12.6.999.999 0 00.093.107l3 3a1 1 0 001.414-1.414l-3-3a.999.999 0 00-.107-.093A7 7 0 009 2z"
                          />
                        </svg>
                      </a>
                    </div>
                  </div>
                </div>
              </Form>
              <Nav className="d-flex justify-content-between fw-semibold">
                <Nav.Link href="/">Ana Sayfa</Nav.Link>
                {/* <Nav.Link href="/admin">Admin</Nav.Link> */}
                <NavDropdown title="Kategoriler" id="collasible-nav-dropdown">
                  {categories &&
                    categories.map((item, index) => (
                      <NavDropdown.Item
                        key={index}
                        href={`/category/${item.defination}`}
                      >
                        {item.defination}
                      </NavDropdown.Item>
                    ))}
                  {/* <NavDropdown.Divider /> */}
                </NavDropdown>
                <Nav.Link href="/contact">İletişim</Nav.Link>
                <Nav.Link href="/about">Hakkımızda</Nav.Link>
              </Nav>
            </Offcanvas.Body>
          </Navbar.Offcanvas>
          <Nav className="d-flex flex-row col-lg-3 justify-content-end order-3">
            {localStorage.getItem("user_token") ? (
              <Nav.Link onClick={handleLogout}>
                <div className="logout mx-3">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="#000000"
                    width="24"
                    height="24"
                    viewBox="0 0 32 32"
                    version="1.1"
                  >
                    <path d="M3.651 16.989h17.326c0.553 0 1-0.448 1-1s-0.447-1-1-1h-17.264l3.617-3.617c0.391-0.39 0.391-1.024 0-1.414s-1.024-0.39-1.414 0l-5.907 6.062 5.907 6.063c0.196 0.195 0.451 0.293 0.707 0.293s0.511-0.098 0.707-0.293c0.391-0.39 0.391-1.023 0-1.414zM29.989 0h-17c-1.105 0-2 0.895-2 2v9h2.013v-7.78c0-0.668 0.542-1.21 1.21-1.21h14.523c0.669 0 1.21 0.542 1.21 1.21l0.032 25.572c0 0.668-0.541 1.21-1.21 1.21h-14.553c-0.668 0-1.21-0.542-1.21-1.21v-7.824l-2.013 0.003v9.030c0 1.105 0.895 2 2 2h16.999c1.105 0 2.001-0.895 2.001-2v-28c-0-1.105-0.896-2-2-2z" />
                  </svg>
                </div>
              </Nav.Link>
            ) : null}
            <Nav.Link
              href={localStorage.getItem("user_token") ? "/account" : "/login"}
            >
              <div className="user mx-3">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 1024 1024"
                >
                  <path
                    fill="#000000"
                    d="M512 512a192 192 0 1 0 0-384 192 192 0 0 0 0 384zm0 64a256 256 0 1 1 0-512 256 256 0 0 1 0 512zm320 320v-96a96 96 0 0 0-96-96H288a96 96 0 0 0-96 96v96a32 32 0 1 1-64 0v-96a160 160 0 0 1 160-160h448a160 160 0 0 1 160 160v96a32 32 0 1 1-64 0z"
                  />
                </svg>
              </div>
            </Nav.Link>
            <Nav.Link href="/favorites">
              <div className="favorites mx-3">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="26"
                  height="26"
                  viewBox="0 0 24 24"
                  fill="none"
                >
                  <path
                    d="M11.8456 6.42726L12 6.59097L12.1544 6.42726C14.132 4.33053 17.4026 4.57697 19.0807 6.94915C20.57 9.05459 20.2133 12.0335 18.275 13.6776L12 19L5.725 13.6776C3.78668 12.0335 3.42999 9.05459 4.91934 6.94915C6.59738 4.57698 9.86801 4.33053 11.8456 6.42726Z"
                    stroke="#000000"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                  />
                </svg>
                <div
                  className="favorites-amount"
                  data-selector="favorite-count"
                >
                  0
                </div>
              </div>
            </Nav.Link>
            <Nav.Link
              href=""
              onClick={() => {
                setSidebarActive(true);
              }}
            >
              {" "}
              <div className="cart mx-3">
                <svg
                  width="24"
                  height="24"
                  viewBox="0 0 32 32"
                  id="svg5"
                  version="1.1"
                >
                  <defs id="defs2" />

                  <g id="layer1" transform="translate(36,-244)">
                    <path
                      d="m -31.371094,255.00586 c -1.625564,0 -2.864805,1.51618 -2.589843,3.10351 l 2.27539,13.13477 c 0.27851,1.60776 1.701467,2.76172 3.314453,2.76172 h 16.767578 c 1.6146248,0 3.0129936,-1.16108 3.3105472,-2.74805 a 1.0001,1.0001 0 0 0 0.00195,-0.0137 l 2.2734375,-13.12109 v -0.002 c 0.2984384,-1.59859 -0.9594241,-3.11523 -2.5859375,-3.11523 z m 0,2 h 22.7675784 c 0.4158021,0 0.6977222,0.33936 0.6210937,0.74805 a 1.0001,1.0001 0 0 0 -0.00195,0.0137 l -2.2753911,13.12695 c -0.124292,0.65116 -0.680335,1.11133 -1.34375,1.11133 h -16.767578 c -0.666611,0 -1.23316,-0.46316 -1.34375,-1.10156 l -2.27539,-13.13672 c -0.07374,-0.42569 0.201707,-0.76172 0.61914,-0.76172 z"
                      id="rect40272"
                    />

                    <path
                      d="m -24.695312,246.07227 a 1,1 0 0 0 -0.556641,0.52734 l -4,9 a 1,1 0 0 0 0.507812,1.32031 1,1 0 0 0 1.320313,-0.50781 l 4,-9 a 1,1 0 0 0 -0.507813,-1.32031 1,1 0 0 0 -0.763671,-0.0195 z"
                      id="path41727"
                    />

                    <path
                      d="m -15.279297,246.07227 a 1,1 0 0 0 -0.763672,0.0195 1,1 0 0 0 -0.507812,1.32031 l 4,9 a 1,1 0 0 0 1.318359,0.50781 1,1 0 0 0 0.507813,-1.32031 l -4,-9 a 1,1 0 0 0 -0.554688,-0.52734 z"
                      id="path41729"
                    />

                    <path
                      d="m -20,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                      id="path43195"
                    />

                    <path
                      d="m -24,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                      id="path43243"
                    />

                    <path
                      d="m -16,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                      id="path43245"
                    />
                  </g>
                </svg>
                <div className="cart-amount" data-selector="cart-count">
                  0
                </div>
              </div>
            </Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
  );
}

export default Header;
