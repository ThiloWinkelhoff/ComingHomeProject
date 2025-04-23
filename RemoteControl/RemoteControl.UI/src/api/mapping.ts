// getConnectedDevices.ts
import api from "./api";

// Remove mapping between a device and a script
const RemoveMapping = async (
  deviceId: number,
  scriptId: number
): Promise<boolean> => {
  try {
    const response = await api.delete<boolean>(`/mapping/remove`, {
      data: { deviceId, scriptId },
    });
    return response.data;
  } catch (error) {
    console.error("Failed to remove mapping:", error);
    throw error;
  }
};

// Add mapping between a device and a script
const AddMapping = async (
  deviceId: number,
  scriptId: number
): Promise<boolean> => {
  try {
    const response = await api.post<boolean>(`/mapping/add`, {
      deviceId,
      scriptId,
    });
    return response.data;
  } catch (error) {
    console.error("Failed to add mapping:", error);
    throw error;
  }
};

// Export both functions together
export { AddMapping, RemoveMapping };
