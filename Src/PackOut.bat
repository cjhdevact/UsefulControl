@echo off
echo �������� ʵ�ù��߼���С���ߣ�UsefulControl��...
pause > nul
if exist %~dp0UsefulControl-Bin rd /s /q %~dp0UsefulControl-Bin
md %~dp0UsefulControl-Bin
copy %~dp0UsefulControl\bin\Release\UsefulControl.exe %~dp0UsefulControl-Bin\UsefulControl.exe
copy %~dp0UsefulControl\bin\x64\Release\UsefulControl.exe %~dp0UsefulControl-Bin\UsefulControl64.exe

copy %~dp0UsefulControl\files\1-��װ.bat %~dp0UsefulControl-Bin\1-��װ.bat
copy %~dp0UsefulControl\files\2-ж��.bat %~dp0UsefulControl-Bin\2-ж��.bat
copy %~dp0UsefulControl\files\3-�Զ���������.bat %~dp0UsefulControl-Bin\3-�Զ���������.bat
copy %~dp0UsefulControl\files\4-���Userinit���Զ������ó���.bat %~dp0UsefulControl-Bin\4-���Userinit���Զ������ó���.bat
copy %~dp0UsefulControl\files\5-ɾ��Userinit���Զ������ó���.bat %~dp0UsefulControl-Bin\5-ɾ��Userinit���Զ������ó���.bat
copy %~dp0UsefulControl\files\UsefulControlAdmxs.exe %~dp0UsefulControl-Bin\UsefulControlAdmxs.exe
copy %~dp0UsefulControl\files\certmgr.exe %~dp0UsefulControl-Bin\certmgr.exe
copy %~dp0UsefulControl\files\rootcert.cer %~dp0UsefulControl-Bin\rootcert.cer
copy %~dp0UsefulControl\files\UsefulControl.xml %~dp0UsefulControl-Bin\UsefulControl.xml
echo.
echo ��ɣ�
echo ������˳�...
pause > nul