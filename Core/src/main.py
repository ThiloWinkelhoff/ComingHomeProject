from flask import Flask, request, jsonify
import time
import threading
# import led_matrix_display as matrix
# import config_led_matrix as device

app = Flask(__name__)

received_data = []  # Shared global data to hold received input

def run_display_loop():
    # device.initialize_device()
    # matrix.display_text(device, "Running...") 
    while True:
        if received_data:
            for item in received_data:
                # matrix.display_text(device, item)
                print(item)
            received_data.clear()  # Clear after displaying once
        time.sleep(1)

@app.route('/input', methods=['POST'])
def receive_input():

    global received_data
    if request.is_json:
        content = request.get_json()
        if isinstance(content, list) and all(isinstance(i, str) for i in content):
            received_data = content
            return jsonify({"status": "received", "data": received_data}), 200
        else:
            return jsonify({"error": "Invalid input. Expected a list of strings."}), 400
    else:
        return jsonify({"error": "Invalid content type. Expected JSON."}), 400

if __name__ == "__main__":
    # Start the display loop in a separate thread
    display_thread = threading.Thread(target=run_display_loop, daemon=True)
    display_thread.start()

    # Start Flask server
    app.run(port=5000)
