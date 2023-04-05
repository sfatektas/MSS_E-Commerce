import { useParams } from "react-router-dom";

export default function Category(props) {
  const {defination} = useParams();
  return (
    <>
      <div className="container vh-100">
        <p className="my-4 ">HOME | Category | <span className="fw-bold">{defination}</span></p>
      </div>
    </>
  );
}
