import Carousel from 'react-bootstrap/Carousel';
import Button from 'react-bootstrap/Button';
import sliderImage2 from '../assets/img/slider2.png'
import sliderImage3 from '../assets/img/slider3.png'

function CarouselFade() {
  return (
    <Carousel fade >
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={sliderImage3}
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 className='mb-4'>First slide label</h3>
          <p className='mb-4'>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
          <Button variant='dark' className='text-white px-5 py-2 fw-light'>Collection</Button>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={sliderImage2}
          alt="Second slide"
        />

        <Carousel.Caption>
          <h3 className='mb-4'>Second slide label</h3>
          <p className='mb-4'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
          <Button variant='dark' className='text-white px-5 py-2 fw-light'>Collection</Button>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default CarouselFade;