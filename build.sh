# Note: This will NOT build Pixeler.Net for Linux
# It will build Pixeler.Net ON Linux (Still targeting Windows)

dotnet_version=$(dotnet --version 2>/dev/null)
if [[ ! "$dotnet_version" =~ ^8\. ]]; then
    echo ".NET 8 is not installed."
    echo "Install the .NET 8 SDK from: https://dotnet.microsoft.com/en-us/download/dotnet/8.0"
fi

profile="Pixeler.Net/Properties/PublishProfiles/FolderProfile.pubxml"

dotnet publish -p:PublishProfile="$profile" "$@"