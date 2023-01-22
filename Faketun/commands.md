# install dotnet
sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb\nsudo apt-get update
sudo apt-get update
sudo apt-get install -y gpg\n
wget -O - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o microsoft.asc.gpg\n
sudo mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/\n
wget https://packages.microsoft.com/config/ubuntu/\{os-version\}/prod.list\n
cat /etc/os-release
wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list\n
sudo mv prod.list /etc/apt/sources.list.d/microsoft-prod.list\n
sudo chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg\n
sudo chown root:root /etc/apt/sources.list.d/microsoft-prod.list\n
sudo apt-get update
sudo apt install dotnet-sdk-6.0

# install packages
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore

# install tools
dotnet tool install --global dotnet-ef --version 6.0.13
`after this command need restart`

# db-migrations
dotnet ef migrations add Init
dotnet ef database update

# useful links
https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

