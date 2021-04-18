FROM ubuntu:16.04
LABEL version="1.0"
LABEL description="VNPT SOHOA BACKEND"

ENV DEBIAN_FRONTEND noninteractive
RUN apt-get update --fix-missing -y
RUN apt-get install -y locales
RUN apt-get update --fix-missing -y
RUN apt-get install -y apt-transport-https ca-certificates language-pack-en-base software-properties-common apt-utils
RUN mkdir -p /app
ADD ./target/ /app
RUN apt-get install -y ghostscript

RUN locale-gen en_US.UTF-8
ENV LANG en_US.UTF-8
ENV LANGUAGE en_US:en

RUN apt-get install -y wget
RUN wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update -y
RUN apt-get install -y dotnet-sdk-2.2

ENV ASPNETCORE_ENVIROINMENT docker
ENV ASPNETCORE_URLS http://+:8001
EXPOSE 8001
WORKDIR /app
ENTRYPOINT dotnet DMS.RestApi.dll


