::/*****************************************************\
::
::     UsefulControl - 4-���Userinit���Զ������ó���.bat
::
::     ��Ȩ����(C) 2023-2024 CJH��
::
::     ж��������
::
::\*****************************************************/
@echo off
cls
title ʵ�ù��߼���С�������Userinit���Զ������ó���
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
title ʵ�ù��߼���С�������Userinit���Զ������ó���
cls
echo.
echo ====================================================
echo    ʵ�ù��߼���С�������Userinit���Զ������ó���
echo ====================================================
echo.
echo �����ʹ�����²�����
echo 4-���Userinit���Զ������ó���.bat [/noadm ^| /mshtaadm ^| /psadm]
echo.
echo /noadm ����⵽�޹���ԱȨ�������Զ���Ȩ��
echo /mshtaadm ǿ��ʹ��mshta.exe�Զ���Ȩ��
echo /psadm ǿ��ʹ��Powershell.exe�Զ���Ȩ��
echo.
goto enda

:main
cd /d "%~dp0"
title ʵ�ù��߼���С�������Userinit���Զ������ó���
cls
echo.
echo ====================================================
echo    ʵ�ù��߼���С�������Userinit���Զ������ó���
echo ====================================================
echo.
echo ����ر�ɱ������Լ���UAC����������UAC�ȼ�Ϊ��ͣ�����������Զ�������ᱻ���ص���ж��ʧ�ܡ�
echo.
echo ע�⣺��װ��Userinit���Զ���������ôUserinit���Զ��������Ḳ��Explorer��Run�µ��Զ����������ֻ֧���������ұߡ������벻Ҫ��װUserinit���Զ�������
echo.
echo �������ʼ���... & pause >nul

::set path=%1
::set path=%path:"=%
set mpath=%programfiles%\CJH\UsefulControl\UsefulControl.exe
::echo %path%
set current_dir=%WINDIR%\System32
pushd %current_dir%
for /f "tokens=1,2,*" %%a in ('reg query "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon" /v "Userinit" ^|findstr /i "Userinit"') do (
    set value=%%c
)
echo The default UserInit value:
echo %value% 
echo.
set value=%value:"=%
set "bat_value=%value%%mpath%,"
echo The value will write in UserInit:
echo %bat_value%
echo.

echo.
echo �����ʱ��ͣ���ڴ˲����������Ƿ�ɱ��������ء�
echo.
reg add "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon" /v "Userinit" /t REG_SZ /d "%bat_value%" /f 

echo.
echo ====================================================
echo    ʵ�ù��߼���С�������Userinit���Զ������ó���
echo ====================================================
echo.
echo ��װ��ɣ�������رա�
echo.
pause >nul

::exit