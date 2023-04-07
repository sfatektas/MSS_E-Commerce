import React from "react";

export default function Product() {
  return (
    <>
        <p className="display-6 text-center mb-4 border-bottom border-bottom pb-4">Ürünler</p>

      <div className="row">
        <div className="product-left col-6">
          <p className="mb-4 fs-4 fw-semibold text-muted">Product Left</p>
        </div>
        <div className="product-right col-6">
          <p className="mb-4 fs-4 fw-semibold text-muted">Product Right</p>
        </div>
      </div>
    </>
  );
}
