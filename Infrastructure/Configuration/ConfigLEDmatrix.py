import time
import argparse

from luma.led_matrix.device import max7219
from luma.core.interface.serial import spi, noop4
from luma.core.render import canvas
from luma.core.virtual import viewport
from luma.core.legacy import text, show_message
from luma.core.legacy.font import proportional, CP437_FONT, TINY_FONT, SINCLAIR_FONT, LCD_FONT

def initialize_device():
    serial = spi(port=0, device=0, gpio=noop())
    return max7219(serial, cascaded=n, block_orientation=block_orientation, 
                     rotate=rotate or 0, blocks_arranged_in_reverse_order=inreverse)

def display_text(device, msg, font=CP437_FONT):
    print(msg)
    show_message(device, msg, fill="white", font=proportional(font))
    time.sleep(1)

def scroll_text(device, msg, font=LCD_FONT, speed=0.1):
    print(msg)
    show_message(device, msg, fill="white", font=proportional(font), scroll_delay=speed),

def vertical_scroll(device, words):
    print("Vertical scrolling")
    virtual = viewport(device, width=device.width, height=len(words) * 8)
    with canvas(virtual) as draw:
        for i, words in enumerate(words):
            text(draw, (0, i * 8), word, fill="white", font=proportional(CP437_FONT))

    for i in range(virtual.height - device.height):
        virtual.set_position((0,i))
        time.sleep(0.05)

def demo(n, block_orientation, rotate, inreverse):
    device = initialize_device(n, block_orientation, rotate, inreverse)
    print("Created Device")

    display_text(device, "MAX7219 LED MATRIX Demo")

    vertical_scroll(device, ["Victor", "Echo", "Rome", "Tango", "India"])

if __name__ == "__main__":
    parser= argparse.ArgumentParser(description='matrix_configuration arguments')
    parser.add_argument('--cascaded', '-n', type=int, default=1, help='Number of cascaded MAX7219 LED matrices')
    parser.add_argument('--block-orientation', type=int, default=0, choices=[0,90,-90] help='Corrects block orientation when wired vertically')
    parser.add_argument('--rotate', type=int, default=0, choices=[0,1,2,3], help='Rotate display 0=0°, 1=90°, 2=180°, 3=270°')

    args = parser.parse_args()
