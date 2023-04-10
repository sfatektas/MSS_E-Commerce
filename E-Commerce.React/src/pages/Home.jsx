import CarouselFade from "../components/home/CarouselFade";
import BannerTwoImg from "../components/home/BannerTwoImg";
import BannerThreeImg from "../components/home/BannerThreeImg";
import HomeProducts from "../components/home/HomeProducts";
import ShowBrands from "../components/home/ShowBrands";
import ImageGallery from "../components/home/ImageGallery";
import HomeFeatures from "../components/home/HomeFeatures";

export default function Home() {
  return (
    <>
      <CarouselFade />
      <BannerTwoImg />
      <HomeProducts />
      <BannerThreeImg />
      <ShowBrands />
      <ImageGallery />
      <HomeFeatures />
    </>
  );
}
