import ReducedItem from "./ReducedItem";

interface Item {
  id: number;
  name: string;
  subItems: ReducedItem[];
  active: boolean;
  getUnconnected(): Promise<ReducedItem[]>;
  removeSubItem(subItemId: number): Promise<boolean>;
  addSubItem(subItemId: number): Promise<boolean>;
  getNaming(): string;
}

export default Item;
