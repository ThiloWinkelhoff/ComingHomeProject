import time
import ClientArrivedEvent
import device_monitor
import ConfigLEDmatrix
from typing import List

class Device:
    IP: str
    Name: str
    scripts: List[str]

if __name__ == "__main__":

    new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()

    unique_scripts = list({script for device in connected_devices for script in device.Scripts})

    matrix_device = ConfigLEDmatrix.initialize_device(1,0,0,False)
    
    while True:
        
        new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()

        unique_scripts = list({script for device in connected_devices for script in device.Scripts})
        
        for script in unique_scripts:
                    ClientArrivedEvent.handle_client_arrival(matrix_device) #hier müssen die scripte von dem device ausgegeben werden
                    print("invoke ClientArrivedEvent")
        time.sleep(10000)