import json
import os
# from FritzBoxConnection import fetch_connected_devices
import subprocess
import device_test

KnownDevices = os.getcwd() + "/devices.json"
 
class Device:
    def __init__(self, name, ip, mac, connected=False, scripts=None):
        self.name = name
        self.ip = ip
        self.mac = mac
        self.scripts = scripts if scripts is not None else []
        self.connected = connected  
 
    def add_script(self, script):
        self.scripts.append(script)
 
    def to_dict(self):
        """Convert the Device object to a dictionary."""
        return {
            'name': self.name,
            'ip': self.ip,
            'mac': self.mac,
            'scripts': self.scripts,
            'connected': self.connected
        }
 
    def __str__(self):
        return f"Device(name={self.name}, ip={self.ip}, mac={self.mac}, scripts={self.scripts}, connected={self.connected})"
 
 
def load_known_devices():
    """Load the list of previously known devices."""
    try:
        with open(KnownDevices, "r", encoding="utf-8") as f:
            content = f.read().strip()
            if not content:
                return []  # Return empty list if file is empty
            return json.loads(content)
    except (FileNotFoundError, json.JSONDecodeError):
        # Create the file if it doesn't exist or has invalid JSON
        with open(KnownDevices, "w", encoding="utf-8") as f:
            json.dump([], f)
        return []
 
 
def save_known_devices(devices):
    """Save the current devices to file."""
    devices_dict = [device.to_dict() for device in devices]
    with open(KnownDevices, 'w', encoding="utf-8") as json_file:  # Use KnownDevices instead of hardcoded path
        json.dump(devices_dict, json_file, indent=4)
 
 
def detect_changes():
    """Detect newly connected and disconnected devices."""
    # fetched_devices = fetch_connected_devices()
    fetched_devices = device_test.get_example_devices()
    known_devices = load_known_devices()  # Load known devices from the file
    fetched_devices = {device.mac: device for device in fetched_devices}

    # Create a set of MAC addresses for easy comparison
    known_devices = {device['mac']: Device(device['name'], device['ip'], device['mac'], device['connected'], device.get('scripts', [])) for device in known_devices}
 
    # Create a dictionary of current devices by MAC address for easy lookup
    # fetched_devices = {device['mac']: Device(device['name'], device['ip'], device['mac']) for device in fetched_devices}
 
    # Track newly connected, disconnected, and reconnected devices
    new_devices = []
    disconnected_devices = []
    connected_devices = []
    devices = []
 
    for known_device in known_devices.values():
        mac = known_device.mac
        if mac in fetched_devices and not known_device.connected:
            # Update device to connected, but keep scripts and other info
            known_device.connected = True
            connected_devices.append(known_device)  # Add to connected devices list
            devices.append(known_device)
        elif mac not in fetched_devices and known_device.connected:
            # Mark the device as disconnected
            known_device.connected = False
            disconnected_devices.append(known_device)
            devices.append(known_device)
        else:
            devices.append(known_device)
 
    # Add newly connected devices to the list
    for mac, device in fetched_devices.items():
        if mac not in known_devices:
            device.connected = True  # Mark as connected
            new_devices.append(device)
            devices.append(device)
 
    save_known_devices(devices)
 
    return new_devices, disconnected_devices, connected_devices
 
 
if __name__ == "__main__":
    new_devices, disconnected_devices, connected_devices = detect_changes()
 
    if new_devices or disconnected_devices or connected_devices:
        print("Device list changed!")
 
        if new_devices:
            print(f"New devices: {len(new_devices)}")
            for device in new_devices:
                print(f"  - {device}")
 
        if disconnected_devices:
            print(f"Disconnected devices: {len(disconnected_devices)}")
            for device in disconnected_devices:
                print(f"  - {device}")
 
        if connected_devices:
            print(f"Reconnected devices: {len(connected_devices)}")
            for device in connected_devices:
                print(f"  - {device}")
 
        # Check and execute scripts for newly connected devices
        for device in new_devices + connected_devices:
            if device.scripts:  # Check if the device has scripts
                for script in device.scripts:  # Iterate through all scripts
                    print(f"Executing script: {script} for device: {device.name}")
                    # Uncomment to actually run the scripts
                    # try:
                    #     subprocess.run(script, shell=True, check=True)
                    # except subprocess.CalledProcessError as e:
                    #     print(f"Error executing script {script} for {device.name}: {e}")
    else:
        print("No changes detected.")