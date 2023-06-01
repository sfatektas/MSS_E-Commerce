import "./assets/style/style.scss";
import { Routes, Route } from "react-router-dom";
import Header from "./components/common/Header";
import About from "./pages/About";
import Contact from "./pages/Contact";
import Home from "./pages/Home";
import Admin from "./pages/Admin";
import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";
import Forbidden from "./pages/Forbidden";
import Account from "./pages/Account";
import Footer from "./components/common/Footer";
import Category from "./pages/Category";
import Favorites from "./pages/Favorites";
import Product from "./pages/Product";
import Search from "./pages/Search";
import Cart from "./pages/Cart";
import { ProtectedRoute } from "./components/common/ProtectedRoute";
import { loaderStore } from "./store/generalStore";
import Loader from "./components/common/Loader";

function App() {
  const { loader } = loaderStore();

  return (
    <>
      {loader?<Loader />:null}
      <Header />
      <Routes>
        <Route
          path="/admin"
          element={
            <ProtectedRoute>
              <Admin />
            </ProtectedRoute>
          }
        />
        <Route path="/" element={<Home />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/about" element={<About />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route
          path="/account"
          element={
            <ProtectedRoute>
              <Account />
            </ProtectedRoute>
          }
        />
        <Route path="/:defination" element={<Category />} />
        <Route path="/:defination/:name" element={<Product />} />
        <Route path="/search/:search" element={<Search/>}/>
        <Route path="/NotFound" element={<NotFound />} />
        <Route path="/Forbidden" element={<Forbidden />} />
        <Route
          path="cart"
          element={
            <ProtectedRoute>
              <Cart />
            </ProtectedRoute>
          }
        />
        <Route
          path="/favorites"
          element={
            <ProtectedRoute>
              <Favorites />
            </ProtectedRoute>
          }
        />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
