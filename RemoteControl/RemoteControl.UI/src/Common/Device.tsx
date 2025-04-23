import ReducedItem from "./ReducedItem";
import { fetchUnmappedScripts } from "../api/devices";
import Item from "./Item";

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
    subItems: ReducedItem[] = [] // Default empty array if not provided
  ) {
    this.id = id;
    this.name = name;
    this.ip = ip;
    this.mac = mac;
    this.active = active;
    this.subItems = subItems;
  }

  // Marking getUnconnected as async to allow the use of await
  async getUnconnected(): Promise<ReducedItem[]> {
    try {
      // Call the fetchUnmappedScripts function and await the result
      const devices = await fetchUnmappedScripts(this.id);

      // Transform the fetched devices into ReducedItem objects (assuming this transformation is required)
      const reducedItems: ReducedItem[] = devices.map((device) => {
        // Creating ReducedItem from Device (mapping necessary fields)
        return new ReducedItemImpl(device.id, device.name);
      });

      return reducedItems;
    } catch (error) {
      console.error("Error fetching unmapped scripts:", error);
      throw error; // Rethrow the error if needed
    }
  }

  // Implement removeSubItem (remove by id for example)
  removeSubItem(subItemId: number): void {
    const index = this.subItems.findIndex((item) => item.id === subItemId);
    if (index !== -1) {
      this.subItems.splice(index, 1); // Removes the subItem from the array
    } else {
      console.error("SubItem not found for removal.");
    }
  }

  // Implement addSubItem (add a ReducedItem)
  addSubItem(newSubItem: ReducedItem): void {
    this.subItems.push(newSubItem); // Adds the new subItem to the array
  }
}

// Implementation of ReducedItem
class ReducedItemImpl implements ReducedItem {
  id: number;
  name: string;

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }

  getContent(): string {
    // Provide a meaningful content summary for ReducedItem
    return `Item ID: ${this.id}, Name: ${this.name}`;
  }
}

export default Device;
