import CarouselFade from "../components/HomeComponents/CarouselFade";
import BannerTwoImg from "../components/HomeComponents/BannerTwoImg";
import BannerThreeImg from "../components/HomeComponents/BannerThreeImg";
import HomeProducts from "../components/HomeComponents/HomeProducts";
import ShowBrands from "../components/HomeComponents/ShowBrands";
import ImageGallery from "../components/HomeComponents/ImageGallery";
import HomeFeatures from "../components/HomeComponents/HomeFeatures"
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
          <ShowBrands />
          <ImageGallery />
          <HomeFeatures />
        </>
      )}
    </>
  );
}
