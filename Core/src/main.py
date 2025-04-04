import time
import ClientArrivedEvent
import ConfigRouter
from typing import List

class Device:
    IP: str
    Name: str
    scripts: List[str]

if __name__ == "__main__":
    known_devices = ""
    fh = ConfigRouter.configure_Router()
    session_devices = ConfigRouter.get_session_devices(fh)

    while True:
        connectedDevices = ConfigRouter.get_session_devices(fh)
        for connectedDevice in connectedDevices:
            if not(session_devices.__contains__(connectedDevice)):
                if known_devices.__contains__(connectedDevice):
                    ClientArrivedEvent.handle_client_arrival()
                    print("invoke ClientArrivedEvent")
                session_devices.__add__(connectedDevice)
        time.sleep(10000)