import axios from "axios";
import { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import Modal from "react-bootstrap/Modal";
import Alert from "react-bootstrap/Alert";
import Button from "react-bootstrap/Button";

export default function AdminUserManagement() {
  const [management, setManagement] = useState("customers");
  const [customer, setCustomer] = useState([]);
  const [supplier, setSupplier] = useState([]);
  const [info, setInfo] = useState("");
  const [infoModal, setInfoModal] = useState(false);
  const [variant, setVariant] = useState("");

  function updateData() {
    axios
      .get("http://api.mssdev.online/api/users?usertype=customer", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setCustomer(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
    axios
      .get("http://api.mssdev.online/api/users?usertype=supplier", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setSupplier(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/users?usertype=customer", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setCustomer(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios
      .get("http://api.mssdev.online/api/users?usertype=supplier", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("user_token")}`,
        },
      })
      .then((response) => {
        setSupplier(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  function Customers() {
    function handleCheckbox(id, status, name) {
      if (
        window.confirm(
          `${name} adlı kullanıcının durumunu ${
            status ? "pasif yapmak" : "aktif yapmak"
          } istediğinize emin misiniz?`
        )
      ) {
        axios
          .put(
            `http://api.mssdev.online/api/users/${id}?status=${
              status ? false : true
            }`,
            {
              headers: {
                Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              },
            }
          )
          .then((response) => {
            updateData()
          })
          .catch((error) => {
            console.log(error);
          });
      }
    }

    return (
      <div className="row user-management">
        <div className="admin-customer-management-left col-12">
          <p className="mb-4 fs-4 fw-semibold text-muted">Müşteriler</p>
          <div className="mb-4">
            <Table responsive hover borderless variant="light">
              <thead>
                <tr>
                  <th className="px-0">Sıra</th>
                  <th>İsim</th>
                  <th>Telefon</th>
                  <th>E-Posta</th>
                  <th>Hesap Aktif/Pasif</th>
                </tr>
              </thead>
              <tbody>
                {customer.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>
                      {item.firstName} {item.lastName}
                    </td>
                    <td>{item.phoneNumber}</td>
                    <td>{item.email}</td>
                    <td>
                      <div
                        className="checkbox"
                        onClick={(e) =>
                          handleCheckbox(item.id, item.isActive, item.firstName)
                        }
                      >
                        <span
                          className={
                            `dot ` + `${item.isActive ? "active" : ""}`
                          }
                        ></span>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </div>
      </div>
    );
  }

  function Suppliers() {
    const [userAddModal, setUserAddModal] = useState(false);
    function handleCheckbox(id, status, name) {
      if (
        window.confirm(
          `${name} adlı kullanıcının durumunu ${
            status ? "pasif yapmak" : "aktif yapmak"
          } istediğinize emin misiniz?`
        )
      ) {
        axios
          .put(
            `http://api.mssdev.online/api/users/${id}?status=${
              status ? false : true
            }`
          )
          .then((response) => {
            updateData()
          })
          .catch((error) => {
            console.log(error);
          });
      }
    }
    function AddSuplierModal(props) {
      const [userName, setUserName] = useState("");
      const [password, setPassword] = useState("");
      const [passwordConfirm, setPasswordConfirm] = useState("");
      const [email, setEmail] = useState("");
      const [phoneNumber, setPhoneNumber] = useState("");
      const [companyName, setCompanyName] = useState("");
      const [companyUserName, setCompanyUserName] = useState("");
      const [companyDetail, setCompanyDetail] = useState("");
      const [companyImage, setcompanyImage] = useState();
      function handleFile(event) {
        event.preventDefault();
        setcompanyImage(event.target.files[0]);
      }
      function handleSubmit(event) {
        event.preventDefault();
        let createSupplier = {
          Username: userName,
          Password: password,
          PasswordConfirm: passwordConfirm,
          Email: email,
          PhoneNumber: phoneNumber,
          CompanyName: companyName,
          CompanyUserName: companyUserName,
          CompanyDetail: companyDetail,
          File: companyImage,
        };
        axios
          .post("http://api.mssdev.online/api/suppliers", createSupplier, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("user_token")}`,
              "Content-Type": "multipart/form-data",
            },
          })
          .then((response) => {
            setInfo("Satıcı Başarıyla Eklendi");
            setVariant("success");
            setInfoModal(true);
            updateData()
          })
          .catch((error) => {
            setInfo(error.response.data.Error);
            setVariant("danger");
            setInfoModal(true);
            console.log(error);
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
              Satıcı Ekle
            </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <form className="d-flex flex-column flex-column">
              <label className="mb-3 fw-semibold ">Kullanıcı Adı</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="username"
                type="text"
                placeholder="Kullanıcı Adı"
                onChange={(e) => setUserName(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Şifre</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="password"
                type="password"
                placeholder="Şifre"
                onChange={(e) => setPassword(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">
                Şifrenizi tekrar girin
              </label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="password"
                type="password"
                placeholder="Şifre"
                onChange={(e) => setPasswordConfirm(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">E-Posta</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="email"
                type="email"
                placeholder="E-Posta"
                onChange={(e) => setEmail(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Telefon Numarası</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="phone"
                type="number"
                placeholder="Telefon Numarası"
                onChange={(e) => setPhoneNumber(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Şirket Adı</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="companyName"
                type="text"
                placeholder="Şirket Adı"
                onChange={(e) => setCompanyName(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Şirket Kullanıcı Adı</label>
              <input
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="companyUserName"
                type="text"
                placeholder="Şirket Kullanıcı Adı"
                onChange={(e) => setCompanyUserName(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Şirket Detayları</label>
              <textarea
                className="mb-3 py-2 px-3 text-muted bg-light rounded-3 shadow-sm border-0"
                name="companyDetail"
                type="text"
                placeholder="Şirket Detayları"
                onChange={(e) => setCompanyDetail(e.target.value)}
              />
              <label className="mb-3 fw-semibold ">Mağaza Görseli</label>
              <div className="file-input mb-3">
                <input
                  className="store-image-button btn ps-0 w-100 border rounded-3"
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
                Satıcı Ekle
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
      <div className="row user-management">
        <div className="admin-supplier-management col-12">
          <div className="d-flex justify-content-between">
            <p className="mb-4 fs-4 fw-semibold text-muted">Satıcılar</p>
            <button
              className="btn btn-light rounded-3 border px-5 fw-semibold"
              onClick={() => setUserAddModal(true)}
            >
              Satıcı Ekle
            </button>
          </div>
          <div className="mb-4">
            <Table responsive hover borderless variant="light">
              <thead>
                <tr>
                  <th className="px-0">Sıra</th>
                  <th>Satıcı</th>
                  <th>Telefon</th>
                  <th>E-Posta</th>
                  <th>Hesap Aktif/Pasif</th>
                </tr>
              </thead>
              <tbody>
                {supplier.map((item, index) => (
                  <tr key={index} className="align-middle">
                    <td>{index + 1}</td>
                    <td>{item.companyName}</td>
                    <td>{item.phoneNumber}</td>
                    <td>{item.email}</td>
                    <td>
                      <div
                        className="checkbox"
                        onClick={(e) =>
                          handleCheckbox(item.id, item.isActive, item.firstName)
                        }
                      >
                        <div
                          className={
                            `dot ` + `${item.isActive ? "active" : ""}`
                          }
                        ></div>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>

          <AddSuplierModal
            show={userAddModal}
            onHide={() => setUserAddModal(false)}
          />
        </div>
      </div>
    );
  }

  return (
    <>
      <Alert show={infoModal} variant={variant}>
        <Alert.Heading>{info}</Alert.Heading>
        <div className="d-flex justify-content-end">
          <Button onClick={() => setInfoModal(false)} variant={variant}>
            Kapat
          </Button>
        </div>
      </Alert>
      <p className="mb-4 fs-4 fw-semibold text-muted">Kullanıcı Yönetimi</p>
      <div className="d-flex w-100 rounded-3 mb-3 border">
        <button
          className="btn btn-light col-6 rounded-end rounded-3 fw-semibold py-3"
          onClick={() => setManagement("customers")}
        >
          Müşteriler
        </button>
        <button
          className="btn btn-light col-6 rounded-start rounded-3 fw-semibold py-3"
          onClick={() => setManagement("suppliers")}
        >
          Satıcılar
        </button>
      </div>
      {management === "customers" && <Customers />}
      {management === "suppliers" && <Suppliers />}
    </>
  );
}
