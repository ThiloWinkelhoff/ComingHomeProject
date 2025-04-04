import json
from fritzconnection.lib.fritzhosts import FritzHosts

def configure_Router():
    with open('secrets.json') as f:
        secrets = json.load(f)
    fritz_host = secrets['fritz_host']
    username = secrets['username']
    password = secrets['password']
    return FritzHosts(address=fritz_host, user=username, password=password)

def get_session_devices(fh: FritzHosts):
    return fh.get_active_hosts()
