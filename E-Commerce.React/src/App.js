import Navigation from "./Navigation";
import "bootstrap/dist/css/bootstrap.min.css";
import "./assets/style/style.scss";
import axios from "axios";
import { useState, useEffect} from "react";

function App() {
  const [siteOptions, setSiteOptions] = useState([]);

  useEffect(() => {
    axios
    .get("https://msse-commerce.azurewebsites.net/api/SiteOption")
    .then((response) => {
      console.log(response.data)
      setSiteOptions(response.data);
    })
    .catch((error) => {
      console.log(error);
    });
  }, [])
  
  return (
    <div>
      <Navigation slogan={siteOptions.slogan}/>
    </div>
  );
}

export default App;
