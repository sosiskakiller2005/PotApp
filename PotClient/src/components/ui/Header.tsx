import {
  Box,
  Heading,
  IconButton,
  Link,
  List,
  Separator,
  Text,
} from "@chakra-ui/react";
import { Tooltip } from "@/components/ui/tooltip";
import { IoSearchOutline } from "react-icons/io5";
import { IoPersonOutline } from "react-icons/io5";
import { IoCartOutline } from "react-icons/io5";

export default function Header() {
  return (
    <Box className="flex-col" p="5">
      <Box className="flex flex-row justify-between" pb="1">
        <div className="p-10">
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
        </div>
        <List.Root className="flex flex-row gap-10" pt="2" unstyled={true}>
          <List.Item>
            <Link color="{var(--potGreen)}">Магазин</Link>
          </List.Item>
          <List.Item>
            <Link color="{var(--potGreen)}">Подписка</Link>
          </List.Item>
          <List.Item>
            <Link color="{var(--potGreen)}">О нас</Link>
          </List.Item>
          <List.Item>
            <Link color="{var(--potGreen)}">Доставка и оплата</Link>
          </List.Item>
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
