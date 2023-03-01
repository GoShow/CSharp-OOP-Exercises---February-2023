using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
engine.Run();