import Brands from "../components/Brands";

export default function Admin() {
  return (
    <>
      <div className="container">
        <div className="admin row my-5">
          <div className="admin-header col-2 d-flex flex-column p-0">
            <div className="p-4">
              <p className="fs-4 text-muted">Yönetim Paneli</p>
            </div>
            <button className="btn fs-5 fw-light text-start mx-4 active">
              Marka
            </button>
          </div>
          <div className="admin-content col-10 px-5 py-4">
            <div className="row">
              <div className="col-12">
                <Brands />
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
