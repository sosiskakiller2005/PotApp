import { createListCollection, Input, Select } from "@chakra-ui/react";

const sortOptions = createListCollection({
  items: [
    { label: "Сначала новые", value: "newest" },
    { label: "Сначала старые", value: "oldest" },
  ],
});

export default function Filters() {
  return (
    <div className="flex flex-col gap-5">
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
    </div>
  );
}
