from flask import Flask, request, jsonify
import time
import threading

app = Flask(__name__)

received_data = []  # Shared global data to hold received input

def run_display_loop():
    while True:
        if received_data:
            print("Received input:")
            for item in received_data:
                print(item)
            received_data.clear()  # Clear after displaying once
        else:
            current_time = time.strftime("%H:%M:%S")
            print(f"Current Time: {current_time}")
        
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
