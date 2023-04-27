import axios from "axios";
import Navigation from "../components/common/Navigation";
import { useEffect, useState } from "react";
import { Base64 } from "js-base64";

export default function Cart() {
  const [userName, setUserName] = useState();
  const [basketItems, setBasketItems] = useState([])

  useEffect(() => {
    const token = localStorage.getItem("user_token");
    const startIndex = token.indexOf(".");
    const endIndex = token.lastIndexOf(".");
    const filteredToken = token.slice(startIndex, endIndex + 1);
    const trimmedPayload = filteredToken.substring(1, filteredToken.length - 1);
    const decodedPayload = Base64.decode(trimmedPayload);

    let tokenUserName = JSON.parse(decodedPayload).nameid;
    setUserName(tokenUserName);

    if (userName) {
      axios
        .get(`https://e-commercemss.azurewebsites.net/api/Baskets/${userName}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("user_token")}`,
          },
        })
        .then((response) => {
          console.log(response);
          setBasketItems(response.data.basketItems)
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, [userName]);
  console.log(basketItems)
  return (
    <>
      <Navigation link="Sepetim" />
      <div className="d-flex justify-content-center my-5">
        {basketItems.map((item,index)=>{
          return(
            <div key={index}>
              <p>Adet :{item.amount}</p>
              <p>Ürün ID :{item.productInStockId}</p>
            </div>
          )
        })}
      </div>
    </>
  );
}
