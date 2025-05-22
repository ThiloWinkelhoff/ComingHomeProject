import json
import os
import time
import requests
import device_monitor
from fritzconnection.lib.fritzhosts import FritzHosts

# URL of your Flask server
FLASK_URL = 'http://localhost:5000/input'  # Replace with your server's IP if needed

if __name__ == "__main__":

    with open(os.path.join(os.getcwd(), 'secrets.json')) as f:
        secrets = json.load(f)

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
                response = requests.post(
                    FLASK_URL,
                    json=[current_time],
                    headers={'Content-Type': 'application/json'}
                )
                print(f"Current Time: {current_time}")
            else:
                print("Sending data to LED matrix display...")
                response = requests.post(
                    FLASK_URL,
                    json=unique_scripts,
                    headers={'Content-Type': 'application/json'}
                )
                print(f"Response: {response.status_code}, {response.json()}")

            time.sleep(1)

        except KeyboardInterrupt:
            print("Stopped by user (Ctrl+C)") 
            break

        except Exception as e:
            print(f"Error occurred: {e}")
            time.sleep(5)
