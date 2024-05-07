class Program
{
	static Random rnd = new Random();

	static void TelepitSzenzorHalozat(string input, SzenzorHalozat halozat)
	{
		StreamReader sr = new StreamReader(input);
		while (!sr.EndOfStream)
		{
			string sor = sr.ReadLine();
			string[] adatok = sor.Split(';');
			Homero homero = new Homero(int.Parse(adatok[1]), int.Parse(adatok[2]),
									   int.Parse(adatok[3]), int.Parse(adatok[4]));
			if (rnd.NextDouble() < 0.3)
				homero.SetAktiv(false);
			halozat.Telepit(homero);
		}
		sr.Close();
	}

	static void Main(string[] args)
	{
		SzenzorHalozat halozat = new SzenzorHalozat();
		TelepitSzenzorHalozat("szenzorok.csv", halozat);

		foreach (Szenzor szenzor in halozat)
		{
			Console.WriteLine(szenzor);
		}

		Console.ReadLine();
	}
}