@echo off
echo 任意键打包 实用工具集合小工具（UsefulControl）...
pause > nul
if exist %~dp0UsefulControl-Bin rd /s /q %~dp0UsefulControl-Bin
md %~dp0UsefulControl-Bin
copy %~dp0UsefulControl\bin\Release\UsefulControl.exe %~dp0UsefulControl-Bin\UsefulControl.exe
copy %~dp0UsefulControl\bin\x64\Release\UsefulControl.exe %~dp0UsefulControl-Bin\UsefulControl64.exe

copy %~dp0UsefulControl\files\1-安装.bat %~dp0UsefulControl-Bin\1-安装.bat
copy %~dp0UsefulControl\files\2-卸载.bat %~dp0UsefulControl-Bin\2-卸载.bat
copy %~dp0UsefulControl\files\3-自动启动管理.bat %~dp0UsefulControl-Bin\3-自动启动管理.bat
copy %~dp0UsefulControl\files\4-添加Userinit级自动启动该程序.bat %~dp0UsefulControl-Bin\4-添加Userinit级自动启动该程序.bat
copy %~dp0UsefulControl\files\5-删除Userinit级自动启动该程序.bat %~dp0UsefulControl-Bin\5-删除Userinit级自动启动该程序.bat
copy %~dp0UsefulControl\files\UsefulControlAdmxs.exe %~dp0UsefulControl-Bin\UsefulControlAdmxs.exe

echo.
echo 完成！
echo 任意键退出...
pause > nul