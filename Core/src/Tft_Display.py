import time
import board
import digitalio
import busio
import adafruit_st7789
from PIL import Image, ImageDraw, ImageFont

# Initialisiere SPI1 (GPIO20 = MOSI, GPIO21 = SCLK)
spi = busio.SPI(clock=board.SCLK_1, MOSI=board.MOSI_1)

# Steuerleitungen
cs_pin = digitalio.DigitalInOut(board.D26)     # Chip Select (Pin 25)
dc_pin = digitalio.DigitalInOut(board.D17)     # Data/Command (Pin 11)
reset_pin = digitalio.DigitalInOut(board.D27)  # Reset (Pin 13)

# Display initialisieren
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

# Bild vorbereiten
image = Image.new("RGB", (240, 240), "black")
draw = ImageDraw.Draw(image)
font = ImageFont.load_default()

# Beispielgrafik/Text zeichnen
draw.rectangle((0, 0, 240, 240), fill=(0, 0, 50))
draw.text((60, 100), "Hallo, Thilo!", font=font, fill=(255, 255, 0))

# Bild anzeigen
disp.image(image)

# Optional: Bild für einige Sekunden anzeigen lassen
time.sleep(10)

# Display löschen (optional)
draw.rectangle((0, 0, 240, 240), fill=(0, 0, 0))
disp.image(image)
