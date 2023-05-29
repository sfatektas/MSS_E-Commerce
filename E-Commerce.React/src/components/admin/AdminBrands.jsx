import axios from "axios";
import { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

export default function AdminBrands() {
  const [brands, setBrands] = useState([]);
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [brandAddModal, setBrandAddModal] = useState();
  const [variant, setVariant] = useState("");

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/Brands", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setBrands(response.data);
      })
      .catch((error) => {
        console.log(error.response.data);
      });
  }, []);

  function deleteBrand(brand) {
    if (window.confirm("Bu markayı silmek istediğinize emin misiniz?")) {
      axios
        .delete(`http://api.mssdev.online/api/brands/${brand}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
          },
        })
        .then((response) => {
          console.log(response);
          setInfo("Marka başarıyla silindi");
          setVariant("success");
          setInfoModal(true);
        })
        .catch((error) => {
          console.log(error.response.data);
        });
    }
  }

  function AddBrand(props) {
    const [brandName, setBrandName] = useState("");
    const [file, setFile] = useState();
    function handleFile(event) {
      setFile(event.target.files[0]);
    }

    function handleSubmit(event) {
      let brandCreateModel = {
        defination: brandName,
        file: file,
      };

      event.preventDefault();
      axios
        .post(
          "http://api.mssdev.online/api/Brands",
          brandCreateModel,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              "Content-Type": "multipart/form-data",
            },
          }
        )
        .then((response) => {
          setInfo("Marka Başarıyla Eklendi");
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
          setBrandAddModal(false);
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
            Marka Ekle
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3 fw-semibold ">Marka Adı</label>
            <input
              className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
              name="brand"
              type="text"
              placeholder="Marka Adı"
              onChange={(e) => setBrandName(e.target.value)}
            />
            <label className="mb-3 fw-semibold ">Marka Görseli</label>
            <div className="file-input mb-3">
              <input
                className="btn ps-0 w-100 border rounded-3"
                type="file"
                name=""
                id=""
                onChange={handleFile}
              />
            </div>
            <button
              onClick={handleSubmit}
              type="submit"
              className="btn btn-light border py-2 mb-2 rounded-3"
            >
              Marka Ekle
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
            <Button onClick={() => setBrandAddModal(false)} variant={variant}>
              Kapat
            </Button>
          </div>
        </Alert>
        <div className="admin-brands col-12">
          <div className="d-flex justify-content-between">
            <p className="mb-4 fs-4 fw-semibold text-muted">Markalar</p>
            <button
              className="btn btn-light rounded-3 border px-5 fw-semibold"
              onClick={() => setBrandAddModal(true)}
            >
              Marka Ekle
            </button>
          </div>
          <Table responsive hover borderless>
            <thead>
              <tr>
                <th className="px-0">Sıra</th>
                <th>Marka Adı</th>
                <th>Logo</th>
                <th>Kontrol</th>
              </tr>
            </thead>
            <tbody>
              {brands.map((item, index) => (
                <tr key={index} className="align-middle">
                  <td>{index + 1}</td>
                  <td className="text-uppercase">{item.defination}</td>
                  <td>
                    <img
                      height="50px"
                      src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                      alt={item.defination}
                    />
                  </td>
                  <td className="p-0">
                    <button
                      value={item.defination}
                      onClick={(e) => deleteBrand(e.target.value)}
                      className="btn btn-light border px-4 rounded-3"
                    >
                      Markayı Sil
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
        <AddBrand show={brandAddModal} onHide={() => setBrandAddModal(false)} />
      </div>
    </>
  );
}
