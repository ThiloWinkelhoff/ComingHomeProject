# Create a cursor from the connection
cursor = conn.cursor()

# Execute a query
cursor.execute("SELECT * FROM your_table_name")

# Fetch all rows from the query
rows = cursor.fetchall()

# Iterate through the rows and print the data
for row in rows:
    print(row)

# Close the cursor
cursor.close()
