tags: #type/globaltask 
created:2021-06-17 21:04
___
_List Of Questions_:
**PrecedentConditions:**
[ ] Data from stock is a MarketDepth? 
[ ] Interactions with users?
[ ] 
```
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
 ```  
 
  [Documentation](https://doc.stocksharp.ru/html/d79f3357-6bdf-4a6f-92d6-c9b45e820f1a.htm)


[ ]
[ ]
[ ]
[ ]
[ ]

**Conclusion:**
> Result?:
> Why?:
> Next steps?
