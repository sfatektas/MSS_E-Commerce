import CarouselFade from "../components/CarouselFade";
import BannerTwoImg from "../components/BannerTwoImg";
import BannerThreeImg from "../components/BannerThreeImg";
import HomeProducts from "../components/HomeProducts";
import Brands from "../components/Brands";
import ImageGallery from "../components/ImageGallery";
import HomeFeatures from "../components/HomeFeatures";
import Loader from "../components/Loader";
import { loaderStore } from "../store/loaderStore";

export default function Home() {
  const { isLoading } = loaderStore();

  return (
    <>
      {isLoading ? (
        <>
          <Loader />
        </>
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
