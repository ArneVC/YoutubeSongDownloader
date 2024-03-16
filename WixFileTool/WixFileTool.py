import os

sourcedirectory = input("define source directory: ")
relativePathFromWixFileToBuildFolder = input("define relative path from wix folder to build folder: ") + "\\"
files = os.listdir(sourcedirectory)
for file in files:
    print(relativePathFromWixFileToBuildFolder + file)