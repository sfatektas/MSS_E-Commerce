import axios from "axios";
import { useEffect, useState } from "react";

export default function AdminContents() {
  useEffect(() => {
    axios
      .get(`https://msse-commerce.azurewebsites.net/api/Slider`)
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <>
      <div className="row">
        <div className="contents col-12">
          <p className="mb-4 fs-4 fw-semibold text-muted">İçerik Ayarları</p>
        </div>
      </div>
    </>
  );
}
