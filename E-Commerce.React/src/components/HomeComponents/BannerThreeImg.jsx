import bannerImage from "../../assets/img/banner3-h1-1.jpg"
import bannerImage2 from "../../assets/img/banner4-h1.jpg";
import bannerImage3 from "../../assets/img/banner5-h1.jpg";

export default function BannerThreeImg() {
  return (
    <>
      <div className="banner-row mb-5 d-flex">
        <div className="banner d-flex flex-md-row flex-column w-100 align-items-center justify-content-center">
          <div className="banner-item">
            <img className="banner-image w-100" src={bannerImage} alt="" />
            <div className="banner-content text-center">
              <p className="campaign p-1 fw-bold">
                ONLY THIS WEEK
              </p>
              <p className="title display-3 fw-bold text-white">BEST SELLING</p>
              <p className="subtitle text-white fw-light mb-4 fs-4">
                get the discount of 25%
              </p>
              <button className="btn btn-light">View Campaign</button>
            </div>
          </div>
          <div>
            <div className="banner-item">
              <img className="banner-image w-100" src={bannerImage2} alt="" />
              <div className="banner-content align-items-end pe-5">
                <p className="campaign bg-primary d-inline-flex text-white p-1 fw-bold">
                  50% OFF
                </p>
                <p className="title fs-3 fw-bold text-white">
                  PHANTOM VISION ACADEMY
                </p>
                <p className="subtitle text-white fw-light mb-4 fs-6">
                Breathable perforated toe stiched stealth
              </p>
                <button className="btn btn-light">View Campaign</button>
              </div>
            </div>
            <div className="banner-item">
              <img className="banner-image w-100" src={bannerImage3} alt="" />
              <div className="banner-content align-items-start ps-5">
                <p className="campaign bg-primary d-inline-flex text-white p-1 fw-bold">
                  50% OFF
                </p>
                <p className="title fs-3 fw-bold text-white">
                  ODYSSEY REACT FLYKNIT 2
                </p>
                <p className="subtitle text-white fw-light mb-4 fs-6">
                Breathable perforated toe stiched stealth
              </p>
                <button className="btn btn-light">View Campaign</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}