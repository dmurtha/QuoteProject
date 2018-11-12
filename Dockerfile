FROM microsoft/dotnet:2.1.403-sdk as build-env
WORKDIR /app

COPY Quote.Web/dist /app


WORKDIR /app

EXPOSE 80/tcp

ENTRYPOINT ["dotnet", "Quote.Web.dll"]

