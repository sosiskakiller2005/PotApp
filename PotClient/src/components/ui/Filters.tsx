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
import type { FiltersState, SortValue } from "../scripts/initialFIlters";

const sortOptions = createListCollection({
  items: [
    { label: "Сначала дорогие", value: "priciest" },
    { label: "Сначала дешевые", value: "cheapiest" },
  ],
});

const roastOptions = [
  { label: "Темная", value: "Темная" },
  { label: "Средняя", value: "Средняя" },
  { label: "Светлая", value: "Светлая" },
  { label: "Без обжарки", value: "Без обжарки" },
];

const countryOptions = [
  { label: "Бразилия", value: "Бразилия" },
  { label: "Вьетнам", value: "Вьетнам" },
  { label: "Колумбия", value: "Колумбия" },
  { label: "Индонезия", value: "Индонезия" },
  { label: "Россия", value: "Россия" },
];

const toggle = (list: string[], value: string, checked: boolean) =>
  checked ? [...list, value] : list.filter((v) => v !== value);

type Props = {
  value: FiltersState;
  onChange: (next: FiltersState) => void;
  priceBounds: [number, number];
};

//#region инпуты для конкретной цены
// type PriceInputProps = {
//   value: number;
//   min: number;
//   max: number;
//   onCommit: (n: number) => void;
// };

// function PriceInput({ value, min, max, onCommit }: PriceInputProps) {
//   const [text, setText] = useState(String(value));

//   const commit = () => {
//     const n = Number(text);
//     if (text.trim() === "" || Number.isNaN(n)) {
//       setText(String(value)); // мусор -> возвращаем прежнее значение
//       return;
//     }
//     const clamped = Math.min(Math.max(n, min), max);
//     setText(String(clamped));
//     onCommit(clamped);
//   };

//   return (
//     <Input
//       type="number"
//       value={text}
//       onChange={(e) => setText(e.target.value)}
//       onBlur={commit}
//       onKeyDown={(e) => {
//         if (e.key === "Enter") commit();
//       }}
//     />
//   );
// }
//#endregion

export default function Filters({ value, onChange, priceBounds }: Props) {
  const range = value.priceRange ?? priceBounds;
  const hasRange = priceBounds[0] < priceBounds[1];
  return (
    <Box
      className="flex flex-col gap-5"
      fontFamily="Golos Text"
      pl="5"
      w="200rem"
    >
      <Heading fontSize="20">Фильтры</Heading>
      <Box className="flex flex-col gap-1">
        <Text>Обжарка</Text>
        {roastOptions.map((o) => (
          <Checkbox.Root
            key={o.value}
            checked={value.roasts.includes(o.value)}
            onCheckedChange={(e) =>
              onChange({
                ...value,
                roasts: toggle(value.roasts, o.value, !!e.checked),
              })
            }
          >
            <Checkbox.HiddenInput />
            <Checkbox.Control />
            <Checkbox.Label>{o.label}</Checkbox.Label>
          </Checkbox.Root>
        ))}
      </Box>

      <Box className="flex flex-col gap-1">
        <Text>Страна</Text>
        {countryOptions.map((o) => (
          <Checkbox.Root
            key={o.value}
            checked={value.countries.includes(o.value)}
            onCheckedChange={(e) =>
              onChange({
                ...value,
                countries: toggle(value.countries, o.value, !!e.checked),
              })
            }
          >
            <Checkbox.HiddenInput />
            <Checkbox.Control />
            <Checkbox.Label>{o.label}</Checkbox.Label>
          </Checkbox.Root>
        ))}
      </Box>

      <Box>
        <Text>Цена</Text>
        {/* <Box className="flex flex-row gap-1 min-w-5">
          <PriceInput
            key={'min-${range[0]}'}
            value={range[0]}
            min={priceBounds[0]}
            max={range[1]}
            onCommit={(n) => onChange({...value, priceRange: [n, range[1]] })}
          ></PriceInput>
          <PriceInput
            key={'max-${range[1]}'}
            value={range[1]}
            min={range[0]}
            max={priceBounds[1]}
            onCommit={(n) => onChange({...value, priceRange: [range[0], n] })}
          ></PriceInput>
        </Box> */}
        {hasRange && (
          <Slider.Root
            min={priceBounds[0]}
            max={priceBounds[1]}
            value={range}
            onValueChange={(e) =>
              onChange({ ...value, priceRange: e.value as [number, number] })
            }
            thumbCollisionBehavior="push"
          >
            <Slider.ValueText />
            <Slider.Control>
              <Slider.Track bg="{var(--potGreenLite)}">
                <Slider.Range bg="{var(--potGreen)}" />
              </Slider.Track>
              <Slider.Thumbs />
            </Slider.Control>
          </Slider.Root>
        )}
      </Box>

      <Input
        placeholder="Поиск..."
        value={value.search}
        onChange={(e) => onChange({ ...value, search: e.target.value })}
      />
      <Select.Root
        collection={sortOptions}
        value={[value.sort]}
        onValueChange={(e) =>
          onChange({ ...value, sort: e.value[0] as SortValue })
        }
      >
        <Select.HiddenSelect />
        <Select.Label>Сортировка</Select.Label>
        <Select.Control>
          <Select.Trigger>
            <Select.ValueText />
          </Select.Trigger>
          <Select.IndicatorGroup>
            <Select.Indicator />
          </Select.IndicatorGroup>
        </Select.Control>
        <Select.Positioner>
          <Select.Content background="{var(--softWhite)}">
            {sortOptions.items.map((item) => (
              <Select.Item key={item.value} item={item}>
                {item.label}
                <Select.ItemIndicator />
              </Select.Item>
            ))}
          </Select.Content>
        </Select.Positioner>
      </Select.Root>
    </Box>
  );
}
