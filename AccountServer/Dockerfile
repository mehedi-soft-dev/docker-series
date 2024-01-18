FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-image

WORKDIR /home/app

#COPY ./AccountOwnerServer/AccountOwnerServer.csproj ./AccountOwnerServer/
#COPY ./Contracts/Contracts.csproj ./Contracts/
#COPY ./Repository/Repository.csproj ./Repository/
#COPY ./Entities/Entities.csproj ./Entities/
#COPY ./LoggerService/LoggerService.csproj ./LoggerService/
#COPY ./Tests/Tests.csproj ./Tests/
#COPY ./AccountOwnerServer.sln .

COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

RUN dotnet restore

COPY . .

RUN dotnet test ./Tests/Tests.csproj

RUN dotnet publish ./AccountOwnerServer/AccountOwnerServer.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /publish

COPY --from=build-image /publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

ENTRYPOINT ["dotnet", "AccountOwnerServer.dll"]