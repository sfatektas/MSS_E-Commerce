import React from "react";

export default function Navigation(props) {
  return (
    <>
      <div className="d-flex flex-column align-items-center py-5 mb-5 text-center bg-secondary">
        <p className="fs-1 text-white fw-bold mb-3">{props.link}</p>
        <div className="d-flex justify-content-center">
          <a className="text-white" href="/">
            Home
          </a>
          <p className="text-white px-2">{">"}</p>
          <p className="text-muted">{props.link}</p>
        </div>
      </div>
    </>
  );
}
