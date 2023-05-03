import Container from "react-bootstrap/Container";
import { generalStore } from "../store/generalStore";

export default function Contact() {
  const { options } = generalStore();
  return (
    <>
      <Container>
        <div className="d-flex flex-column my-4 text-center">
          <p className="fs-1 text-secondary fw-bold">İletişim</p>
        </div>
        <div className="row d-flex flex-column flex-lg-row align-items-center align-items-lg-start">
          <div className="col-12 col-lg-4 d-flex flex-column mb-5 mb-lg-0">
            <p className="text-muted fw-light mb-4">BİZE ULAŞIN</p>
            <p className="fs-2 fw-semibold mb-4">
              Acentelerimizden birini ziyaret edin veya bizimle iletişime geçin
            </p>
            <p className="fw-semibold mb-4">Ana Merkez</p>
            <div className="d-flex align-items-center mb-3">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M19 9L19 17C19 18.8856 19 19.8284 18.4142 20.4142C17.8284 21 16.8856 21 15 21L14 21L10 21L9 21C7.11438 21 6.17157 21 5.58579 20.4142C5 19.8284 5 18.8856 5 17L5 9"
                  stroke="#000"
                  strokeWidth="2"
                  strokeLinejoin="round"
                />
                <path
                  d="M3 11L7.5 7L10.6713 4.18109C11.429 3.50752 12.571 3.50752 13.3287 4.18109L16.5 7L21 11"
                  stroke="#000"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                />
                <path
                  d="M10 21V17C10 15.8954 10.8954 15 12 15V15C13.1046 15 14 15.8954 14 17V21"
                  stroke="#000"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                />
              </svg>
              <p className="px-3 text-muted fw-light">
                {options && options.adress}
              </p>
            </div>
            <div className="d-flex align-items-center mb-3">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M3.29289 5.29289C3.47386 5.11193 3.72386 5 4 5H20C20.2761 5 20.5261 5.11193 20.7071 5.29289M3.29289 5.29289C3.11193 5.47386 3 5.72386 3 6V18C3 18.5523 3.44772 19 4 19H20C20.5523 19 21 18.5523 21 18V6C21 5.72386 20.8881 5.47386 20.7071 5.29289M3.29289 5.29289L10.5858 12.5857C11.3668 13.3668 12.6332 13.3668 13.4142 12.5857L20.7071 5.29289"
                  stroke="#000"
                  strokeWidth="1.5"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                />
              </svg>
              <a
                href={`mailto: ${options && options.email}`}
                className="px-3 text-muted fw-light text-decoration-none"
              >
                {options && options.email}
              </a>
            </div>
            <div className="d-flex align-items-center mb-3">
              {" "}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="#000"
                width="30"
                height="30"
                viewBox="0 0 24 24"
              >
                <path d="M21.384,17.752a2.108,2.108,0,0,1-.522,3.359,7.543,7.543,0,0,1-5.476.642C10.5,20.523,3.477,13.5,2.247,8.614a7.543,7.543,0,0,1,.642-5.476,2.108,2.108,0,0,1,3.359-.522L8.333,4.7a2.094,2.094,0,0,1,.445,2.328A3.877,3.877,0,0,1,8,8.2c-2.384,2.384,5.417,10.185,7.8,7.8a3.877,3.877,0,0,1,1.173-.781,2.092,2.092,0,0,1,2.328.445Z" />
              </svg>
              <a
                href={`tel:${options && options.phoneNumber}`}
                className="px-3 text-muted fw-light text-decoration-none"
              >
                +90 {options && options.phoneNumber}
              </a>
            </div>
            <div className="d-flex align-items-center mb-3">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M6 10L6.72147 5.6712C6.8822 4.70683 7.71658 4 8.69425 4H15.3057C16.2834 4 17.1178 4.70683 17.2785 5.6712L18 10M6 10H18M6 10C4.89543 10 4 10.8954 4 12V14C4 15.1046 4.89543 16 6 16M18 10C19.1046 10 20 10.8954 20 12V14C20 15.1046 19.1046 16 18 16M18 16H6M18 16L17.9999 17.5001C17.9999 18.3284 17.3283 19 16.4999 19C15.6715 19 15 18.3284 15 17.5001V16H18ZM6 16V17.5001C6 18.3284 6.67155 19 7.49995 19C8.32835 19 8.9999 18.3284 8.9999 17.5001V16H6Z"
                  stroke="#000"
                />
              </svg>
              <p className="px-3 text-muted fw-light">
                Pazartesi - Cuma : 9.00-17.00
              </p>
            </div>
          </div>
          <div className="col-12 col-lg-8">
            <p className="text-muted fw-light mb-4">MESAJ BIRAKIN</p>
            <form className="contact-form">
              <label className="mb-4 fw-semibold fs-2">
                Sizi dinlemeyi seviyoruz
              </label>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-3">
                  İsim <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="İsim"
                  type="text"
                  name="uname"
                  required
                  className="mb-3 p-3 text-muted bg-light rounded rounded-3 shadow-sm border-0"
                />
              </div>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-3">
                  Email <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="E-Mail"
                  type="text"
                  name="email"
                  required
                  className="mb-3 p-3 text-muted bg-light rounded rounded-3 shadow-sm border-0"
                />
              </div>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-3">
                  Konu <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="Konu"
                  type="text"
                  name="subject"
                  required
                  className="mb-3 p-3 text-muted bg-light rounded rounded-3 shadow-sm border-0"
                />
              </div>
              <div className="input-container d-flex flex-column mb-5">
                <label className="mb-3">
                  Mesaj <span className="text-primary">*</span>
                </label>
                <textarea
                  placeholder="Mesaj"
                  type="text"
                  name="mesaj"
                  required
                  className="mb-3 p-3 text-muted bg-light rounded rounded-3 shadow-sm border-0"
                />
              </div>
              <div className="button-container d-flex flex-column mb-5">
                <button
                  type="submit"
                  className="btn bg-primary text-white py-2 rounded-3"
                >
                  Gönder
                </button>
              </div>
            </form>
          </div>
        </div>
      </Container>
    </>
  );
}
