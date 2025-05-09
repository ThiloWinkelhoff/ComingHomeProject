import time
import board
import digitalio
import busio
import adafruit_st7789
from PIL import Image, ImageDraw, ImageFont

# Initialisiere SPI1
spi = busio.SPI(clock=board.SCLK_1, MOSI=board.MOSI_1)

# Steuerleitungen
cs_pin = digitalio.DigitalInOut(board.D22)     # GPIO22 (Pin 15)
dc_pin = digitalio.DigitalInOut(board.D17)     # GPIO17 (Pin 11)
reset_pin = digitalio.DigitalInOut(board.D27)  # GPIO27 (Pin 13)

# Display konfigurieren
disp = adafruit_st7789.ST7789(
    spi,
    cs=cs_pin,
    dc=dc_pin,
    rst=reset_pin,
    baudrate=24000000,
    width=240,
    height=240,
    x_offset=0,
    y_offset=80
)

# Leeres Bild erstellen
image = Image.new("RGB", (240, 240), "black")
draw = ImageDraw.Draw(image)
font = ImageFont.load_default()

# Test-Text anzeigen
draw.text((60, 110), "Display läuft!", font=font, fill=(0, 255, 0))
disp.image(image)

# Optional: 10 Sekunden anzeigen lassen
time.sleep(10)

# Display löschen (optional)
draw.rectangle((0, 0, 240, 240), fill=(0, 0, 0))
disp.image(image)
