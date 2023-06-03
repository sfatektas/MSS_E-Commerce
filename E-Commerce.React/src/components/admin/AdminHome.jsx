export default function AdminHome() {
  return (
    <>
      <div className="row">
        <div className="panel col-12">
          <p className="mb-4 fs-4 fw-semibold text-muted">Yönetim Paneli</p>
          <div className="row d-flex justify-content-between">
            <div className="col-2 d-flex flex-column border rounded-3 shadow-sm">
              <p className="text-success mt-3 text-end me-2">+%78</p>
              <div className="d-flex flex-column align-items-center ">
                <span className="fs-1 fw-semibold">
                  24.000 <span className="fs-5">TRY</span>
                </span>
                <p className="mb-5 fs-5">Aylık Kazanç</p>
              </div>
            </div>
            <div className="col-2 d-flex flex-column border rounded-3 shadow-sm">
              <p className="text-success mt-3 text-end me-2">+%6</p>
              <div className="d-flex flex-column align-items-center ">
                <span className="fs-1 fw-semibold">80</span>
                <p className="mb-5 fs-5">Yeni Sipariş</p>
              </div>
            </div>
            <div className="col-2 d-flex flex-column border rounded-3 shadow-sm">
              <p className="text-success mt-3 text-end me-2">+%10</p>
              <div className="d-flex flex-column align-items-center ">
                <span className="fs-1 fw-semibold">22</span>
                <p className="mb-5 fs-5">Yeni Müşteri</p>
              </div>
            </div>
            <div className="col-2 d-flex flex-column border rounded-3 shadow-sm">
              <p className="text-success mt-3 text-end me-2">+%50</p>
              <div className="d-flex flex-column align-items-center ">
                <span className="fs-1 fw-semibold">40</span>
                <p className="mb-5 fs-5">Yeni Ürün</p>
              </div>
            </div>
            <div className="col-2 d-flex flex-column border rounded-3 shadow-sm">
              <p className="text-success mt-3 text-end me-2">+%2</p>
              <div className="d-flex flex-column align-items-center ">
                <span className="fs-1 fw-semibold">5</span>
                <p className="mb-5 fs-5">Yeni Yorum</p>
              </div>
            </div>
          </div>
          <div className="row"></div>
        </div>
      </div>
    </>
  );
}
