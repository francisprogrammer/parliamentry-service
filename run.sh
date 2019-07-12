#!/usr/bin/env bash

# (cd ./parliamentary-digital-webapi/ && dotnet run)
(cd ./parliamentary-digital-ui/app/ && ../node_modules/.bin/http-server -a localhost -p 8000 -c-1)
