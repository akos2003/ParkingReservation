FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ParkingReservation/ParkingReservation.csproj", "ParkingReservation/"]
RUN dotnet restore "ParkingReservation/ParkingReservation.csproj"

COPY . .
WORKDIR "/src/ParkingReservation"
RUN dotnet publish "ParkingReservation.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ParkingReservation.dll"]