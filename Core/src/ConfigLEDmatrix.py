import argparse
from luma.led_matrix.device import max7219
from luma.core.interface.serial import spi, noop


def initialize_device(n = 1, block_orientation = 0, rotate = 0, inreverse = False):
    serial = spi(port=0, device=0, gpio=noop())
    return max7219(serial, cascaded=n, block_orientation=block_orientation, 
                     rotate=rotate or 0, blocks_arranged_in_reverse_order=inreverse)

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description='matrix_configuration arguments')
    parser.add_argument('--cascaded', '-n', type=int, default=1, help='Number of cascaded MAX7219 LED matrices')
    parser.add_argument('--block-orientation', type=int, default=0, choices=[0, 90, -90], help='Corrects block orientation when wired vertically')
    parser.add_argument('--rotate', type=int, default=0, choices=[0, 1, 2, 3], help='Rotate display 0=0°, 1=90°, 2=180°, 3=270°')

    args = parser.parse_args()