import { useEffect, useState, useMemo } from "react";
import Showcase from "./Showcase";
import { useJsonState } from "../store/productContext";

const data = [
  {
    id: 1,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Jordan-PNG-Pic.png",
  },
  {
    id: 2,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-Clipart.png",
  },
  {
    id: 3,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-File.png",
  },
  {
    id: 4,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-Photos.png",
  },
  {
    id: 5,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Air-Max-PNG-Cutout.png",
  },
  {
    id: 6,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Jordan-PNG-Pic.png",
  },
  {
    id: 7,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Air-Max-PNG-Cutout.png",
  },
  {
    id: 8,
    category: "Shoes",
    title: "Nike React Metcon AMP",
    price: 180.22,
    image:
      "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-Photos.png",
  },
  // {
  //   id: 9,
  //   category: "Shoes",
  //   title: "Nike React Metcon AMP",
  //   price: 180.22,
  //   image:
  //     "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-File.png",
  // },
  // {
  //   id: 10,
  //   category: "Shoes",
  //   title: "Nike React Metcon AMP",
  //   price: 180.22,
  //   image:
  //     "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Jordan-PNG-Pic.png",
  // },
  // {
  //   id: 11,
  //   category: "Shoes",
  //   title: "Nike React Metcon AMP",
  //   price: 180.22,
  //   image:
  //     "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-PNG-Clipart.png",
  // },
  // {
  //   id: 12,
  //   category: "Shoes",
  //   title: "Nike React Metcon AMP",
  //   price: 180.22,
  //   image:
  //     "https://www.pngall.com/wp-content/uploads/13/Nike-Shoes-Jordan-PNG-Pic.png",
  // },
];

export default function HomeProducts() {
  const { jsonState,setJsonState} = useJsonState();

  useEffect(() => {
    setJsonState(data);
  }, [setJsonState]);

  return (
    <div className="products-main container mb-5">
      <div className="products-header d-flex flex-column align-items-center mb-4">
        <span className="title display-6 fw-bold mb-3">FEATURE PRODUCTS</span>
        <p className="text-muted">Visit our shop to see amazing products (1:1 Photo)</p>
      </div>
      <div className="products-content">
        <div className="row">
          {jsonState.map((item) => (
            <Showcase
              key={item.id}
              id={item.id}
              title={item.title}
              category={item.category}
              price={item.price}
              image={item.image}
            />
          ))}
        </div>
      </div>
    </div>
  );
}
