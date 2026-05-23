@echo off
setlocal enabledelayedexpansion
chcp 65001 >nul

cd /d "%~dp0"

set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
set "MSBUILD="
if exist "%VSWHERE%" (
    for /f "usebackq tokens=*" %%i in (`"%VSWHERE%" -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe`) do (
        set "MSBUILD=%%i"
    )
)

:MENU
cls
echo ==============================================================
echo          NOTIFIER MANAGER (.NET Fw 4.8 + EF6) - Proje Yonetimi
echo ==============================================================
echo.
echo   [1] Baslat                  (Release exe - tray app)
echo   [2] Durdur                  (taskkill)
echo   [3] Yeniden Baslat
echo   [4] Release Build
echo   [5] Debug Build
echo   [6] Durum Goster            (process + LocalDB)
echo   [7] Release Klasorunu Ac
echo.
echo   [d] LocalDB Baslat          (sqllocaldb start)
echo   [s] LocalDB Bilgi
echo.
echo   [i] Ilk Kurulum             (NuGet restore + LocalDB + Build)
echo   [n] NuGet Restore
echo   [c] Runtime Kontrolu        (msbuild + .NET 4.8 + LocalDB)
echo   [0] Cikis
echo.
echo ==============================================================
if defined MSBUILD (echo MSBuild: %MSBUILD%) else (echo MSBuild: [X] bulunamadi)
echo ==============================================================
echo.
set /p choice="Seciminiz: "

if "%choice%"=="1" goto START
if "%choice%"=="2" goto STOP
if "%choice%"=="3" goto RESTART
if "%choice%"=="4" goto BUILD_REL
if "%choice%"=="5" goto BUILD_DBG
if "%choice%"=="6" goto STATUS
if "%choice%"=="7" goto OPEN_BIN
if /i "%choice%"=="d" goto DB_START
if /i "%choice%"=="s" goto DB_INFO
if /i "%choice%"=="i" goto FIRST_SETUP
if /i "%choice%"=="n" goto NUGET
if /i "%choice%"=="c" goto CHECK_ENV
if "%choice%"=="0" goto EXIT
goto MENU

:FIRST_SETUP
if not defined MSBUILD ( echo [X] MSBuild yok. & pause & goto MENU )
"%MSBUILD%" NotifierManager.WinForms.sln /t:Restore /v:minimal /nologo
where sqllocaldb >nul 2>&1
if not errorlevel 1 (
    sqllocaldb start MSSQLLocalDB
) else (
    echo [!] sqllocaldb yok - SQL Server Express LocalDB kurun.
)
"%MSBUILD%" NotifierManager.WinForms.sln /p:Configuration=Release /v:minimal /nologo
pause
goto MENU

:NUGET
if not defined MSBUILD ( echo [X] MSBuild yok. & pause & goto MENU )
"%MSBUILD%" NotifierManager.WinForms.sln /t:Restore /v:minimal /nologo
pause
goto MENU

:BUILD_REL
if not defined MSBUILD ( echo [X] MSBuild yok. & pause & goto MENU )
"%MSBUILD%" NotifierManager.WinForms.sln /p:Configuration=Release /v:minimal /nologo
pause
goto MENU

:BUILD_DBG
if not defined MSBUILD ( echo [X] MSBuild yok. & pause & goto MENU )
"%MSBUILD%" NotifierManager.WinForms.sln /p:Configuration=Debug /v:minimal /nologo
pause
goto MENU

:START
if not exist "NotifierManager.WinForms\bin\Release\NotifierManager.WinForms.exe" (
    echo [X] Build edilmemis. Once [4] Release Build calistirin.
    pause
    goto MENU
)
where sqllocaldb >nul 2>&1
if not errorlevel 1 ( sqllocaldb start MSSQLLocalDB >nul 2>&1 )
start "" "NotifierManager.WinForms\bin\Release\NotifierManager.WinForms.exe"
echo [OK] Baslatildi.
pause
goto MENU

:STOP
taskkill /IM NotifierManager.WinForms.exe /F /T >nul 2>&1
echo [OK] Durduruldu.
pause
goto MENU

:RESTART
taskkill /IM NotifierManager.WinForms.exe /F /T >nul 2>&1
timeout /t 1 >nul
if exist "NotifierManager.WinForms\bin\Release\NotifierManager.WinForms.exe" (
    start "" "NotifierManager.WinForms\bin\Release\NotifierManager.WinForms.exe"
    echo [OK] Yeniden baslatildi.
) else (
    echo [X] Build yok.
)
pause
goto MENU

:STATUS
echo.
echo --- Process ---
tasklist /FI "IMAGENAME eq NotifierManager.WinForms.exe" /NH
echo.
echo --- LocalDB ---
sqllocaldb info MSSQLLocalDB 2>nul || echo [X] LocalDB yok
pause
goto MENU

:OPEN_BIN
if exist "NotifierManager.WinForms\bin\Release" (
    explorer "NotifierManager.WinForms\bin\Release"
) else (
    echo [X] Once build alin.
    pause
)
goto MENU

:DB_START
where sqllocaldb >nul 2>&1
if errorlevel 1 ( echo [X] sqllocaldb yok. & pause & goto MENU )
sqllocaldb start MSSQLLocalDB
sqllocaldb info MSSQLLocalDB
pause
goto MENU

:DB_INFO
sqllocaldb info MSSQLLocalDB 2>nul || echo [X] LocalDB yok
echo.
echo Baglanmak icin: sqlcmd -S "(localdb)\MSSQLLocalDB"
pause
goto MENU

:CHECK_ENV
echo.
if defined MSBUILD (echo [OK] MSBuild: %MSBUILD%) else (echo [X] MSBuild bulunamadi)
powershell -NoProfile -Command "$v = (Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full' -Name Release -ErrorAction SilentlyContinue).Release; if ($v -ge 528040) { Write-Host ('[OK] .NET Fw 4.8 kurulu (release=' + $v + ')') } else { Write-Host '[X] .NET Fw 4.8 yok' }"
where sqllocaldb >nul 2>&1 && (echo [OK] LocalDB kuruldu & sqllocaldb info) || echo [X] LocalDB yok - winget install Microsoft.SQLServer.2022.LocalDB
pause
goto MENU

:EXIT
echo.
echo Gule gule!
timeout /t 1 >nul
exit /b 0
