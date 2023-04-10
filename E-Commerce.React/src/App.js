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
import Account from "./pages/Account";
import Footer from "./components/common/Footer";
import Category from "./pages/Category";
import Favorites from "./pages/Favorites";
import Product from "./pages/Product";
import Cart from "./pages/Cart";
import Campaign from "./pages/Campaign";
import { ProtectedRoute } from "./components/common/ProtectedRoute";

function App() {
  return (
    <>
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
        <Route path="/category/:defination" element={<Category />} />
        <Route path="/campaign" element={<Campaign />} />
        <Route path="*" element={<NotFound />} />
        <Route
          path="cart"
          element={
            <ProtectedRoute>
              <Cart />
            </ProtectedRoute>
          }
        />
        <Route path="/favorites" element={<Favorites />} />
        <Route path="/product/:name" element={<Product />} />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
