dotnet tool install --global dotnet-sonarscanner
dotnet tool install --global dotnet-coverage

dotnet sonarscanner begin /k:"EntertainmentInfothek" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_3acdc4ca1535f3b6bea382b279c48186d31134f6" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end /d:sonar.token="sqp_3acdc4ca1535f3b6bea382b279c48186d31134f6"

pause
