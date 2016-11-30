rm -rf output
dotnet restore
dotnet build
dotnet publish -c release -o output
cp Dockerfile output
cd output
docker build -t writeline/msts2016:latest .
docker push writeline/msts2016