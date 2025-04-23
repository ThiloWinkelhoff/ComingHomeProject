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

def is_mac_connected(mac):
    try:
        conn = pyodbc.connect(connection_string, autocommit=True)
        cursor = conn.cursor()

        # Check if a device with the given MAC address exists
        cursor.execute("SELECT 1 FROM Devices WHERE MAC = ?", (mac,))
        row = cursor.fetchone()

        return row is not None  # True if exists, False if not

    except Exception as e:
        print(f"Error: {e}")
        return False

    finally:
        if 'conn' in locals() and conn:
            conn.close()

# Example usage
if __name__ == "__main__":
    mac_to_check = "00:1A:2B:3C:4D:5E"  # replace with the actual MAC
    if is_mac_connected(mac_to_check):
        print("MAC is connected.")
    else:
        print("MAC is not connected.")
