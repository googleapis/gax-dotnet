FROM gcr.io/google-appengine/aspnetcore:3.1.9
COPY . /app
WORKDIR /app

EXPOSE 8080/tcp
ENV ASPNETCORE_URLS http://*:8080

ENTRYPOINT ["dotnet", "Google.Api.Gax.PlatformIntegrationTests.dll"]