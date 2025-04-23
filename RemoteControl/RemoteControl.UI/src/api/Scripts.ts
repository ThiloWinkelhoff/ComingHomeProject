import ReducedItem from "../Common/ReducedItem";
import Script from "../Common/Script";
import api from "./api";

const fetchScripts = async (): Promise<Script[]> => {
  try {
    const response = await api.get("/scripts");

    // Convert plain objects into Script instances
    const scripts = response.data.map(
      (script: Script) =>
        new Script(script.id, script.name, script.active, script.subItems)
    );

    return scripts;
  } catch (error) {
    console.error("Failed to fetch scripts:", error);
    throw error;
  }
};

const fetchUnmappedDevices = async (id: number): Promise<ReducedItem[]> => {
  try {
    // Correct string interpolation
    const response = await api.get<ReducedItem[]>(
      `/mapping/Script/${id}/Unmapped`
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
export default fetchScripts;
export { fetchUnmappedDevices };
