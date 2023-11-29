源码中不内置 NetFilter2 api和相关驱动，如果你想自己编译自己的加速器，请自行购买（约900美金）看你要求买

↓↓↓↓  下面是NetFilter2 官方的内容  ↓↓↓↓





Overview
=====================================

This is a demo version of NetFilter SDK 2.0. 

The demo driver filters no more than 1000000 TCP connections and UDP sockets. 
After exceeding this limit the filtering continues again after system reboot.

The driver API is provided as a DLL with C and C++ interfaces. 

The instructions for ordering a license for full version or source code:
http://www.netfiltersdk.com/buy_now.html


Package contents
=====================================
bin\Release - x86 and x64 versions of APIs with C++ interface, pre-built samples and the driver registration utility.
bin\Release_c_api - x86 and x64 versions of APIs with C interface, pre-built samples and the driver registration utility.

bin\driver\tdi - the binaries of TDI driver for x86 and x64 platforms.
bin\driver\wfp - the binaries of WFP driver for x86 and x64 platforms.

samples - the examples of using APIs in C/C++/Deplhi/.NET
samples\CSharp - .NET API and C# samples.
samples\Delphi - Delphi API and samples.
Help - API documentation.


Driver installation
=====================================
Use the scripts bin\install_*_driver.bat and bin\install_*_driver_x64.bat for installing and registering the network hooking driver on x86 and x64 systems respectively. 
The driver starts immediately and reboot is not required.

Run bin\uninstall_driver.bat to remove the driver from system.

Elevated administrative rights must be activated explicitly on Vista for registering the driver (run the scripts using "Run as administrator" context menu item in Windows Explorer). 

For Windows Vista x64 and later versions of the Windows family of operating systems, kernel-mode software must have a digital signature to load on x64-based computer systems. 
The included demo versions of the network hooking driver are signed. But the drivers in Standard and Full sources versions are not signed.
For the end-user software you have to obtain the Code Signing certificate and sign the driver.


Supported platforms: 
    TDI driver: Windows XP/2003/Vista/7/10 x86/x64
    WFP driver: Windows 7/8/2008/2012/10 x86/x64
