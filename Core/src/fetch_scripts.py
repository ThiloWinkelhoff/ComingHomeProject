import pyodbc

# Define connection parameters
server = '[::1]'  # Or the actual IP address of your SQL Server
database = 'ComingHomeProject'
username = 'ComingHomeUser'
password = 'CHU'

# Create the connection string using SQL Server ODBC driver
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'


def fetchScripts(mac):
    # Establish the connection
    try:
        conn = pyodbc.connect(connection_string, autocommit=True)

        cursor = conn.cursor()

        # Step 1: Check if the device with given MAC is connected (use 'Id' instead of 'DeviceId' for Devices table)
        cursor.execute("SELECT CONNECTED, Id FROM Devices WHERE MAC = ?", (mac,))
        rows = cursor.fetchall()

        # List to store script names
        script_names = []

        # Step 2: If device is not connected, get the associated scripts
        for row in rows:
            if row[0] == 0:  # Device is not connected (assuming 0 = not connected)
                cursor.execute("""
                    SELECT DISTINCT S.ScriptName
                    FROM Scripts S
                    JOIN DeviceScriptsMappings DSM ON S.Id = DSM.ScriptId
                    WHERE DSM.DeviceId = ?
                """, (row[1],))  # Use 'row[1]' as the Device Id, not DeviceId column

                # Fetch scripts and add to list
                fetched_scripts = cursor.fetchall()
                if fetched_scripts:
                    for script in fetched_scripts:
                        script_names.append(script[0])  # Add only the script name

                # Step 3: Update device status to connected
                cursor.execute('UPDATE Devices SET Connected = 1 WHERE Id = ?', (row[1],))  # Use 'Id' instead of 'DeviceId'

        # Return the script names associated with the device
        if script_names:
            return script_names
        return None


    except Exception as e:
        return []  # Return an empty list in case of error

    finally:
        if conn:
            conn.close()
        else:
            print("Connection not established.")

if __name__ == "__main__":
    # List of MAC addresses to check
    macs = ["AA:BB:CC:DD:EE:01", "AA:BB:CC:DD:EE:02"]
    all_scripts = []
    for mac in macs:
        fetched = fetchScripts(mac)
        if fetched:
            all_scripts.extend(fetched)  # Add the scripts for each MAC address

    # Remove duplicates and print the script names
    unique_scripts = list(set(all_scripts))
    print(unique_scripts)