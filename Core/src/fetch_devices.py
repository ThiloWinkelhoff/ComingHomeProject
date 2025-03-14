import json
from fritzconnection.lib.fritzhosts import FritzHosts

def get_connected_devices():
    """Fetch the list of currently connected devices."""
    with open('secrets.json') as f:
        secrets = json.load(f)

    fritz_host = secrets['fritz_host']
    username = secrets['username']
    password = secrets['password']

    fh = FritzHosts(address=fritz_host, user=username, password=password)
    
    # Get connected devices (only active ones)
    devices = [device for device in fh.get_hosts_info() if device["status"]]
    
    return devices

if __name__ == "__main__":
    devices = get_connected_devices()
    print(json.dumps(devices, indent=4))
