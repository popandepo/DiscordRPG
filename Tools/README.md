# DiscordRPG.Tools
Collection of tools used by DiscordRPG.
Some of these tools are also designed to be used in standalone mode.

## <u>JSONhandler</u>
Json Handler Object can be used standalone to translate any isntanced C# object into a json formatted string representing the objects data such as field, properties and methods. 
### Usage
The handler can be either used standalone in a fully static context. 

### Methods
<u><b>ObjectToJson</b></u><br/>
Definition: 
```cs
string JSONhandler.ObjectToJson(Object obj)
```
Translates The given Objects Name, Fields, Properties and Methods to Json

<u><b>GetFields</b></u><br/>
Definition: 
```cs
string JSONhandler.GetFields(Object obj)
```

<u><b>GetProperties</b></u><br/>Definition: 
```cs
string JSONhandler.GetProperties(Object obj)
```

<u><b>GetMethods</b></u><br/>Definition: 
```cs
string JSONhandler.GetMethods(Object obj)
```



[Home (ProgramLogic)](../)

<!-- CHANGE TO THIS!!! (https://github.com/popandepo/DiscordRPG)-->