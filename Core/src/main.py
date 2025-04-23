import time
import device_monitor
#import ConfigLEDmatrix
#import led_matrix_display as matrix
from typing import List

if __name__ == "__main__":
    while True:
        print("Running...")

        # Update device status (you might want to check changes, new, or disconnected devices)
        try:
            unique_scripts = device_monitor.detect_changes()
       

            if not unique_scripts:
                    current_time = time.strftime("%H:%M:%S")

                    print(f"Current Time: {current_time}")
                    #matrix.display_text(matrix_device, current_time)
            else:
                for script in unique_scripts:
                    print(script)
                    time.sleep(5)
                    # matrix.display_text(matrix_device, script)

            # Pause before the next loop
            time.sleep(1)
        except KeyboardInterrupt:
            print("Stopped by user (Ctrl+C)") 
            break
