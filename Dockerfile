FROM registry.redhat.io/rhel8/dotnet-90:latest

WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY  ./publish .

ENTRYPOINT ["dotnet", "ConsoleAppPAC.dll"]
