import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Heading,
  Text,
  Image,
  Box
} from "@chakra-ui/react";
import type { Product } from "../../services/Product";

interface ProductCardProps {
  product: Product;
}

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <Card.Root  className="w-full card" background="{var(--potWhite)}" border="none" w="19rem">
        <Image className="self-center" src={`${product.imagePath}`} alt="Иконка товара" rounded={4} w="full"/>
      <CardHeader>
        <Text fontSize="smaller" color="blackAlpha.500">{product.productType}</Text>
        <Heading as="h3">{product.name}</Heading>
      </CardHeader>
      <CardBody >
        <Box className="flex flex-row gap-3">
          <Text>{product.country}</Text>
          ·
          <Text>{product.roastDegree}</Text>
        </Box>
      </CardBody>
      <CardFooter className="flex flex-row justify-between">
        <Text>{product.price} ₽</Text>
        <Button bg="{var(--potGreen)}" color="{var(--softWhite)}">
          В корзину
        </Button>
        </CardFooter>
    </Card.Root>
  );
}
