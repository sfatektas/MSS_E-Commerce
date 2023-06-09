import { useState } from "react";
import { generalStore } from "../store/generalStore";
import SupplierAccount from "../components/supplier/SupplierAccount";
import CustomerAccount from "../components/customer/CustomerAccount";
import { Base64 } from "js-base64";
import { Navigate } from "react-router-dom";

export default function Account() {
  try {
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const tokenFiltered = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = tokenFiltered.substring(1, tokenFiltered.length - 1);
    const tokenPayload = Base64.decode(trimmedPayload);
    let userRole = JSON.parse(tokenPayload).role;

    if (userRole === "supplier") {
      return <SupplierAccount />;
    } else if (userRole === "customer") {
      return <CustomerAccount />;
    } else if (userRole === "admin") {
      return <Navigate to="/admin" />;
    } else {
      return <Navigate to="/login" />;
    }
  } catch {
    return <Navigate to="/forbidden" />;
  }
}
