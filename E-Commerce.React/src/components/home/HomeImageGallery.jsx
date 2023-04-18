export default function HomeImageGallery() {
  let imageList = [
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_1.jpg",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_2.jpg",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_3.jpg",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_4.jpg",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_5.jpg",
    "https://demo2.wpopal.com/ekommart/wp-content/uploads/2020/02/h1_gallery_2.jpg",
  ];

  return (
    <>
      <div className="gallery row d-flex m-0 ">
        {imageList.map((logo, index) => (
          <div className="gallery-image col-6 col-md-4 col-lg-2  p-0 d-flex" key={index}>
            <img src={logo} alt={index} className="w-100" />
          </div>
        ))}
      </div>
    </>
  );
}
