@dotnet publish -c Release -r win10-x64 -p:PublishTrimmed=True -p:TrimMode=CopyUsed -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --self-contained true
