import pyodbc

# Define connection parameters
server = '[::1]'
database = 'ComingHomeDatabase'
username = 'ComingHomeUser'
password = 'ComingHomeUser'

# Create the connection string
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'


def fetchScripts(mac):
    conn = None
    try:
        conn = pyodbc.connect(connection_string, autocommit=True)
        cursor = conn.cursor()

        # Step 1: Get DeviceId from MAC
        cursor.execute("SELECT Id FROM Devices WHERE Mac = ?", (mac,))
        device_row = cursor.fetchone()
        if not device_row:
            return []  # No device found for the MAC
        device_id = device_row[0]

        # Step 2: Get ScriptIds from mapping table
        cursor.execute("SELECT ScriptId FROM DeviceScriptsMappings WHERE DeviceId = ?", (device_id,))
        script_id_rows = cursor.fetchall()
        if not script_id_rows:
            return []  # No scripts mapped

        script_ids = [row[0] for row in script_id_rows]

        # Step 3: Get script names from Scripts table using IN clause
        placeholders = ', '.join('?' for _ in script_ids)
        query = f"SELECT ScriptName FROM Scripts WHERE Id IN ({placeholders})"
        cursor.execute(query, script_ids)

        fetched_scripts = cursor.fetchall()
        script_names = [row[0] for row in fetched_scripts]

        return script_names

    except Exception as e:
        print(f"Error: {e}")
        return []

    finally:
        if conn:
            conn.close()


if __name__ == "__main__":
    all_scripts = []
    fetched = fetchScripts("34:1C:F0:FF:22:8C")
    if fetched:
        all_scripts.extend(fetched)

    unique_scripts = list(set(all_scripts))
    print(unique_scripts)
