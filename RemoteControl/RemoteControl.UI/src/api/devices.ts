const getConnectedDevices = async (): Promise<string> => {
  try {
    const response = await fetch("https://your-api-endpoint.com/devices", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        // Add any auth headers if needed
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Failed to fetch connected devices:", error);
    throw error;
  }
};

export default getConnectedDevices;
