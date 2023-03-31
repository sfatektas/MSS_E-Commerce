import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import logo from "./assets/img/logo.svg";


function Navigation({slogan}) {
  return (
    <Navbar collapseOnSelect expand="lg" bg="light" variant="light" className="py-4">
      <Container className="d-flex flex-row justify-content-between">
        <Navbar.Brand
          className="logo col-12 col-lg-2 d-flex align-items-center justify-content-center justify-content-lg-start pb-4 p-lg-0"
          href="#home"
        >
          <img height="30px" src={logo}></img>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav col-lg-7">
          <Nav className="d-flex flex-row justify-content-between">
            <Nav.Link className="text-black px-4" href="#!">{slogan}</Nav.Link>
            <Nav.Link className="text-black px-4" href="#!">Contact</Nav.Link>
            <NavDropdown  title="Categories" id="collasible-nav-dropdown">
              <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
              <NavDropdown.Item href="#action/3.2">
                Another action
              </NavDropdown.Item>
              <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">
                Separated link
              </NavDropdown.Item>
            </NavDropdown>
            <Nav.Link className="text-black px-4" href="#!">About Us</Nav.Link>
            <Nav.Link className="text-black px-4" href="#!">Try</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Nav className="d-flex flex-row col-lg-3 justify-content-end">
            <Nav.Link href="#!">
              {" "}
              <div className="search mx-3">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="#000000"
                    width="22"
                    height="22"
                    viewBox="0 0 1920 1920"
                  >
                    <path
                      d="M790.588 1468.235c-373.722 0-677.647-303.924-677.647-677.647 0-373.722 303.925-677.647 677.647-677.647 373.723 0 677.647 303.925 677.647 677.647 0 373.723-303.924 677.647-677.647 677.647Zm596.781-160.715c120.396-138.692 193.807-319.285 193.807-516.932C1581.176 354.748 1226.428 0 790.588 0S0 354.748 0 790.588s354.748 790.588 790.588 790.588c197.647 0 378.24-73.411 516.932-193.807l516.028 516.142 79.963-79.963-516.142-516.028Z"
                    />
                  </svg>
              </div>
            </Nav.Link>
            <Nav.Link href="#!">
              {" "}
              <div className="user mx-3">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                  >
                    <path
                      d="M12 12C14.7614 12 17 9.76142 17 7C17 4.23858 14.7614 2 12 2C9.23858 2 7 4.23858 7 7C7 9.76142 9.23858 12 12 12Z"
                      stroke="#292D32"
                      strokeWidth="1.5"
                      strokeLinecap="round"
                    />
                    <path
                      d="M20.5899 22C20.5899 18.13 16.7399 15 11.9999 15C7.25991 15 3.40991 18.13 3.40991 22"
                      stroke="#292D32"
                      strokeWidth="1.5"
                      strokeLinecap="round"
                    />
                  </svg>
              </div>
            </Nav.Link>
            <Nav.Link href="#!">
              <div className="favorites mx-3">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                  >
                    <path
                      d="M4.3314 12.0474L12 20L19.6686 12.0474C20.5211 11.1633 21 9.96429 21 8.71405C21 6.11055 18.9648 4 16.4543 4C15.2487 4 14.0925 4.49666 13.24 5.38071L12 6.66667L10.76 5.38071C9.90749 4.49666 8.75128 4 7.54569 4C5.03517 4 3 6.11055 3 8.71405C3 9.96429 3.47892 11.1633 4.3314 12.0474Z"
                      stroke="#000000"
                      strokeWidth="1.5"
                      strokeLinecap="round"
                      strokeLinejoin="round"
                    />
                  </svg>
                  <div className="favorites-amount" data-selector="favorite-count">
                    0
                  </div>
              </div>
            </Nav.Link>
            <Nav.Link href="#!">
              {" "}
              <div className="cart mx-3">
                  <svg
                    width="24"
                    height="24"
                    viewBox="0 0 32 32"
                    id="svg5"
                    version="1.1"
                  >
                    <defs id="defs2" />

                    <g id="layer1" transform="translate(36,-244)">
                      <path
                        d="m -31.371094,255.00586 c -1.625564,0 -2.864805,1.51618 -2.589843,3.10351 l 2.27539,13.13477 c 0.27851,1.60776 1.701467,2.76172 3.314453,2.76172 h 16.767578 c 1.6146248,0 3.0129936,-1.16108 3.3105472,-2.74805 a 1.0001,1.0001 0 0 0 0.00195,-0.0137 l 2.2734375,-13.12109 v -0.002 c 0.2984384,-1.59859 -0.9594241,-3.11523 -2.5859375,-3.11523 z m 0,2 h 22.7675784 c 0.4158021,0 0.6977222,0.33936 0.6210937,0.74805 a 1.0001,1.0001 0 0 0 -0.00195,0.0137 l -2.2753911,13.12695 c -0.124292,0.65116 -0.680335,1.11133 -1.34375,1.11133 h -16.767578 c -0.666611,0 -1.23316,-0.46316 -1.34375,-1.10156 l -2.27539,-13.13672 c -0.07374,-0.42569 0.201707,-0.76172 0.61914,-0.76172 z"
                        id="rect40272"
                      />

                      <path
                        d="m -24.695312,246.07227 a 1,1 0 0 0 -0.556641,0.52734 l -4,9 a 1,1 0 0 0 0.507812,1.32031 1,1 0 0 0 1.320313,-0.50781 l 4,-9 a 1,1 0 0 0 -0.507813,-1.32031 1,1 0 0 0 -0.763671,-0.0195 z"
                        id="path41727"
                      />

                      <path
                        d="m -15.279297,246.07227 a 1,1 0 0 0 -0.763672,0.0195 1,1 0 0 0 -0.507812,1.32031 l 4,9 a 1,1 0 0 0 1.318359,0.50781 1,1 0 0 0 0.507813,-1.32031 l -4,-9 a 1,1 0 0 0 -0.554688,-0.52734 z"
                        id="path41729"
                      />

                      <path
                        d="m -20,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                        id="path43195"
                      />

                      <path
                        d="m -24,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                        id="path43243"
                      />

                      <path
                        d="m -16,259.00586 a 1,1 0 0 0 -1,1 v 8 a 1,1 0 0 0 1,1 1,1 0 0 0 1,-1 v -8 a 1,1 0 0 0 -1,-1 z"
                        id="path43245"
                      />
                    </g>
                  </svg>
                  <div className="cart-amount" data-selector="cart-count">
                    0
                  </div>
              </div>
            </Nav.Link>
          </Nav>
      </Container>
    </Navbar>
  );
}

export default Navigation;
