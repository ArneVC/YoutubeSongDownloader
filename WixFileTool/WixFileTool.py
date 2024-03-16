import os

sourcedirectory = input("define source directory: ")
relativePathFromWixFileToBuildFolder = input("define relative path from wix folder to build folder: ") + "\\"
files = os.listdir(sourcedirectory)
filePaths = []
for file in files:
    full_path = os.path.join(sourcedirectory, file)
    if not os.path.isdir(full_path):
        filePaths.append(relativePathFromWixFileToBuildFolder + file)
    else:
        # assume subfolders don't have subfolders themselves as it's the case for this project
        subDirectory = sourcedirectory + "\\" + file
        subDirectoryFiles = os.listdir(subDirectory)
        for subDirectoryFile in subDirectoryFiles:
            filePaths.append(relativePathFromWixFileToBuildFolder + file + "\\" + subDirectoryFile)

actualLines = []
  
for filepath in filePaths:
    actualLines.append("<File Source=\"" + filepath + "/>")
    
file = open('filepaths.output', 'w+')
file.writelines(actualLines)