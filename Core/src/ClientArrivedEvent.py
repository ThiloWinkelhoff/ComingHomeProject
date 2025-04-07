from typing import List
import ConfigLEDmatrix

def handle_client_arrival(matrix_device, scripts: List[str]):
    for script in scripts:
        ConfigLEDmatrix.vertical_scroll(matrix_device, script)
