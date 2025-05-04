import json
import os
import time
from device import Device

from fritzconnection.lib.fritzhosts import FritzHosts

def fetch_connected_devices(fh: FritzHosts):

    """Fetch the list of currently connected devices with timing logs."""
    start = time.time()
    devices_info = fh.get_hosts_info()
    print(f"get_hosts_info() took {time.time() - start:.2f} seconds")
    start = time.time()

    devices = []
    for device_info in devices_info:
        if device_info["status"]:
            device = Device(
                name=device_info["name"],
                ip=device_info["ip"],
                mac=device_info["mac"],
                connected=device_info["status"]
            )
            devices.append(device)

    print(f"get_hosts_info() took {time.time() - start:.2f} seconds")

    return devices

if __name__ == "__main__":
    devices = fetch_connected_devices()
    print(json.dumps([device.__dict__ for device in devices], indent=4))
