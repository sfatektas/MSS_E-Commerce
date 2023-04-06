import axios from "axios";
import { useState, useEffect } from "react";

export default function AddProduct() {
  const [brandName, setBrandName] = useState("");
  const [file, setFile] = useState();

  function handleFile(event) {
    setFile(event.target.files[0]);
  }

  function handleSubmit(event) {
    let brandCreateModel = {
      defination: brandName,
      file: file,
    };

    event.preventDefault();
    axios
      .post(
        "https://e-commercemss.azurewebsites.net/api/Brands",
        brandCreateModel,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      )
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  }
  return (
    <>
      <div className="add-product">
        <p className="mb-2 fs-4 fw-semibold">Marka Ekle</p>
        <form className="d-flex flex-column flex-column">
          <label className="mb-2">Marka Adı</label>
          <input
            className="mb-3 d-flex p-2"
            name="brand"
            type="text"
            placeholder="Marka Adı"
            onChange={(e) => setBrandName(e.target.value)}
          />
          <input
            className="mb-3"
            type="file"
            name=""
            id=""
            onChange={handleFile}
          />
          <button
            onClick={handleSubmit}
            type="submit"
            className="btn bg-dark text-white py-2"
          >
            Ürün Ekle
          </button>
        </form>
      </div>
    </>
  );
}
