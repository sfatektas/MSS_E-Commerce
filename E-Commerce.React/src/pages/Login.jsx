import { useState, useEffect } from "react";
import Container from "react-bootstrap/Container";
import { authStore } from "../store/authStore";
import { useNavigate, Link } from "react-router-dom";

export default function Login() {
  let navigate = useNavigate();
  const [uname, setUname] = useState("");
  const [password, setPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [unameError, setUnameError] = useState("");
  const [buttonStatus, setButtonStatus] = useState(true);
  const { authText, loginFetch, loginStatus } = authStore();

  useEffect(() => {
    if (loginStatus === 200) {
      setTimeout(() => {
        navigate("/");
      }, 1000);
    }
  }, [loginStatus, navigate]);

  function handleSubmit(e) {
    e.preventDefault();
    if (password.length <= 5) {
      setPasswordError("* Şifreniz 6 karakterden kısa olamaz");
    } else if (uname.length <= 5) {
      setUnameError("Kullanıcı adınız 6 karakterden kısa olamaz");
    } else {
      loginFetch(uname, password);
    }
  }

  function handleUname(e) {
    setUname(e.target.value);
    if (e.target.value.length <= 5) {
      setUnameError("* Kullanıcı adınız 6 karakterden kısa olamaz");
    } else {
      if (password.length >= 5) {
        setButtonStatus(false);
      }
      setUnameError("");
    }
  }

  function handlePassword(e) {
    setPassword(e.target.value);
    if (e.target.value.length <= 5) {
      setPasswordError("* Şifreniz 6 karakterden kısa olamaz");
    } else {
      if (uname.length >= 5) {
        setButtonStatus(false);
      }
      setPasswordError("");
    }
  }
  return (
    <>
      <div className="d-flex flex-column my-4 text-center">
        <p className="fs-1 text-secondary fw-bold">Üye Girişi</p>
      </div>
      <Container className="login-page align-items-center d-flex flex-column mb-5">
        <div className="login-form d-flex flex-column p-5 shadow m-5 m-lg-0 rounded-3">
          <form>
            <label className="mb-4 fw-bold h4">Giriş Yap</label>
            <div className="input-container d-flex flex-column mb-3">
              <label className="mb-2">
                Kullanıcı Adı <span className="text-primary">*</span>
              </label>
              <input
                placeholder="Kullanıcı Adı"
                type="text"
                name="uname"
                onChange={handleUname}
                required
                className="border rounded-3"
              />
              <p className="text-primary">{unameError}</p>
            </div>
            <div className="input-container d-flex flex-column">
              <label className="mb-2">
                Şifre <span className="text-primary">*</span>
              </label>
              <input
                placeholder="********"
                type="password"
                name="pass"
                value={password}
                onChange={handlePassword}
                required
                className="border rounded-3"
              />
              <p className="text-primary">{passwordError}</p>
            </div>
            <p className="text-black text-center mb-4 mt-2">{authText}</p>
            <div className="button-container d-flex flex-column mb-4">
              <button
                onClick={handleSubmit}
                type="submit"
                className="btn bg-primary text-white py-2 rounded-3"
                disabled={buttonStatus}
              >
                Giriş Yap
              </button>
            </div>
          </form>
          <Link className="text-decoration-none text-white" to="/register">
            <button
              type="submit"
              className="btn bg-dark w-100 text-white py-2 rounded-3"
            >
              Kayıt Ol
            </button>
          </Link>
        </div>
      </Container>
    </>
  );
}
