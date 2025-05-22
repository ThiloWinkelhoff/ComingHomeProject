import json
import os
import time
from device import Device

from fritzconnection.lib.fritzhosts import FritzHosts

def fetch_connected_devices(fh: FritzHosts):

    """Fetch the list of currently connected devices with timing logs."""
    devices_info = fh.get_hosts_info()

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
    return devices

def fetch_unconnected_devices(fh: FritzHosts):

    """Fetch the list of currently connected devices with timing logs."""
    devices_info = fh.get_hosts_info()

    devices = []
    for device_info in devices_info:
        if not device_info["status"]:
            device = Device(
                name=device_info["name"],
                ip=device_info["ip"],
                mac=device_info["mac"],
                connected=device_info["status"]
            )
            devices.append(device)
    return devices

if __name__ == "__main__":
    devices = fetch_connected_devices()
    print(json.dumps([device.__dict__ for device in devices], indent=4))


