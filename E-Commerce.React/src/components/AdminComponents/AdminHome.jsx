import React from "react";

export default function AdminHome() {
  return (
    <>
    <p className="display-6 text-center mb-4 border-bottom pb-4">Yönetim Paneli</p>
      <div className="row">
        <div className="admin-left col-12 col-lg-8">
          <p className="mb-4 fs-4 fw-semibold text-muted">Admin Left</p>
        </div>
        <div className="admin-right col-12 col-lg-4">
          <p className="mb-4 fs-4 fw-semibold text-muted">Admin Right</p>
        </div>
      </div>
    </>
  );
}
