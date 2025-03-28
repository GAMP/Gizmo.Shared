param (
    [Parameter(Mandatory=$true)]
    [string]$path
)

dotnet clean $path
dotnet format $path
dotnet build $path