import os

sourcedirectory = input("define source directory: ")
relativePathFromWixFileToBuildFolder = input("define relative path from wix folder to build folder: ") + "\\"
files = os.listdir(sourcedirectory)
filePaths = []
for file in files:
    full_path = os.path.join(sourcedirectory, file)
    if not os.path.isdir(full_path):
        filePaths.append(relativePathFromWixFileToBuildFolder + file)
        
for filepath in filePaths:
    print(filepath)