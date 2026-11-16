import {
  Box,
  createListCollection,
  Heading,
  Input,
  Select,
  Text,
  Checkbox,
  Slider,
} from "@chakra-ui/react";

const sortOptions = createListCollection({
  items: [
    { label: "Сначала новые", value: "newest" },
    { label: "Сначала старые", value: "oldest" },
  ],
});

export default function Filters() {
  return (
    <Box
      className="flex flex-col gap-5"
      fontFamily="Golos Text"
      pl="5"
      pr="5"
      minWidth={200}
    >
      <Heading fontSize="20">Фильтры</Heading>
      <Box>
        <Text>Обжарка</Text>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Высокая</Checkbox.Label>
        </Checkbox.Root>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Средняя</Checkbox.Label>
        </Checkbox.Root>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Низкая</Checkbox.Label>
        </Checkbox.Root>
      </Box>
      <Box>
        <Text>Страна</Text>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Бразилия</Checkbox.Label>
        </Checkbox.Root>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Колумбия</Checkbox.Label>
        </Checkbox.Root>
        <Checkbox.Root>
          <Checkbox.HiddenInput />
          <Checkbox.Control />
          <Checkbox.Label>Росия</Checkbox.Label>
        </Checkbox.Root>
      </Box>
      <Box>
        <Text>Цена</Text>
        <Box className="flex flex-row gap-1 min-w-5">
          <Input></Input>
          <Input></Input>
        </Box>
        <Slider.Root defaultValue={[30, 90]} thumbCollisionBehavior="push">

          <Slider.Control>
            <Slider.Track bg="{var(--potGreenLite)}">
              <Slider.Range bg="{var(--potGreen)}" />
            </Slider.Track>
            <Slider.Thumbs />
          </Slider.Control>
        </Slider.Root>
      </Box>

      <Input placeholder="Поиск..." />
      <Select.Root collection={sortOptions}>
        <Select.Label>Сортировка</Select.Label>
        <Select.Control>
          <Select.Trigger>
            <Select.ValueText placeholder="Выберите вид сортировки" />
          </Select.Trigger>
          <Select.IndicatorGroup>
            <Select.Indicator />
          </Select.IndicatorGroup>
        </Select.Control>
        {sortOptions.items.map((item) => (
          <Select.Item key={item.value} item={item}>
            {item.label}
            <Select.ItemIndicator />
          </Select.Item>
        ))}
      </Select.Root>
    </Box>
  );
}
