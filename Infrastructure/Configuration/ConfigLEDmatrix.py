import time
import argparse

from luma.led_matrix.device import max7219
from luma.core.interface.serial import spi, noop4
from luma.core.render import canvas
from luma.core.virtual import viewport
from luma.core.legacy import text, show_message
from luma.core.legacy.font import proportional, CP437_FONT, TINY_FONT, SINCLAIR_FONT, LCD_FONT

def InitializeMatrix():
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

if __name__ == "__main__":
    parser= arg