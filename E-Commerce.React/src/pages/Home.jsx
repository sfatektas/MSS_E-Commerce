import HomeCarousel from "../components/home/HomeCarousel";
import HomeProducts from "../components/home/HomeProducts";
import BrandsShowcase from "../components/common/BrandsShowcase";
import HomeImageGallery from "../components/home/HomeImageGallery";
import HomeFeatures from "../components/home/HomeFeatures";
import {BannerThreeImg,BannerTwoImg} from "../components/home/HomeBanners"

export default function Home() {
  return (
    <>
      <HomeCarousel />
      <BannerTwoImg />
      <HomeProducts />
      <BannerThreeImg />
      <BrandsShowcase />
      <HomeImageGallery />
      <HomeFeatures />
    </>
  );
}
