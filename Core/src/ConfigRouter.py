import json
from fritzconnection.lib.fritzhosts import FritzHosts

# Load secrets from the JSON file
with open('secrets.json') as f:
    secrets = json.load(f)

fritz_host = secrets['fritz_host']
username = secrets['username']
password = secrets['password']

fh = FritzHosts(address=fritz_host, user=username, password=password)

connected_devices = fh.get_hosts_info()

for device in connected_devices:
    print(f"Name: {device['name']}, IP: {device['ip']}, MAC: {device['mac']}, Status: {device['status']}")
