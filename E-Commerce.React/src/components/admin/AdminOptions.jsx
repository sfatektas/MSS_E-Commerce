import axios from "axios";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import { generalStore } from "../../store/generalStore";
import { useEffect, useState } from "react";

export default function AdminOptions() {
  //MODAL
  const [info, setInfo] = useState("");
  const [show, setModalShow] = useState(false);
  const [variant, setVariant] = useState("");

  //API
  const { options, getOptions } = generalStore();
  const [id, setId] = useState("");
  const [logo, setLogo] = useState("");
  const [slogan, setSlogan] = useState("");
  const [facebookLink, setFacebook] = useState("");
  const [twitterLink, setTwitter] = useState("");
  const [linkedInLink, setLinkedin] = useState("");
  const [instagramLink, setInstagram] = useState("");
  const [phoneNumber, setPhone] = useState("");
  const [email, setEmail] = useState("");
  const [adress, setAdress] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      const options = await getOptions();
      setId(options.id);
      setLogo(options.logo);
      setSlogan(options.slogan);
      setFacebook(options.facebookLink);
      setTwitter(options.twitterLink);
      setLinkedin(options.linkedInLink);
      setInstagram(options.instagramLink);
      setPhone(options.phoneNumber);
      setEmail(options.email);
      setAdress(options.adress);
    };

    fetchData();
  }, []);

  function handleSubmit(event) {
    event.preventDefault();
    let setOptions = {
      id: id,
      logo: logo,
      slogan: slogan,
      facebookLink: facebookLink,
      twitterLink: twitterLink,
      linkedInLink: linkedInLink,
      instagramLink: instagramLink,
      phoneNumber: phoneNumber,
      email: email,
      adress: adress,
    };
    console.log(setOptions);
    axios
      .put(
        "https://msse-commerce.azurewebsites.net/api/siteoption",
        setOptions ,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
          },
        }
      )
      .then((response) => {
        setInfo("Ayarlar başarıyla güncellendi");
        setVariant("success");
        setModalShow(true);
        setTimeout(() => {
          window.location.reload(false);
        }, 2000);
      })
      .catch((error) => {
        setInfo(error.response.data.Error);
        setVariant("danger");
        setModalShow(true);
        console.log(error.response.data);
      });
  }

  return (
    <>
      <div className="row">
        <Alert show={show} variant={variant}>
          <Alert.Heading>{info}</Alert.Heading>
          <div className="d-flex justify-content-end">
            <Button onClick={() => setModalShow(false)} variant={variant}>
              Kapat
            </Button>
          </div>
        </Alert>
        <div className="options">
          <div className="d-flex justify-content-between">
            <p className="mb-4 fs-4 fw-semibold text-muted">Site Ayarları</p>
            <button
              className="btn btn-light border px-5 rounded-3 fw-semibold"
              onClick={handleSubmit}
            >
              Kaydet
            </button>
          </div>
          <div className="row">
            <form className="d-flex row">
              <div className="col-6 pe-4">
                <div className="d-flex flex-column">
                  <label className="mb-3 fw-semibold">Logo</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={logo}
                    onChange={(e) => setLogo(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">Slogan</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={slogan}
                    onChange={(e) => setSlogan(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">İletişim Numarası</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={phoneNumber}
                    onChange={(e) => setPhone(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">E-Mail</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">Adres</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={adress}
                    onChange={(e) => setAdress(e.target.value)}
                  />
                </div>
              </div>
              <div className="col-6 ps-4">
                <div className="d-flex flex-column">
                  <label className="mb-3 fw-semibold">Facebook Adresi</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={facebookLink}
                    onChange={(e) => setFacebook(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">Twitter Adresi</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={twitterLink}
                    onChange={(e) => setTwitter(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">LinkedIn Adresi</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={linkedInLink}
                    onChange={(e) => setLinkedin(e.target.value)}
                  />
                  <label className="mb-3 fw-semibold">Instagram Adresi</label>
                  <input
                    className="mb-3 py-2 px-3 text-muted  bg-light rounded-3 shadow-sm border-0"
                    type="text"
                    value={instagramLink}
                    onChange={(e) => setInstagram(e.target.value)}
                  />
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
