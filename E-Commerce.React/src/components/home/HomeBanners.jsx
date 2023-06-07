import { sliderStore } from "../../store/generalStore";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

export function BannerTwoImg() {
  const { sliders } = sliderStore();
  const [twoImageBanner, setTwoImagebanner] = useState();
  useEffect(() => {
    if (sliders != null) {
      setTwoImagebanner(sliders[1].sliderItems);
    }
  }, [sliders]);

  return (
    <>
      {twoImageBanner != null ? (
        <div className="banner-row d-flex mb-5">
          <div className="banner d-flex flex-md-row flex-column w-100 align-items-center justify-content-center margin-top-100">
            <div className="banner-item h-100" >
              <img
                className="banner-image w-100"
                src={`http://api.mssdev.online/api/files/${twoImageBanner[0].imageUrl}`}
                alt=""
                style={{height:"350px"}}
              />
              <div className="banner-content align-items-start ps-5">
                <p className="title display-4 fw-bold text-white text-uppercase">
                  {twoImageBanner[0].title}
                </p>
                <p className="subtitle fw-light mb-4 fs-6">
                  {twoImageBanner[0].subTitle}
                </p>
                <Link
                  to={twoImageBanner[0].buttonLink}
                  className="btn btn-light px-4 rounded-3"
                >
                  {twoImageBanner[0].buttonText}
                </Link>
              </div>
            </div>
            <div className="banner-item h-100">
              <img
                className="banner-image w-100"
                src={`http://api.mssdev.online/api/files/${twoImageBanner[1].imageUrl}`}
                alt=""
                style={{height:"350px"}}
              />
              <div className="banner-content align-items-start ps-5">
                <span className="title fs-3 fw-bold text-white text-uppercase">
                  {twoImageBanner[1].title}
                </span>
                <p className="subtitle text-white fw-light mb-4 fs-6">
                  {twoImageBanner[1].subTitle}
                </p>
                <Link
                  to={twoImageBanner[1].buttonLink}
                  className="btn btn-light px-4 rounded-3"
                >
                  {twoImageBanner[1].buttonText}
                </Link>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <div
          className="loader loader--style2 d-flex justify-content-center"
          title="1"
        >
          <svg
            version="1.1"
            id="loader-1"
            x="0px"
            y="0px"
            width="80"
            height="80"
            viewBox="0 0 50 50"
          >
            <path
              fill="#000"
              d="M25.251,6.461c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615V6.461z"
            >
              <animateTransform
                attributeType="xml"
                attributeName="transform"
                type="rotate"
                from="0 25 25"
                to="360 25 25"
                dur="0.6s"
                repeatCount="indefinite"
              />
            </path>
          </svg>
        </div>
      )}
    </>
  );
}
export function BannerThreeImg() {
  const { sliders } = sliderStore();
  const [threeImageBanner, setThreeImagebanner] = useState();
  useEffect(() => {
    if (sliders != null) {
      setThreeImagebanner(sliders[2].sliderItems);
    }
  }, [sliders]);
  return (
    <>
      {threeImageBanner != null ? (
        <div className="banner-row mb-5 d-flex pt-5">
          <div className="banner d-flex flex-md-row flex-column w-100 align-items-center justify-content-center">
            <div className="banner-item">
              <img
                className="banner-image w-100"
                src={`http://api.mssdev.online/api/files/${threeImageBanner[0].imageUrl}`}
                alt=""
                style={{height:"620px"}}
              />
              <div className="banner-content text-center">
                <p className="title display-3 fw-bold text-white">
                  {threeImageBanner[0].title}
                </p>
                <p className="subtitle text-white fw-light mb-4 fs-4">
                  {threeImageBanner[0].subTitle}
                </p>
                <Link
                  to={threeImageBanner[1].buttonLink}
                  className="btn btn-light px-4 rounded-3"
                >
                  {threeImageBanner[0].buttonText}
                </Link>
              </div>
            </div>
            <div>
              <div className="banner-item">
                <img
                  className="banner-image w-100"
                  src={`http://api.mssdev.online/api/files/${threeImageBanner[1].imageUrl}`}
                  alt=""
                  style={{height:"310px"}}
                />
                <div className="banner-content align-items-end pe-5">
                  <p className="title fs-3 fw-bold text-white text-uppercase">
                    {threeImageBanner[1].title}
                  </p>
                  <p className="subtitle text-white fw-light mb-4 fs-6">
                    {threeImageBanner[1].subTitle}
                  </p>
                  <Link
                    to={threeImageBanner[1].buttonLink}
                    className="btn btn-light px-4 rounded-3"
                  >
                    {threeImageBanner[1].buttonText}
                  </Link>
                </div>
              </div>
              <div className="banner-item">
                <img
                  className="banner-image w-100"
                  src={`http://api.mssdev.online/api/files/${threeImageBanner[2].imageUrl}`}
                  alt=""
                  style={{height:"310px"}}
                />
                <div className="banner-content align-items-start ps-5">
                  <p className="title fs-3 fw-bold text-white text-uppercase">
                    {threeImageBanner[2].title}
                  </p>
                  <p className="subtitle text-white fw-light mb-4 fs-6">
                    {threeImageBanner[2].subTitle}
                  </p>
                  <Link
                    to={threeImageBanner[1].buttonLink}
                    className="btn btn-light px-4 rounded-3"
                  >
                    {threeImageBanner[2].buttonText}
                  </Link>
                </div>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <div
          className="loader loader--style2 d-flex justify-content-center"
          title="1"
        >
          <svg
            version="1.1"
            id="loader-1"
            x="0px"
            y="0px"
            width="80"
            height="80"
            viewBox="0 0 50 50"
          >
            <path
              fill="#000"
              d="M25.251,6.461c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615V6.461z"
            >
              <animateTransform
                attributeType="xml"
                attributeName="transform"
                type="rotate"
                from="0 25 25"
                to="360 25 25"
                dur="0.6s"
                repeatCount="indefinite"
              />
            </path>
          </svg>
        </div>
      )}
    </>
  );
}
