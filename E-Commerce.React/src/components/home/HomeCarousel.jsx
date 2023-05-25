import Carousel from "react-bootstrap/Carousel";
import axios from "axios";
import { useEffect, useState } from "react";

function CarouselFade() {
  const [sliders, setSliders] = useState([]);
  useEffect(() => {
    axios
      .get(`https://msse-commerce.azurewebsites.net/api/Slider/1`)
      .then((response) => {
        setSliders(response.data.sliderItems);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);
  return (
    <Carousel fade>
      {sliders.map((item, index) => {
        return (
          <Carousel.Item key={index}>
            <img
              className="d-block w-100"
              src={`https://msse-commerce.azurewebsites.net/api/files/${item.imageUrl}`}
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
  );
}

export default CarouselFade;
