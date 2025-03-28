import time
import argparse

from luma.led_matrix.device import max7219
from luma.core.interface.serial import spi, noop4
from luma.core.render import canvas
from luma.core.virtual import viewport
from luma.core.legacy import text, show_message
from luma.core.legacy.font import proportional, CP437_FONT, TINY_FONT, SINCLAIR_FONT, LCD_FONT

def configure():
    serial = spi(port=0, device=0, gpio=noop())
    device = max7219(serial, cascaded=n, block_orientation=block_orientation, 
                     rotate=rotate or 0, blocks_arranged_in_reverse_order=inreverse)
    print("Created device")

def printMessage(msg: str):
    configure()
    show_message(device, msg, fill="white", font=proportional(CP437_FONT))
    time.sleep(1)

def printVerticalScorllingMsg(words):
    configure()
    virtual = viewport(device, width=device.width, height=len(words))
    with canvas(virtual) as draw:
        for i, words in enumerate(words):
            text(draw, (0, i * 8), word, fill="white", font=proportional(CP437_FONT))

    for i in range(virtual.height - device.height):
        virtual.set_position((0,i))
        time.sleep(0.1)