::/*****************************************************\
::
::     UsefulControl - 2-ж��.bat
::
::     ��Ȩ����(C) 2023-2025 CJH��
::
::     ж��������
::
::\*****************************************************/
@echo off
cls
title ʵ�ù��߼���С����ж�س���
if "%1" == "/noadm" goto main
if "%1" == "/?" goto hlp
fltmc 1>nul 2>nul&& goto main
echo ���ڻ�ȡ����ԱȨ��...
echo.
echo ����ʹ�� %0 /noadm ����Bat��Ȩ�������ֶ��Թ���Ա�������
echo �����ǰ��������ѭ�����֣�����δ�ɹ���ȡ����ԱȨ�ޣ���ע����ǰ�û����������ԣ�
echo Ȼ���Թ���Ա�û��˺����л��ֶ��Թ���Ա������С�
if "%1" == "/mshtaadm" goto mshtaAdmin
if "%1" == "/psadm" goto powershellAdmin
ver | findstr "10\.[0-9]\.[0-9]*" >nul && goto powershellAdmin
:mshtaAdmin
rem ԭ��������mshta����vbscript�ű���bat�ļ���Ȩ
rem ����ʹ����ǰ������ŵ�%~dpnx0����ʾ��ǰ�ű�����ԭ��Ķ��ļ���%~s0���ɿ�
rem ����ʹ��������Net session���ڶ����Ǽ���Ƿ���Ȩ�ɹ��������Ȩʧ������ת��failed��ǩ
rem ����Ч��������Ȩʧ��֮��bat�ļ�����ִ�е�����
::Net session >nul 2>&1 || mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c ""%~dpnx0""","","runas",1)(window.close)&&exit
set parameters=
:parameter
@if not "%~1"=="" ( set parameters=%parameters% %~1& shift /1& goto :parameter)
set parameters="%parameters:~1%"
mshta vbscript:createobject("shell.application").shellexecute("%~dpnx0",%parameters%,"","runas",1)(window.close)&exit
cd /d "%~dp0"
Net session >nul 2>&1 || goto failed
goto main

:powershellAdmin
rem ԭ��������powershell��bat�ļ���Ȩ
rem ����ʹ��������Net session���ڶ����Ǽ���Ƿ���Ȩ�ɹ��������Ȩʧ������ת��failed��ǩ
rem ����Ч��������Ȩʧ��֮��bat�ļ�����ִ�е�����
Net session >nul 2>&1 || powershell start-process \"%0\" -argumentlist \"%1 %2\" -verb runas && exit
Net session >nul 2>&1 || goto failed
goto main

:failed
cls
echo.
echo ��ǰδ�Թ���Ա������С����ֶ��Թ���Ա������б�����
echo.
echo ������ر�... & pause > NUL
goto enda


:hlp
title ʵ�ù��߼���С����ж�س���
cls
echo.
echo ====================================================
echo               ʵ�ù��߼���С����ж�س���
echo ====================================================
echo.
echo �����ʹ�����²�����
echo 2-ж��.bat [/noadm ^| /mshtaadm ^| /psadm]
echo.
echo /noadm ����⵽�޹���ԱȨ�������Զ���Ȩ��
echo /mshtaadm ǿ��ʹ��mshta.exe�Զ���Ȩ��
echo /psadm ǿ��ʹ��Powershell.exe�Զ���Ȩ��
echo.
goto enda

:main
cd /d "%~dp0"
title ʵ�ù��߼���С����ж�س���
cls
echo.
echo ====================================================
echo               ʵ�ù��߼���С����ж�س���
echo ====================================================
echo.
echo ж��ǰ����ر�ɱ������Լ���UAC����������UAC�ȼ�Ϊ��ͣ�������ж���������Լ��Զ�������ᱻ���ص���ж��ʧ�ܡ�
echo.
echo �������ʼж��... & pause >nul

cls
echo.
echo ====================================================
echo               ʵ�ù��߼���С����ж�س���
echo ====================================================
echo.
echo ����ж����...
echo.
taskkill /f /im UsefulControl.exe
::ver|findstr "\<10\.[0-9]\.[0-9][0-9]*\>" > nul && (set netv=4)
ver|findstr "\<6\.[0-1]\.[0-9][0-9]*\>" > nul && (set netv=4c)
ver|findstr "\<6\.[2-9]\.[0-9][0-9]*\>" > nul && (set netv=4c)
ver|findstr "\<5\.[0-9]\.[0-9][0-9]*\>" > nul && (set netv=4c)

if "%PROCESSOR_ARCHITECTURE%"=="x86" goto x86
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" goto x64

:x86
echo.
echo �����ʱ��ͣ���ڴ˲����������Ƿ�ɱ��������ء�
echo.
Reg delete HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /f
schtasks.exe /Delete /TN \CJH\UsefulControl /F
del /q "%windir%\UsefulControl.exe"
del /q "%windir%\PolicyDefinitions\UsefulControl.admx"
del /q "%windir%\PolicyDefinitions\zh-CN\UsefulControl.adml"
del /q "%windir%\PolicyDefinitions\en-US\UsefulControl.adml"

del /q "%userprofile%\..\Public\Desktop\ʵ�ù��߼���С����.lnk"
rd /s /q "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\ʵ�ù��߼���С����"
::dir /a /s /b "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\CJH" | findstr . >nul && echo. || rd /s /q "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\CJH"

choice /C YN /T 5 /D N /M "��(Y)��(N)ɾ���Զ������ã�5����Զ�ѡ��N��"
if errorlevel 1 set a=1
if errorlevel 2 set a=2
if "%a%" == "1" Reg delete HKCU\Software\CJH\UsefulControl /f

Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v DisplayIcon /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v DisplayName /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v Publisher /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v UninstallString /f

cd /d "%windir%"

PUSHD ..
rd /s /q "%programfiles%\CJH\UsefulControl"
::dir /a /s /b "%windir%\CJH\" | findstr . >nul && echo. || rd /s /q "%windir%\CJH"

echo.
cls

echo.
echo ====================================================
echo               ʵ�ù��߼���С����ж�س���
echo ====================================================
echo.
echo ж����ɣ�������˳�... & pause > nul
goto enda

:x64
echo.
echo �����ʱ��ͣ���ڴ˲����������Ƿ�ɱ��������ء�
echo.
Reg delete HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /f
schtasks.exe /Delete /TN \CJH\UsefulControl /F
del /q "%windir%\UsefulControl.exe"
del /q "%windir%\syswow64\UsefulControl.exe"
del /q "%windir%\PolicyDefinitions\UsefulControl.admx"
del /q "%windir%\PolicyDefinitions\zh-CN\UsefulControl.adml"
del /q "%windir%\PolicyDefinitions\en-US\UsefulControl.adml"

rd /s /q "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\ʵ�ù��߼���С����"
del /q "%userprofile%\..\Public\Desktop\ʵ�ù��߼���С����.lnk"
::dir /a /s /b "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\CJH" | findstr . >nul && echo. || rd /s /q "%systemdrive%\ProgramData\Microsoft\Windows\Start Menu\Programs\CJH"

choice /C YN /T 5 /D N /M "��(Y)��(N)ɾ���Զ������ã�5����Զ�ѡ��N��"
if errorlevel 1 set a=1
if errorlevel 2 set a=2
if "%a%" == "1" Reg delete HKCU\Software\CJH\UsefulControl /f

Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v DisplayIcon /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v DisplayName /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v Publisher /f
Reg delete HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\UsefulControl /v UninstallString /f

cd /d "%windir%"
PUSHD ..
rd /s /q "%programfiles%\CJH\UsefulControl"
::dir /a /s /b "%windir%\CJH" | findstr . >nul && echo. || rd /s /q "%windir%\CJH"

echo.
cls

echo.
echo ====================================================
echo               ʵ�ù��߼���С����ж�س���
echo ====================================================
echo.
echo ж����ɣ�������˳�... & pause > nul
goto enda

:enda