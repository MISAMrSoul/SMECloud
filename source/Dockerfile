# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "Misa.SmeNetCore.dll"]