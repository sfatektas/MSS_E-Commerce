import Carousel from "react-bootstrap/Carousel";
import axios from "axios";
import { useEffect, useState } from "react";
import { sliderStore } from "../../store/generalStore";
function CarouselFade() {
  const { sliders } = sliderStore();
  const [carouselSlider, setCarouselSlider] = useState();

  useEffect(() => {
    if (sliders != null) {
      setCarouselSlider(sliders[0].sliderItems);
    }
  }, [sliders]);
  return (
    <>
      {" "}
      {carouselSlider != null ? (
        <Carousel fade>
          {carouselSlider.map((item, index) => {
            return (
              <Carousel.Item key={index}>
                <img
                  className="d-block w-100"
                  src={`http://api.mssdev.online/api/files/${item.imageUrl}`}
                  alt={item.title}
                />
                <Carousel.Caption>
                  <h3 className="mb-4">{item.title}</h3>
                  <p className="mb-4">{item.subTitle}</p>
                  <a
                    className="btn btn-dark text-white px-5 py-2 fw-light rounded-3"
                    href={item.buttonLink}
                    target="_blank"
                  >
                    {item.buttonText}
                  </a>
                </Carousel.Caption>
              </Carousel.Item>
            );
          })}
        </Carousel>
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

export default CarouselFade;
