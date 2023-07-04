import { useState } from "react";
import { generalStore } from "../../store/generalStore";
import { Link } from "react-router-dom";

export default function Footer() {
  const { options, categories } = generalStore();
  const [contactInfoShow, setContactInfoShow] = useState("d-none");
  const [adressInfoShow, setAdressInfoShow] = useState("d-none");
  const [categoryInfoShow, setCategoryInfoShow] = useState("d-none");
  const [subscribeInfoShow, setSubscribeInfoShow] = useState("d-none");
  return (
    <>
      <div className="footer">
        <div className="footer-top p-0 p-lg-5 border-bottom border-muted">
          <div className="container">
            <div className="row py-3 py-lg-5">
              <div className="contact col-12 col-lg-3 mb-lg-0">
                <div
                  className="d-flex align-items-center justify-content-between mb-4 mb-lg-0"
                  onClick={() => {
                    contactInfoShow == "d-none"
                      ? setContactInfoShow("d-block")
                      : setContactInfoShow("d-none");
                  }}
                >
                  <p className="title text-white fw-bold mb-0 mb-lg-4 py-3 text-uppercase">
                    İLETİŞİM
                  </p>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    xmlnsXlink="http://www.w3.org/1999/xlink"
                    width="25px"
                    height="25px"
                    viewBox="0 -4.5 20 20"
                    version="1.1"
                    className="ms-3 d-lg-none"
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
                        transform="translate(-220.000000, -6684.000000)"
                        fill="#fff"
                      >
                        <g
                          id="icons"
                          transform="translate(56.000000, 160.000000)"
                        >
                          <path
                            d="M164.292308,6524.36583 L164.292308,6524.36583 C163.902564,6524.77071 163.902564,6525.42619 164.292308,6525.83004 L172.555873,6534.39267 C173.33636,6535.20244 174.602528,6535.20244 175.383014,6534.39267 L183.70754,6525.76791 C184.093286,6525.36716 184.098283,6524.71997 183.717533,6524.31405 C183.328789,6523.89985 182.68821,6523.89467 182.29347,6524.30266 L174.676479,6532.19636 C174.285736,6532.60124 173.653152,6532.60124 173.262409,6532.19636 L165.705379,6524.36583 C165.315635,6523.96094 164.683051,6523.96094 164.292308,6524.36583"
                            id="arrow_down-[#338]"
                          ></path>
                        </g>
                      </g>
                    </g>
                  </svg>
                </div>
                <div className={`d-lg-block mb-4 ${contactInfoShow}`}>
                  <div className="subtitle text-light mb-4">
                    <p>
                      Herhangi bir sorunuz varsa lütfen bizimle iletişime geçin.
                    </p>
                    <a
                      href={`mailto: ${options && options.email}`}
                      className="text-white text-decoration-none"
                    >
                      {options && options.email}
                    </a>
                  </div>
                  <div className="d-flex align-items-center">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="50"
                      height="50"
                      viewBox="0 0 1024 1024"
                      fill="#EF3636"
                      className="icon"
                      version="1.1"
                    >
                      <path
                        d="M983.902 1023.894H40.098a7.994 7.994 0 0 1-7.998-8v-95.98c0-68.64 35.562-94.948 101.174-119.474 11.654-4.342 26.706-8.858 42.64-13.636 67.572-20.262 160.124-48.022 160.124-106.838 0-4.422 3.578-7.998 7.998-7.998s7.998 3.576 7.998 7.998c0 70.718-99.134 100.45-171.528 122.162-15.676 4.702-30.478 9.138-41.63 13.31-61.504 22.978-90.778 44.49-90.778 104.476v87.982h927.808v-87.982c0-59.986-29.276-81.498-90.792-104.476-11.138-4.172-25.95-8.61-41.618-13.31-72.39-21.712-171.528-51.444-171.528-122.162a7.994 7.994 0 0 1 7.998-7.998 7.992 7.992 0 0 1 7.998 7.998c0 58.816 92.544 86.576 160.124 106.838 15.934 4.78 30.992 9.294 42.63 13.636 65.626 24.528 101.182 50.834 101.182 119.474v95.98c0 4.422-3.578 8-7.998 8z"
                        fill=""
                      />
                      <path
                        d="M512 719.958c-109.562 0-268.006-158.608-286.152-327.058a7.99 7.99 0 0 1 7.092-8.81c4.552-0.39 8.342 2.71 8.81 7.092 8.154 75.656 46.888 155.576 106.274 219.252 53.786 57.69 116.616 93.528 163.974 93.528 51.928 0 121.724-42.836 177.854-109.134a8.044 8.044 0 0 1 11.28-0.938 8.014 8.014 0 0 1 0.938 11.28c-59.034 69.732-133.644 114.788-190.07 114.788zM741.14 543.992a7.992 7.992 0 0 1-6.92-12.012c32.54-56.058 49.722-115.516 49.722-171.95a7.994 7.994 0 0 1 8-7.998 7.992 7.992 0 0 1 7.996 7.998c0 59.254-17.934 121.482-51.878 179.978a7.984 7.984 0 0 1-6.92 3.984z"
                        fill=""
                      />
                      <path
                        d="M344.036 694.632a7.994 7.994 0 0 1-7.998-7.998v-68.766c0-4.422 3.578-7.998 7.998-7.998s7.998 3.576 7.998 7.998v68.766a7.994 7.994 0 0 1-7.998 7.998zM679.964 687.962a7.994 7.994 0 0 1-7.998-7.998v-62.08a7.994 7.994 0 0 1 7.998-7.998 7.992 7.992 0 0 1 7.998 7.998v62.08a7.992 7.992 0 0 1-7.998 7.998zM376.02 992.462c-0.874 0-1.756-0.14-2.632-0.454a8 8 0 0 1-4.92-10.186 151.48 151.48 0 0 1 16.894-33.976c28.276-42.524 75.618-67.924 126.638-67.924 11.358 0 22.668 1.25 33.62 3.732a8.006 8.006 0 0 1 6.06 9.562c-0.968 4.31-5.28 7.044-9.56 6.03a137.668 137.668 0 0 0-30.12-3.328c-45.654 0-88.012 22.73-113.312 60.786a135.646 135.646 0 0 0-15.114 30.4 8 8 0 0 1-7.554 5.358zM647.972 992.462a8.01 8.01 0 0 1-7.56-5.358 134.146 134.146 0 0 0-15.124-30.384 137.06 137.06 0 0 0-22.62-26.166 7.986 7.986 0 0 1-0.624-11.294c2.952-3.266 8.03-3.546 11.278-0.61a153.044 153.044 0 0 1 25.308 29.198 152.962 152.962 0 0 1 16.902 33.976 8.012 8.012 0 0 1-7.56 10.638zM496.004 991.9a7.996 7.996 0 0 1-5.656-13.654l143.97-143.968a7.996 7.996 0 1 1 11.31 11.308l-143.97 143.97a7.964 7.964 0 0 1-5.654 2.344zM823.936 328.038a7.994 7.994 0 0 1-7.998-8C815.938 152.45 679.59 16.102 512 16.102S208.064 152.45 208.064 320.04c0 4.422-3.578 8-8 8a7.994 7.994 0 0 1-7.998-8C192.066 143.63 335.592 0.106 512 0.106c176.4 0 319.934 143.526 319.934 319.934a7.994 7.994 0 0 1-7.998 7.998z"
                        fill=""
                      />
                      <path
                        d="M200.064 759.95a7.994 7.994 0 0 1-7.998-8V320.04a7.994 7.994 0 0 1 7.998-7.998c4.422 0 8 3.578 8 7.998v431.91c0 4.422-3.578 8-8 8z"
                        fill=""
                      />
                      <path
                        d="M823.936 759.95a7.994 7.994 0 0 1-7.998-8V320.04c0-4.42 3.576-7.998 7.998-7.998s7.998 3.578 7.998 7.998v431.91c0 4.422-3.576 8-7.998 8z"
                        fill=""
                      />
                      <path
                        d="M201.682 375.864l-3.234-15.668c277.74-57.308 505.576-282.95 507.854-285.222l11.31 11.294c-2.294 2.312-233.41 231.296-515.93 289.596z"
                        fill=""
                      />
                      <path
                        d="M820.874 344.988c-149.876-54.59-259.04-137.746-260.118-138.582l9.748-12.684c1.062 0.82 108.4 82.522 255.838 136.236l-5.468 15.03z"
                        fill=""
                      />
                      <path
                        d="M603.982 607.98a8.018 8.018 0 0 1-7.938-6.984 8.002 8.002 0 0 1 6.938-8.95c1.482-0.188 149.718-19.762 184.336-84.664 10.216-19.106 9.374-39.976-2.532-63.792a8.004 8.004 0 0 1 3.578-10.732 8.012 8.012 0 0 1 10.732 3.578c14.2 28.4 14.98 54.808 2.342 78.492-38.524 72.164-190.024 92.176-196.458 92.988a7.138 7.138 0 0 1-0.998 0.064z"
                        fill=""
                      />
                      <path
                        d="M577.986 623.976c-19.058 0-33.992-10.544-33.992-23.996 0-13.45 14.934-23.994 33.992-23.994s33.992 10.544 33.992 23.994c0 13.452-14.934 23.996-33.992 23.996z m0-31.992c-11.154 0-17.996 5.17-17.996 7.996 0 2.828 6.842 8 17.996 8s17.996-5.172 17.996-8c0-2.826-6.842-7.996-17.996-7.996z"
                        fill=""
                      />
                      <path
                        d="M512 815.938c-155.264 0-195.068-81.14-196.686-84.594a7.992 7.992 0 0 1 3.85-10.636c3.976-1.876 8.734-0.156 10.616 3.826 0.398 0.812 37.938 75.406 182.22 75.406 144.876 0 176.244-74.204 176.526-74.954 1.64-4.092 6.312-6.108 10.404-4.452a8.016 8.016 0 0 1 4.468 10.388c-1.406 3.468-35.804 85.016-191.398 85.016z"
                        fill=""
                      />
                    </svg>
                    <a
                      href={`tel:${options && options.phoneNumber}`}
                      className="number m-2 fs-4 text-white text-decoration-none"
                    >
                      {options && options.phoneNumber}
                    </a>
                  </div>
                </div>
              </div>
              <div className="location col-12 col-lg-3">
                <div
                  className="d-flex align-items-center justify-content-between mb-4 mb-lg-0"
                  onClick={() =>
                    adressInfoShow == "d-none"
                      ? setAdressInfoShow("d-block")
                      : setAdressInfoShow("d-none")
                  }
                >
                  <p className="title text-white fw-bold mb-0 mb-lg-4 py-3 text-uppercase">
                    MAZAĞA ADRESİ
                  </p>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    xmlnsXlink="http://www.w3.org/1999/xlink"
                    width="25px"
                    height="25px"
                    viewBox="0 -4.5 20 20"
                    version="1.1"
                    className="ms-3 d-lg-none"
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
                        transform="translate(-220.000000, -6684.000000)"
                        fill="#fff"
                      >
                        <g
                          id="icons"
                          transform="translate(56.000000, 160.000000)"
                        >
                          <path
                            d="M164.292308,6524.36583 L164.292308,6524.36583 C163.902564,6524.77071 163.902564,6525.42619 164.292308,6525.83004 L172.555873,6534.39267 C173.33636,6535.20244 174.602528,6535.20244 175.383014,6534.39267 L183.70754,6525.76791 C184.093286,6525.36716 184.098283,6524.71997 183.717533,6524.31405 C183.328789,6523.89985 182.68821,6523.89467 182.29347,6524.30266 L174.676479,6532.19636 C174.285736,6532.60124 173.653152,6532.60124 173.262409,6532.19636 L165.705379,6524.36583 C165.315635,6523.96094 164.683051,6523.96094 164.292308,6524.36583"
                            id="arrow_down-[#338]"
                          ></path>
                        </g>
                      </g>
                    </g>
                  </svg>
                </div>
                <div className={`d-lg-block mb-4 ${adressInfoShow}`}>
                  <p className="subtitle text-light mb-4">
                    {options && options.adress}
                  </p>
                  <p className="text-light">
                    Pazartesi – Cuma:{" "}
                    <span className="text-white">09.00 – 17.00</span>
                  </p>
                  <p className="text-light">
                    Cumartes: <span className="text-white">09.00 – 12.00</span>
                  </p>
                </div>
              </div>
              <div className="categories col-12 col-lg-2">
                <div
                  className="d-flex align-items-center justify-content-between mb-4 mb-lg-0"
                  onClick={() =>
                    categoryInfoShow == "d-none"
                      ? setCategoryInfoShow("d-block")
                      : setCategoryInfoShow("d-none")
                  }
                >
                  <p className="title text-white fw-bold mb-0 mb-lg-4 py-3 text-uppercase">
                    KATEGORİLER
                  </p>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    xmlnsXlink="http://www.w3.org/1999/xlink"
                    width="25px"
                    height="25px"
                    viewBox="0 -4.5 20 20"
                    version="1.1"
                    className="ms-3 d-lg-none"
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
                        transform="translate(-220.000000, -6684.000000)"
                        fill="#fff"
                      >
                        <g
                          id="icons"
                          transform="translate(56.000000, 160.000000)"
                        >
                          <path
                            d="M164.292308,6524.36583 L164.292308,6524.36583 C163.902564,6524.77071 163.902564,6525.42619 164.292308,6525.83004 L172.555873,6534.39267 C173.33636,6535.20244 174.602528,6535.20244 175.383014,6534.39267 L183.70754,6525.76791 C184.093286,6525.36716 184.098283,6524.71997 183.717533,6524.31405 C183.328789,6523.89985 182.68821,6523.89467 182.29347,6524.30266 L174.676479,6532.19636 C174.285736,6532.60124 173.653152,6532.60124 173.262409,6532.19636 L165.705379,6524.36583 C165.315635,6523.96094 164.683051,6523.96094 164.292308,6524.36583"
                            id="arrow_down-[#338]"
                          ></path>
                        </g>
                      </g>
                    </g>
                  </svg>
                </div>
                <div className={`d-lg-block mb-4 ${categoryInfoShow}`}>
                  <ul className="text-light list-unstyled">
                    {categories &&
                      categories.map((item, index) => (
                        <li key={index} className="mb-1">
                          <Link
                            className="text-decoration-none text-light"
                            to={`/${item.defination}`}
                          >
                            {item.defination}
                          </Link>
                        </li>
                      ))}
                  </ul>
                </div>
              </div>
              <div className="newsletter col-12 col-lg-4">
                <div className="d-flex align-items-center justify-content-lg-start justify-content-center mb-2 mb-lg-0">
                  <p className="title text-white fw-bold mb-0 mb-lg-4 py-0 py-lg-3 text-uppercase">
                    Bültene Abone Ol
                  </p>
                </div>
                <div>
                  <p className="subtitle text-white fw-light mb-2 mb-lg-4 text-center text-lg-start">
                    En son güncellemeler için haftalık bültene abone olun.
                  </p>
                </div>
                <div className="input-group shadow rounded-3">
                  <input
                    placeholder="E-Posta Adresiniz"
                    aria-label="E-Posta Adresiniz"
                    className="bg-secondary py-3 form-control rounded-3 text-white deneme"
                  />
                  <button className="newsletter-button btn btn-primary text-white rounded-3 ms-1">
                    Abone Ol
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="footer-bottom">
          <div className="container">
            <div className="row d-flex justify-content-between py-5 pb-0 pb-lg-5">
              <div className="copyright col-12 col-lg-4 order-3 order-lg-1 d-flex align-items-center justify-content-center justify-content-lg-start">
                <p className="text-light m-0">
                  Copyright © 2023
                  <a
                    href="#!"
                    className="text-primary fw-bold text-decoration-none"
                  >
                    <span> MSS</span>
                  </a>
                  . All Rights Reserved.
                </p>
              </div>
              <div className="social-links col-12 col-lg-4 order-2 d-flex justify-content-center align-items-center mb-4 mb-lg-0">
                <a
                  href={`tel:${options && options.phoneNumber}`}
                  className="mx-3"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="#fff"
                    width="30"
                    height="30"
                    viewBox="0 0 24 24"
                  >
                    <path d="M21.384,17.752a2.108,2.108,0,0,1-.522,3.359,7.543,7.543,0,0,1-5.476.642C10.5,20.523,3.477,13.5,2.247,8.614a7.543,7.543,0,0,1,.642-5.476,2.108,2.108,0,0,1,3.359-.522L8.333,4.7a2.094,2.094,0,0,1,.445,2.328A3.877,3.877,0,0,1,8,8.2c-2.384,2.384,5.417,10.185,7.8,7.8a3.877,3.877,0,0,1,1.173-.781,2.092,2.092,0,0,1,2.328.445Z" />
                  </svg>
                </a>
                <a
                  href={options && options.facebookLink}
                  className="facebook mx-3"
                  target="_blank"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="30"
                    height="30"
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
                <a
                  href={options && options.twitterLink}
                  className="twitter mx-3"
                  target="_blank"
                >
                  <svg
                    width="30"
                    height="30"
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
                  target="_blank"
                >
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="#fff"
                    width="30"
                    height="30"
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
                  target="_blank"
                >
                  <svg width="30" height="30" viewBox="0 0 20 20" version="1.1">
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
              <div className="col-lg-4 order-2 order-lg-3 col-12 d-flex pb-2 justify-content-center justify-content-lg-end mb-3 mb-lg-0">
                <img
                  src="https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/payment.png"
                  alt=""
                  width={"250px"}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
