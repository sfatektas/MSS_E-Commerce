import axios from "axios";
import { useEffect } from "react";

export default function Brands() {
  let brandLogos = [
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-1.png",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-2.png",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-3.png",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-4.png",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-5.png",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/brand-1.png",
  ];

  return (
    <>
      <div className="border-top">
        <div className="container">
          <div className="brands row d-flex justify-content-center p-4">
            {brandLogos.map((logo, index) => (
              <div className="brand-image text-center col-6 col-lg-3 col-xl-2 py-5" key={index}>
                <a href="#!">
                  <img src={logo} />
                </a>
              </div>
            ))}
          </div>
        </div>
      </div>
    </>
  );
}
