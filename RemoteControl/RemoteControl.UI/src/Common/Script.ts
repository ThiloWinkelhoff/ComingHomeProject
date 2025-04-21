import { JSX } from "react";
import Item from "./Item";
import ReducedItem from "./ReducedItem";

// Mock ReducedItem implementation
class MockReducedItem implements ReducedItem {
  id: number;
  name: string;

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }

  // Mock implementation of getContent method
  getContent(): string {
    return `Content for ${this.name}`;
  }
}

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

// Creating mock data
const mockData: Script[] = [
  new Script(1, "Script One", true, [
    new MockReducedItem(1, "SubItem A"),
    new MockReducedItem(2, "SubItem B"),
  ]),
  new Script(2, "Script Two", false, [
    new MockReducedItem(3, "SubItem C"),
    new MockReducedItem(4, "SubItem D"),
  ]),
  new Script(3, "Script Three", true, [
    new MockReducedItem(5, "SubItem E"),
    new MockReducedItem(6, "SubItem F"),
  ]),
];

// Export the mock data array
export default mockData;
