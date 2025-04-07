from typing import List
import led_matrix_display as display
def handle_client_arrival(matrix_device, scripts: List[str]):
    for script in scripts:
        display.vertical_scroll(matrix_device, script)
