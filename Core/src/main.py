import json
import os
import time
import device_monitor
from fritzconnection.lib.fritzhosts import FritzHosts

if __name__ == "__main__":
    total_start = time.time()

    # Step 1: Load secrets
    start = time.time()
    with open(os.getcwd() + '/secrets.json') as f:
        secrets = json.load(f)
    print(os.getcwd() + '/secrets.json')
    # Step 2: Initialize FritzHosts
    start = time.time()
    fritz_host = secrets['fritz_host']
    username = secrets['username']
    password = secrets['password']
    fh = FritzHosts(address=fritz_host, user=username, password=password)

    while True:
        print("Running...")

        try:
            unique_scripts = device_monitor.detect_changes(fh)

            if not unique_scripts:
                current_time = time.strftime("%H:%M:%S")
                print(f"Current Time: {current_time}")
            else:
                for script in unique_scripts:
                    print(script)

            time.sleep(1)

        except KeyboardInterrupt:
            print("Stopped by user (Ctrl+C)") 
            break
