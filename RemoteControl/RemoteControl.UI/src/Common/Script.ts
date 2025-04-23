import { JSX } from "react";
import Item from "./Item";
import ReducedItem from "./ReducedItem";

// Script class as provided earlier
class Script implements Item {
  id: number;
  name: string;
  subItems: ReducedItem[];
  active: boolean;

  constructor(
    id: number,
    name: string,
    active: boolean,
    subItems: ReducedItem[]
  ) {
    this.id = id;
    this.name = name;
    this.active = active;
    this.subItems = subItems;
  }
  getContent(): JSX.Element {
    throw new Error("Method not implemented.");
  }

  removeSubItem(): void {
    throw new Error("Method not implemented.");
  }

  addSubItem(): void {
    throw new Error("Method not implemented.");
  }
}

// Export the mock data array
export default Script;
