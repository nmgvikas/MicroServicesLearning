# Dockerfile is a Build Workflow spec
# you ask docker to provision a temporary container to build the image
# you always with with what you need from the lowermost dependency
FROM mcr.microsoft.com/windows/servercore:ltsc2019

#Copy the files onto the base image

COPY scripts\\myscript.ps1 c:\\yourscript.ps1

#Provide the startup command
CMD ["powershell.exe", "c:\\yourscript.ps1"]