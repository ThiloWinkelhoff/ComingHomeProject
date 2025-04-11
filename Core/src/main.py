import time
# import ClientArrivedEvent
import device_monitor
# import ConfigLEDmatrix
from typing import List

if __name__ == "__main__":

    # Initial detection of devices
    new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()

    # Set to collect unique scripts from connected devices
    unique_scripts = list({script for device in connected_devices for script in device.scripts})

    # matrix_device = ConfigLEDmatrix.initialize_device(1, 0, 0, False)
    
    while True:
        print("Running...")

        # Update device status (you might want to check changes, new, or disconnected devices)
        new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()

        print("NEW DEVICES:")
        print(new_devices)
        print("DISCONNECTED DEVICES:")
        print(disconnected_devices)
        print("CONNECTED DEVICES:")
        print(connected_devices)        
        # Collect unique scripts from the connected devices
        unique_scripts = list({script for device in connected_devices for script in device.scripts})

        # Print each unique script
        for script in unique_scripts:
            # ClientArrivedEvent.handle_client_arrival(matrix_device) # Use the scripts here
            print(script)

        # Pause before the next loop
        time.sleep(10)
