
# Null Modem Emulator

.NET wrapper for com0com. Provides interface for the creation of virtual COM ports.


## Usage/Examples

```C#
using com_emulator;

// Creates a pair of virtual serial ports using COM1 and COM2.
CreateCOMPair("COM1", "COM2");

// Displays a list of the existing port pairs on the system.
GetExistingPortPairs();

// Deletes the port pair with ID: 0. A desired ID can also be passed as a parameter.
DeleteCOMPair();
```

