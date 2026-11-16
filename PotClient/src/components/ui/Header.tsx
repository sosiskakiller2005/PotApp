import {
  Box,
  Heading,
  IconButton,
  List,
  Separator,
  Text,
} from "@chakra-ui/react";
import { Tooltip } from "@/components/ui/tooltip";
import { IoSearchOutline } from "react-icons/io5";
import { IoPersonOutline } from "react-icons/io5";
import { IoCartOutline } from "react-icons/io5";
import { NavLink } from "react-router-dom";

const navLinks = [
  { to: "/shop", label: "Магазин" },
  { to: "/subscription", label: "Подписка" },
  { to: "/about", label: "О нас" },
  { to: "/delivery", label: "Доставка и оплата" },
];

export default function Header() {
  return (
    <Box className="flex-col" p="5">
      <Box className="flex flex-row justify-between" pb="1">
        <NavLink to="/" className="p-10 block">
          <Heading
            fontFamily="Cormorant Garamond"
            fontWeight="500"
            fontSize="5xl"
          >
            Чашка и точка
          </Heading>
          <Heading fontFamily="Golos Text" fontWeight="400" pl="2">
            Кофе и немного чая
          </Heading>
        </NavLink>
        <List.Root className="flex flex-row gap-10" pt="2" unstyled={true}>
           {navLinks.map(({ to, label }) => (
            <List.Item key={to}>
              <NavLink
                to={to}
                style={{ color: "var(--potGreen)" }}
                className={({ isActive }) =>
                  isActive
                    ? "font-bold underline underline-offset-4"
                    : "hover:underline underline-offset-4"
                }
              >
                {label}
              </NavLink>
            </List.Item>
          ))}
        </List.Root>
        <ul className="flex flex-row g-5 justify-evenly">
          <li>
            <Tooltip content="Поиск товаров">
              <IconButton
                aria-label="Поиск товаров"
                variant="ghost"
                color="{var(--potGreen)}"
              >
                <IoSearchOutline color="{var(--potGreen)}" />
              </IconButton>
            </Tooltip>
          </li>
          <li>
            <Tooltip content="Профиль">
              <IconButton
                aria-label="Профиль"
                variant="ghost"
                color="{var(--potGreen)}"
              >
                <IoPersonOutline color="{var(--potGreen)}" />
              </IconButton>
            </Tooltip>
          </li>
          <li>
            <Tooltip content="Корзина">
              <IconButton
                aria-label="Корзина"
                variant="ghost"
                color="{var(--potGreen)}"
              >
                <IoCartOutline color="{var(--potGreen)}" />
              </IconButton>
            </Tooltip>
          </li>
          <li>
            <Text p="1.5">Корзина · 2</Text>
          </li>
        </ul>
      </Box>
      <Separator borderColor="blackAlpha.300" />
    </Box>
  );
}
