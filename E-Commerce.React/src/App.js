import Header from "./components/Header";
import "./assets/style/style.scss";
import { Routes, Route } from "react-router-dom";
import About from "./pages/About";
import Contact from "./pages/Contact";
import Home from "./pages/Home";
import Login from "./pages/Login";


function App() {
  
  // const [siteOptions, setSiteOptions] = useState([]);

  // useEffect(() => {
  //   axios
  //     .get("https://msse-commerce.azurewebsites.net/api/SiteOption")
  //     .then((response) => {
  //       console.log(response.data);
  //       setSiteOptions(response.data);
  //     })
  //     .catch((error) => {
  //       console.log(error);
  //     });
  // }, []);

  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/about" element={<About />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </>
  );
}

export default App;
