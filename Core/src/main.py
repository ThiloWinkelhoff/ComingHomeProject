import time
import device_monitor
#import ConfigLEDmatrix
#import led_matrix_display as matrix
from typing import List

if __name__ == "__main__":

    # Initial detection of devices
    new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()

    # Set to collect unique scripts from connected devices
    unique_scripts = list({script for device in connected_devices for script in device.scripts})

    #matrix_device = ConfigLEDmatrix.initialize_device(1, 0, 0, False)
    
    while True:
        print("Running...")

        # Update device status (you might want to check changes, new, or disconnected devices)
        try:
            new_devices, disconnected_devices, connected_devices = device_monitor.detect_changes()
        except KeyboardInterrupt:
            print("Stopped by user (Ctrl+C)") 
            break
        # Collect unique scripts from the connected devices
        unique_scripts = list({script for device in connected_devices for script in device.scripts})

        if not unique_scripts:
                current_time = time.strftime("%H:%M:%S")

                print(f"Current Time: {current_time}")
                #matrix.display_text(matrix_device, current_time)
        else:
            for script in unique_scripts:
                print(script)
                # matrix.display_text(matrix_device, script)

        # Pause before the next loop
        time.sleep(1)
