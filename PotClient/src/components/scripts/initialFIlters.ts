export type SortValue = "cheapiest" | "priciest";

export type FiltersState = {
  roasts: string[];
  countries: string[];
  priceRange: [number, number] | null; // null = фильтр по цене выключен
  search: string;
  sort: SortValue;
};

export const initialFilters: FiltersState = {
  roasts: [],
  countries: [],
  priceRange: null,
  search: "",
  sort: "priciest",
};