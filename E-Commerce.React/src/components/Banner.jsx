import bannerImage from "../assets/img/banner1-h1.jpg";
import bannerImage2 from "../assets/img/banner2-h1.jpg";

export default function Banner() {
  return (
    <>
      <div className="banner-row mb-5 d-flex">
        <div className="banner d-flex flex-md-row flex-column w-100 align-items-center justify-content-center">
          <div className="banner-item">
            <img className="banner-image w-100" src={bannerImage} alt="" />
            <div className="banner-content">
              <p className="discount bg-primary text-white p-1 fw-bold d-none d-sm-inline-flex">40% OFF</p>
              <p className="title fw-bold text-white fs-md-1 fs-5">STYLE MEETS SUBSTANCE</p>
              <p className="text-white fw-light fs-6">Breathable perforated toe stiched stealt</p>
              <button className="btn btn-light fw-bold">Find Your Shoe</button>
            </div>
          </div>
          <div className="banner-item d-none d-lg-block">
            <img className="banner-image w-100" src={bannerImage2} alt="" />
            <div className="banner-content">
              <p className="discount bg-primary d-inline-flex text-white p-1 fw-bold">50% OFF</p>
              <p className="title fs-3 fw-bold text-white">ENERGY TAKES OVER</p>
              <button className="btn btn-light fw-bold">View Campaign</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
