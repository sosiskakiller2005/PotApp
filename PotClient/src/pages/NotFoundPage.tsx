import { NavLink } from "react-router-dom";

export default function NotFoundPage() {
  return (
    <section className="p-10 flex flex-col gap-3">
      <h2>Страница не найдена</h2>
      <NavLink to="/shop" className="underline underline-offset-4">
        Вернуться в магазин
      </NavLink>
    </section>
  );
}