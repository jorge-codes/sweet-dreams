#!/bin/zsh
cwd=$(pwd)
/Applications/Unity/Hub/Editor/2022.3.0f1/Unity.app/Contents/MacOS/Unity -batchmode -projectPath cwd -buildOSXUniversalPlayer Builds/mac/SweetDreams.app
#/Applications/Unity/Hub/Editor/2022.3.0f1/Unity.app/Contents/MacOS/Unity -silent-crashes -quit -projectPath cwd -buildWindows64Player Builds/win/SweetDreams.exe
