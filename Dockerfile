FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY linux-x64/ ./
ENTRYPOINT ["dotnet", "pp_test.dll"]
