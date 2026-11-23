import axios from "axios";

export interface Product {
  id: number;
  name: string;
  description: string;
  productType: string;
  imagePath: string | null;
  price: number;
  weight: number;
  brand: string;
  country: string;
  roastDegree: string;
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
