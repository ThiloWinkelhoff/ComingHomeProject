// getConnectedDevices.ts
import api from "./api";
import Device from "../Common/Device";
import ReducedItem from "../Common/ReducedItem";

const fetchConnectedDevices = async (): Promise<Device[]> => {
  try {
    const response = await api.get<Device[]>("/Devices");
    return response.data;
  } catch (error) {
    console.error("Failed to fetch connected devices:", error);
    throw error;
  }
};

const fetchUnmappedScripts = async (id: number): Promise<ReducedItem[]> => {
  try {
    // Correct string interpolation
    const response = await api.get<ReducedItem[]>(`/Scripts/Unmapped/${id}`);
    return response.data;
  } catch (error) {
    console.error("Failed to fetch unmapped scripts:", error); // Corrected error message
    throw error;
  }
};

// Export both functions properly
export default fetchConnectedDevices;
export { fetchUnmappedScripts };
