#handles displaying of messages using LED Matrix
from luma.core.render import canvas
from luma.core.virtual import viewport
from luma.core.legacy import text, show_message
from luma.core.legacy.font import proportional, CP437_FONT, TINY_FONT, SINCLAIR_FONT, LCD_FONT
import ConfigLEDmatrix
import time

#default displaying of text on matrix
def display_text(device, msg, font=CP437_FONT):
    print(msg)
    show_message(device, msg, fill="white", font=proportional(font))
    time.sleep(1)

def demo(device):
    print("Created Device")

    display_text(device, "MAX7219 LED MATRIX Demo")

if __name__ == "__main__":
    device = ConfigLEDmatrix.initialize_device()
    demo(device)