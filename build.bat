@echo off
dotnet build .\MonoGame.IMEHelper\ -c:Release -p:Platform=WindowsDX
dotnet build .\MonoGame.IMEHelper\ -c:Release -p:Platform=DesktopGL
dotnet build .\MonoGame.IMEHelper\ -c:Release -p:Platform=FNA