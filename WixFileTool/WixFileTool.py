import os

windowsNumber = input ("windows number: ")
sourcedirectory = ""
relativePathFromWixFileToBuildFolder = ""
filename = ""
if windowsNumber == "86":
    sourcedirectory = "..\\YoutubeSongDownloader\\bin\\Release\\net8.0-windows\\publish\\win-x86\\"
    relativePathFromWixFileToBuildFolder = "..\\YoutubeSongDownloader\\bin\\Release\\net8.0-windows\\publish\\win-x86\\"
    filename = "x86.output"
elif windowsNumber == "64":
    sourcedirectory = "..\\YoutubeSongDownloader\\bin\\Release\\net8.0-windows\\publish\\win-x64\\"
    relativePathFromWixFileToBuildFolder = "..\\YoutubeSongDownloader\\bin\\Release\\net8.0-windows\\publish\\win-x64\\"
    filename = "x64.output"
else:
    print("input 64 for 64 bit windows or 86 for 32 bit windows")
    quit()

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
    entry = ""
    entry += "<Component Id=\"Component_x" + windowsNumber + "_Accessibility\" Guid=\"*\">\n"
    entry += "    <File Source=\"" + filepath + "\"/>\n"
    entry += "</Component>\n"
    actualLines.append(entry)
    
file = open(filename, 'w+')
file.writelines(actualLines)

print("wrote wix file entry lines to " + filename)