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
  const [carousel, setCarousel] = useState([])
  useEffect(() => {
    axios
      .get(`http://api.mssdev.online/api/Slider`)
      .then((response) => {
        setCarousel(response.data[0])
        console.log(response.data[0])
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function deleteSliderItem(sliderItemId) {
    if (window.confirm("Bu ürünü silmek istediğinize emin misiniz?")) {
      axios
        .delete(
          `http://api.mssdev.online/api/SliderItem/${sliderItemId}`,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
            },
          }
        )
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
          <p className="mb-4 fs-4 fw-semibold text-muted">İçerik Ayarları</p>
          <div>
            <p className="fw-semibold">Ana Sayfa Slider Alanı</p>
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

                {carousel.sliderItems&&(carousel.sliderItems).map((item, index) => (
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
        </div>
      </div>
    </>
  );
}
