import axios from "axios";
import { useEffect, useState} from "react";

export default function ShowBrands() {

  const [brands, setBrands] = useState([]);

  useEffect(() => {
    axios
      .get("https://e-commercemss.azurewebsites.net/api/Brands")
      .then((response) => {
        setBrands(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <>
      <div className="border-top">
        <div className="container">
          <div className="brands row d-flex justify-content-center p-4">
            {brands.slice(0, 6).map((item, index) => (
              <div className="brand-image text-center col-6 col-lg-3 col-xl-2 py-5" key={index}>
                <a href="#!">
                  <img src={`https://e-commercemss.azurewebsites.net/api/files/${item.imageUrl}`} alt={item.defination} />
                </a>
              </div>
            ))}
          </div>
        </div>
      </div>
    </>
  );
}
