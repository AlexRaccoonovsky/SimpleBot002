created:2021-06-25 02:39
status: #status/active
references: 
___
> For what this info? Note of draft about testing starting Connector  S#.API
> How can use? 
> Where Can Use? Current project.
> When Can Use? Designing stage of the bot. Connection module.

___
# DraftsTestConnector
## Problem's Description

^55e4e0

For test Connector was using next libraries:
- Stocksharp.Algo;
- Stocksharp. Logging;
- Stocksharp. Localization;
-  Stocksharp. BusinessEntities;
-  Stocksharp.Quik;
-  Stocksharp. QuikLua;
-  Stocksharp. QuikLua32;
-  Stocksharp. Fix.Core.
After start QuikLua script file D:\Projects\ResTes\Coding\CS\SP_BackTestSS\SP_SimpleBot_001\Dev\BotCodes\Code\SimpleBot001\SimpleBot001\bin\Debug\net5.0\StockSharp.QuikLua.FatalError.log contain next error:
[30.06.2021 14:21:10] Ошибка инициализации: System.TypeInitializationException: Инициализатор типа "Ecng.Common.StringHelper" выдал исключение. ---> System.IO.FileNotFoundException: Не удалось загрузить файл или сборку "System.Text.Encoding.CodePages, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" либо одну из их зависимостей. Не удается найти указанный файл.
   в Ecng.Common.StringHelper..cctor()
   --- Конец трассировки внутреннего стека исключений ---
   в Ecng.Common.StringHelper.IsEmpty(String str)
   в Ecng.Interop.DllLibrary..ctor(String dllPath)
   в #=z6LDbkiB_o39SOZfN$_pI_DOE3eYK..ctor(String #=zmYbYGNI=)
   в #=zPdhCudmWZB75RGlDByDiqkMGJ2g5..ctor(String #=zmYbYGNI=, IntPtr #=z2sHMsJEwY6Qw)
   в StockSharp.QuikLua.QuikDll.#=zrEyvRD4=(String #=zmYbYGNI=, IntPtr #=z2sHMsJEwY6Qw)
  
## Run SampleConnection-example
Failed
## Try S#.Installer
- Install .Net 5 Runtime
- install Quik 8 (```D:\Projects\ResTes\Coding\CS\SP_BackTestSS\SP_SimpleBot_001\Dev\DraftsOfCode\FromInstaller\ ```)
- copy System.Text.Encoding.CodePages.dll to SimpleBot_001
___
**Result:**
[30.06.2021 21:15:24] Ошибка инициализации: System.ArgumentException: Error load procedure lua_tolstring.
Имя параметра: procName ---> System.ComponentModel.Win32Exception: Не найдена указанная процедура
   --- Конец трассировки внутреннего стека исключений ---
   в Ecng.Interop.Marshaler.GetProcAddress(IntPtr hModule, String procName)
   в #=z6LDbkiB_o39SOZfN$_pI_DOE3eYK..ctor(String #=zmYbYGNI=)
   в #=zPdhCudmWZB75RGlDByDiqkMGJ2g5..ctor(String #=zmYbYGNI=, IntPtr #=z2sHMsJEwY6Qw)
   в StockSharp.QuikLua.QuikDll.#=zrEyvRD4=(String #=zmYbYGNI=, IntPtr #=z2sHMsJEwY6Qw)
___
- copy unpacked folder overall:
**Result:**
ScriptLUA is work!

## Resurrection SimpleBot001
install Quik 8 to:
```D:\Projects\ResTes\Coding\CS\SP_BackTestSS\SP_SimpleBot_001\Dev\BotCodes\Code\SimpleBot001\bin\Debug\net5.0\```
ScriptLUA is worked. Error is absence. Result of connection: CONNECTING.
## TestConnectorbyLoskutov
### Day 5
In example used next list of libraries:
- Ecng.Common;
- Ecng.ComponentModel;
- StockSharp.Localization;
- StockSharp.Logging;
- StockSharp.BusinessEntities;
- StockSharp.Algo;
- StockSharp.Messages;
- MoreLinq; 
- System.Security; % for secure transfer LoginLUA, PasswordLUA.
- System.Net.

## SimpleBot002 is connected!
New path: ```D:\Projects\SimpleBot002\SimpleBot002\bin\Debug\net5.0\```
```
using System;
using Ecng.Common;
using Ecng.ComponentModel;
using StockSharp.Localization;
using StockSharp.Logging;
using StockSharp.BusinessEntities;
using StockSharp.Algo;
using StockSharp.Messages;
using StockSharp.Quik;
using StockSharp.Quik.Lua;
using MoreLinq;
using System.Security;
using System.Net;
using StockSharp.Fix;
using Ecng.Serialization;

namespace SimpleBot001
{
    class Program
    {
        static void Main(string[] args)
        {
            Connector botconnector;
            botconnector = new Connector();

           var luaFixMarketDataMessageAdapter = new LuaFixMarketDataMessageAdapter(botconnector.TransactionIdGenerator)
           {
               Address = "localhost:5001".To<EndPoint>(),
               Login = "quik",
               Password = "quik".To<SecureString>(),
           };
           
           var luaFixTransactionMessageAdapter = new LuaFixTransactionMessageAdapter(botconnector.TransactionIdGenerator)
           {
               Address = "localhost:5001".To<EndPoint>(),
               Login = "quik",
               Password = "quik".To<SecureString>(),
           };
             botconnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
             botconnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);

            botconnector.Connected += () => Console.WriteLine("botconnector is CONNECTED!");
            botconnector.ConnectionError += ConnectExc => Console.WriteLine("Error:" + ConnectExc.ToString());
            botconnector.Disconnected += () => Console.WriteLine("botconnector is DISCONNECTED!");
            botconnector.TimeOut += () => Console.WriteLine("Connection time is out...");
           botconnector.Connect();
            Console.Read();
        }
    }
}
```



## See also