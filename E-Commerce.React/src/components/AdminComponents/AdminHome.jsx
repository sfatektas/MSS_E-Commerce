import React from "react";

export default function AdminHome() {
  return (
    <>
    <p className="display-5 fw-light text-muted mb-4">Yönetim Paneli</p>
      <div className="row">
        <div className="admin-left col-6">
          <p className="mb-4 fs-4 fw-semibold text-muted">Admin Left</p>
        </div>
        <div className="admin-right col-6">
          <p className="mb-4 fs-4 fw-semibold text-muted">Admin Right</p>
        </div>
      </div>
    </>
  );
}