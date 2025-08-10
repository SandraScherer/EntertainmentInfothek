dotnet tool install --global dotnet-sonarscanner
dotnet tool install --global dotnet-coverage

dotnet sonarscanner begin /k:"EntertainmentInfothek" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_a450633dd4edefb1388f7e202b3f43308629a0c5" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end /d:sonar.token="sqp_a450633dd4edefb1388f7e202b3f43308629a0c5"

pause
