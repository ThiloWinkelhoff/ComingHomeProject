// getConnectedDevices.ts
import api from "./api";
import Device from "../Common/Device";
import ReducedItem from "../Common/ReducedItem";

const fetchConnectedDevices = async (): Promise<Device[]> => {
  try {
    const response = await api.get("/Devices");

    // Rehydrate each plain object into a Device instance
    const devices = response.data.map(
      (device: Device) =>
        new Device(
          device.id,
          device.name,
          device.ip,
          device.mac,
          device.active,
          device.subItems
        )
    );

    return devices;
  } catch (error) {
    console.error("Failed to fetch connected devices:", error);
    throw error;
  }
};

const fetchUnmappedScripts = async (id: number): Promise<ReducedItem[]> => {
  try {
    // Correct string interpolation
    const response = await api.get<ReducedItem[]>(
      `/mapping/Device/${id}/Unmapped`
    );
    const unmapped = response.data.map(
      (reducedItem: ReducedItem) =>
        new ReducedItem(reducedItem.id, reducedItem.name)
    );
    return unmapped;
  } catch (error) {
    console.error("Failed to fetch unmapped scripts:", error); // Corrected error message
    throw error;
  }
};

// Export both functions properly
export default fetchConnectedDevices;
export { fetchUnmappedScripts };
