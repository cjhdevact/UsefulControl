::/*****************************************************\
::
::     UsefulControl - 4-添加Userinit级自动启动该程序.bat
::
::     版权所有(C) 2023-2024 CJH。
::
::     卸载批处理
::
::\*****************************************************/
@echo off
cls
title 实用工具集合小工具添加Userinit级自动启动该程序
if "%1" == "/noadm" goto main
if "%1" == "/?" goto hlp
fltmc 1>nul 2>nul&& goto main
echo 正在获取管理员权限...
echo.
echo 可以使用 %0 /noadm 跳过Bat提权，但请手动以管理员身份运行
echo 如果当前窗口无限循环出现，或者未成功获取管理员权限，请注销当前用户或重启电脑，
echo 然后以管理员用户账号运行或手动以管理员身份运行。
if "%1" == "/mshtaadm" goto mshtaAdmin
if "%1" == "/psadm" goto powershellAdmin
ver | findstr "10\.[0-9]\.[0-9]*" >nul && goto powershellAdmin
:mshtaAdmin
rem 原理是利用mshta运行vbscript脚本给bat文件提权
rem 这里使用了前后带引号的%~dpnx0来表示当前脚本，比原版的短文件名%~s0更可靠
rem 这里使用了两次Net session，第二次是检测是否提权成功，如果提权失败则跳转到failed标签
rem 这有效避免了提权失败之后bat文件继续执行的问题
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
rem 原理是利用powershell给bat文件提权
rem 这里使用了两次Net session，第二次是检测是否提权成功，如果提权失败则跳转到failed标签
rem 这有效避免了提权失败之后bat文件继续执行的问题
Net session >nul 2>&1 || powershell start-process \"%0\" -argumentlist \"%1 %2\" -verb runas && exit
Net session >nul 2>&1 || goto failed
goto main

:failed
cls
echo.
echo 当前未以管理员身份运行。请手动以管理员身份运行本程序。
echo.
echo 任意键关闭... & pause > NUL
goto enda


:hlp
title 实用工具集合小工具添加Userinit级自动启动该程序
cls
echo.
echo ====================================================
echo    实用工具集合小工具添加Userinit级自动启动该程序
echo ====================================================
echo.
echo 你可以使用以下参数：
echo 4-添加Userinit级自动启动该程序.bat [/noadm ^| /mshtaadm ^| /psadm]
echo.
echo /noadm 当检测到无管理员权限跳过自动提权。
echo /mshtaadm 强制使用mshta.exe自动提权。
echo /psadm 强制使用Powershell.exe自动提权。
echo.
goto enda

:main
cd /d "%~dp0"
title 实用工具集合小工具添加Userinit级自动启动该程序
cls
echo.
echo ====================================================
echo    实用工具集合小工具添加Userinit级自动启动该程序
echo ====================================================
echo.
echo 建议关闭杀毒软件以及在UAC设置中设置UAC等级为最低，否则在添加自动启动项会被拦截导致卸载失败。
echo.
echo 注意：安装了Userinit级自动启动后，那么Userinit级自动启动将会覆盖Explorer的Run下的自动启动项，并且只支持启动到右边。否则请不要安装Userinit级自动启动。
echo.
echo 任意键开始添加... & pause >nul

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
echo 如果长时间停留在此操作，请检测是否被杀毒软件拦截。
echo.
reg add "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Winlogon" /v "Userinit" /t REG_SZ /d "%bat_value%" /f 

echo.
echo ====================================================
echo    实用工具集合小工具添加Userinit级自动启动该程序
echo ====================================================
echo.
echo 安装完成，任意键关闭。
echo.
pause >nul

::exit