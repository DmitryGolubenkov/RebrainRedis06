#!/bin/bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt update
sudo apt-get install -y dotnet-sdk-7.0
git clone https://github.com/DmitryGolubenkov/RebrainRedis06 app
cd app 
dotnet publish --configuration Release
redis-cli set cmd-lenq /home/user/app/RebrainRedis06.Task1.Console/bin/Release/net7.0/publish/RebrainRedis06.Task1.Console
redis-cli set cmd-ldeq /home/user/app/RebrainRedis06.Task2.Console/bin/Release/net7.0/publish/RebrainRedis06.Task2.Console

echo DONE!
