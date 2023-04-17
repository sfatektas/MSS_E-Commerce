import { useParams } from "react-router-dom";
import { generalStore } from "../store/generalStore";
import { Navigate } from "react-router-dom";
import productJson from "../products.json";
import Showcase from "../components/home/Showcase";

const data = productJson;

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
          <div className="container mb-5">
            <p className="my-4 ">
              HOME | Category | <span className="fw-bold">{defination}</span>
            </p>

            <div className="row">
              <div className="filters col-2">Filtreler</div>
              <div className="products col-10">
                <div className="row">
                  {data.map((item) => {
                    if (item.category == defination) {
                      return (
                        <Showcase
                          key={item.id}
                          id={item.id}
                          title={item.title}
                          category={item.category}
                          price={item.price}
                          image={item.image}
                        />
                      );
                    }
                  })}
                </div>
              </div>
            </div>
          </div>
        </>
      );
    } else {
      return <Navigate to="/NotFound" />;
    }
  } catch {}
}
