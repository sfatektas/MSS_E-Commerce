import axios from "axios";
import { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";

export default function Brands() {
  const [brandName, setBrandName] = useState("");
  const [file, setFile] = useState();
  const [brands, setBrands] = useState([]);
  const [info, setInfo] = useState("");
  const [show, setModalShow] = useState(false)
  const [variant, setVariant] = useState("")

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Brands")
      .then((response) => {
        setBrands(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function deleteBrand(brand) {
    axios
      .delete(`https://e-commercemss.azurewebsites.net/api/brands/${brand}`)
      .then((response) => {
        console.log(response);
        setInfo("Marka başarıyla silindi")
        setVariant("success")
        setModalShow(true)

      })
      .catch((error) => {
        console.log(error);
      });
  }

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
        "https://e-commercemss.azurewebsites.net/api/Brands",
        brandCreateModel,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      )
      .then((response) => {
        setInfo("Marka Başarıyla Eklendi")
        setVariant("success")
        setModalShow(true)
        setTimeout(() => {
          window.location.reload(false);
        }, 2000);
      })
      .catch((error) => {
        setInfo(error.response.data.Error);
        setVariant("danger")
        setModalShow(true)
        console.log(error);
      });
  }
  return (
    <>
      <p className="display-5 fw-light text-muted mb-4">Markalar</p>
      <div className="row">
      <Alert show={show} variant={variant}>
        <Alert.Heading>{info}</Alert.Heading>
        <div className="d-flex justify-content-end">
          <Button onClick={() => setModalShow(false)} variant={variant}>
            Kapat
          </Button>
        </div>
      </Alert>
        <div className="list-brands col-8">
          <p className="mb-4 fs-4 fw-semibold text-muted">Marka Listesi</p>
          <Table hover responsive variant="light table">
            <thead>
              <tr>
                <th>Sıra</th>
                <th>Marka Adı</th>
                <th>Logo</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {brands.map((item, index) => (
                <tr key={index} className="align-middle">
                  <td>{index + 1}</td>
                  <td className="text-uppercase">{item.defination}</td>
                  <td>
                    <img
                      src={`https://e-commercemss.azurewebsites.net/api/files/${item.imageUrl}`}
                      alt={item.defination}
                    />
                  </td>
                  <td className="p-0">
                    <button
                      value={item.defination}
                      onClick={(e) => deleteBrand(e.target.value)}
                      className="btn btn-dark text-white px-4"
                    >
                      Markayı Sil
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
        <div className="add-brands col-4">
          <p className="mb-4 fs-4 fw-semibold text-muted">Marka Ekle</p>
          <form className="d-flex flex-column flex-column">
            <label className="mb-3">Marka Adı</label>
            <input
              className="mb-3 d-flex p-2"
              name="brand"
              type="text"
              placeholder="Marka Adı"
              onChange={(e) => setBrandName(e.target.value)}
            />
            <input
              className="mb-3 btn ps-0"
              type="file"
              name=""
              id=""
              onChange={handleFile}
            />
            <button
              onClick={handleSubmit}
              type="submit"
              className="btn bg-dark text-white py-2 mb-2"
            >
              Marka Ekle
            </button>
          </form>
        </div>
      </div>
    </>
  );
}
