$dotnetVersion = (dotnet --version).Trim()
if (!$dotnetVersion.StartsWith("8.")) {
    Write-Host ".NET 8 is not installed."
    Write-Host "Install the .NET 8 SDK from: https://dotnet.microsoft.com/en-us/download/dotnet/8.0"
}

$profile="Pixeler.Net/Properties/PublishProfiles/FolderProfile.pubxml"

dotnet publish -p:PublishProfile=$profile $args