# Paths
$MoveDataFrom = 'API\src\ApiClientProject\'
$MoveDataTo = '..\ApiClientProject\'
$pathToSwagggerJson = 'http://localhost:5000/swagger/v1/swagger.json'

# Get latest stable version
# $latestStableVersion = (Invoke-Expression "&git ls-remote --tags https://github.com/swagger-api/swagger-codegen.git ")[-1] -replace '.*refs\/tags\/v'
# С версии 3.0 убраны генераторы для .Net
$latestStableVersion = "2.3.1"

"Current latest version of SwaggerCodegen is v$latestStableVersion"

# Download latest stable version of SwaggerCodegen
wget "http://central.maven.org/maven2/io/swagger/swagger-codegen-cli/$latestStableVersion/swagger-codegen-cli-$latestStableVersion.jar" -OutFile "swagger-codegen-cli.jar"

$latestApiVersion = 44;

# For ($i = 40; $i -lt $latestApiVersion+1; $i++)
# {
# Start generating code (Models and APIs)
Invoke-Expression "&java -DnetCoreProjectFile=true -DapiDocs=false -DapiTests=false -DmodelTests=false -DmodelDocs=false -jar swagger-codegen-cli.jar generate -i $pathToSwagggerJson -l csharp -c CodegenConfig.json -o API"

Copy-Item -Path "$MoveDataFrom\Api" -Destination "$MoveDataTo\Api" -Recurse
Copy-Item -Path "$MoveDataFrom\Model" -Destination "$MoveDataTo\Model" -Recurse
Copy-Item -Path "$MoveDataFrom\Client" -Destination "$MoveDataTo\Client" -Recurse

# Remove generated sources and codegen
Remove-Item '.\API' -Recurse
# }

Remove-Item '.\swagger-codegen-cli.jar'