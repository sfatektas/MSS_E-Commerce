import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";

export default function LogoutModal(props) {
  return (
    <Modal
      {...props}
      size="sm"
      aria-labelledby="contained-modal-title-vcenter"
    >
      <Modal.Header closeButton>
        {/* <Modal.Title id="contained-modal-title-vcenter">
          Başarıyla çıkış yapıldı
        </Modal.Title> */}
      </Modal.Header>
      <Modal.Body className="text-center">
        <p className="fs-4">Başarıyla çıkış yapıldı</p>
      </Modal.Body>
      <Modal.Footer className="d-flex justify-content-center">
        <Button className="modal-button text-white bg-dark border-0" onClick={props.onHide}>Kapat</Button>
      </Modal.Footer>
    </Modal>
  );
}
