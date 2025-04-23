import pyodbc

class Device:
    def __init__(self, name, ip, mac, connected=False, scripts=None):
        self.name = name
        self.ip = ip
        self.mac = mac
        self.scripts = scripts if scripts is not None else []
        self.connected = connected  
 
    def add_script(self, script):
        self.scripts.append(script)
 
    def to_dict(self):
        """Convert the Device object to a dictionary."""
        return {
            'name': self.name,
            'ip': self.ip,
            'mac': self.mac,
            'scripts': self.scripts,
            'connected': self.connected
        }
 
    def __str__(self):
        return f"Device(name={self.name}, ip={self.ip}, mac={self.mac}, scripts={self.scripts}, connected={self.connected})"
    
# Define connection parameters
server = '[::1]'  # Or the actual IP address of your SQL Server
database = 'ComingHomeProject'
username = 'ComingHomeUser'
password = 'CHU'

# Create the connection string using SQL Server ODBC driver
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

def add_device_to_db(device: Device):
    try:
        conn = pyodbc.connect(connection_string, autocommit=True)
        cursor = conn.cursor()
        cursor.execute("""
            INSERT INTO Devices (Name, Ip, Mac, Connected)
            VALUES (?, ?, ?, ?)
        """, (device.name, device.ip, device.mac, int(device.connected)))
        print("Device added successfully.")

    except Exception as e:
        print(f"Error inserting device: {e}")

    finally:
        if 'conn' in locals() and conn:
            conn.close()

            
if __name__ == "__main__":
    # Sample test device
    test_device = Device(
        name="Test Device",
        ip="192.168.0.123",
        mac="AA:BB:CC:DD:EE:FF",
        connected=True
    )

    add_device_to_db(test_device)