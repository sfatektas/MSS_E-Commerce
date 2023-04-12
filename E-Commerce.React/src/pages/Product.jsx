import { useParams } from "react-router-dom";

export default function Product() {
    const {name} = useParams(); 
    // Ürün linki sorgulanıp true dönerse sayfa görüntülenecek.
  return (
    <>
    <div className="container vh-100">
      <p className="my-4 "><span className="fw-bold">{name}</span></p>
    </div>
  </>
  )
}
