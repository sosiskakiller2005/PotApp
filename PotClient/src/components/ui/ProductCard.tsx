import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Heading,
  Text,
  Image,
  Box,
  Dialog,
  Portal,
  CloseButton,
} from "@chakra-ui/react";
import type { Product } from "../../services/Product";

export interface ProductCardProps {
  product: Product;
}

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <Card.Root
      className="w-full card"
      background="{var(--potWhite)}"
      border="none"
      w="19rem"
    >
      <Dialog.Root>
        <Dialog.Trigger asChild>
          <Image
            className="self-center"
            src={`${product.imagePath}`}
            alt="Иконка товара"
            rounded={4}
            w="full"
          />
        </Dialog.Trigger>
        <Portal>
          <Dialog.Backdrop />
          <Dialog.Positioner>
            <Dialog.Content background="{var(--softWhite)}" color="{var(--potGreen)}">
              <Dialog.Header>
                <Dialog.Title>{product.name}</Dialog.Title>
              </Dialog.Header>
              <Dialog.Body>
                <p>
                  {product.description}
                </p>
              </Dialog.Body>
              <Dialog.Footer>
                <Dialog.ActionTrigger asChild>
                  <Button variant="outline" colorPalette="fg" color="blackAlpha.500">Закрыть</Button>
                </Dialog.ActionTrigger>
                <Button background="{var(--potGreen)}" color="{var(--softWhite)}">В корзину</Button>
              </Dialog.Footer>
              <Dialog.CloseTrigger asChild>
                <CloseButton size="sm" colorPalette={"green"}/>
              </Dialog.CloseTrigger>
            </Dialog.Content>
          </Dialog.Positioner>
        </Portal>
      </Dialog.Root>
      <CardHeader>
        <Text fontSize="smaller" color="blackAlpha.500">
          {product.productType}
        </Text>
        <Heading as="h3">{product.name}</Heading>
      </CardHeader>
      <CardBody>
        <Box className="flex flex-row gap-3">
          <Text>{product.country}</Text>·<Text>{product.roastDegree}</Text>
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
