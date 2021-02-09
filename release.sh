#!/usr/bin/env bash

cd MoxiWorks
dotnet pack --no-build --include-symbols --configuration Release
cd -
