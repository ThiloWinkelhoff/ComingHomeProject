from typing import List
import ConfigLEDmatrix

def handle_client_arrival(scripts: List[str]):
    for script in scripts:
        ConfigLEDmatrix.display_text(script)#falsche methode
