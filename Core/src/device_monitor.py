import json
import os
from FritzBoxConnection import fetch_connected_devices
import subprocess
import device_test
from database_check_if_connected import is_mac_connected
from database_add_device import add_device_to_db
from database_fetch_scripts import fetchScripts

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
 
 
def detect_changes():
    """Detect newly connected and disconnected devices."""
    # fetched_devices = fetch_connected_devices()
    fetched_devices = device_test.get_example_devices()

    scripts = []
    for device in fetched_devices:
        fetched_scripts = None
        if(is_mac_connected(device.mac)):
            # Fetch scripts associated with the device using the device's MAC address
            fetched_scripts = fetchScripts(device.mac)
        else:
            add_device_to_db(device)
    
        # Check if scripts were fetched successfully
        if fetched_scripts is not None:
            # Append the fetched scripts to the scripts list
            scripts.extend(fetched_scripts)

    unique_scripts = list(set(scripts))
 
    return unique_scripts
 
if __name__ == "__main__":
    unique_scripts = detect_changes()

    if unique_scripts:
        print("Unique scripts for connected devices:")
        for script in unique_scripts:
            print(f"- {script}")
    else:
        print("No scripts found for currently connected devices.")
