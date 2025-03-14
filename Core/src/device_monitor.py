import json
import os
import subprocess
from fetch_devices import get_connected_devices

CONNECTED_DEVICES_FILE = "connected_devices.json"

def load_known_devices():
    """Load previously known devices from file."""
    if os.path.exists(CONNECTED_DEVICES_FILE):
        with open(CONNECTED_DEVICES_FILE, "r") as f:
            return json.load(f)
    return []

def save_known_devices(devices):
    """Save the current devices to file."""
    with open(CONNECTED_DEVICES_FILE, "w") as f:
        json.dump(devices, f, indent=4)

def detect_changes():
    """Detect newly connected and disconnected devices."""
    current_devices = get_connected_devices()
    known_devices = load_known_devices()

    # Extract MAC addresses
    known_macs = {device["mac"] for device in known_devices}
    current_macs = {device["mac"] for device in current_devices}

    # Find new and disconnected devices
    new_devices = [device for device in current_devices if device["mac"] not in known_macs]
    disconnected_devices = [device for device in known_devices if device["mac"] not in current_macs]

    # Update the stored device list
    save_known_devices(current_devices)

    return new_devices, disconnected_devices

if __name__ == "__main__":
    new_devices, disconnected_devices = detect_changes()

    if new_devices or disconnected_devices:
        print("Device list changed!")
        print(f"New devices: {json.dumps(new_devices, indent=4)}")
        print(f"Disconnected devices: {json.dumps(disconnected_devices, indent=4)}")

        # Execute another script based on newly connected devices
        if new_devices:
            subprocess.run(["python", "handle_new_devices.py"], check=True)
    else:
        print("No changes detected.")
