import CarouselFade from "../components/CarouselFade";
import Banner from "../components/Banner";
import HomeProducts from "../components/HomeProducts";
import { Container } from "react-bootstrap";

export default function Home() {
  return (
    <>
      <CarouselFade />
      <Banner />
      <Container>
        <HomeProducts/>
      </Container>

    </>
  );
}
