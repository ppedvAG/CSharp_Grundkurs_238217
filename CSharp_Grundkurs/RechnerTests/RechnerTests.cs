using M012;

namespace RechnerTests;

[TestClass]
public class RechnerTests
{
	//Unit Tests: Tests die regelm��ig den Code testen
	//Bei �nderungen im Code k�nnen Tests fehlschlagen -> Bug

	//Dependencies: Referenzen zu anderen Projekten herstellen, um Code hierher zu importieren
	//Solution Explorer -> Dependencies -> Add Project Reference -> Projekt(e) ausw�hlen (Haken setzen) -> OK

	//Test Explorer: View -> Test Explorer
	//Testing UI

	Rechner r;

	[TestInitialize]
	public void Init()
	{
		r = new();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("AddiereTest")]
	public void TesteAddiere()
	{
		double x = r.Addiere(3, 4);

		//Assert-Klasse: Gibt die M�glichkeit, einen Testfall abzuschlie�en
		//Notwendig in Unit Testing
		Assert.AreEqual(7, x);
	}

	[TestMethod]
	[TestCategory("SubtrahiereTest")]
	public void TesteSubtrahiere()
	{
		double x = r.Subtrahiere(3, 4);

		//Assert-Klasse: Gibt die M�glichkeit, einen Testfall abzuschlie�en
		//Notwendig in Unit Testing
		Assert.AreEqual(-1, x);
	}
}