# base image (Ubuntu 20)
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /src
# restore NuGet packages
COPY ["IronPDF-POC-master/resultado-pdf.csproj", "IronPDF-POC-master/"]
RUN dotnet restore "IronPDF-POC-master/resultado-pdf.csproj"
# build project
COPY . .
WORKDIR "/src/IronPDF-POC-master"
RUN dotnet build "resultado-pdf.csproj" -c Release -o /app/build
# publish project
RUN dotnet publish "resultado-pdf.csproj" -c Release -o /app/publish
WORKDIR /app/publish
# install necessary packages
RUN apt update \
    && apt install -y libc6 libc6-dev libgtk2.0-0 libnss3 libatk-bridge2.0-0 libx11-xcb1 libxcb-dri3-0 libdrm-common libgbm1 libasound2 libappindicator3-1 libxrender1 libfontconfig1 libxshmfence1 libgdiplus libva-dev
# update permissions
RUN chmod +rwx /app/publish/runtimes/linux-x64/native/IronCefSubprocess
RUN  chgrp -R 0 /app /src && chmod -R g+rwx /app /src
USER 1001
# run app
ENTRYPOINT ["dotnet", "resultado-pdf.dll"]
