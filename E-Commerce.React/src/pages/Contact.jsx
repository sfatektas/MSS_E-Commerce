import Container from "react-bootstrap/Container";
import Navigation from "../components/Navigation";

export default function Contact() {
  return (
    <>
      <Navigation link="İletişim" />
      <Container>
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
                  stroke="#EF3636"
                  stroke-width="2"
                  stroke-linejoin="round"
                />
                <path
                  d="M3 11L7.5 7L10.6713 4.18109C11.429 3.50752 12.571 3.50752 13.3287 4.18109L16.5 7L21 11"
                  stroke="#EF3636"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                />
                <path
                  d="M10 21V17C10 15.8954 10.8954 15 12 15V15C13.1046 15 14 15.8954 14 17V21"
                  stroke="#EF3636"
                  stroke-width="2"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                />
              </svg>
              <p className="px-3 text-muted fw-light">
                Bahçeşehir / İstanbul
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
                  stroke="#EF3636"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                />
              </svg>
              <p className="px-3 text-muted fw-light">contact@mss.com</p>
            </div>
            <div className="d-flex align-items-center mb-3">
              {" "}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  fill-rule="evenodd"
                  clip-rule="evenodd"
                  d="M8.20049 15.799C1.3025 8.90022 2.28338 5.74115 3.01055 4.72316C3.10396 4.55862 5.40647 1.11188 7.87459 3.13407C14.0008 8.17945 6.5 8 11.3894 12.6113C16.2788 17.2226 15.8214 9.99995 20.8659 16.1249C22.8882 18.594 19.4413 20.8964 19.2778 20.9888C18.2598 21.717 15.0995 22.6978 8.20049 15.799Z"
                  stroke="#EF3636"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                />
              </svg>
              <p className="px-3 text-muted fw-light">+90 123 456 78</p>
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
                  stroke="#EF3636"
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
                <label className="mb-2">
                  İsim <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="İsim"
                  type="text"
                  name="uname"
                  required
                  className="p-2"
                />
              </div>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-2">
                  Email <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="E-Mail"
                  type="text"
                  name="email"
                  required
                  className="p-2"
                />
              </div>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-2">
                  Konu <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="Konu"
                  type="text"
                  name="subject"
                  required
                  className="p-2"
                />
              </div>
              <div className="input-container d-flex flex-column mb-5">
                <label className="mb-2">
                  Mesaj <span className="text-primary">*</span>
                </label>
                <textarea
                  placeholder="Mesaj"
                  type="text"
                  name="mesaj"
                  required
                  className="p-2"
                />
              </div>
              <div className="button-container d-flex flex-column mb-5">
                <button
                  onClick=""
                  type="submit"
                  className="btn bg-primary text-white py-2"
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
