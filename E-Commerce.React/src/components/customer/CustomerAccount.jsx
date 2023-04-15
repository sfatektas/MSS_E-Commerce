import { useEffect, useState } from "react";
import { generalStore } from "../../store/generalStore";
import { authStore } from "../../store/authStore";
import { useNavigate } from "react-router-dom";
import CustomerHome from "./CustomerHome";
import CustomerDetails from "./CustomerDetails";
import CustomerOrders from "./CustomerOrders";
import CustomerSettings from "./CustomerSettings";

export default function CustomerAccount() {
  const [accountPanel, setAccountPanel] = useState("customerHome");
  const { logout, logoutStatus } = authStore();
  const { options } = generalStore();
  let navigate = useNavigate();

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
      <div className="">
        <div className="customer-panel row flex-column flex-lg-row m-0">
          <div className="customer-header col-12 col-lg-2 d-flex flex-row flex-lg-column p-0">
            <div className="d-flex flex-column p-4 w-100">
              <p className="display-4 fw-bold text-center mb-3 user-select-none">
                {options.logo}
              </p>
              <a
                className={`btn d-flex align-items-center mb-2 rounded-3 text-start ${
                  accountPanel === "customerHome" && "active"
                }`}
                onClick={() => setAccountPanel("customerHome")}
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
                <span className="ms-2">Hesabım</span>
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
                  accountPanel === "customerDetails" && "active"
                }`}
                onClick={() => setAccountPanel("customerDetails")}
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                >
                  <g id="Complete">
                    <g id="info-circle">
                      <g>
                        <circle
                          cx="12"
                          cy="12"
                          data-name="--Circle"
                          fill="none"
                          id="_--Circle"
                          r="10"
                          stroke="#000000"
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          strokeWidth="2"
                        />

                        <line
                          fill="none"
                          stroke="#000000"
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          strokeWidth="2"
                          x1="12"
                          x2="12"
                          y1="12"
                          y2="16"
                        />

                        <line
                          fill="none"
                          stroke="#000000"
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          strokeWidth="2"
                          x1="12"
                          x2="12"
                          y1="8"
                          y2="8"
                        />
                      </g>
                    </g>
                  </g>
                </svg>
                <span className="ms-2">Üyelik Bilgilerim</span>
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
                  accountPanel === "customerOrders" && "active"
                }`}
                onClick={() => setAccountPanel("customerOrders")}
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
                <span className="ms-2">Siparişlerim</span>
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
                  accountPanel === "options" && "active"
                }`}
                onClick={() => setAccountPanel("options")}
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="#292D32"
                  width="24"
                  height="24"
                  viewBox="0 0 1920 1920"
                >
                  <path
                    d="M1703.534 960c0-41.788-3.84-84.48-11.633-127.172l210.184-182.174-199.454-340.856-265.186 88.433c-66.974-55.567-143.323-99.389-223.85-128.415L1158.932 0h-397.78L706.49 269.704c-81.43 29.138-156.423 72.282-223.962 128.414l-265.073-88.32L18 650.654l210.184 182.174C220.39 875.52 216.55 918.212 216.55 960s3.84 84.48 11.633 127.172L18 1269.346l199.454 340.856 265.186-88.433c66.974 55.567 143.322 99.389 223.85 128.415L761.152 1920h397.779l54.663-269.704c81.318-29.138 156.424-72.282 223.963-128.414l265.073 88.433 199.454-340.856-210.184-182.174c7.793-42.805 11.633-85.497 11.633-127.285m-743.492 395.294c-217.976 0-395.294-177.318-395.294-395.294 0-217.976 177.318-395.294 395.294-395.294 217.977 0 395.294 177.318 395.294 395.294 0 217.976-177.317 395.294-395.294 395.294"
                    fillRule="evenodd"
                  />
                </svg>
                <span className="ms-2">Genel Ayarlar</span>
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
                  accountPanel === "logout" && "active"
                }`}
                onClick={handleLogout}
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="#000000"
                  width="24"
                  height="24"
                  viewBox="0 0 32 32"
                  version="1.1"
                >
                  <path d="M3.651 16.989h17.326c0.553 0 1-0.448 1-1s-0.447-1-1-1h-17.264l3.617-3.617c0.391-0.39 0.391-1.024 0-1.414s-1.024-0.39-1.414 0l-5.907 6.062 5.907 6.063c0.196 0.195 0.451 0.293 0.707 0.293s0.511-0.098 0.707-0.293c0.391-0.39 0.391-1.023 0-1.414zM29.989 0h-17c-1.105 0-2 0.895-2 2v9h2.013v-7.78c0-0.668 0.542-1.21 1.21-1.21h14.523c0.669 0 1.21 0.542 1.21 1.21l0.032 25.572c0 0.668-0.541 1.21-1.21 1.21h-14.553c-0.668 0-1.21-0.542-1.21-1.21v-7.824l-2.013 0.003v9.030c0 1.105 0.895 2 2 2h16.999c1.105 0 2.001-0.895 2.001-2v-28c-0-1.105-0.896-2-2-2z"></path>
                </svg>
                <span className="ms-2">Çıkış yap</span>
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
          <div className="customer-content col-12 col-lg-10 px-5 py-4">
            <div>
              {accountPanel === "customerHome" && <CustomerHome />}
              {accountPanel === "customerDetails" && <CustomerDetails />}
              {accountPanel === "customerOrders" && <CustomerOrders />}
              {accountPanel === "options" && <CustomerSettings />}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
