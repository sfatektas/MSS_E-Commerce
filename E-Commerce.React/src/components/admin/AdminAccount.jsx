import { useState } from "react";
import { Navigate } from "react-router-dom";
import AdminBrands from "./AdminBrands";
import AdminProducts from "./AdminProducts";
import AdminHome from "./AdminHome";
import AdminOptions from "./AdminOptions";
import AdminContents from "./AdminContents";
import UserManagement from "./AdminUserManagement";
import { generalStore } from "../../store/generalStore";
import { Base64 } from "js-base64";

export default function AdminAccount() {
  try {
    const [adminPanel, setAdminPanel] = useState("adminHome");
    const { options } = generalStore();
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const tokenFiltered = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = tokenFiltered.substring(1, tokenFiltered.length - 1);
    const tokenPayload = Base64.decode(trimmedPayload);
    let userRole = JSON.parse(tokenPayload).role;

    if (userRole === "admin") {
      return (
        <>
          <div className="">
            <div className="admin row flex-column flex-lg-row m-0">
              <div className="admin-header col-12 col-lg-2 d-flex flex-row flex-lg-column p-0">
                <div className="d-flex flex-column p-4 w-100">
                  <p className="display-4 fw-bold text-center mb-3 user-select-none">
                    {options.logo}
                  </p>
                  <a
                    className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                      adminPanel === "adminHome" && "active"
                    }`}
                    onClick={() => setAdminPanel("adminHome")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      version="1.1"
                      id="_x32_"
                      width="26"
                      height="26"
                      viewBox="0 0 512 512"
                      fill="#292D32"
                    >
                      <g>
                        <path d="M62.953,387.594h392.078c13.188,0,23.984-10.797,23.984-23.969V109.406c0-13.188-10.797-23.969-23.984-23.969   H62.953c-13.203,0-23.984,10.781-23.984,23.969v254.219C38.969,376.797,49.75,387.594,62.953,387.594z M70.156,116.594h377.688   v239.813H70.156V116.594z" />
                        <path d="M0,401.375v6c0,10.547,8.625,19.188,19.188,19.188h473.625c10.563,0,19.188-8.641,19.188-19.188v-6H0z" />
                      </g>
                    </svg>
                    <span className="ms-2">Yönetim Paneli</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                  <a
                    className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                      adminPanel === "contents" && "active"
                    }`}
                    onClick={() => setAdminPanel("contents")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="26"
                      height="26"
                      viewBox="0 0 24 24"
                      fill="none"
                    >
                      <path
                        d="M10.51 11.22L8.31 2.39C8.26 2.16 8.05 2 7.81 2C4.6 2 2 4.6 2 7.81V13.51C2 13.85 2.33 14.1 2.66 14L10.16 11.83C10.42 11.76 10.58 11.49 10.51 11.22Z"
                        fill="#292D32"
                      />
                      <path
                        d="M11.12 13.6789C11.05 13.3989 10.76 13.2289 10.48 13.3089L2.37 15.6689C2.15 15.7389 2 15.9389 2 16.1689V16.1889C2 19.3989 4.6 21.9989 7.81 21.9989H12.53C12.86 21.9989 13.11 21.6889 13.03 21.3589L11.12 13.6789Z"
                        fill="#292D32"
                      />
                      <path
                        d="M16.1908 2H10.4408C10.1108 2 9.86081 2.31 9.94081 2.64L14.6808 21.61C14.7408 21.84 14.9408 22 15.1808 22H16.1808C19.4008 22 22.0008 19.4 22.0008 16.19V7.81C22.0008 4.6 19.4008 2 16.1908 2Z"
                        fill="#292D32"
                      />
                    </svg>
                    <span className="ms-2">İçerik Ayarları</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                  <a
                    className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                      adminPanel === "product" && "active"
                    }`}
                    onClick={() => setAdminPanel("product")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#292D32"
                      width="26"
                      height="26"
                      viewBox="0 0 16 16"
                    >
                      <path d="M0 2.53h2.49v10.95H0zm11 0h2.49v10.95H11zm-6.02 0h1.24v10.95H4.98zm2.49 0h1.24v10.95H7.47zm7.29 0H16v10.95h-1.24z" />
                    </svg>
                    <span className="ms-2">Ürünler</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                  <a
                    className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                      adminPanel === "brands" && "active"
                    }`}
                    onClick={() => setAdminPanel("brands")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="26"
                      height="26"
                      viewBox="0 0 24 24"
                      id="meteor-icon-kit__solid-brands"
                      fill="none"
                    >
                      <g clipPath="url(#clip0_525_169)">
                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M18.2924 4.29342C18.105 3.90179 18 3.46315 18 3C18 1.34315 19.3431 0 21 0C22.6569 0 24 1.34315 24 3C24 4.65685 22.6569 6 21 6C20.5369 6 20.0982 5.89505 19.7066 5.70763L17.6064 7.80784C17.2049 7.27174 16.7283 6.79513 16.1922 6.39362L18.2924 4.29342Z"
                          fill="#292D32"
                        />

                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M7.80784 6.39361L5.70763 4.29341C5.89505 3.90177 6 3.46314 6 3C6 1.34315 4.65685 0 3 0C1.34315 0 0 1.34315 0 3C0 4.65685 1.34315 6 3 6C3.46315 6 3.90179 5.89505 4.29343 5.70762L6.39362 7.80782C6.79513 7.27172 7.27174 6.79512 7.80784 6.39361Z"
                          fill="#292D32"
                        />

                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M6.39362 16.1922L4.29342 18.2924C3.90179 18.105 3.46315 18 3 18C1.34315 18 0 19.3431 0 21C0 22.6569 1.34315 24 3 24C4.65685 24 6 22.6569 6 21C6 20.5369 5.89505 20.0982 5.70763 19.7066L7.80784 17.6064C7.27174 17.2049 6.79513 16.7283 6.39362 16.1922Z"
                          fill="#292D32"
                        />

                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M16.1922 17.6064L18.2924 19.7066C18.105 20.0982 18 20.5368 18 21C18 22.6569 19.3431 24 21 24C22.6569 24 24 22.6569 24 21C24 19.3431 22.6569 18 21 18C20.5369 18 20.0982 18.1049 19.7066 18.2924L17.6064 16.1922C17.2049 16.7283 16.7283 17.2049 16.1922 17.6064Z"
                          fill="#292D32"
                        />

                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M12 17C9.23858 17 7 14.7614 7 12C7 9.23858 9.23858 7 12 7C14.7614 7 17 9.23858 17 12C17 14.7614 14.7614 17 12 17Z"
                          fill="#292D32"
                        />
                      </g>

                      <defs>
                        <clipPath id="clip0_525_169">
                          <rect width="24" height="24" fill="white" />
                        </clipPath>
                      </defs>
                    </svg>
                    <span className="ms-2">Markalar</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                  <a
                    className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                      adminPanel === "options" && "active"
                    }`}
                    onClick={() => setAdminPanel("options")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#292D32"
                      width="26"
                      height="26"
                      viewBox="0 0 1920 1920"
                    >
                      <path
                        d="M1703.534 960c0-41.788-3.84-84.48-11.633-127.172l210.184-182.174-199.454-340.856-265.186 88.433c-66.974-55.567-143.323-99.389-223.85-128.415L1158.932 0h-397.78L706.49 269.704c-81.43 29.138-156.423 72.282-223.962 128.414l-265.073-88.32L18 650.654l210.184 182.174C220.39 875.52 216.55 918.212 216.55 960s3.84 84.48 11.633 127.172L18 1269.346l199.454 340.856 265.186-88.433c66.974 55.567 143.322 99.389 223.85 128.415L761.152 1920h397.779l54.663-269.704c81.318-29.138 156.424-72.282 223.963-128.414l265.073 88.433 199.454-340.856-210.184-182.174c7.793-42.805 11.633-85.497 11.633-127.285m-743.492 395.294c-217.976 0-395.294-177.318-395.294-395.294 0-217.976 177.318-395.294 395.294-395.294 217.977 0 395.294 177.318 395.294 395.294 0 217.976-177.317 395.294-395.294 395.294"
                        fillRule="evenodd"
                      />
                    </svg>
                    <span className="ms-2">Site Ayarları</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                  <a
                    className={`btn d-flex align-items-center mb-3 rounded-3 text-start ${
                      adminPanel === "userManagement" && "active"
                    }`}
                    onClick={() => setAdminPanel("userManagement")}
                  >
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="26"
                      height="26"
                      viewBox="0 0 24 24"
                      fill="none"
                    >
                      <rect width="24" height="24" fill="none" />
                      <path
                        fillRule="evenodd"
                        clipRule="evenodd"
                        d="M5 9.5C5 7.01472 7.01472 5 9.5 5C11.9853 5 14 7.01472 14 9.5C14 11.9853 11.9853 14 9.5 14C7.01472 14 5 11.9853 5 9.5Z"
                        fill="#292D32"
                      />
                      <path
                        d="M14.3675 12.0632C14.322 12.1494 14.3413 12.2569 14.4196 12.3149C15.0012 12.7454 15.7209 13 16.5 13C18.433 13 20 11.433 20 9.5C20 7.567 18.433 6 16.5 6C15.7209 6 15.0012 6.2546 14.4196 6.68513C14.3413 6.74313 14.322 6.85058 14.3675 6.93679C14.7714 7.70219 15 8.5744 15 9.5C15 10.4256 14.7714 11.2978 14.3675 12.0632Z"
                        fill="#292D32"
                      />
                      <path
                        fillRule="evenodd"
                        clipRule="evenodd"
                        d="M4.64115 15.6993C5.87351 15.1644 7.49045 15 9.49995 15C11.5112 15 13.1293 15.1647 14.3621 15.7008C15.705 16.2847 16.5212 17.2793 16.949 18.6836C17.1495 19.3418 16.6551 20 15.9738 20H3.02801C2.34589 20 1.85045 19.3408 2.05157 18.6814C2.47994 17.2769 3.29738 16.2826 4.64115 15.6993Z"
                        fill="#292D32"
                      />
                      <path
                        d="M14.8185 14.0364C14.4045 14.0621 14.3802 14.6183 14.7606 14.7837V14.7837C15.803 15.237 16.5879 15.9043 17.1508 16.756C17.6127 17.4549 18.33 18 19.1677 18H20.9483C21.6555 18 22.1715 17.2973 21.9227 16.6108C21.9084 16.5713 21.8935 16.5321 21.8781 16.4932C21.5357 15.6286 20.9488 14.9921 20.0798 14.5864C19.2639 14.2055 18.2425 14.0483 17.0392 14.0008L17.0194 14H16.9997C16.2909 14 15.5506 13.9909 14.8185 14.0364Z"
                        fill="#292D32"
                      />
                    </svg>
                    <span className="ms-2">Kullanıcı Yönetimi</span>
                    <svg
                      className="arrow"
                      xmlns="http://www.w3.org/2000/svg"
                      fill="#000000"
                      width="24"
                      height="24"
                      viewBox="0 0 1024 1024"
                    >
                      <path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" />
                    </svg>
                  </a>
                </div>
              </div>
              <div className="admin-content col-12 col-lg-10 px-5 py-4">
                <div className="content-right">
                  <div>
                    {adminPanel === "adminHome" && <AdminHome />}
                    {adminPanel === "brands" && <AdminBrands />}
                    {adminPanel === "product" && <AdminProducts />}
                    {adminPanel === "options" && <AdminOptions />}
                    {adminPanel === "contents" && <AdminContents />}
                    {adminPanel === "userManagement" && <UserManagement />}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </>
      );
    } else {
      return <Navigate to="/forbidden" />;
    }
  } catch {
    return <Navigate to="/forbidden" />;
  }
}
