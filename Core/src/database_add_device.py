import pyodbc

# Define connection parameters
server = '[::1]'  # Or the actual IP address of your SQL Server
database = 'ComingHomeProject'
username = 'ComingHomeUser'
password = 'CHU'

# Create the connection string using SQL Server ODBC driver
connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

# Establish the connection
try:
    print("start")
    conn = pyodbc.connect(connection_string, autocommit=True)
    print("Connection successful!")

    cursor = conn.cursor()

    # Execute a query
    cursor.execute("SELECT * FROM Devices")

    # Fetch all rows from the query
    rows = cursor.fetchall()

    # Print the rows
    for row in rows:
        print(row)

    # Close the cursor
    cursor.close()

except Exception as e:
    print(f"Error: {e}")

finally:
    if conn:
        conn.close()
    else:
        print("Connection not established.")
