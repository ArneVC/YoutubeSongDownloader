class ConvertFileIntoByteArray:
    def file_to_byte_array(self, file_path):
        try:
            with open(file_path, "rb") as file:
                byte_array = bytearray(file.read())
            return byte_array
        except:
            print("file doesn't exist")
            return []
    
    def run(self):
        file_path = input("File name / path: ")
        byte_array = self.file_to_byte_array(file_path)
        if len(byte_array) != 0:
            print("ok")
        else:
            print("no array")