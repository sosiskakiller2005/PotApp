import { useEffect, useState } from "react";
import "./App.css";
import "./index.css";
import Filters from "./components/ui/Filters";
import ProductCard from "./components/ui/ProductCard";
import { fetchProducts, type Product } from "./services/Product";
import Header from "./components/ui/Header";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetchProducts();

      setProducts(response);
    };

    fetchData();
  }, []);

  return (
    <main>
      <Header/>
      <section className="main flex flex-row gap-3 ">
        <Filters/>
        <div>
          <ul className="flex flex-col gap-5 w-1/2">
            {products.map((p) => (
              <li key={p.id}>
                <ProductCard product={p} />
              </li>
            ))}
          </ul>
        </div>
      </section>

    </main>
  );
}

export default App;
