import bannerImage from "../../assets/img/banner3-h1-1.jpg";
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
              <p className="title display-3 fw-bold text-white">KAMPANYA</p>
              <p className="subtitle text-white fw-light mb-4 fs-4">
                2 Al 1 Öde!
              </p>
              <a href="#!" className="btn btn-light px-4 rounded-3">
                Button Link
              </a>
            </div>
          </div>
          <div>
            <div className="banner-item">
              <img className="banner-image w-100" src={bannerImage2} alt="" />
              <div className="banner-content align-items-end pe-5">
                <p className="title fs-3 fw-bold text-white text-uppercase">
                  CASUAL ÜRÜNLERDE İNDİRİM
                </p>
                <p className="subtitle text-white fw-light mb-4 fs-6">
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit.{" "}
                </p>
                <a href="#!" className="btn btn-light px-4 rounded-3">
                  Button Link
                </a>
              </div>
            </div>
            <div className="banner-item">
              <img className="banner-image w-100" src={bannerImage3} alt="" />
              <div className="banner-content align-items-start ps-5">
                <p className="title fs-3 fw-bold text-white text-uppercase">
                  İLK ALIMA ÖZEL
                </p>
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
      </div>
    </>
  );
}
