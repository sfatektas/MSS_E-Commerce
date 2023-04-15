import { useState } from "react";
import { Navigate } from "react-router-dom";
import AdminAccount from "../components/admin/AdminAccount";
import { generalStore } from "../store/generalStore";
import { Base64 } from "js-base64";

export default function Admin() {
  try {
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const tokenFiltered = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = tokenFiltered.substring(1, tokenFiltered.length - 1);
    const tokenPayload = Base64.decode(trimmedPayload);
    let userRole = JSON.parse(tokenPayload).role;
    if (userRole === "admin") {
      return <AdminAccount />;
    } else {
      return <Navigate to="/forbidden" />;
    }
  } catch {
    return <Navigate to="/forbidden" />;
  }
}
