::Tips Set the CSIGNCERT as your path.
@echo off
path D:\ProjectsTmp\SignPack;%path%
echo �����ǩ�� ʵ�ù��߼���С���ߣ�UsefulControl��...
pause > nul
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControl.exe"
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControl64.exe"
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0UsefulControl-Bin\UsefulControlAdmxs.exe"
echo.
echo ��ɣ�
echo ������˳�...
pause > nul