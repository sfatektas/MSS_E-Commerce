import React from 'react'

export default function Showcase(props) {
  return (
    <div className='col-6 col-md-3 d-flex flex-row'>
          <div className='showcase d-flex flex-column align-items-center shadow-sm p-0 my-3'>
        <div className="showcase-image mb-3 h-100 d-flex align-items-center p-2">
            <img className='w-100' src={props.image} alt={props.title+" Image"} />
        </div>
        <div className="showcase-content mb-5 text-center">
            <p className="showcase-category text-muted fw-light">{props.category}</p>
            <p className="showcase-title fw-semibold">{props.title}</p>
            <p className="showcase-price text-primary fw-bold">${props.price}</p>
            <button className='btn text-white'>Buy Product</button>
        </div>
    </div>
    </div>
  )
}
