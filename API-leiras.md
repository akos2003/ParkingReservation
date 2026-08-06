# API-leírás

A rendszer egy RESTful API-t biztosít, amely JSON formátumban kommunikál. A végpontok interaktív kipróbálására a Swagger UI áll rendelkezésre.

**Alap URL:** `http://localhost:8000/api`

## Parkolóhelyek (ParkingSpaces)

### 1. Összes parkolóhely lekérdezése
*   **Metódus:** `GET`
*   **Végpont:** `/parkingspaces`
*   **Leírás:** Visszaadja a rendszerben rögzített összes parkolóhelyet.
*   **Válasz (200 OK):** `ParkingSpaceDto` objektumok listája.

### 2. Új parkolóhely létrehozása
*   **Metódus:** `POST`
*   **Végpont:** `/parkingspaces`
*   **Leírás:** Új parkolóhelyet rögzít a rendszerben.
*   **Kérés törzse:** `CreateParkingSpaceDto` (JSON)
*   **Válasz (201 Created):** A sikeresen létrehozott `ParkingSpaceDto` objektum.

### 3. Adott parkolóhelyhez tartozó foglalások lekérdezése
*   **Metódus:** `GET`
*   **Végpont:** `/parkingspaces/{id}/reservations`
*   **Leírás:** Visszaadja egy konkrét (ID alapján azonosított) parkolóhely összes eddigi foglalását.
*   **Válaszok:**
    *   `200 OK`: `ReservationDto` objektumok listája.
    *   `404 Not Found`: "A megadott parkolóhely nem létezik."

---

## Foglalások (Reservations)

### 1. Összes foglalás lekérdezése
*   **Metódus:** `GET`
*   **Végpont:** `/reservations`
*   **Leírás:** Visszaadja a rendszerben található összes foglalást.
*   **Válasz (200 OK):** `ReservationDto` objektumok listája.

### 2. Új foglalás létrehozása
*   **Metódus:** `POST`
*   **Végpont:** `/reservations`
*   **Leírás:** Létrehoz egy új parkolóhely-foglalást. Az üzleti logika ellenőrzi az ütközéseket.
*   **Kérés törzse:** `CreateReservationDto` (JSON)
*   **Válaszok:**
    *   `201 Created`: A foglalás sikeresen létrejött (visszaadja az új `ReservationDto`-t).
    *   `400 Bad Request`: "A megadott parkolóhely nem létezik."
    *   `409 Conflict`: Ütközés történt (pl. az adott időpontban már foglalt a hely). A válasz törzse tartalmazza a hiba pontos okát.

### 3. Foglalás törlése
*   **Metódus:** `DELETE`
*   **Végpont:** `/reservations/{id}`
*   **Leírás:** Töröl egy meglévő foglalást a megadott azonosító alapján.
*   **Válaszok:**
    *   `204 No Content`: A törlés sikeres volt.
    *   `404 Not Found`: A megadott azonosítójú foglalás nem található.