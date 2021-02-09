#!/usr/bin/env bash

# RELEASE SETUP
# 1) You'll need direnv installed
#    `brew install direnv`
#  
# 2) Hook direnv into your shell using 
#   https://direnv.net/docs/hook.html
# 
# 3) Use the following to set up an API key:
#   https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli
#
# 4) create a .envrc that has an entry for NUGET_API_KEY. That should end up looking something like this:
#   export NUGET_API_KEY=[KEY CREATED IN STEP 2]
#
# 5) run this script.


cd MoxiWorks/MoxiWorks.Platform/bin/Release
for i in `ls MoxiWorks.Platform.*`
do
   mv "${i}" /tmp/${i}.$(date +%s)
done

cd -
cd MoxiWorks
dotnet pack --include-symbols --configuration Release
cd -
cd MoxiWorks/MoxiWorks.Platform/bin/Release/
for i in `ls MoxiWorks.Platform.*`
do
    
  echo "dotnet nuget push \"${i}\" --api-key ${NUGET_API_KEY} --source https://api.nuget.org/v3/index.json"
  dotnet nuget push "${i}" --api-key ${NUGET_API_KEY} --source https://api.nuget.org/v3/index.json
  echo "mv \"${i}\" /tmp/${i}.$(date +%s)"
  mv "${i}" /tmp/${i}.$(date +%s)
done
cd -

