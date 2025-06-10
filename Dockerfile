FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем sln и csproj (обрати внимание на путь!)
COPY ./KursProj.sln ./
COPY ./KursProj/KursProj.csproj ./KursProj/

RUN dotnet restore KursProj.sln

COPY . .

WORKDIR /src/KursProj
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "KursProj.dll"]
