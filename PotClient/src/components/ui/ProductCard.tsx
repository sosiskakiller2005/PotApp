import {
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Heading,
  Text,
} from "@chakra-ui/react";

export default function ProductCard() {
  return (
    <Card.Root variant="outline" className="w-full">
      <CardHeader>
        <Heading>Товар</Heading>
      </CardHeader>
      <CardBody>
        <Text>Описание товара</Text>
      </CardBody>
      <CardFooter></CardFooter>
    </Card.Root>
  );
}
