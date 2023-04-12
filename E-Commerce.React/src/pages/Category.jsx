import { useParams } from "react-router-dom";
import { generalStore } from "../store/generalStore";
import { Navigate } from "react-router-dom";
import { isValid } from "js-base64";

export default function Category(props) {
  const { defination } = useParams();
  const { categories } = generalStore();

  try {
    let definationList = categories.map((item) => {
      return item.defination;
    });
    let isValid = definationList.includes(defination);
    if (isValid) {
      return (
        <>
          <div className="container vh-100">
            <p className="my-4 ">
              HOME | Category | <span className="fw-bold">{defination}</span>
            </p>
          </div>
        </>
      );
    } else {
      return <Navigate to="/NotFound" />;
    }
  } catch {}
}
