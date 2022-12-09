# escape=`
FROM mcr.microsoft.com/windows/servercore/iis:windowsservercore-ltsc2019
SHELL ["powershell"]

ARG ENV_NAME=DEV

EXPOSE 80

COPY template.html c:\template.html

COPY tiger.jpg c:\inetpub\wwwroot\tiger.jpg

#Read the conents of c:\template.html and modify the {} values

RUN (Get-Content -Raw c:\template.html) `
    -replace '{hostname}', [Environment]::MachineName `
    -replace '{environment}',[Environment]::GetEnvironmentVariable('ENV_NAME') `
    | Set-Content -Path c:\inetpub\wwwroot\index.html


