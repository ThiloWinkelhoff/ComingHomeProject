import { JSX } from "react";
import Item from "./Item";
import ReducedItem from "./ReducedItem";
import ScriptRender from "./ScriptRender";
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

// Device class as provided earlier
class Device implements Item {
  id: number;
  name: string;
  ip: string;
  mac: string;
  active: boolean;
  subItems: ReducedItem[];

  constructor(
    id: number,
    name: string,
    ip: string,
    mac: string,
    active: boolean,
    subItems: ReducedItem[]
  ) {
    this.id = id;
    this.name = name;
    this.ip = ip;
    this.mac = mac;
    this.active = active;
    this.subItems = subItems;
  }
  getContent(): JSX.Element {
    return <ScriptRender></ScriptRender>;
  }

  removeSubItem(): void {
    throw new Error("Method not implemented.");
  }
  addSubItem(): void {
    throw new Error("Method not implemented.");
  }
}

// Creating mock data for Device
const mockDeviceData: Device[] = [
  new Device(1, "Device One", "192.168.1.1", "00:14:22:01:23:45", true, [
    new MockReducedItem(1, "Fetch Missed Calls"),
    new MockReducedItem(2, "Light up Living Room"),
  ]),
  new Device(2, "Device Two", "192.168.1.2", "00:14:22:01:23:46", false, [
    new MockReducedItem(3, "Light up Bathroom"),
    new MockReducedItem(4, "Start Coffee Machine"),
  ]),
  new Device(3, "Device Three", "192.168.1.3", "00:14:22:01:23:47", true, [
    new MockReducedItem(5, "SubItem E"),
    new MockReducedItem(6, "SubItem F"),
  ]),
];

// Export the mock device data
export default mockDeviceData;
