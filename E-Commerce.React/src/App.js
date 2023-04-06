import Header from "./components/Header";
import "./assets/style/style.scss";
import { Routes, Route, Redirect } from "react-router-dom";
import About from "./pages/About";
import Contact from "./pages/Contact";
import Home from "./pages/Home";
import Admin from "./pages/Admin";
import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";
import Account from "./pages/Account";
import Footer from "./components/Footer";
import Category from "./pages/Category";
import { ProtectedRoute } from "./components/ProtectedRoute";

function App() {
  let isAuth;

  if (localStorage.getItem("TOKEN")) {
    isAuth = true;
  }

  return (
    <>
      <Header />
      <Routes>
        <Route path="/admin" element={ <ProtectedRoute>
              <Admin />
            </ProtectedRoute>} />
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
        <Route path="*" element={<NotFound />} />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
