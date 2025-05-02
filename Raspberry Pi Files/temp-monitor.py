import socket
import time
import math
from PIL import Image, ImageDraw, ImageFont
import GC9A01 as GC9A01
import os

# Initialize both displays
disp1 = GC9A01.GC9A01(port=0, cs=0, dc=25, rst=24, spi_speed_hz=64000000)
disp2 = GC9A01.GC9A01(port=1, cs=0, dc=23, rst=22, spi_speed_hz=64000000)

disp1.begin()
disp2.begin()

WIDTH, HEIGHT = disp1.width, disp1.height

# Load font (optional for labels)
try:
    font = ImageFont.truetype("/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf", 18)
except:
    font = ImageFont.load_default()

def get_text_wh(text, draw):
    text_bbox = draw.textbbox((0,0), text, font=font)
    text_width = text_bbox[2] - text_bbox[0]
    text_height = text_bbox[3] - text_bbox[1]

    return text_width, text_height

# Method to show a startup immage that centers it in the screen
def show_startup_screen(disp, message):
    img = Image.new("RGB", (WIDTH, HEIGHT), color=(0, 0, 255))
    draw = ImageDraw.Draw(img)

    text_width, text_height = get_text_wh(message, draw)

    text_x = (WIDTH - text_width) // 2
    text_y = (HEIGHT - text_height) // 2

    draw.text((text_x, text_y), message, font=font, fill="white")

    rotated_img = img.rotate(90, expand=True)

    disp.display(rotated_img)

show_startup_screen(disp1, "Hello")
show_startup_screen(disp2, "There...")

# Set up gauge parameters
center_x, center_y = WIDTH // 2, HEIGHT // 2
radius = 5  # Radius of the circle
needle_length = 70  # Length of the needle
needle_width = 5

# Temperature range and corresponding angles
min_temp = 20  # Minimum temperature (°C)
max_temp = 100  # Maximum temperature (°C)
min_angle = -45  # Angle for min temperature (°C) (starts downward)
max_angle = 222  # Angle for max temperature (°C)

# Load background image and resize to match the display size
background = Image.open("Empty_Temp.jpg").resize((WIDTH, HEIGHT))

# Function to map temperature to angle (reverse sweep direction)
def temp_to_angle(temp):
    return min_angle + (temp - min_temp) * (max_angle - min_angle) / (max_temp - min_temp)

# Function to draw the gauge on top of the background image
def draw_gauge(disp, angle, label, temp):
    img = background.copy()
    draw = ImageDraw.Draw(img)

    # Draw the red circle (gauge)
    draw.ellipse(
        (center_x - radius, center_y - radius, center_x + radius, center_y + radius),
        outline="red", width=5
    )

    # Calculate the needle's end point using polar coordinates (clockwise sweep)
    needle_x = center_x + needle_length * math.cos(math.radians(180 - angle))
    needle_y = center_y - needle_length * math.sin(math.radians(180 - angle))

    # Get height and width properties for label and temp
    label_width, label_height = get_text_wh(label, draw)
    temp_width, temp_height = get_text_wh(str(temp), draw)

    # Use the width to find a center x based on the screen size
    # for the label and the temperature
    label_x = (WIDTH - label_width) // 2
    temp_x = (WIDTH - temp_width) // 2

    # Draw the needle
    draw.line(
        (center_x, center_y, needle_x, needle_y),
        fill="white", width=needle_width
    )

    # Optionally, add text (e.g., "CPU Temp" on display1)
    draw.text((label_x, 200), label, font=font, fill="white")
    draw.text((temp_x, 180), f"{temp:.1f}", font=font, fill="white")
    disp.display(img.rotate(90, expand=True))

# Method to show waiting screen
def show_waiting_screen(disp):
    img = Image.new("RGB", (WIDTH, HEIGHT), color=(0,0,255))
    draw = ImageDraw.Draw(img)

    # Collect hostname
    hostname = os.uname()[1]

    waiting_text = "Waiting..."
    label = "Hostname:"

    waiting_text_width, waiting_text_height = get_text_wh(waiting_text, draw)
    hostname_width, hostname_height = get_text_wh(hostname, draw)
    label_width, label_height = get_text_wh(label, draw)

    waiting_text_x = (WIDTH - waiting_text_width) // 2
    waiting_text_y = (HEIGHT // 3) -  (waiting_text_height // 2)

    hostname_x = (WIDTH - hostname_width) // 2
    hostname_y = (HEIGHT // 2) -  (hostname_height // 2)

    total_height = waiting_text_height + hostname_height + label_height + 10
    start_y = (HEIGHT - total_height) // 2

    # Draw Waiting... on first line
    draw.text(((WIDTH - waiting_text_width) // 2, start_y), waiting_text, font=font, fill="white")

    # Draw Hostname: label on second line
    draw.text(((WIDTH - label_width) // 2, start_y + label_height + 5), label, font=font, fill="white")

    # Draw hostname on third line
    draw.text(((WIDTH - hostname_width) // 2, start_y + label_height + hostname_height + 10), hostname, font=font, fill="white")

    rotated_img = img.rotate(90, expand=True)

    disp.display(rotated_img)

# Set up the UDP client to listen for temperature data
def get_udp_socket(host="0.0.0.0", port=12345):
    # Create a UDP socket
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    client_socket.bind((host, port))
    client_socket.settimeout(3.0)
    return client_socket

last_values = [None, None]
udp_socket = get_udp_socket()
last_data_time = None
waiting_for_data = True
initial_run = True
three_second_timer = time.time() + 3

# Main loop to continuously update the display based on received temperature
try:
    while True:   
        try:
            data, addr = udp_socket.recvfrom(1024)
            if data:
                last_data_time = time.time()

                if waiting_for_data:
                    # Enter main loop if waiting for data is false.
                    waiting_for_data = False    

                parts = data.decode("utf-8").strip().split(",")
                values = []
                labels = []

                for part in parts:
                    if ':' in part:
                        label, value = part.split(":")
                        labels.append(label.strip())
                        try:
                            values.append(float(value.strip()))
                        except ValueError:
                            print(f"Invalid value received: {value}")

                label1, value1, label2, value2 = None, None, None, None
                if len(values) >= 2:
                    label1, value1, label2, value2 = labels[0], values[0], labels[1], values[1]
                elif len(values) == 1:
                    label1, value1 = labels[0], values[0]
            else:
                if waiting_for_data:
                    pass

        # If timeout or no data for a while enter waiting mode.
        except socket.timeout:
            if initial_run and time.time() > three_second_timer:
                initial_run = False
                last_data_time = time.time()
            if last_data_time is None:
                continue
            if time.time() - last_data_time > 5:
                if not waiting_for_data:
                    print("No data for 5 seconds - pausing loop, waiting for data...")
                    waiting_for_data = True

        # Update displays if not in waiting mode
        if not waiting_for_data:
            if value1 is not None and value1 != last_values[0]:
                angle1 = temp_to_angle(value1)
                draw_gauge(disp1, angle1, label1, value1)
                last_values[0] = value1
            if value2 is not None and value2 != last_values[1]:
                angle2 = temp_to_angle(value2)
                draw_gauge(disp2, angle2, label2, value2)
                last_values[1] = value2
            
        elif waiting_for_data:
            show_waiting_screen(disp1)
            show_waiting_screen(disp2)

        # Adjust the speed of the update (you can change this to be more or less frequent)
        time.sleep(1)
except KeyboardInterrupt:
    print("Exiting...")
finally:
    udp_socket.close()