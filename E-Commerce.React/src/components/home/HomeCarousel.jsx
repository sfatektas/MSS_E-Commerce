import Carousel from 'react-bootstrap/Carousel';
import Button from 'react-bootstrap/Button';
import sliderImage from '../../assets/img/slider.png'

function CarouselFade() {
  return (
    <Carousel fade >
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={sliderImage}
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 className='mb-4'>First slide label</h3>
          <p className='mb-4'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          <Button variant='dark' className='text-white px-5 py-2 fw-light rounded-3'>Koleksiyon</Button>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={sliderImage}
          alt="Second slide"
        />

        <Carousel.Caption>
          <h3 className='mb-4'>Second slide label</h3>
          <p className='mb-4'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          <Button variant='dark' className='text-white px-5 py-2 fw-light rounded-3'>Koleksiyon</Button>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default CarouselFade;