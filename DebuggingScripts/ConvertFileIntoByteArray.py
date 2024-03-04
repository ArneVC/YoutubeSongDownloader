class ConvertFileIntoByteArray:
    def file_to_byte_array(self, file_path):
        try:
            with open(file_path, "rb") as file:
                byte_array = bytearray(file.read())
            return byte_array
        except:
            print("file doesn't exist")
            return []
        
    def print_out_byte_array(self, byte_array, amount_of_bytes):
        try:
            amount_of_bytes = int(amount_of_bytes)
            if 0 <= amount_of_bytes <= len(byte_array):
                formatted_bytes = ' '.join([f"{byte:02x}" for byte in byte_array[:amount_of_bytes]])
                print(formatted_bytes)
            else:
                print("Invalid amount of bytes specified.")
        except ValueError:
            print("Invalid input. Please enter an integer.")
    
    def run(self):
        file_path = input("File name / path: ")
        byte_array = self.file_to_byte_array(file_path)
        if len(byte_array) != 0:
            amount_of_bytes = input("Amount of bytes: ")
            self.print_out_byte_array(byte_array, amount_of_bytes)
        else:
            print("no array")