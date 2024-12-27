::Tips Set the CSIGNCERT as your path.
@echo off
path D:\ProjectsTmp\SignPack;%path%
echo 任意键签名 实用工具集合小工具（UsefulControl）...
pause > nul
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControl.exe"
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControl64.exe"
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControlAdmxs.exe"
echo.
echo 完成！
echo 任意键退出...
pause > nul