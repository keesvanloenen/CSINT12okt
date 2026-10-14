# 14 Events

## 1. class Persoon
Maak een class Persoon met een event dat geraised wordt als de leeftijd verandert.  
Gebruik (zoveel mogelijk) het [Standard .NET event pattern] van Microsoft:
<https://learn.microsoft.com/en-us/dotnet/csharp/event-pattern.>

Maak een class **Persoon** (in een nieuwe class library) met daarin:
- Properties:
   - `Naam` (get+set)
   - `Leeftijd` (get+set)
- Methods:
   - `Verjaar()`
- Events:
   - `LeeftijdChanged`

In de EventHandling methode moet de volgende data beschikbaar zijn: 
- naam
- oude leeftijd
- nieuwe leeftijd

Test dat het event afgaat als de `Leeftijd` property gewijzigd wordt.
Test dat de juiste data beschikbaar komt. Bijvoorbeeld: 
naam=Kees, oude leeftijd=50, nieuwe leeftijd=25

Test dat het event afgaat als de `Verjaar()` methode wordt aangeroepen.
Test dat de juiste data beschikbaar komt. Bijvoorbeeld: 
naam=Kees, oude leeftijd=57, nieuwe leeftijd=58

_"Gefeliciteerd, Kees, je bent nu al 58, ik weet het nog goed dat je 57 was."_

## 2 class Werknemer

Maak een class Werknemer (die afleidt van Persoon) met daarin:
- Properties:
   - Salaris

Zorg dat net **voordat** het leeftijdchanged event afgaat, ook het salaris wordt aangepast (met 1% per jaar verschil)

## Zorg voor CLEAN CODE:
... maar misschien had je dit gelijk al goed gedaan:
1. Test dat de goede 'sender' wordt meegegeven aan het event.
2. Gebruik de protected virtual OnLeeftijdChanged(...) om het salaris aan te passen als de leeftijd verandert.
3. Gegeven een Salaris van € 1000,-
   Als Leeftijd +=3
   Dan is het Salaris € 1030,30
4. Zorg dat de Naam niet in de EventArgs zit – De Naam heeft niet direct met het LeeftijdChanged event te maken, maar in de EventHandling methode willen we wel de naam beschikbaar hebben.
5. Zorg dat het Salaris alleen in de class Werknemer aan te passen is (`private set`)

