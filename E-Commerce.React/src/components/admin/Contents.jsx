
export default function Contents() {
  return (
    <>
      <p className="display-6 text-center mb-4 border-bottom pb-4">
        İçerik Ayarları
      </p>
      <div className="row">
        <div className="contents-left col-12 col-lg-8">
          <p className="mb-4 fs-4 fw-semibold text-muted">Contents Left</p>
        </div>
        <div className="contents-right col-12 col-lg-4">
          <p className="mb-4 fs-4 fw-semibold text-muted">Contents Right</p>
        </div>
      </div>
    </>
  );
}
