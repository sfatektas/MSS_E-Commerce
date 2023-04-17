import bannerImage from "../../assets/img/banner1-h1.jpg";
import bannerImage2 from "../../assets/img/banner2-h1.jpg";

export default function BannerTwoImg() {
  return (
    <>
      <div className="banner-row d-flex mb-5">
        <div className="banner d-flex flex-md-row flex-column w-100 align-items-center justify-content-center margin-top-100">
          <div className="banner-item h-100">
            <img className="banner-image w-100" src={bannerImage} alt="" />
            <div className="banner-content align-items-start ps-5">
              <p className="title display-4 fw-bold text-white text-uppercase">
                RAHATLIKLA TANIŞIN
              </p>
              <p className="subtitle fw-light mb-4 fs-6">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
              </p>
              <a href="#!" className="btn btn-light px-4 rounded-3">
                Button Link
              </a>
            </div>
          </div>
          <div className="banner-item h-100">
            <img className="banner-image w-100" src={bannerImage2} alt="" />
            <div className="banner-content align-items-start ps-5">
              <span className="title fs-3 fw-bold text-white text-uppercase">
                SPORCU ÜRÜNLERİ
              </span>
              <p className="subtitle text-white fw-light mb-4 fs-6">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
              </p>
              <a href="#!" className="btn btn-light px-4 rounded-3">
                Button Link
              </a>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
