import AddProduct from "../components/AddProduct";

export default function Admin() {
  return (
    <>
      <div className="container vh-100">
        <div className="border col-6 my-5 p-4">
          <AddProduct />
        </div>
      </div>
    </>
  );
}
