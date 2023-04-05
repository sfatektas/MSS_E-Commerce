import { useState, useRef, useEffect } from "react";
import Container from "react-bootstrap/Container";
import { authStore } from "../store/authStore";
import { useNavigate } from "react-router-dom";
import Loader from "../components/Loader";
import { loaderStore } from "../store/loaderStore";

export default function Login() {
  const [uname, setUname] = useState("");
  const [password, setPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [unameError, setUnameError] = useState("");
  const [buttonStatus, setButtonStatus] = useState(true);
  const { loginFetch, loginStatus } = authStore();

  useEffect(() => {
    if (loginStatus == 204) {
      setTimeout(() => {
        navigate("/");
      }, 2000);
    }
  }, [loginStatus]);

  let navigate = useNavigate();

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
      setUnameError("* Şifreniz 6 karakterden kısa olamaz");
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

  function loginPage() {
    if (localStorage.getItem("TOKEN")) {
      return (
        <div>
          {setTimeout(() => {
            navigate("/");
          }, 0)}
        </div>
      );
    } else {
      return (
        <>
          <div className="page-title">Giriş Yap</div>
          <Container className="login-page align-items-center d-flex flex-column mb-5">
            <div className="login-form d-flex flex-column p-5 shadow m-5 m-lg-0">
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
                  />
                  <p className="text-primary">{passwordError}</p>
                </div>
                <p className="text-black fw-light mb-4">** Login Status **</p>
                <div className="button-container d-flex flex-column mb-4">
                  <button
                    onClick={handleSubmit}
                    type="submit"
                    className="btn bg-primary text-white py-2"
                    disabled={buttonStatus}
                  >
                    Giriş Yap
                  </button>
                </div>
              </form>
              <a className="text-decoration-none text-white" href="/register">
                <button
                  type="submit"
                  className="btn bg-dark w-100 text-white py-2"
                >
                  Kayıt Ol
                </button>
              </a>
            </div>
          </Container>
        </>
      );
    }
  }

  return loginPage();
}
