from typing import List
import ConfigLEDmatrix

def handle_client_arrival(scripts: List[str]):
    device = ConfigLEDmatrix.initialize_device()
    for script in scripts:
        ConfigLEDmatrix.vertical_scroll(device, script)
