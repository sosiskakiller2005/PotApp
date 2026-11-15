import axios from "axios";

export interface Product {
  id: number;
  name: string;
  description: string;
  productTypeName: string;
  brandName: string;
  countryName: string;
  roastDegreeName: string;
  imagePath: string | null;
  price: number;
  weight: number;
}

interface GetProductsResponse {
  products: Product[];
}

export const fetchProducts = async (): Promise<Product[]> => {
  try {
    const response = await axios.get<GetProductsResponse>(
      "https://localhost:7205/api/products",
    );

    return response.data.products;
  } catch (error) {
    console.error("Error fetching products:", error);
    throw error;
  }
};
