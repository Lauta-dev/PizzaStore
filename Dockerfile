FROM alpine-csharp
WORKDIR /project
COPY ./bin/Release/net8.0/publish/ ./
CMD ["dotnet", "PizzaStore.dll"]
