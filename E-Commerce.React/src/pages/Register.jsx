import React from "react";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function Register() {
  let navigate = useNavigate();

  function registerPage() {
    if (localStorage.getItem("TOKEN")) {
      return setTimeout(() => {
        navigate("/");
      }, 0);
    } else {
      return (
        <>
          {" "}
          <div className="page-title">Giriş Yap</div>
          <Container className="login-page align-items-center align-items-lg-start d-flex flex-column flex-lg-row justify-content-around">
            <div className="register-form p-5 bg-light shadow">
              <form className="d-flex flex-column">
                <label className="fw-bold h4">Kayıt Ol</label>
                <small id="emailHelp" className="form-text text-muted mb-2">
                  Bilgilerinizi 3. kişilerle paylaşmıyoruz
                </small>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Kullanıcı Adı <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="Kullanıcı Adı"
                    type="text"
                    name="uname"
                    required
                  />
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Ad <span className="text-primary">*</span>
                  </label>
                  <input placeholder="Ad" type="text" name="name" required />
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Soyad <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="Soyad"
                    type="text"
                    name="surName"
                    required
                  />
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    E-Posta <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="E-Posta"
                    type="email"
                    name="email"
                    required
                  />
                </div>
                <div className="input-container d-flex flex-column mb-4">
                  <label className="mb-2">
                    Şifre <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="********"
                    type="password"
                    name="pass"
                    required
                  />
                </div>
                <div className="input-container d-flex flex-column mb-4">
                  <label className="mb-2">
                    Şifrenizi Tekrar Giriniz{" "}
                    <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="********"
                    type="password"
                    name="pass-again"
                    required
                  />
                </div>
                <div className="button-container d-flex flex-column">
                  <button
                    type="submit"
                    className="btn bg-primary text-white py-2"
                  >
                    Kayıt Ol
                  </button>{" "}
                </div>
              </form>
            </div>
          </Container>
        </>
      );
    }
  }

  return registerPage();
}
