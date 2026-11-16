import {
  Box,
  Heading,
  List,
  Text,
  Icon,
  Link,
  Separator,
} from "@chakra-ui/react";
import { NavLink } from "react-router-dom";
import { FaGithub } from "react-icons/fa";
import { LuExternalLink } from "react-icons/lu";

const navLinks1 = [
  { to: "/shop", label: "Магазин" },
  { to: "/subscription", label: "Подписка" },
];

const navLinks2 = [
  { to: "/about", label: "О нас" },
  { to: "/delivery", label: "Доставка и оплата" },
];

export default function Footer() {
  return (
    <Box
      className="flex flex-col"
      pt="5"
      pl="5"
      pr="5"
      background="{var(--potGreenLite)}"
    >
      <Box className="flex flex-row justify-between" pb="2">
        <NavLink to="/" className="p-10 block self-center">
          <Heading
            fontFamily="Cormorant Garamond"
            fontWeight="500"
            fontSize="5xl"
            color="{var(--potGreen)}"
          >
            Чашка и точка
          </Heading>
          <Heading
            fontFamily="Golos Text"
            fontWeight="400"
            pl="2"
            color="{var(--potGreen)}"
          >
            Кофе и немного чая
          </Heading>
        </NavLink>
        <Box className="flex flex-row" gap="5">
          <List.Root unstyled={true}>
            {navLinks1.map(({ to, label }) => (
              <List.Item p="2" key={to}>
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
          <List.Root unstyled={true}>
            {navLinks2.map(({ to, label }) => (
              <List.Item p="2" key={to}>
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
        </Box>
        <Box>
          <Text color="{var(--potGreen)}">
            <Icon>
              <FaGithub />
            </Icon>{" "}
            Страница проекта:
          </Text>
          <Link
            color="{var(--potGreen)}"
            href="https://github.com/sosiskakiller2005"
          >
            https://github.com/sosiskakiller2005
            <LuExternalLink />
          </Link>
        </Box>
      </Box>
      <Separator borderColor="blackAlpha.300" />
      <Box className="flex flex-row justify-evenly text-gray-400" fontSize="sm">
        <Text>© Чашка и точка, 2026</Text>
        <Text>Политика конфиденциальности</Text>
        <Text>Публичная оферта</Text>
      </Box>
    </Box>
  );
}
