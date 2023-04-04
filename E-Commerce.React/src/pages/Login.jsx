import Container from "react-bootstrap/Container";

export default function Login() {
  function handleSubmit() {}

  return (
    <>
      <div className="page-title">Giriş Yap / Üye Ol</div>
      <Container className="login-page align-items-center align-items-lg-start d-flex flex-column flex-lg-row justify-content-around">
        <div className="login-form p-5 shadow m-5 m-lg-0">
          <form onSubmit={handleSubmit}>
            <label className="mb-4 fw-bold h4">Giriş Yap</label>
            <div className="input-container d-flex flex-column mb-3">
              <label className="mb-2">
                E-Mail <span className="text-primary">*</span>
              </label>
              <input placeholder="E-Posta" type="email" name="email" required />
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
            <div className="button-container d-flex flex-column">
              <button type="submit" className="btn bg-primary text-white py-2">
                Giriş Yap
              </button>
            </div>
          </form>
        </div>
        <div className="register-form p-5 bg-light shadow">
          <form className="d-flex flex-column" onSubmit={handleSubmit}>
            <label className="fw-bold h4">Kayıt Ol</label>
            <small id="emailHelp" class="form-text text-muted mb-2">
              Bilgilerinizi 3. kişilerle paylaşmıyoruz
            </small>
            <div className="input-container d-flex flex-column mb-3">
              <label className="mb-2">İsim </label>
              <input placeholder="İsim" type="text" name="name" required />
            </div>
            <div className="input-container d-flex flex-column mb-3">
              <label className="mb-2">Soy İsim </label>
              <input
                placeholder="Soy İsim"
                type="text"
                name="surName"
                required
              />
            </div>
            <div className="input-container d-flex flex-column mb-3">
              <label className="mb-2">E-Mail </label>
              <input placeholder="E-Posta" type="email" name="email" required />
            </div>
            <div className="input-container d-flex flex-column mb-4">
              <label className="mb-2">Şifre </label>
              <input
                placeholder="********"
                type="password"
                name="pass"
                required
              />
            </div>
            <div className="button-container d-flex flex-column">
              <button type="submit" className="btn bg-primary text-white py-2">
                Kayıt Ol
              </button>{" "}
            </div>
          </form>
        </div>
      </Container>
    </>
  );
}
