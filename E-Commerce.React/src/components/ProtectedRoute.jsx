import { Navigate } from "react-router-dom";

export const ProtectedRoute = ({ children }) => {
  let isAuth;
  if (localStorage.getItem("TOKEN")) {
    isAuth = true;
  }
  if (!isAuth) {
    return <Navigate to="/login" />;
  }
  return children;
};
