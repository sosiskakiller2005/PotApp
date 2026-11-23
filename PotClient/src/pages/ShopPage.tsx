import { useEffect, useMemo, useState } from "react";
import Filters, {
} from "../components/ui/Filters";
import ProductCard from "../components/ui/ProductCard";
import { fetchProducts, type Product } from "../services/Product";
import { Box, Wrap } from "@chakra-ui/react";
import { initialFilters } from "@/components/scripts/initialFIlters";

export default function ShopPage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [filters, setFilters] = useState(initialFilters);

  useEffect(() => {
    fetchProducts().then(setProducts);
  }, []);

  const priceBounds = useMemo<[number, number]>(() => {
    if (products.length === 0) return [0, 0];
    const prices = products.map((p) => p.price);
    return [Math.min(...prices), Math.max(...prices)];
  }, [products]);

  const visible = useMemo(() => {
    const { roasts, countries, priceRange, search, sort } = filters;
    const q = search.trim().toLowerCase();

    const result = products.filter(
      (p) =>
        (roasts.length === 0 || roasts.includes(p.roastDegree)) &&
        (countries.length === 0 || countries.includes(p.country)) &&
        (!priceRange ||
          (p.price >= priceRange[0] && p.price <= priceRange[1])) &&
        (!q || p.name.toLowerCase().includes(q)),
    );

    return result.sort((a, b) =>
      sort === "cheapiest" ? a.price - b.price : b.price - a.price,
    );
  }, [products, filters]);

  return (
    <section className="main flex flex-row gap-3 ">
      <Filters value={filters} onChange={setFilters} priceBounds={priceBounds}/>
        <Box minW={1205}>
          <ul className="flex flex-row">
            <Wrap gap={10} >
              {visible.map((p) => (
                <li key={p.id}>
                  <ProductCard product={p} />
                </li>
              ))}
            </Wrap>
          </ul>
        </Box>
    </section>
  );
}
