::/*****************************************************\
::
::     UsefulControl - 3-自动启动管理.bat
::
::     版权所有(C) 2023-2024 CJH。
::
::     自动启动管理批处理
::
::\*****************************************************/
@echo off
cls
cd /d %~dp0
title 实用工具集合小工具自动启动管理
if "%1" == "/?" goto hlp
if "%1" == "/noadm" goto main
fltmc 1>nul 2>nul&& goto main
echo 正在获取管理员权限...
echo.
echo 可以使用 %0 /noadm 跳过Bat提权，但请手动以管理员身份运行
echo 如果当前窗口无限循环出现，或者未成功获取管理员权限，请注销当前用户或重启电脑，
echo 然后以管理员用户账号运行或手动以管理员身份运行。
if "%1" == "/mshtaadm" goto mshtaAdmin
if "%2" == "/mshtaadm" goto mshtaAdmin
if "%1" == "/psadm" goto powershellAdmin
if "%2" == "/psadm" goto powershellAdmin
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
title 实用工具集合小工具自动启动管理
cls
echo.
echo ====================================================
echo              实用工具集合小工具自动启动管理
echo ====================================================
echo.
echo 你可以使用以下参数：
echo 3-自动启动管理.bat [/noadm ^| /mshtaadm ^| /psadm]
echo.
echo /noadm 当检测到无管理员权限跳过自动提权。
echo /mshtaadm 强制使用mshta.exe自动提权。
echo /psadm 强制使用Powershell.exe自动提权。
echo.
goto enda

:main
cls
echo.
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
echo 请选择你的操作：
echo.
echo         1  设置自动启动为顶部
echo         2  设置自动启动为底部
echo         3  设置自动启动为左边
echo         4  设置自动启动为右边
echo         5  设置自动启动为左上角
echo         6  设置自动启动为右上角
echo         7  设置自动启动为左下角
echo         8  设置自动启动为右下角
echo.
echo         9  设置自动启动（任务计划级）
echo.
echo        10  删除自动启动
echo        11  删除自动启动（任务计划级）
echo.
echo        12  退出
echo.
echo 注意：如果你已经安装了Userinit级自动启动或者任务计划级自启动，那么它们将会覆盖当前设置，并且只支持启动到左边。要使当前设置生效，请删除Userinit级自动启动或任务计划级自启动。
echo ========================================================
echo.
set /p chooice=请输入对应的数字以执行相应的操作：
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
echo 无效的选项，任意键返回。 & pause >nul
goto main

:ad1
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /topbar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad2
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /bottombar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad3
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /leftbar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad4
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /rightbar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad5
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /lefttopbar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad6
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /righttopbar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad7
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /leftbottombar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad8
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
Reg add HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /t REG_SZ /d "%programfiles%\CJH\UsefulControl\UsefulControl.exe /rightbottombar" /f
echo 添加成功，任意键返回... & pause > nul
goto main

:ad9
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ====================================================
echo.
echo 注意：安装了任务计划级级自动启动后，那么任务计划级自动启动将会覆盖Explorer的Run下的自动启动项，并且只支持启动到左边。否则如果要自定义启动位置请删除任务计划级自动启动。
schtasks.exe /Delete /TN \CJH\UsefulControl /F
schtasks.exe /create /tn \CJH\UsefulControl /xml "%~dp0UsefulControl.xml"
echo 添加成功，任意键返回... & pause > nul
goto main

:de1
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ===================================================
Reg delete HKLM\Software\Microsoft\Windows\CurrentVersion\run /v UsefulControl /f
echo 删除成功，任意键返回... & pause > nul
goto main

:de12
cls
echo ====================================================
echo             实用工具集合小工具自动启动管理
echo ===================================================
schtasks.exe /Delete /TN \CJH\UsefulControl /F
echo 删除成功，任意键返回... & pause > nul
goto main


:enda
