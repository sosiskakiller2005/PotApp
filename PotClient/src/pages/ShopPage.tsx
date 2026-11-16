import { useEffect, useState } from "react";
import Filters from "../components/ui/Filters";
import ProductCard from "../components/ui/ProductCard";
import { fetchProducts, type Product } from "../services/Product";

export default function ShopPage() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetchProducts();

      setProducts(response);
    };

    fetchData();
  }, []);

  return (
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
  );
}