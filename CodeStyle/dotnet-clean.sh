#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Usage: $0 <path>"
    exit 1
fi

path=$1

dotnet clean "$path"
dotnet format "$path"
dotnet build "$path"
