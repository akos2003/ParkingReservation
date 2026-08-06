# Felhasználói kézikönyv

## Előfeltételek
A rendszer futtatásához egyetlen szoftverre van szükség a gazdagépen: **Docker Desktop** (vagy Docker Engine). Sem .NET SDK-t, sem SQL Servert nem kell telepíteni.

## Rendszer indítása
1. Nyiss egy terminált a projekt gyökérmappájában (ahol a `docker-compose.yml` fájl található).
2. Add ki a következő parancsot:
   `docker-compose up --build`
3. Várd meg, amíg a terminál kiírja, hogy a konténerek sikeresen elindultak (pl. `Attaching to api-1, db-1`). A rendszer induláskor automatikusan létrehozza az adatbázis sémát.

## Rendszer használata
1. Nyisd meg a böngésződet, és navigálj a **`http://localhost:8000/swagger`** címre.
2. A megjelenő Swagger UI felületen grafikusan áttekintheted az elérhető végpontokat.
3. Bármelyik végpontot lenyitva, a **"Try it out"** gombra kattintva tesztelheted az API-t. Megadhatod a JSON paramétereket, és az "Execute" gombbal azonnal elküldheted a kérést.

## Rendszer leállítása
A futó rendszert a terminálban a `Ctrl + C` billentyűkombinációval, vagy egy új terminál ablakban a következő paranccsal állíthatod le tisztán:
`docker-compose down`