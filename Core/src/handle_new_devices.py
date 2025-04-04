import json

def handle_new_devices():
    """Perform actions when a new device connects."""
    with open("connected_devices.json", "r") as f:
        devices = json.load(f)

    print("Handling new connected devices...")
    for device in devices:
        print(f"Device: {device['name']} ({device['ip']}) - {device['mac']}")

if __name__ == "__main__":
    handle_new_devices()
