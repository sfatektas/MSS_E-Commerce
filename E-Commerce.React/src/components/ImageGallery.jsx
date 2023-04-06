export default function imageGallery() {
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
          <div
            className="gallery-image col-6 col-lg-2 p-0"
            key={index}
          >
            <a className="h-100 w-100" href="#!">
              <img src={logo} className="w-100" />
            </a>
          </div>
        ))}
      </div>
    </>
  );
}
