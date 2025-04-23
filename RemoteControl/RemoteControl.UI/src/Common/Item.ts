import ReducedItem from "./ReducedItem";

interface Item {
  id: number;
  name: string;
  subItems: ReducedItem[];
  active: boolean;
  getUnconnected(): Promise<ReducedItem[]>;
  removeSubItem(): Promise<boolean>;
  addSubItem(): Promise<boolean>;
}

export default Item;
