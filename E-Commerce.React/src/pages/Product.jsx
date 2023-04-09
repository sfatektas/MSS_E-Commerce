import { useParams } from "react-router-dom";

export default function Product() {
    const {name} = useParams();
  return (
    <>
    <div className="container vh-100">
      <p className="my-4 "><span className="fw-bold">{name}</span></p>
    </div>
  </>
  )
}
