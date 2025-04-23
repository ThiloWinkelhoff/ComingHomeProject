 
class Device:
    def __init__(self, name, ip, mac, connected=False, scripts=None):
        self.name = name
        self.ip = ip
        self.mac = mac
        self.scripts = scripts if scripts is not None else []
        self.connected = connected  
 
    def add_script(self, script):
        self.scripts.append(script)
 
    def to_dict(self):
        """Convert the Device object to a dictionary."""
        return {
            'name': self.name,
            'ip': self.ip,
            'mac': self.mac,
            'scripts': self.scripts,
            'connected': self.connected
        }
 
    def __str__(self):
        return f"Device(name={self.name}, ip={self.ip}, mac={self.mac}, scripts={self.scripts}, connected={self.connected})"
 
 
def get_example_devices():
    """Return a list of example Device objects for testing."""
    example_data = [
        Device(name="Laptop", ip="192.168.0.101", mac="AA:BB:CC:DD:EE:01"),
        Device(name="Smartphone", ip="192.168.0.102", mac="AA:BB:CC:DD:EE:02"),
        Device(name="Printer", ip="192.168.0.103", mac="AA:BB:CC:DD:EE:03"),
        Device(name="TV", ip="192.168.0.104", mac="AA:BB:CC:DD:EE:04"),
    ]
    return example_data
