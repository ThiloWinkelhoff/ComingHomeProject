import time
from add_device import add_device_to_db
from check_if_connected import is_mac_connected
from fetch_scripts import fetchScripts
from fritz_box_connection import fetch_connected_devices
from fritzconnection.lib.fritzhosts import FritzHosts


def detect_changes(fh: FritzHosts):
    """Detect newly connected and disconnected devices."""
    fetched_devices = fetch_connected_devices(fh)

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
