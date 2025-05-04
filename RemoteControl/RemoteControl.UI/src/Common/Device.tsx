import ReducedItem from "./ReducedItem";
import { fetchUnmappedScripts } from "../api/devices";
import Item from "./Item";
import { AddMapping, RemoveMapping } from "../api/mapping";

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
  getNaming(): string {
    return this.name + ":" + this.ip;
  }

  // Marking getUnconnected as async to allow the use of await
  async getUnconnected(): Promise<ReducedItem[]> {
    try {
      // Call the fetchUnmappedScripts function and await the result
      const devices = await fetchUnmappedScripts(this.id);

      // Transform the fetched devices into ReducedItem objects (assuming this transformation is required)
      const reducedItems: ReducedItem[] = devices.map((device) => {
        // Creating ReducedItem from Device (mapping necessary fields)
        return new ReducedItem(device.id, device.name);
      });

      return reducedItems;
    } catch (error) {
      console.error("Error fetching unmapped scripts:", error);
      throw error; // Rethrow the error if needed
    }
  }

  async removeSubItem(subItemId: number): Promise<boolean> {
    try {
      return await RemoveMapping(this.id, subItemId);
    } catch (error) {
      console.error("Error removing sub item:", error);
      return false;
    }
  }

  async addSubItem(subItemId: number): Promise<boolean> {
    try {
      return await AddMapping(this.id, subItemId);
    } catch (error) {
      console.error("Error adding sub item:", error);
      return false;
    }
  }
}

export default Device;
