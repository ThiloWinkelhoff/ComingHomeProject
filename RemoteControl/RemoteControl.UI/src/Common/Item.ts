import { JSX } from "react";
import ReducedItem from "./ReducedItem";

interface Item {
  id: number;
  name: string;
  subItems: ReducedItem[];
  active: boolean;
  getContent(): JSX.Element;
  removeSubItem(): void;
  addSubItem(): void;
}

export default Item;
