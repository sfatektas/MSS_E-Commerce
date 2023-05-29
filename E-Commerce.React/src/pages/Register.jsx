import axios from "axios";
import { useEffect, useState } from "react";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function Register() {
  let navigate = useNavigate();
  const [uname, setUname] = useState("");
  const [unameError, setUnameError] = useState("");
  const [firstName, setFirstName] = useState("");
  const [firstNameError, setFirstNameError] = useState("");
  const [lastName, setLastname] = useState("");
  const [lastNameError, setLastNameError] = useState("");
  const [email, setEmail] = useState("");
  const [emailError, setEmailError] = useState("");
  const [gender, setGender] = useState("");
  const [genderError, setGenderError] = useState("");
  const [phone, setPhone] = useState("");
  const [phoneError, setPhoneError] = useState("");
  const [password, setPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [passwordConfirm, setPasswordConfirm] = useState("");
  const [passwordConfirmError, setPasswordConfirmError] = useState("");
  const [passwordCheck, setPasswordCheck] = useState(false);
  const [buttonStatus, setButtonStatus] = useState(true);
  const [registerError, setRegisterError] = useState("")

  useEffect(() => {
    if (Boolean(password.match(/[A-Z]/)) && Boolean(password.match(/[0-9]/))) {
      setPasswordCheck(true);
    } else {
      setPasswordError(
        "Şifreniz 1 büyük karakter ve 1 rakam içermek zorundadır"
      );
      setPasswordCheck(false);
    }
    if (
      password.length >= 5 &&
      password == passwordConfirm &&
      firstName.length >= 2 &&
      lastName.length >= 2 &&
      phone.length >= 9 &&
      uname.length >= 5 && 
      passwordCheck==true
    ) {
      setButtonStatus(false);
    }else{
      setButtonStatus(true)
    }
  }, [
    uname,
    firstName,
    lastName,
    email,
    gender,
    phone,
    password,
    passwordConfirm,
  ]);

  function handleUname(e) {
    setUname(e.target.value);
    if (e.target.value.length <= 5) {
      setUnameError("* Kullanıcı adınız 6 karakterden kısa olamaz");
    } else {
      setUnameError("");
    }
  }

  function handlePassword(e) {
    setPassword(e.target.value);
    if (e.target.value.length <= 5) {
      setPasswordError("* Şifreniz 6 karakterden kısa olamaz");
    } else {
      setPasswordError("");
    }
  }

  function handlePasswordConfirm(e) {
    setPasswordConfirm(e.target.value);
    if (e.target.value != password) {
      setPasswordConfirmError("* Şifreler eşleşmiyor");
    } else {
      setPasswordConfirmError("");
    }
  }

  function handleFirstName(e) {
    setFirstName(e.target.value);
    if (e.target.value.length <= 2) {
      setFirstNameError("* İsminiz 3 karakterden kısa olamaz");
    } else {
      setFirstNameError("");
    }
  }

  function handleLastName(e) {
    setLastname(e.target.value);
    if (e.target.value.length <= 2) {
      setLastNameError("* Soyadınız 3 karakterden kısa olamaz");
    } else {
      setLastNameError("");
    }
  }

  function handleGender(e) {
    setGender(e.target.value);
    if (e.target.value == 0) {
      setGenderError("* Lütfen seçim yapın");
    } else {
      setGenderError("");
    }
  }

  function handlePhone(e) {
    setPhone(e.target.value);
    if (e.target.value.length <= 9) {
      setPhoneError("* Geçerli bir telefon numarası girin");
    } else {
      setPhoneError("");
    }
  }

  function handleMail(e) {
    setEmail(e.target.value);
    if (e.target.value.includes("@")) {
      setEmailError("");
    } else {
      setEmailError("* Lütfen geçerli bir mail girin");
    }
  }

  function handleSubmit(e) {
    e.preventDefault();
    let user = {
      Username: uname,
      Firstname: firstName,
      Lastname: lastName,
      Password: password,
      PasswordConfirm: passwordConfirm,
      Email: email,
      PhoneNumber: phone,
      GenderId: gender,
    };

    axios
      .post(`http://api.mssdev.online/api/auth/register`, user)
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
        setRegisterError(error.response.data.Error)
        console.log(registerError)
      });
    console.log(user);
  }

  function registerPage() {
    if (localStorage.getItem("user_token")) {
      return setTimeout(() => {
        navigate("/");
      }, 0);
    } else {
      return (
        <>
          <div className="d-flex flex-column my-4 text-center">
            <p className="fs-1 text-secondary fw-bold">Kayıt Ol</p>
          </div>
          <Container className="login-page align-items-center align-items-lg-start d-flex flex-column flex-lg-row justify-content-around mb-5">
            <div className="register-form p-5 bg-light shadow rounded-3">
              <form className="d-flex flex-column">
                <p>{registerError}</p>
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
                    className="border rounded-3"
                    onChange={handleUname}
                  />
                  <p className="text-primary">{unameError}</p>
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Ad <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="Ad"
                    type="text"
                    name="name"
                    required
                    className="border rounded-3"
                    onChange={handleFirstName}
                  />
                  <p className="text-primary">{firstNameError}</p>
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
                    className="border rounded-3"
                    onChange={handleLastName}
                  />
                  <p className="text-primary">{lastNameError}</p>
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Cinsiyet <span className="text-primary">*</span>
                  </label>
                  <select
                    name="gender"
                    id="gender"
                    className="border rounded-3 py-2 text-muted"
                    onChange={handleGender}
                    required
                  >
                    <option value="0">Seçin</option>
                    <option value="1">Erkek</option>
                    <option value="2">Kadın</option>
                    <option value="3">Belirtmek istemiyorum</option>
                  </select>
                  <p className="text-primary">{genderError}</p>
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
                    className="border rounded-3"
                    onChange={handleMail}
                  />
                  <p className="text-primary">{emailError}</p>
                </div>
                <div className="input-container d-flex flex-column mb-3">
                  <label className="mb-2">
                    Telefon <span className="text-primary">*</span>
                  </label>
                  <input
                    placeholder="+90"
                    type="phone"
                    name="phone"
                    required
                    className="border rounded-3"
                    onChange={handlePhone}
                  />
                  <p className="text-primary">{phoneError}</p>
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
                    className="border rounded-3"
                    onChange={handlePassword}
                  />
                  <p className="text-primary">{passwordError}</p>
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
                    className="border rounded-3"
                    onChange={handlePasswordConfirm}
                  />
                  <p className="text-primary">{passwordConfirmError}</p>
                </div>
                <div className="button-container d-flex flex-column">
                  <button
                    type="submit"
                    className="btn bg-primary text-white py-2 rounded-3"
                    disabled={buttonStatus}
                    onClick={handleSubmit}
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
