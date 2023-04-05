import React from "react";

export default function Loader(props) {
  return (
    <div className="loader-main vh-100 d-flex flex-column justify-content-center align-items-center">
      <div className="loader loader--style2" title="1">
        <svg
          version="1.1"
          id="loader-1"
          x="0px"
          y="0px"
          width="80"
          height="80"
          viewBox="0 0 50 50"
        >
          <path
            fill="#000"
            d="M25.251,6.461c-10.318,0-18.683,8.365-18.683,18.683h4.068c0-8.071,6.543-14.615,14.615-14.615V6.461z"
          >
            <animateTransform
              attributeType="xml"
              attributeName="transform"
              type="rotate"
              from="0 25 25"
              to="360 25 25"
              dur="0.6s"
              repeatCount="indefinite"
            />
          </path>
        </svg>
      </div>
      <div className="ms-3 text-white fs-4 fw-light">
        Loading...
      </div>
    </div>
  );
}
