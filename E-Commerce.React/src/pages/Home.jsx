import CarouselFade from "../components/CarouselFade";
import BannerTwoImg from "../components/BannerTwoImg";
import BannerThreeImg from "../components/BannerThreeImg";
import HomeProducts from "../components/HomeProducts";
import ShowBrands from "../components/ShowBrands";
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
          <ShowBrands />
          <ImageGallery />
          <HomeFeatures />
        </>
      )}
    </>
  );
}
