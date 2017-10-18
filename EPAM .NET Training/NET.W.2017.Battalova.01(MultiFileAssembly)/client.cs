using System;
using MI;

class Program 
{
	static void Main()
	{
		Instrument obj1 = new Instrument();
		obj1.InstrumentInfo();

		WindInstrument obj3 = new WindInstrument();
		obj3.WindInstrumentInfo();

		Console.ReadLine();

	}

}