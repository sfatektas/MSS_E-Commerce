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
            <p className="fs-2 fw-semibold mb-4">Visit one of our agency locations or contact us today</p>
            <p className="fw-semibold mb-4">Head Office</p>
            <div className="d-flex mb-3">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M4.3314 12.0474L12 20L19.6686 12.0474C20.5211 11.1633 21 9.96429 21 8.71405C21 6.11055 18.9648 4 16.4543 4C15.2487 4 14.0925 4.49666 13.24 5.38071L12 6.66667L10.76 5.38071C9.90749 4.49666 8.75128 4 7.54569 4C5.03517 4 3 6.11055 3 8.71405C3 9.96429 3.47892 11.1633 4.3314 12.0474Z"
                  stroke="#000000"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
              </svg>
              <p className="px-3 text-muted fw-light">56 Glassford Street Glasgow G1 1UL New York</p>
            </div>
            <div className="d-flex mb-3">
              {" "}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M4.3314 12.0474L12 20L19.6686 12.0474C20.5211 11.1633 21 9.96429 21 8.71405C21 6.11055 18.9648 4 16.4543 4C15.2487 4 14.0925 4.49666 13.24 5.38071L12 6.66667L10.76 5.38071C9.90749 4.49666 8.75128 4 7.54569 4C5.03517 4 3 6.11055 3 8.71405C3 9.96429 3.47892 11.1633 4.3314 12.0474Z"
                  stroke="#000000"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
              </svg>
              <p className="px-3 text-muted fw-light">contact@example.com</p>
            </div>
            <div className="d-flex mb-3">
              {" "}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M4.3314 12.0474L12 20L19.6686 12.0474C20.5211 11.1633 21 9.96429 21 8.71405C21 6.11055 18.9648 4 16.4543 4C15.2487 4 14.0925 4.49666 13.24 5.38071L12 6.66667L10.76 5.38071C9.90749 4.49666 8.75128 4 7.54569 4C5.03517 4 3 6.11055 3 8.71405C3 9.96429 3.47892 11.1633 4.3314 12.0474Z"
                  stroke="#000000"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
              </svg>
              <p className="px-3 text-muted fw-light">+90 123 456 78</p>
            </div>
            <div className="d-flex mb-3">
              {" "}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M4.3314 12.0474L12 20L19.6686 12.0474C20.5211 11.1633 21 9.96429 21 8.71405C21 6.11055 18.9648 4 16.4543 4C15.2487 4 14.0925 4.49666 13.24 5.38071L12 6.66667L10.76 5.38071C9.90749 4.49666 8.75128 4 7.54569 4C5.03517 4 3 6.11055 3 8.71405C3 9.96429 3.47892 11.1633 4.3314 12.0474Z"
                  stroke="#000000"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
              </svg>
              <p className="px-3 text-muted fw-light">Monday to Saturday: 9.00am to 16.pm</p>
            </div>
          </div>
          <div className="col-12 col-lg-8">
            <p className="text-muted fw-light mb-4">MESAJ BIRAKIN</p>
            <form>
              <label className="mb-4 fw-semibold fs-2">Sizi dinlemeyi seviyoruz</label>
              <div className="input-container d-flex flex-column mb-3">
                <label className="mb-2">
                  İsim <span className="text-primary">*</span>
                </label>
                <input
                  placeholder="İsim"
                  type="text"
                  name="uname"
                  required
                  className="p-2 border-light"
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
                  className="p-2 border-light"
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
                  className="p-2 border-light"
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
                  className="p-2 border-light"
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
