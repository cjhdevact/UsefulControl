::/*****************************************************\
::
::     UsefulControl - 3-�Զ���������.bat
::
::     ��Ȩ����(C) 2023-2024 CJH��
::
::     �Զ���������������
::
::\*****************************************************/
@echo off
cls
cd /d %~dp0
title ʵ�ù��߼���С�����Զ���������
if "%1" == "/?" goto hlp
if "%1" == "/noadm" goto main
fltmc 1>nul 2>nul&& goto main
echo ���ڻ�ȡ����ԱȨ��...
echo.
echo ����ʹ�� %0 /noadm ����Bat��Ȩ�������ֶ��Թ���Ա�������
echo �����ǰ��������ѭ�����֣�����δ�ɹ���ȡ����ԱȨ�ޣ���ע����ǰ�û����������ԣ�
echo Ȼ���Թ���Ա�û��˺����л��ֶ��Թ���Ա������С�
if "%1" == "/mshtaadm" goto mshtaAdmin
if "%2" == "/mshtaadm" goto mshtaAdmin
if "%1" == "/psadm" goto powershellAdmin
if "%2" == "/psadm" goto powershellAdmin
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
title ʵ�ù��߼���С�����Զ���������
cls
echo.
echo ====================================================
echo              ʵ�ù��߼���С�����Զ���������
echo ====================================================
echo.
echo �����ʹ�����²�����
echo 3-�Զ���������.bat [/noadm ^| /mshtaadm ^| /psadm]
echo.
echo /noadm ����⵽�޹���ԱȨ�������Զ���Ȩ��
echo /mshtaadm ǿ��ʹ��mshta.exe�Զ���Ȩ��
echo /psadm ǿ��ʹ��Powershell.exe�Զ���Ȩ��
echo.
goto enda

:main
cls
echo.
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
echo ��ѡ����Ĳ�����
echo.
echo         1  �����Զ�����Ϊ����
echo         2  �����Զ�����Ϊ�ײ�
echo         3  �����Զ�����Ϊ���
echo         4  �����Զ�����Ϊ�ұ�
echo         5  �����Զ�����Ϊ���Ͻ�
echo         6  �����Զ�����Ϊ���Ͻ�
echo         7  �����Զ�����Ϊ���½�
echo         8  �����Զ�����Ϊ���½�
echo.
echo         9  �����Զ�����������ƻ�����
echo.
echo        10  ɾ���Զ�����
echo        11  ɾ���Զ�����������ƻ�����
echo.
echo        12  �˳�
echo.
echo ע�⣺������Ѿ���װ��Userinit���Զ�������������ƻ�������������ô���ǽ��Ḳ�ǵ�ǰ���ã�����ֻ֧����������ߡ�Ҫʹ��ǰ������Ч����ɾ��Userinit���Զ�����������ƻ�����������
echo ========================================================
echo.
set /p chooice=�������Ӧ��������ִ����Ӧ�Ĳ�����
if "%chooice%" == "1" goto ad1
if "%chooice%" == "2" goto ad2
if "%chooice%" == "3" goto ad3
if "%chooice%" == "4" goto ad4
if "%chooice%" == "5" goto ad5
if "%chooice%" == "6" goto ad6
if "%chooice%" == "7" goto ad7
if "%chooice%" == "8" goto ad8
if "%chooice%" == "9" goto ad9
if "%chooice%" == "10" goto de1
if "%chooice%" == "11" goto de12
if "%chooice%" == "12" goto enda
echo.
echo ��Ч��ѡ���������ء� & pause >nul
goto main

:ad1
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /topbar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad2
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /bottombar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad3
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /leftbar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad4
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /rightbar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad5
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /lefttopbar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad6
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /righttopbar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad7
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /leftbottombar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad8
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /rightbottombar" /f
echo ��ӳɹ������������... & pause > nul
goto main

:ad9
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ====================================================
echo.
echo ע�⣺��װ������ƻ������Զ���������ô����ƻ����Զ��������Ḳ��Explorer��Run�µ��Զ����������ֻ֧����������ߡ��������Ҫ�Զ�������λ����ɾ������ƻ����Զ�������
schtasks.exe /Delete /TN \CJH\UsefulControl /F
schtasks.exe /create /tn \CJH\UsefulControl /xml "%~dp0UsefulControl.xml"
echo ��ӳɹ������������... & pause > nul
goto main

:de1
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ===================================================
Reg delete HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /f
echo ɾ���ɹ������������... & pause > nul
goto main

:de12
cls
echo ====================================================
echo             ʵ�ù��߼���С�����Զ���������
echo ===================================================
schtasks.exe /Delete /TN \CJH\UsefulControl /F
echo ɾ���ɹ������������... & pause > nul
goto main


:enda
