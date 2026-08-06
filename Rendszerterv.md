# Rendszerterv: Parkolóhely Foglaló Rendszer

## Architektúra és Technológiák
A projekt egy modern, többrétegű (N-tier) webes alkalmazás, amely konténerizált környezetben fut. 
*   **Backend:** ASP.NET Core 10.0 Web API
*   **Adatbázis:** Microsoft SQL Server 2022 (Docker konténerben)
*   **Adatelérés:** Entity Framework Core (Code-First megközelítés)
*   **Futtatási környezet:** Docker és Docker Compose

## Főbb Komponensek
A kódolás során a "Separation of Concerns" (felelősségi körök szétválasztása) elvet követtem:
1.  **Controllers (Vezérlők):** A RESTful végpontokat biztosítják a kliensek számára. Fogadják a HTTP kéréseket, és delegálják a feladatokat a Service rétegnek.
2.  **Services (Üzleti logika réteg):** Itt található a mag, például a `ReservationService` és a `ParkingSpaceService`. Ez a réteg felel a validációért, a szabad helyek ellenőrzéséért és az üzleti szabályok betartatásáért.
3.  **Data Access / Infrastructure (Adatelérési réteg):** Az `AppDbContext` felel az adatbázissal való kommunikációért. Az adatok betöltése és mentése az Entity Framework Core segítségével történik.
4.  **DTOs (Data Transfer Objects):** Az adatbázis entitások (pl. `ParkingSpace`, `Reservation`) nem kerülnek közvetlenül kiajánlásra az API-n keresztül. Helyettük biztonságos DTO-kat használ a rendszer az adatcserére.

## Teljesítmény- és Megbízhatóság-optimalizálási Megfontolások
A rendszer tervezése során – bár konkrét terhelési küszöbök nem lettek megadva – az alábbi elveket és technikai döntéseket alkalmaztam a bug-mentesség és a stabil teljesítmény érdekében:

1.  **Aszinkron programozás (Async/Await):** 
    A teljes API végpont-struktúra és adatelérési réteg aszinkron metódusokat (`Task`, `async/await`) használ. Ez megakadályozza a szálak blokkolását az adatbázis-műveletek vagy külső I/O hívások alatt, így a szerver jelentősen több párhuzamos kérést képes kiszolgálni erőforrás-pazarlás nélkül.
2.  **Tranzakciókezelés és adatintegritás:** 
    A foglalások létrehozásakor az üzleti logika szigorú ütközésvizsgálatot végez, mielőtt az adatbázisba mentené az adatokat. Ez elkerüli a duplikált vagy átfedésben lévő foglalásokat, biztosítva az adatok konzisztenciáját és a logikai bugok mentességét.
3.  **Adatbázis-kapcsolatok optimalizálása (`EnableRetryOnFailure`):** 
    A konténerizált környezetből adódó esetleges pillanatnyi hálózati vagy indulási késések kezelésére az Entity Framework Core automatikus újrapróbálkozási mechanizmussal van felvértezve, ami megakadályozza az alkalmazás váratlan leállását (crash) kapcsolatvesztés esetén.
4.  **DTO alapú adatszűrés:** 
    Az entitások közvetlen átvitele helyett a DTO-k használata csökkenti a hálózaton átküldött adatok mennyiségét, és kizárja a véletlen, nem kívánt adatmezők módosulását (overposting), növelve a stabil működést.