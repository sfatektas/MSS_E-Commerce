import axios from "axios";
import { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

export default function AdminContents() {
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");
  const [carousel, setCarousel] = useState([]);
  const [sliderAddModal, setSliderAddModal] = useState();
  const [twoBanner, setTwoBanner] = useState([]);
  const [threeBanner, setThreeBanner] = useState([]);
  const [management, setManagement] = useState("carousel");
  useEffect(() => {
    axios
      .get(`http://api.mssdev.online/api/Slider`)
      .then((response) => {
        setCarousel(response.data[0]);
        setTwoBanner(response.data[1]);
        setThreeBanner(response.data[2]);
        console.log(response.data[0]);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function deleteSliderItem(sliderItemId) {
    if (window.confirm("Bu ürünü silmek istediğinize emin misiniz?")) {
      axios
        .delete(`http://api.mssdev.online/api/SliderItem/${sliderItemId}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
          },
        })
        .then((response) => {
          setInfo("Slider Item başarıyla silindi");
          setVariant("success");
          setInfoModal(true);
        })
        .catch((error) => {
          console.log(error.response);
        });
    }
  }
  function TwoBanner() {
    return (
      <div>
        <p className="fw-semibold mb-3">2'li Slider Alanı</p>
        <div className="mb-4">
          <Table responsive hover borderless>
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Görsel</th>
                <th>Başlık</th>
                <th>Alt Başlık</th>
                <th>Denetim</th>
              </tr>
            </thead>
            <tbody>
              {twoBanner.sliderItems &&
                twoBanner.sliderItems.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>
                      <img
                        height="50px"
                        src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                        alt={item.name}
                      />
                    </td>
                    <td>{item.title}</td>
                    <td>{item.subTitle}</td>
                    <td>
                      <button
                        value={item.id}
                        // onClick={(e) => deleteSliderItem(e.target.value)}
                        className="btn btn-light border px-4 rounded-3"
                      >
                        Düzenle
                      </button>
                    </td>
                  </tr>
                ))}
            </tbody>
          </Table>
        </div>
      </div>
    );
  }
  function ThreeBanner() {
    return (
      <div>
        <p className="fw-semibold mb-3">3'lü Banner Alanı</p>
        <div className="mb-4">
          <Table responsive hover borderless>
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Görsel</th>
                <th>Başlık</th>
                <th>Alt Başlık</th>
                <th>Denetim</th>
              </tr>
            </thead>
            <tbody>
              {threeBanner.sliderItems &&
                threeBanner.sliderItems.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>
                      <img
                        height="50px"
                        src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                        alt={item.name}
                      />
                    </td>
                    <td>{item.title}</td>
                    <td>{item.subTitle}</td>
                    <td>
                      <button
                        value={item.id}
                        // onClick={(e) => deleteSliderItem(e.target.value)}
                        className="btn btn-light border px-4 rounded-3"
                      >
                        Düzenle
                      </button>
                    </td>
                  </tr>
                ))}
            </tbody>
          </Table>
        </div>
      </div>
    );
  }
  function CarouselSlider() {
    return (
      <div>
        <div className="d-flex justify-content-between">
          <p className="fw-semibold mb-3">Ana Sayfa Slider Alanı</p>
          <button
            className="btn btn-light rounded-3 border px-5 fw-semibold"
            onClick={() => setSliderAddModal(true)}
          >
            Slider Ekle
          </button>
        </div>

        <div className="mb-4">
          <Table responsive hover borderless>
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Görsel</th>
                <th>Başlık</th>
                <th>Alt Başlık</th>
                <th>Denetim</th>
              </tr>
            </thead>
            <tbody>
              {carousel.sliderItems &&
                carousel.sliderItems.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>
                      <img
                        height="50px"
                        src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                        alt={item.name}
                      />
                    </td>
                    <td>{item.title}</td>
                    <td>{item.subTitle}</td>
                    <td>
                      <button
                        value={item.id}
                        onClick={(e) => deleteSliderItem(e.target.value)}
                        className="btn btn-light border px-4 rounded-3"
                      >
                        Kaldır
                      </button>
                    </td>
                  </tr>
                ))}
            </tbody>
          </Table>
        </div>
      </div>
    );
  }
  function AddSliderItem(props) {
    //Post Stateleri
    const [sliderTitle, setSliderTitle] = useState("");
    const [sliderSubtitle, setSliderSubtitle] = useState("");
    const [sliderButtonText, setSliderButtonText] = useState("");
    const [sliderButtonLink, setSliderButtonLink] = useState("");
    const [sliderFile, setSliderFile] = useState();

    function handleFile(event) {
      event.preventDefault();
      setSliderFile(event.target.files[0]);
    }

    function handleSubmit(event) {
      event.preventDefault();
      let createSlider = {
        SliderId: 1,
        Title: sliderTitle,
        SubTitle: sliderSubtitle,
        ButtonText: sliderButtonText,
        ButtonLink: sliderButtonLink,
        File: sliderFile,
      };
      axios
        .post("http://api.mssdev.online/api/SliderItem/create", createSlider, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
            "Content-Type": "multipart/form-data",
          },
        })
        .then((response) => {
          setInfo("Slider Başarıyla Eklendi");
          setVariant("success");
          setInfoModal(true);
          setTimeout(() => {
            window.location.reload(false);
          }, 2000);
        })
        .catch((error) => {
          setInfo(error.response.data.Error);
          setVariant("danger");
          setInfoModal(true);
          setSliderAddModal(false);
          console.log(error.response.data);
        });
    }
    return (
      <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Ürün Ekle
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3 fw-semibold ">Slider Başlığı</label>
            <input
              className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Slider Başlığı"
              onChange={(e) => setSliderTitle(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Slider Alt Bilgi Metni</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Slider Alt Bilgi Metni"
              onChange={(e) => setSliderSubtitle(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Slider Button Yazısı</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Slider Button Yazısı"
              onChange={(e) => setSliderButtonText(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Slider Button Linki</label>
            <textarea
              className="mb-3 p-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Slider Button Linki"
              onChange={(e) => setSliderButtonLink(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Slider Görseli</label>
            <div className="file-input mb-3">
              <input
                className="product-image-button btn ps-0 w-100 border rounded-3"
                type="file"
                name=""
                id=""
                onChange={handleFile}
              />
            </div>
            <button
              type="submit"
              className="btn btn-light border py-2 mb-2 rounded-3"
              onClick={handleSubmit}
            >
              Slider Ekle
            </button>
          </form>
        </Modal.Body>
        <Modal.Footer>
          <button
            className="btn btn-light border rounded-3 px-5"
            onClick={props.onHide}
          >
            Kapat
          </button>
        </Modal.Footer>
      </Modal>
    );
  }
  return (
    <>
      <div className="row">
        <Alert show={infoModal} variant={variant}>
          <Alert.Heading>{info}</Alert.Heading>
          <div className="d-flex justify-content-end">
            <Button onClick={() => setInfoModal(false)} variant={variant}>
              Kapat
            </Button>
          </div>
        </Alert>
        <div className="contents col-12">
          <div className="d-flex flex-column justify-content-between">
            <p className="mb-4 fs-4 fw-semibold text-muted">İçerik Ayarları</p>
            <div className="d-flex w-100 rounded-3 mb-3 border">
              <button
                className="btn btn-light col-4 rounded-end rounded-3 fw-semibold py-3"
                onClick={() => setManagement("carousel")}
              >
                Ana Sayfa Slider
              </button>
              <button
                className="btn btn-light col-4 rounded-0 fw-semibold py-3"
                onClick={() => setManagement("twoBanner")}
              >
                2'li Banner Alanı
              </button>
              <button
                className="btn btn-light col-4 rounded-start rounded-3 fw-semibold py-3"
                onClick={() => setManagement("threeBanner")}
              >
                3'lü Banner Alanı
              </button>
            </div>
          </div>
        </div>
        {management === "carousel" && <CarouselSlider />}
        {management === "twoBanner" && <TwoBanner />}
        {management === "threeBanner" && <ThreeBanner />}
        <AddSliderItem
          show={sliderAddModal}
          onHide={() => setSliderAddModal(false)}
        />
      </div>
    </>
  );
}
