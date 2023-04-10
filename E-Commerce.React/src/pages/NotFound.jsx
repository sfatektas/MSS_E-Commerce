import { Link } from "react-router-dom";

export default function NotFound() {
  return (
    <div className="d-flex align-items-center justify-content-center my-5">
      <div className="text-center my-5">
        <h1 className="display-1 fw-bold">404</h1>
        <p className="fs-3 mb-2">
          {" "}
          <span className="text-danger">Hata!</span> Sayfa bulunamadı.
        </p>
        <p className="lead mb-3">Aradığınız sayfa bulunamadı veya bu sayfaya erişiminiz yok.</p>
        <Link to="/" className="btn btn-primary text-white px-4">
          Ana Sayfa
        </Link>
      </div>
    </div>
  );
}
