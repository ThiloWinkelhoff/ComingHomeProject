import Item from "./Item";
import ReducedItem from "./ReducedItem";
import { fetchUnmappedDevices } from "../api/Scripts";
import { AddMapping, RemoveMapping } from "../api/mapping";

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
  getNaming(): string {
    return this.name;
  }

  // Marking getUnconnected as async to allow the use of await
  async getUnconnected(): Promise<ReducedItem[]> {
    try {
      // Call the fetchUnmappedScripts function and await the result
      const devices = await fetchUnmappedDevices(this.id);

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
      return await RemoveMapping(subItemId, this.id);
    } catch (error) {
      console.error("Error removing sub item:", error);
      return false;
    }
  }

  async addSubItem(subItemId: number): Promise<boolean> {
    try {
      return await AddMapping(subItemId, this.id);
    } catch (error) {
      console.error("Error adding sub item:", error);
      return false;
    }
  }
}

// Export the mock data array
export default Script;
