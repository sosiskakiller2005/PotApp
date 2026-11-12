import "./App.css";
import Filters from "./components/ui/Filters";
import ProductCard from "./components/ui/ProductCard";

function App() {
  return (
    <section className="p-8 flex flex-row gap-3">
      <Filters />
      <div>
        <ul className="flex flex-col gap-5 ">
          <li>
            <ProductCard />
          </li>
          <li>
            <ProductCard />
          </li>
          <li>
            <ProductCard />
          </li>
        </ul>
      </div>
    </section>
  );
}

export default App;
