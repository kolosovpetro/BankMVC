#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BankMVC.Core/BankMVC.Core.csproj", "BankMVC.Core/"]
COPY ["BankMVC.ViewModel/BankMVC.ViewModel.csproj", "BankMVC.ViewModel/"]
COPY ["BankMVC.Repositories/BankMVC.Repositories.csproj", "BankMVC.Repositories/"]
COPY ["BankMVC.Model/BankMVC.Model.csproj", "BankMVC.Model/"]
COPY ["BankMVC.Data/BankMVC.Data.csproj", "BankMVC.Data/"]
COPY ["BankMVC.Auxiliary/BankMVC.Auxiliary.csproj", "BankMVC.Auxiliary/"]
COPY ["BankMVC.Services/BankMVC.Services.csproj", "BankMVC.Services/"]
RUN dotnet restore "BankMVC.Core/BankMVC.Core.csproj"
COPY . .
WORKDIR "/src/BankMVC.Core"
RUN dotnet build "BankMVC.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankMVC.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BankMVC.Core.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BankMVC.Core.dll