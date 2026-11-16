import { createBrowserRouter, Navigate } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import AboutPage from "./pages/AboutPage";
import DeliveryPage from "./pages/DeliveryPage";
import ShopPage from "./pages/ShopPage";
import SubscriptionPage from "./pages/SubscriptionPage";
import ProductPage from "./pages/ProductPage";
import NotFoundPage from "./pages/NotFoundPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    children: [
      { index: true, element: <Navigate to="/shop" replace /> },
      { path: "shop", element: <ShopPage /> },
      { path: "shop/:id", element: <ProductPage /> },
      { path: "subscription", element: <SubscriptionPage /> },
      { path: "about", element: <AboutPage /> },
      { path: "delivery", element: <DeliveryPage /> },
      { path: "*", element: <NotFoundPage /> },
    ],
  },
]);