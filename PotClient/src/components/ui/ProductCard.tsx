import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Heading,
  Text,
  Image
} from "@chakra-ui/react";
import type { Product } from "../../services/Product";

interface ProductCardProps {
  product: Product;
}

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <Card.Root variant="outline" className="w-full" >
      <CardHeader>
        <Heading>{product.name}</Heading>
      </CardHeader>
      <CardBody>
        <Card.Title>{product.description}</Card.Title>
        <Image src={`${product.imagePath}`} alt="Иконка товара" aspectRatio={3/4} rounded="md"/>
        <Text>Тип: {product.productTypeName}</Text>
        <Text>Бренд: {product.brandName}</Text>
        <Text>Страна: {product.countryName}</Text>
        <Text>Обжарка: {product.roastDegreeName}</Text>
        <Text>{product.weight} грамм</Text>
      </CardBody>
      <CardFooter>
        <Button>
        </Button>
        </CardFooter>
    </Card.Root>
  );
}
