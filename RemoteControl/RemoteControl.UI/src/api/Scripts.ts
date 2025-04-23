import Script from "../Common/Script";
import api from "./api";

const fetchScripts = async (): Promise<Script[]> => {
  try {
    const response = await api.get<Script[]>("/scripts");
    return response.data;
  } catch (error) {
    console.error("Failed to fetch connected devices:", error);
    throw error;
  }
};

export default fetchScripts;
