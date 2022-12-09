Get-ChildItem c:\Windows

1..180 | ForEach-Object {
        Start-Sleep -Seconds 1
    Write-Host "Counter :`t $_" -ForegroundColor Yellow 
}