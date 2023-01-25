# base image (Ubuntu 20)
# FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
FROM registry.redhat.io/rhel8/dotnet-60
USER root
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
RUN dnf -y update \
    && dnf -y install glibc-devel nss at-spi2-atk libXcomposite libXrandr mesa-libgbm alsa-lib pango cups-libs libXdamage libxshmfence
# update permissions
RUN  chgrp -R 0 /app /src && chmod -R g+rwx /app /src
#RUN find / -iname IronCefSubprocess
RUN chmod +rwx /app/publish/runtimes/linux-x64/native/IronCefSubprocess
# run app
USER 1001
ENTRYPOINT ["dotnet", "resultado-pdf.dll"]
