import bannerImage from "../../assets/img/banner1-h1.jpg";
import bannerImage2 from "../../assets/img/banner2-h1.jpg";

export default function BannerTwoImg() {
  return (
    <>
      <div className="banner-row d-flex mb-5">
        <div className="banner d-flex flex-sm-row flex-column w-100 align-items-center justify-content-center margin-top-100">
          <div className="banner-item">
            <img className="banner-image w-100" src={bannerImage} alt="" />
            <div className="banner-content align-items-start ps-5">
              <p className="campaign bg-primary d-inline-flex text-white p-1 fw-bold">
                50% OFF
              </p>
              <p className="title display-4 fw-bold text-white">
                STYLE MEETS SUBSTANCE
              </p>
              <p className="subtitle text-white fw-light mb-4 fs-6">
                Breathable perforated toe stiched stealth
              </p>
              <a href="/campaign" className="btn btn-light">View Campaign</a>
            </div>
          </div>
          <div className="banner-item">
            <img className="banner-image w-100" src={bannerImage2} alt="" />
            <div className="banner-content align-items-start ps-5">
              <p className="campaign bg-primary d-inline-flex text-white p-1 fw-bold">
                50% OFF
              </p>
              <p className="title fs-3 fw-bold text-white">
                PHANTOM VISION ACADEMY
              </p>
              <p className="subtitle text-white fw-light mb-4 fs-6">
                Breathable perforated toe stiched stealth
              </p>
              <a href="/campaign" className="btn btn-light">View Campaign</a>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
