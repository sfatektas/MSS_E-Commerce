import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import Modal from "react-bootstrap/Modal";

export default function Showcase(props) {
  const [basketModal, setBasketModal] = useState(false);
  const [favoritesModal, setFavoritesModal] = useState(false);

  function addBasket() {
    setBasketModal(true);
  }
  function addFavorites() {
    setFavoritesModal(true);
  }
  useEffect(() => {
    setTimeout(() => {
      setBasketModal(false);
      setFavoritesModal(false);
    }, 1500);
  }, [basketModal, favoritesModal]);

  function AddedCartModal(props) {
    return (
      <Modal
        {...props}
        size="md"
        aria-labelledby="contained-modal-title-vcenter"
      >
        <Modal.Body className="overflow-hidden position-relative rounded-3">
          <div className="basket-left-color bg-success"></div>
          <div className=" text-center d-flex align-items-center justify-content-center">
            <div className="basket-modal-icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="#000000"
                width="30"
                height="30"
                viewBox="0 0 14 14"
                role="img"
                focusable="false"
                aria-hidden="true"
              >
                <path
                  fill="green"
                  d="M13 4.1974q0 .3097-.21677.5265L7.17806 10.329l-1.0529 1.0529q-.21677.2168-.52645.2168-.30968 0-.52645-.2168L4.01935 10.329 1.21677 7.5264Q1 7.3097 1 7t.21677-.5265l1.05291-1.0529q.21677-.2167.52645-.2167.30968 0 .52645.2167l2.27613 2.2839 5.07871-5.0864q.21677-.2168.52645-.2168.30968 0 .52645.2168l1.05291 1.0529Q13 3.8877 13 4.1974z"
                />
              </svg>
            </div>
            <div className="basket-modal-text ps-2">
              <p>Ürün sepete eklendi</p>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    );
  }
  function AddedFavoritesModal(props) {
    return (
      <Modal
        {...props}
        size="sm"
        aria-labelledby="contained-modal-title-vcenter"
      >
        <Modal.Body className="overflow-hidden position-relative rounded-3">
          <div className="favorites-left-color bg-primary"></div>
          <div className=" text-center d-flex align-items-center justify-content-center">
            <div className="favorites-modal-icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="30"
                height="30"
                viewBox="0 0 24 24"
                fill="none"
              >
                <path
                  d="M19.3 5.71002C18.841 5.24601 18.2943 4.87797 17.6917 4.62731C17.0891 4.37666 16.4426 4.2484 15.79 4.25002C15.1373 4.2484 14.4909 4.37666 13.8883 4.62731C13.2857 4.87797 12.739 5.24601 12.28 5.71002L12 6.00002L11.72 5.72001C10.7917 4.79182 9.53273 4.27037 8.22 4.27037C6.90726 4.27037 5.64829 4.79182 4.72 5.72001C3.80386 6.65466 3.29071 7.91125 3.29071 9.22002C3.29071 10.5288 3.80386 11.7854 4.72 12.72L11.49 19.51C11.6306 19.6505 11.8212 19.7294 12.02 19.7294C12.2187 19.7294 12.4094 19.6505 12.55 19.51L19.32 12.72C20.2365 11.7823 20.7479 10.5221 20.7442 9.21092C20.7405 7.89973 20.2218 6.64248 19.3 5.71002Z"
                  fill="#EF3636"
                ></path>
              </svg>
            </div>
            <div className="favorites-modal-text ps-2">
              <p>Ürün favorilere eklendi</p>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    );
  }
  return (
    <div className="col-12 col-lg-3 col-md-6 d-flex flex-row">
      <AddedCartModal show={basketModal} onHide={() => setBasketModal(false)} />
      <AddedFavoritesModal
        show={favoritesModal}
        onHide={() => setFavoritesModal(false)}
      />
      <div className="showcase d-flex flex-column align-items-center shadow-sm p-0 mb-3 rounded-3 w-100 overflow-hidden">
        <div className="showcase-buttons d-flex flex-column">
          <a onClick={addFavorites} className="btn text- mb-2">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="26"
              height="26"
              viewBox="0 0 24 24"
              fill="none"
            >
              <path
                d="M11.8456 6.42726L12 6.59097L12.1544 6.42726C14.132 4.33053 17.4026 4.57697 19.0807 6.94915C20.57 9.05459 20.2133 12.0335 18.275 13.6776L12 19L5.725 13.6776C3.78668 12.0335 3.42999 9.05459 4.91934 6.94915C6.59738 4.57698 9.86801 4.33053 11.8456 6.42726Z"
                stroke="#464455"
                strokeLinecap="round"
                strokeLinejoin="round"
              />
            </svg>
          </a>
          <a onClick={addBasket} className="btn text- mb-2">
            <svg
              width="24"
              height="24"
              viewBox="0 0 32 32"
              id="svg5"
              version="1.1"
            >
              <defs id="defs2"></defs>
              <g id="layer1" transform="translate(36,-244)">
                <path
                  d="m -31.371094,255.00586 c -1.625564,0 -2.864805,1.51618 -2.589843,3.10351 l 2.27539,13.13477 c 0.27851,1.60776 1.701467,2.76172 3.314453,2.76172 h 16.767578 c 1.6146248,0 3.0129936,-1.16108 3.3105472,-2.74805 a 1.0001,1.0001 0 0 0 0.00195,-0.0137 l 2.2734375,-13.12109 v -0.002 c 0.2984384,-1.59859 -0.9594241,-3.11523 -2.5859375,-3.11523 z m 0,2 h 22.7675784 c 0.4158021,0 0.6977222,0.33936 0.6210937,0.74805 a 1.0001,1.0001 0 0 0 -0.00195,0.0137 l -2.2753911,13.12695 c -0.124292,0.65116 -0.680335,1.11133 -1.34375,1.11133 h -16.767578 c -0.666611,0 -1.23316,-0.46316 -1.34375,-1.10156 l -2.27539,-13.13672 c -0.07374,-0.42569 0.201707,-0.76172 0.61914,-0.76172 z"
                  id="rect40272"
                ></path>
                <path
                  d="m -24.695312,246.07227 a 1,1 0 0 0 -0.556641,0.52734 l -4,9 a 1,1 0 0 0 0.507812,1.32031 1,1 0 0 0 1.320313,-0.50781 l 4,-9 a 1,1 0 0 0 -0.507813,-1.32031 1,1 0 0 0 -0.763671,-0.0195 z"
                  id="path41727"
                ></path>
                <path
                  d="m -15.279297,246.07227 a 1,1 0 0 0 -0.763672,0.0195 1,1 0 0 0 -0.507812,1.32031 l 4,9 a 1,1 0 0 0 1.318359,0.50781 1,1 0 0 0 0.507813,-1.32031 l -4,-9 a 1,1 0 0 0 -0.554688,-0.52734 z"
                  id="path41729"
                ></path>
                <path
                  d="m -20,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                  id="path43195"
                ></path>
                <path
                  d="m -24,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                  id="path43243"
                ></path>
                <path
                  d="m -16,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                  id="path43245"
                ></path>
              </g>
            </svg>
          </a>
        </div>
        <div className="showcase-image mb-3 d-flex align-items-center position-relative w-100">
          <a href={`/${props.category}/${props.id}`} className="w-100">
            <img
              className="w-100"
              src={`https://msse-commerce.azurewebsites.net/api/files/${props.image}`}
              alt={props.title + " Image"}
            />
          </a>
        </div>
        <div className="showcase-content mb-5 text-center">
          <p className="showcase-brand text-muted fw-light mb-3">
            {props.brand}
          </p>
          <p className="showcase-title fw-semibold mb-3">{props.title}</p>
          <p className="showcase-price text-primary fw-bold mb-3">
            {props.price} TL
          </p>
          <a
            className="showcase-button btn rounded-3"
            href={`/${props.category}/${props.id}`}
          >
            Satın Al
          </a>
        </div>
      </div>
    </div>
  );
}
