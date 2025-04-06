import json
import os
from fritzconnection.lib.fritzhosts import FritzHosts

def fetch_connected_devices():
    """Fetch the list of currently connected devices."""
    with open(os.getcwd()+'/secrets.json') as f:
        secrets = json.load(f)

    fritz_host = secrets['fritz_host']
    username = secrets['username']
    password = secrets['password']

    fh = FritzHosts(address=fritz_host, user=username, password=password)
    
    # Get connected devices (only active ones)
    devices = [device for device in fh.get_hosts_info() if device["status"]]
    
    return devices

if __name__ == "__main__":
    devices = fetch_connected_devices()
    print(json.dumps(devices, indent=4))
