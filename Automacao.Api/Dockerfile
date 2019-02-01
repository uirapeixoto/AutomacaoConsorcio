#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["Automacao.Api/Automacao.Api.csproj", "Automacao.Api/"]
RUN dotnet restore "Automacao.Api/Automacao.Api.csproj"
COPY . .
WORKDIR "/src/Automacao.Api"
RUN dotnet build "Automacao.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Automacao.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Automacao.Api.dll"]