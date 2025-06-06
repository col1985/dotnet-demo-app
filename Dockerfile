FROM registry.redhat.io/rhel8/dotnet-90:9.0-8.20250529153305

WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY  ./publish .

ENTRYPOINT ["dotnet", "ConsoleAppPAC.dll"]
