import CarouselFade from "../components/CarouselFade";
import BannerTwoImg from "../components/BannerTwoImg";
import BannerThreeImg from "../components/BannerThreeImg";
import HomeProducts from "../components/HomeProducts";
import Brands from "../components/Brands";
import ImageGallery from "../components/ImageGallery";
import HomeFeatures from "../components/HomeFeatures";
import Loader from "../components/Loader";
import { useState } from "react";

export default function Home() {
  const [isLoading, setIsLoading] = useState(true);
  setTimeout(() => {
    setIsLoading(false)
  }, 2000);
  return (
    <>
      {isLoading ? (
        <Loader />
      ) : (
        <>
          {" "}
          <CarouselFade />
          <BannerTwoImg />
          <HomeProducts />
          <BannerThreeImg />
          <Brands />
          <ImageGallery />
          <HomeFeatures />
        </>
      )}
    </>
  );
}
